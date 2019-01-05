﻿namespace SceneClipse
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
            this.axMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBookmarkName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelBookmarkStart = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBookmarkEnd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericBookmarkStartHour = new System.Windows.Forms.NumericUpDown();
            this.numericBookmarkStartMin = new System.Windows.Forms.NumericUpDown();
            this.numericBookmarkStartSec = new System.Windows.Forms.NumericUpDown();
            this.numericBookmarkEndHour = new System.Windows.Forms.NumericUpDown();
            this.numericBookmarkEndMin = new System.Windows.Forms.NumericUpDown();
            this.numericBookmarkEndSec = new System.Windows.Forms.NumericUpDown();
            this.panelTagList = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTagInput = new System.Windows.Forms.TextBox();
            this.buttonLoadBookmark = new System.Windows.Forms.Button();
            this.buttonSaveBookmark = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonParse = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonExportBandicut = new System.Windows.Forms.Button();
            this.buttonSeekPrev = new System.Windows.Forms.Button();
            this.buttonSeekNext = new System.Windows.Forms.Button();
            this.numericSeekTimeAmount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSeekType = new System.Windows.Forms.ComboBox();
            this.checkAutoSeekToTime = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndSec)).BeginInit();
            this.panelTagList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeekTimeAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // axMediaPlayer1
            // 
            this.axMediaPlayer1.Enabled = true;
            this.axMediaPlayer1.Location = new System.Drawing.Point(269, 122);
            this.axMediaPlayer1.Name = "axMediaPlayer1";
            this.axMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMediaPlayer1.OcxState")));
            this.axMediaPlayer1.Size = new System.Drawing.Size(611, 426);
            this.axMediaPlayer1.TabIndex = 1;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(93, 353);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "재생/정지";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 353);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "파일 열기";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxOpenFileName
            // 
            this.textBoxOpenFileName.Location = new System.Drawing.Point(14, 82);
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
            this.labelPlayTime.Location = new System.Drawing.Point(162, 12);
            this.labelPlayTime.Name = "labelPlayTime";
            this.labelPlayTime.Size = new System.Drawing.Size(100, 55);
            this.labelPlayTime.TabIndex = 9;
            // 
            // labelOpenFileName
            // 
            this.labelOpenFileName.AutoSize = true;
            this.labelOpenFileName.Location = new System.Drawing.Point(12, 51);
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
            this.buttonBookmark.Location = new System.Drawing.Point(6, 20);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(156, 23);
            this.buttonBookmark.TabIndex = 12;
            this.buttonBookmark.Text = "책갈피 생성";
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.buttonBookmark_Click);
            // 
            // listViewBookmark
            // 
            this.listViewBookmark.Location = new System.Drawing.Point(12, 122);
            this.listViewBookmark.Name = "listViewBookmark";
            this.listViewBookmark.Size = new System.Drawing.Size(250, 225);
            this.listViewBookmark.TabIndex = 13;
            this.listViewBookmark.UseCompatibleStateImageBehavior = false;
            this.listViewBookmark.View = System.Windows.Forms.View.Details;
            this.listViewBookmark.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewBookmark_ItemSelectionChanged);
            this.listViewBookmark.SelectedIndexChanged += new System.EventHandler(this.listViewBookmark_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(104, 104);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(230, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 104);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxBookmarkName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTagList, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(340, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 104);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // textBoxBookmarkName
            // 
            this.textBoxBookmarkName.Location = new System.Drawing.Point(3, 3);
            this.textBoxBookmarkName.Name = "textBoxBookmarkName";
            this.textBoxBookmarkName.Size = new System.Drawing.Size(387, 21);
            this.textBoxBookmarkName.TabIndex = 0;
            this.textBoxBookmarkName.TextChanged += new System.EventHandler(this.textBoxBookmarkName_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelBookmarkStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelBookmarkEnd, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartHour, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartMin, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartSec, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndHour, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndMin, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndSec, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkAutoSeekToTime, 12, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(534, 24);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelBookmarkStart
            // 
            this.labelBookmarkStart.Location = new System.Drawing.Point(3, 7);
            this.labelBookmarkStart.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelBookmarkStart.Name = "labelBookmarkStart";
            this.labelBookmarkStart.Size = new System.Drawing.Size(39, 12);
            this.labelBookmarkStart.TabIndex = 0;
            this.labelBookmarkStart.Text = "시작 :";
            this.labelBookmarkStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = ":";
            // 
            // labelBookmarkEnd
            // 
            this.labelBookmarkEnd.Location = new System.Drawing.Point(198, 7);
            this.labelBookmarkEnd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelBookmarkEnd.Name = "labelBookmarkEnd";
            this.labelBookmarkEnd.Size = new System.Drawing.Size(39, 12);
            this.labelBookmarkEnd.TabIndex = 1;
            this.labelBookmarkEnd.Text = "끝 :";
            this.labelBookmarkEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = ":";
            // 
            // numericBookmarkStartHour
            // 
            this.numericBookmarkStartHour.Location = new System.Drawing.Point(48, 3);
            this.numericBookmarkStartHour.Name = "numericBookmarkStartHour";
            this.numericBookmarkStartHour.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkStartHour.TabIndex = 4;
            this.numericBookmarkStartHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkStartHour.ValueChanged += new System.EventHandler(this.numericBookmarkStartHour_ValueChanged);
            // 
            // numericBookmarkStartMin
            // 
            this.numericBookmarkStartMin.Location = new System.Drawing.Point(103, 3);
            this.numericBookmarkStartMin.Maximum = new decimal(new int[] {
            61,
            0,
            0,
            0});
            this.numericBookmarkStartMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericBookmarkStartMin.Name = "numericBookmarkStartMin";
            this.numericBookmarkStartMin.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkStartMin.TabIndex = 5;
            this.numericBookmarkStartMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkStartMin.ValueChanged += new System.EventHandler(this.numericBookmarkStartMin_ValueChanged);
            // 
            // numericBookmarkStartSec
            // 
            this.numericBookmarkStartSec.Location = new System.Drawing.Point(158, 3);
            this.numericBookmarkStartSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericBookmarkStartSec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericBookmarkStartSec.Name = "numericBookmarkStartSec";
            this.numericBookmarkStartSec.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkStartSec.TabIndex = 6;
            this.numericBookmarkStartSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkStartSec.ValueChanged += new System.EventHandler(this.numericBookmarkStartSec_ValueChanged);
            // 
            // numericBookmarkEndHour
            // 
            this.numericBookmarkEndHour.Location = new System.Drawing.Point(243, 3);
            this.numericBookmarkEndHour.Name = "numericBookmarkEndHour";
            this.numericBookmarkEndHour.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkEndHour.TabIndex = 7;
            this.numericBookmarkEndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkEndHour.ValueChanged += new System.EventHandler(this.numericBookmarkEndHour_ValueChanged);
            // 
            // numericBookmarkEndMin
            // 
            this.numericBookmarkEndMin.Location = new System.Drawing.Point(298, 3);
            this.numericBookmarkEndMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericBookmarkEndMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericBookmarkEndMin.Name = "numericBookmarkEndMin";
            this.numericBookmarkEndMin.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkEndMin.TabIndex = 8;
            this.numericBookmarkEndMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkEndMin.ValueChanged += new System.EventHandler(this.numericBookmarkEndMin_ValueChanged);
            // 
            // numericBookmarkEndSec
            // 
            this.numericBookmarkEndSec.Location = new System.Drawing.Point(353, 3);
            this.numericBookmarkEndSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericBookmarkEndSec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericBookmarkEndSec.Name = "numericBookmarkEndSec";
            this.numericBookmarkEndSec.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkEndSec.TabIndex = 9;
            this.numericBookmarkEndSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkEndSec.ValueChanged += new System.EventHandler(this.numericBookmarkEndSec_ValueChanged);
            // 
            // panelTagList
            // 
            this.panelTagList.AutoScroll = true;
            this.panelTagList.AutoScrollMinSize = new System.Drawing.Size(550, 0);
            this.panelTagList.ColumnCount = 2;
            this.panelTagList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.panelTagList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 505F));
            this.panelTagList.Controls.Add(this.label6, 0, 0);
            this.panelTagList.Controls.Add(this.textBoxTagInput, 1, 0);
            this.panelTagList.Location = new System.Drawing.Point(3, 59);
            this.panelTagList.Name = "panelTagList";
            this.panelTagList.RowCount = 1;
            this.panelTagList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTagList.Size = new System.Drawing.Size(534, 42);
            this.panelTagList.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "태그 :";
            // 
            // textBoxTagInput
            // 
            this.textBoxTagInput.Location = new System.Drawing.Point(48, 3);
            this.textBoxTagInput.Name = "textBoxTagInput";
            this.textBoxTagInput.Size = new System.Drawing.Size(100, 21);
            this.textBoxTagInput.TabIndex = 1;
            this.textBoxTagInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTagInput_KeyPress);
            // 
            // buttonLoadBookmark
            // 
            this.buttonLoadBookmark.Location = new System.Drawing.Point(87, 49);
            this.buttonLoadBookmark.Name = "buttonLoadBookmark";
            this.buttonLoadBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadBookmark.TabIndex = 16;
            this.buttonLoadBookmark.Text = "불러오기";
            this.buttonLoadBookmark.UseVisualStyleBackColor = true;
            this.buttonLoadBookmark.Click += new System.EventHandler(this.buttonLoadBookmark_Click);
            // 
            // buttonSaveBookmark
            // 
            this.buttonSaveBookmark.Location = new System.Drawing.Point(6, 49);
            this.buttonSaveBookmark.Name = "buttonSaveBookmark";
            this.buttonSaveBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveBookmark.TabIndex = 17;
            this.buttonSaveBookmark.Text = "저장";
            this.buttonSaveBookmark.UseVisualStyleBackColor = true;
            this.buttonSaveBookmark.Click += new System.EventHandler(this.buttonSaveBookmark_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonExportBandicut);
            this.groupBox1.Controls.Add(this.buttonParse);
            this.groupBox1.Controls.Add(this.buttonBookmark);
            this.groupBox1.Controls.Add(this.buttonSaveBookmark);
            this.groupBox1.Controls.Add(this.buttonLoadBookmark);
            this.groupBox1.Location = new System.Drawing.Point(12, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 108);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "책갈피";
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(168, 20);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 18;
            this.buttonParse.Text = "자동생성";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(175, 353);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 19;
            this.buttonQuit.Text = "종료";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonExportBandicut
            // 
            this.buttonExportBandicut.Location = new System.Drawing.Point(6, 79);
            this.buttonExportBandicut.Name = "buttonExportBandicut";
            this.buttonExportBandicut.Size = new System.Drawing.Size(156, 23);
            this.buttonExportBandicut.TabIndex = 19;
            this.buttonExportBandicut.Text = "반디컷 프로젝트로";
            this.buttonExportBandicut.UseVisualStyleBackColor = true;
            // 
            // buttonSeekPrev
            // 
            this.buttonSeekPrev.Location = new System.Drawing.Point(124, 384);
            this.buttonSeekPrev.Name = "buttonSeekPrev";
            this.buttonSeekPrev.Size = new System.Drawing.Size(60, 23);
            this.buttonSeekPrev.TabIndex = 20;
            this.buttonSeekPrev.Text = "앞으로";
            this.buttonSeekPrev.UseVisualStyleBackColor = true;
            this.buttonSeekPrev.Click += new System.EventHandler(this.buttonSeekPrev_Click);
            // 
            // buttonSeekNext
            // 
            this.buttonSeekNext.Location = new System.Drawing.Point(190, 384);
            this.buttonSeekNext.Name = "buttonSeekNext";
            this.buttonSeekNext.Size = new System.Drawing.Size(60, 23);
            this.buttonSeekNext.TabIndex = 21;
            this.buttonSeekNext.Text = "뒤로";
            this.buttonSeekNext.UseVisualStyleBackColor = true;
            this.buttonSeekNext.Click += new System.EventHandler(this.buttonSeekNext_Click);
            // 
            // numericSeekTimeAmount
            // 
            this.numericSeekTimeAmount.Location = new System.Drawing.Point(18, 384);
            this.numericSeekTimeAmount.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericSeekTimeAmount.Name = "numericSeekTimeAmount";
            this.numericSeekTimeAmount.Size = new System.Drawing.Size(31, 21);
            this.numericSeekTimeAmount.TabIndex = 22;
            this.numericSeekTimeAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // comboBoxSeekType
            // 
            this.comboBoxSeekType.FormattingEnabled = true;
            this.comboBoxSeekType.Items.AddRange(new object[] {
            "초",
            "분",
            "시간"});
            this.comboBoxSeekType.Location = new System.Drawing.Point(56, 384);
            this.comboBoxSeekType.Name = "comboBoxSeekType";
            this.comboBoxSeekType.Size = new System.Drawing.Size(62, 20);
            this.comboBoxSeekType.TabIndex = 23;
            this.comboBoxSeekType.Text = "초";
            // 
            // checkAutoSeekToTime
            // 
            this.checkAutoSeekToTime.AutoSize = true;
            this.checkAutoSeekToTime.Checked = true;
            this.checkAutoSeekToTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSeekToTime.Location = new System.Drawing.Point(393, 3);
            this.checkAutoSeekToTime.Name = "checkAutoSeekToTime";
            this.checkAutoSeekToTime.Size = new System.Drawing.Size(136, 16);
            this.checkAutoSeekToTime.TabIndex = 10;
            this.checkAutoSeekToTime.Text = "시간수정시 자동이동";
            this.checkAutoSeekToTime.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 551);
            this.Controls.Add(this.comboBoxSeekType);
            this.Controls.Add(this.numericSeekTimeAmount);
            this.Controls.Add(this.buttonSeekNext);
            this.Controls.Add(this.buttonSeekPrev);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listViewBookmark);
            this.Controls.Add(this.labelOpenFileName);
            this.Controls.Add(this.labelPlayTime);
            this.Controls.Add(this.textBoxOpenFileName);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.axMediaPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkStartSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkEndSec)).EndInit();
            this.panelTagList.ResumeLayout(false);
            this.panelTagList.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericSeekTimeAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AxWMPLib.AxWindowsMediaPlayer axMediaPlayer1;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxBookmarkName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelBookmarkStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBookmarkEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericBookmarkStartHour;
        private System.Windows.Forms.NumericUpDown numericBookmarkStartMin;
        private System.Windows.Forms.NumericUpDown numericBookmarkStartSec;
        private System.Windows.Forms.NumericUpDown numericBookmarkEndHour;
        private System.Windows.Forms.NumericUpDown numericBookmarkEndMin;
        private System.Windows.Forms.NumericUpDown numericBookmarkEndSec;
        private System.Windows.Forms.TableLayoutPanel panelTagList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTagInput;
        private System.Windows.Forms.Button buttonLoadBookmark;
        private System.Windows.Forms.Button buttonSaveBookmark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Button buttonExportBandicut;
        private System.Windows.Forms.Button buttonSeekPrev;
        private System.Windows.Forms.Button buttonSeekNext;
        private System.Windows.Forms.NumericUpDown numericSeekTimeAmount;
        private System.Windows.Forms.ComboBox comboBoxSeekType;
        private System.Windows.Forms.CheckBox checkAutoSeekToTime;
    }
}

