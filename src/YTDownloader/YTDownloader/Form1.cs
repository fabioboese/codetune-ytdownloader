using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YoutubeExplode;

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        private bool busy = false;
        private bool success = false;
        private string destinationFile = string.Empty;
        private Exception downloadException = null;

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
                success = true;
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
                    success = true;
                }
            }
            else
            {
                downloadException = new Exception($"No suitable video stream found for {video.Title}.");
            }
            busy = false;
        }

        private void LogError(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ### ERRO ###: {message}\r\n");
            txtLog.SelectionStart = txtLog.Text.Length;
        }
        private void LogProgress(string message)
        {
            txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] --- INFO ---: {message}\r\n");
            txtLog.SelectionStart = txtLog.Text.Length;
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
            if (success)
                LogProgress($"Download concluído com sucesso para o arquivo {destinationFile}");
            else
            {
                if (downloadException != null)
                    LogError(downloadException.Message);
                LogError("Falha ao realizar o download do vídeo");
            }
        }

        private void RunDownloadInBackground(ThreadStart downloadAction)
        {
            LogProgress($"Realizando o download do vídeo para o arquivo {destinationFile}");
            System.Threading.Thread thread = new System.Threading.Thread(downloadAction);
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
            success = false;
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

        private void btnDownloadFast_Click(object sender, EventArgs e)
        {
            if (SelectDestinationFile())
            {
                SetBusyView();
                RunDownloadInBackground(FastDownload);
                ShowDownloadResults();
                SetIdleView();
            }
        }

        private void btnDownloadSlow_Click(object sender, EventArgs e)
        {
            if (SelectDestinationFile())
            {
                SetBusyView();
                RunDownloadInBackground(SlowDownload);
                ShowDownloadResults();
                SetIdleView();
            }
        }
    }
}
