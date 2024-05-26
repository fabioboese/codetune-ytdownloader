namespace YTDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDownloadSlow = new System.Windows.Forms.Button();
            this.btnDownloadFast = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.rdbVideoOnly = new System.Windows.Forms.RadioButton();
            this.rdbVideoAndAudio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkErrorLogLevel = new System.Windows.Forms.CheckBox();
            this.chkInfoLogLevel = new System.Windows.Forms.CheckBox();
            this.chkTraceLogLevel = new System.Windows.Forms.CheckBox();
            this.lklCleanLogs = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link:";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.Location = new System.Drawing.Point(59, 14);
            this.txtLink.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(820, 26);
            this.txtLink.TabIndex = 3;
            this.txtLink.TextChanged += new System.EventHandler(this.txtLink_TextChanged);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(59, 50);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(329, 26);
            this.txtId.TabIndex = 3;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID:";
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(0, 413);
            this.pbProgress.MarqueeAnimationSpeed = 5;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(892, 12);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbProgress.TabIndex = 4;
            this.pbProgress.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lklCleanLogs);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.rdbVideoAndAudio);
            this.panel1.Controls.Add(this.rdbVideoOnly);
            this.panel1.Controls.Add(this.btnDownloadSlow);
            this.panel1.Controls.Add(this.btnDownloadFast);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLink);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 162);
            this.panel1.TabIndex = 5;
            // 
            // btnDownloadSlow
            // 
            this.btnDownloadSlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadSlow.Enabled = false;
            this.btnDownloadSlow.Image = global::YTDownloader.Properties.Resources.download_solid__1__h24;
            this.btnDownloadSlow.Location = new System.Drawing.Point(592, 50);
            this.btnDownloadSlow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDownloadSlow.Name = "btnDownloadSlow";
            this.btnDownloadSlow.Size = new System.Drawing.Size(188, 103);
            this.btnDownloadSlow.TabIndex = 0;
            this.btnDownloadSlow.Text = "Baixar (lento)";
            this.btnDownloadSlow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadSlow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownloadSlow.UseVisualStyleBackColor = true;
            this.btnDownloadSlow.Click += new System.EventHandler(this.btnDownloadSlow_Click);
            // 
            // btnDownloadFast
            // 
            this.btnDownloadFast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadFast.Enabled = false;
            this.btnDownloadFast.Image = global::YTDownloader.Properties.Resources.download_solid_h24;
            this.btnDownloadFast.Location = new System.Drawing.Point(396, 50);
            this.btnDownloadFast.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDownloadFast.Name = "btnDownloadFast";
            this.btnDownloadFast.Size = new System.Drawing.Size(188, 103);
            this.btnDownloadFast.TabIndex = 0;
            this.btnDownloadFast.Text = "Baixar (rápido)";
            this.btnDownloadFast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadFast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownloadFast.UseVisualStyleBackColor = true;
            this.btnDownloadFast.Click += new System.EventHandler(this.btnDownloadFast_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 162);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(892, 251);
            this.txtLog.TabIndex = 6;
            this.txtLog.WordWrap = false;
            // 
            // rdbVideoOnly
            // 
            this.rdbVideoOnly.AutoSize = true;
            this.rdbVideoOnly.Location = new System.Drawing.Point(215, 84);
            this.rdbVideoOnly.Name = "rdbVideoOnly";
            this.rdbVideoOnly.Size = new System.Drawing.Size(137, 24);
            this.rdbVideoOnly.TabIndex = 4;
            this.rdbVideoOnly.Text = "Somente Vídeo";
            this.rdbVideoOnly.UseVisualStyleBackColor = true;
            // 
            // rdbVideoAndAudio
            // 
            this.rdbVideoAndAudio.AutoSize = true;
            this.rdbVideoAndAudio.Checked = true;
            this.rdbVideoAndAudio.Location = new System.Drawing.Point(59, 84);
            this.rdbVideoAndAudio.Name = "rdbVideoAndAudio";
            this.rdbVideoAndAudio.Size = new System.Drawing.Size(126, 24);
            this.rdbVideoAndAudio.TabIndex = 4;
            this.rdbVideoAndAudio.TabStop = true;
            this.rdbVideoAndAudio.Text = "Vídeo e Áudio";
            this.rdbVideoAndAudio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkTraceLogLevel);
            this.groupBox1.Controls.Add(this.chkInfoLogLevel);
            this.groupBox1.Controls.Add(this.chkErrorLogLevel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(787, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 99);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nível de Log";
            // 
            // chkErrorLogLevel
            // 
            this.chkErrorLogLevel.AutoSize = true;
            this.chkErrorLogLevel.Checked = true;
            this.chkErrorLogLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErrorLogLevel.Location = new System.Drawing.Point(6, 20);
            this.chkErrorLogLevel.Name = "chkErrorLogLevel";
            this.chkErrorLogLevel.Size = new System.Drawing.Size(70, 19);
            this.chkErrorLogLevel.TabIndex = 0;
            this.chkErrorLogLevel.Text = "ERROR";
            this.chkErrorLogLevel.UseVisualStyleBackColor = true;
            // 
            // chkInfoLogLevel
            // 
            this.chkInfoLogLevel.AutoSize = true;
            this.chkInfoLogLevel.Checked = true;
            this.chkInfoLogLevel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInfoLogLevel.Location = new System.Drawing.Point(6, 45);
            this.chkInfoLogLevel.Name = "chkInfoLogLevel";
            this.chkInfoLogLevel.Size = new System.Drawing.Size(54, 19);
            this.chkInfoLogLevel.TabIndex = 0;
            this.chkInfoLogLevel.Text = "INFO";
            this.chkInfoLogLevel.UseVisualStyleBackColor = true;
            // 
            // chkTraceLogLevel
            // 
            this.chkTraceLogLevel.AutoSize = true;
            this.chkTraceLogLevel.Location = new System.Drawing.Point(6, 70);
            this.chkTraceLogLevel.Name = "chkTraceLogLevel";
            this.chkTraceLogLevel.Size = new System.Drawing.Size(65, 19);
            this.chkTraceLogLevel.TabIndex = 0;
            this.chkTraceLogLevel.Text = "TRACE";
            this.chkTraceLogLevel.UseVisualStyleBackColor = true;
            // 
            // lklCleanLogs
            // 
            this.lklCleanLogs.AutoSize = true;
            this.lklCleanLogs.Location = new System.Drawing.Point(9, 139);
            this.lklCleanLogs.Name = "lklCleanLogs";
            this.lklCleanLogs.Size = new System.Drawing.Size(96, 20);
            this.lklCleanLogs.TabIndex = 6;
            this.lklCleanLogs.TabStop = true;
            this.lklCleanLogs.Text = "Limpar Logs";
            this.lklCleanLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklCleanLogs_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 425);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "YT Downloader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownloadFast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnDownloadSlow;
        private System.Windows.Forms.RadioButton rdbVideoAndAudio;
        private System.Windows.Forms.RadioButton rdbVideoOnly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTraceLogLevel;
        private System.Windows.Forms.CheckBox chkInfoLogLevel;
        private System.Windows.Forms.CheckBox chkErrorLogLevel;
        private System.Windows.Forms.LinkLabel lklCleanLogs;
    }
}

