namespace SceneClipse
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.axMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelTimeDisplay = new System.Windows.Forms.Label();
            this.timerCurrentTime = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxOpenFileName = new System.Windows.Forms.TextBox();
            this.labelPlayTime = new System.Windows.Forms.Label();
            this.labelOpenFileName = new System.Windows.Forms.Label();
            this.timerPlayTime = new System.Windows.Forms.Timer(this.components);
            this.buttonBookmark = new System.Windows.Forms.Button();
            this.listViewBookmark = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "현재 시간 : ";
            // 
            // axMediaPlayer1
            // 
            this.axMediaPlayer1.Enabled = true;
            this.axMediaPlayer1.Location = new System.Drawing.Point(177, 108);
            this.axMediaPlayer1.Name = "axMediaPlayer1";
            this.axMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMediaPlayer1.OcxState")));
            this.axMediaPlayer1.Size = new System.Drawing.Size(611, 426);
            this.axMediaPlayer1.TabIndex = 1;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(14, 510);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(14, 481);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelTimeDisplay
            // 
            this.labelTimeDisplay.AutoSize = true;
            this.labelTimeDisplay.Location = new System.Drawing.Point(14, 121);
            this.labelTimeDisplay.Name = "labelTimeDisplay";
            this.labelTimeDisplay.Size = new System.Drawing.Size(0, 12);
            this.labelTimeDisplay.TabIndex = 4;
            // 
            // timerCurrentTime
            // 
            this.timerCurrentTime.Enabled = true;
            this.timerCurrentTime.Interval = 1000;
            this.timerCurrentTime.Tick += new System.EventHandler(this.timerCurrentTime_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(96, 481);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(14, 452);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "파일 열기";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxOpenFileName
            // 
            this.textBoxOpenFileName.Location = new System.Drawing.Point(16, 178);
            this.textBoxOpenFileName.MaximumSize = new System.Drawing.Size(150, 500);
            this.textBoxOpenFileName.MinimumSize = new System.Drawing.Size(150, 4);
            this.textBoxOpenFileName.Multiline = true;
            this.textBoxOpenFileName.Name = "textBoxOpenFileName";
            this.textBoxOpenFileName.ReadOnly = true;
            this.textBoxOpenFileName.ShortcutsEnabled = false;
            this.textBoxOpenFileName.Size = new System.Drawing.Size(150, 36);
            this.textBoxOpenFileName.TabIndex = 8;
            // 
            // labelPlayTime
            // 
            this.labelPlayTime.Location = new System.Drawing.Point(14, 336);
            this.labelPlayTime.Name = "labelPlayTime";
            this.labelPlayTime.Size = new System.Drawing.Size(100, 55);
            this.labelPlayTime.TabIndex = 9;
            // 
            // labelOpenFileName
            // 
            this.labelOpenFileName.AutoSize = true;
            this.labelOpenFileName.Location = new System.Drawing.Point(14, 147);
            this.labelOpenFileName.Name = "labelOpenFileName";
            this.labelOpenFileName.Size = new System.Drawing.Size(121, 12);
            this.labelOpenFileName.TabIndex = 10;
            this.labelOpenFileName.Text = "현재 재생중인 파일 : ";
            // 
            // timerPlayTime
            // 
            this.timerPlayTime.Interval = 1000;
            this.timerPlayTime.Tick += new System.EventHandler(this.timerPlayTime_Tick);
            // 
            // buttonBookmark
            // 
            this.buttonBookmark.Location = new System.Drawing.Point(96, 510);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonBookmark.TabIndex = 12;
            this.buttonBookmark.Text = "책갈피";
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.buttonBookmark_Click);
            // 
            // listViewBookmark
            // 
            this.listViewBookmark.Location = new System.Drawing.Point(13, 236);
            this.listViewBookmark.Name = "listViewBookmark";
            this.listViewBookmark.Size = new System.Drawing.Size(153, 175);
            this.listViewBookmark.TabIndex = 13;
            this.listViewBookmark.UseCompatibleStateImageBehavior = false;
            this.listViewBookmark.View = System.Windows.Forms.View.Details;
            this.listViewBookmark.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewBookmark_ItemSelectionChanged);
            this.listViewBookmark.SelectedIndexChanged += new System.EventHandler(this.listViewBookmark_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(177, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 540);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listViewBookmark);
            this.Controls.Add(this.buttonBookmark);
            this.Controls.Add(this.labelOpenFileName);
            this.Controls.Add(this.labelPlayTime);
            this.Controls.Add(this.textBoxOpenFileName);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelTimeDisplay);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.axMediaPlayer1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private AxWMPLib.AxWindowsMediaPlayer axMediaPlayer1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelTimeDisplay;
        private System.Windows.Forms.Timer timerCurrentTime;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxOpenFileName;
        private System.Windows.Forms.Label labelPlayTime;
        private System.Windows.Forms.Label labelOpenFileName;
        private System.Windows.Forms.Timer timerPlayTime;
        private System.Windows.Forms.Button buttonBookmark;
        private System.Windows.Forms.ListView listViewBookmark;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

