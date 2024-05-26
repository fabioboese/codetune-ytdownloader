using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using Xabe.FFmpeg;
using YoutubeExplode;
using YTDownloader.Properties;

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        private bool busy = false;
        private string destinationFile = string.Empty;

        private bool audioSuccess = false;
        private bool videoSuccess = false;
        private Exception downloadException = null;
        private string[] audioConversionTrace = null;
        private Exception audioConversionException = null;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void SlowDownload()
        {
            try
            {
                var VideoUrl = $"https://www.youtube.com/embed/{txtId.Text}.avi";
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(VideoUrl);

                System.IO.File.WriteAllBytes(destinationFile, video.GetBytes());
                videoSuccess = true;
            }
            catch (Exception ex)
            {
                downloadException = ex;
            }
            busy = false;
        }

        private void FastDownload()
        {
            var youtube = new YoutubeClient();
            var video = youtube.Videos.GetAsync(txtLink.Text).GetAwaiter().GetResult();

            // Get all available muxed streams
            var streamManifest = youtube.Videos.Streams.GetManifestAsync(video.Id).GetAwaiter().GetResult();
            var muxedStreams = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).ToList();
            
            if (muxedStreams.Any())
            {
                var streamInfo = muxedStreams.First();
                using (var httpClient = new HttpClient())
                {
                    var stream = httpClient.GetStreamAsync(streamInfo.Url).GetAwaiter().GetResult();
                    var datetime = DateTime.Now;

                    using (var outputStream = File.Create(destinationFile))
                    {
                        stream.CopyToAsync(outputStream).GetAwaiter().GetResult();
                    }
                    stream.Dispose();
                    stream.Close();
                    videoSuccess = true;
                }
            }
            else
            {
                downloadException = new Exception($"No suitable video stream found for {video.Title}.");
            }
            busy = false;
        }

        private void TryExtractAudio(string destinationFile)
        {
            try
            {
                LogProgress("Extraindo o áudio do vídeo");
                var inputFile = destinationFile;
                var outputFile = Path.ChangeExtension(destinationFile, "mp3");
                var mp3out = "";
                var ffmpegProcess = new Process();
                ffmpegProcess.StartInfo.UseShellExecute = false;
                ffmpegProcess.StartInfo.RedirectStandardInput = true;
                ffmpegProcess.StartInfo.RedirectStandardOutput = false;
                ffmpegProcess.StartInfo.RedirectStandardError = true;
                ffmpegProcess.StartInfo.CreateNoWindow = true;
                ffmpegProcess.StartInfo.FileName = "depend\\ffmpeg.exe";
                ffmpegProcess.StartInfo.Arguments = " -i \"" + inputFile + "\" -vn -f mp3 -ab 320k output \"" + outputFile + "\" -y";
                var cmd = ffmpegProcess.StartInfo.FileName + " " + ffmpegProcess.StartInfo.Arguments;   
                ffmpegProcess.Start();
                mp3out = ffmpegProcess.StandardError.ReadToEnd();
                ffmpegProcess.WaitForExit();
                if (!ffmpegProcess.HasExited)
                {
                    ffmpegProcess.Kill();
                }
                audioConversionTrace = mp3out.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                audioSuccess = true;
            }
            catch (Exception ex)
            {
                audioConversionException = ex;
            }
        }

        private void LogError(string message)
        {
            if (chkErrorLogLevel.Checked)
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ### ERRO ###: {message}\r\n");
                txtLog.SelectionStart = txtLog.Text.Length;
            }
        }

        private void LogProgress(string message)
        {
            if (chkInfoLogLevel.Checked)
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] --- INFO ---: {message}\r\n");
                txtLog.SelectionStart = txtLog.Text.Length;
            }
        }

        private void LogTrace(string message)
        {
            if (chkTraceLogLevel.Checked)
            { 
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] --- TRCE ---: {message}\r\n");
                txtLog.SelectionStart = txtLog.Text.Length;
            }
        }

        private string ExtractId(string link)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"(?:https?:\/\/)?(?:www\.)?(?:m\.)?(?:youtu\.be\/|youtube\.com\/(?:embed\/|v\/|watch\?v=|watch\?.+&v=))((\w|-){11})(?![\w-])");
            var match = regex.Match(link);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        private bool SelectDestinationFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "AVI Files|*.avi";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                destinationFile = sfd.FileName;
                return true;
            }
            else
                return false;
        }

        private void ShowDownloadResults()
        {
            if (videoSuccess)
                LogProgress($"Download concluído com sucesso para o arquivo {destinationFile}");
            else
            {
                if (downloadException != null)
                    LogError(downloadException.Message);
                LogError("Falha ao realizar o download do vídeo");
            }
        }

        private void ShowAudioConversionResults()
        {
            if (audioSuccess)
            {
                foreach(var trace in audioConversionTrace)
                    LogTrace(trace);
                LogProgress($"Conversão do áudio concluída com sucesso para o arquivo {destinationFile}");
            }
            else
            {
                if (audioConversionException != null)
                    LogError(audioConversionException.Message);
                LogError("Falha ao realizar a conversão do áudio");
            }
        }

        private void RunDownloadInBackground(ThreadStart downloadAction)
        {
            LogProgress($"Realizando o download do vídeo para o arquivo {destinationFile}");
            var thread = new Thread(downloadAction);
            thread.Start();
            while (busy)
            {
                Application.DoEvents();
                Thread.Sleep(500);
            }
        }

        private void SetIdleView()
        {
            panel1.Enabled = true;
            pbProgress.Visible = false;
        }

        private void SetBusyView()
        {
            pbProgress.Visible = true;
            panel1.Enabled = false;
            videoSuccess = false;
            audioSuccess = false;
            downloadException = null;
            audioConversionTrace = null;
            audioConversionException = null;
            busy = true;
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            txtId.Text = ExtractId(txtLink.Text);
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            btnDownloadFast.Enabled = txtLink.Text != string.Empty;
            btnDownloadSlow.Enabled = txtId.Text != string.Empty;
        }

        private void btnDownloadFast_Click(object sender, EventArgs e) => Run(FastDownload);

        private void btnDownloadSlow_Click(object sender, EventArgs e) => Run(SlowDownload);

        private void Run(ThreadStart actionThread)
        {
            if (SelectDestinationFile())
            {
                SetBusyView();
                RunDownloadInBackground(actionThread);
                ShowDownloadResults();
                if (rdbVideoAndAudio.Checked)
                {
                    TryExtractAudio(destinationFile);
                    ShowAudioConversionResults();
                }
                SetIdleView();
                if (downloadException != null)
                    MessageBox.Show(downloadException.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (audioConversionException != null)
                    MessageBox.Show(audioConversionException.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Operação concluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lklCleanLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLog.Clear();
        }
    }
}
