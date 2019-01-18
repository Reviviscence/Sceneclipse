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
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.textBoxOpenFileName = new System.Windows.Forms.TextBox();
            this.labelPlayTime = new System.Windows.Forms.Label();
            this.labelOpenFileName = new System.Windows.Forms.Label();
            this.buttonBookmark = new System.Windows.Forms.Button();
            this.listViewBookmark = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxBookmarkName = new System.Windows.Forms.TextBox();
            this.buttonJumpPrevBookmark = new System.Windows.Forms.Button();
            this.buttonJumpNextBookmark = new System.Windows.Forms.Button();
            this.checkBoxPartialplay = new System.Windows.Forms.CheckBox();
            this.labelPartialplayOption = new System.Windows.Forms.Label();
            this.radioPartialplayOptionJump = new System.Windows.Forms.RadioButton();
            this.radioPartialplayOptionLoop = new System.Windows.Forms.RadioButton();
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
            this.checkAutoSeekToTime = new System.Windows.Forms.CheckBox();
            this.buttonSetCurrentTimeToEnd = new System.Windows.Forms.Button();
            this.buttonSetCurrentTimeToStart = new System.Windows.Forms.Button();
            this.panelTagList = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTagInput = new System.Windows.Forms.TextBox();
            this.buttonLoadBookmark = new System.Windows.Forms.Button();
            this.buttonSaveBookmark = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExportBandicut = new System.Windows.Forms.Button();
            this.buttonParse = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSeekPrev = new System.Windows.Forms.Button();
            this.buttonSeekNext = new System.Windows.Forms.Button();
            this.numericSeekTimeAmount = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSeekType = new System.Windows.Forms.ComboBox();
            this.panelMediaPlayer = new System.Windows.Forms.Panel();
            this.trackBarVideoProgress = new System.Windows.Forms.TrackBar();
            this.panelTrackbarBackground = new System.Windows.Forms.Panel();
            this.timerDisplayPlaytime = new System.Windows.Forms.Timer(this.components);
            this.buttonRemoveBookmark = new System.Windows.Forms.Button();
            this.trackBarVolumeControl = new System.Windows.Forms.TrackBar();
            this.panelVolumeControl = new System.Windows.Forms.Panel();
            this.checkAutoloadBookmark = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxBookmarkTimeModifyHead = new System.Windows.Forms.CheckBox();
            this.checkBoxBookmarkTimeModifyTail = new System.Windows.Forms.CheckBox();
            this.numericBookmarkTimeModifyValue = new System.Windows.Forms.NumericUpDown();
            this.comboBoxBookmarkTimeModifyType = new System.Windows.Forms.ComboBox();
            this.buttonModifyFixedTag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoProgress)).BeginInit();
            this.panelTrackbarBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeControl)).BeginInit();
            this.panelVolumeControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkTimeModifyValue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPause.Location = new System.Drawing.Point(12, 411);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(116, 23);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "재생/정지";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpenFile.Location = new System.Drawing.Point(12, 382);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(116, 23);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "파일 열기";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            this.buttonOpenFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonOpenFile_MouseClick);
            this.buttonOpenFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonOpenFile_MouseUp);
            // 
            // textBoxOpenFileName
            // 
            this.textBoxOpenFileName.Location = new System.Drawing.Point(12, 80);
            this.textBoxOpenFileName.MaximumSize = new System.Drawing.Size(150, 500);
            this.textBoxOpenFileName.MinimumSize = new System.Drawing.Size(100, 4);
            this.textBoxOpenFileName.Multiline = true;
            this.textBoxOpenFileName.Name = "textBoxOpenFileName";
            this.textBoxOpenFileName.ReadOnly = true;
            this.textBoxOpenFileName.ShortcutsEnabled = false;
            this.textBoxOpenFileName.Size = new System.Drawing.Size(125, 36);
            this.textBoxOpenFileName.TabIndex = 8;
            // 
            // labelPlayTime
            // 
            this.labelPlayTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPlayTime.Location = new System.Drawing.Point(261, 518);
            this.labelPlayTime.Name = "labelPlayTime";
            this.labelPlayTime.Size = new System.Drawing.Size(297, 29);
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
            // buttonBookmark
            // 
            this.buttonBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBookmark.Location = new System.Drawing.Point(12, 279);
            this.buttonBookmark.Name = "buttonBookmark";
            this.buttonBookmark.Size = new System.Drawing.Size(116, 69);
            this.buttonBookmark.TabIndex = 12;
            this.buttonBookmark.Text = "책갈피 만들기";
            this.buttonBookmark.UseVisualStyleBackColor = true;
            this.buttonBookmark.Click += new System.EventHandler(this.buttonBookmark_Click);
            // 
            // listViewBookmark
            // 
            this.listViewBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewBookmark.FullRowSelect = true;
            this.listViewBookmark.Location = new System.Drawing.Point(12, 122);
            this.listViewBookmark.MultiSelect = false;
            this.listViewBookmark.Name = "listViewBookmark";
            this.listViewBookmark.Size = new System.Drawing.Size(238, 151);
            this.listViewBookmark.Sorting = System.Windows.Forms.SortOrder.Ascending;
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
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(146, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 104);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTagList, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(258, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 104);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.textBoxBookmarkName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonJumpPrevBookmark, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonJumpNextBookmark, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxPartialplay, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelPartialplayOption, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioPartialplayOptionJump, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioPartialplayOptionLoop, 6, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(611, 26);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // textBoxBookmarkName
            // 
            this.textBoxBookmarkName.Location = new System.Drawing.Point(29, 3);
            this.textBoxBookmarkName.Name = "textBoxBookmarkName";
            this.textBoxBookmarkName.Size = new System.Drawing.Size(250, 21);
            this.textBoxBookmarkName.TabIndex = 0;
            this.textBoxBookmarkName.TextChanged += new System.EventHandler(this.textBoxBookmarkName_TextChanged);
            // 
            // buttonJumpPrevBookmark
            // 
            this.buttonJumpPrevBookmark.Location = new System.Drawing.Point(3, 3);
            this.buttonJumpPrevBookmark.Name = "buttonJumpPrevBookmark";
            this.buttonJumpPrevBookmark.Size = new System.Drawing.Size(20, 20);
            this.buttonJumpPrevBookmark.TabIndex = 1;
            this.buttonJumpPrevBookmark.Text = "<";
            this.buttonJumpPrevBookmark.UseVisualStyleBackColor = true;
            this.buttonJumpPrevBookmark.Click += new System.EventHandler(this.buttonJumpPrevBookmark_Click);
            // 
            // buttonJumpNextBookmark
            // 
            this.buttonJumpNextBookmark.Location = new System.Drawing.Point(285, 3);
            this.buttonJumpNextBookmark.Name = "buttonJumpNextBookmark";
            this.buttonJumpNextBookmark.Size = new System.Drawing.Size(20, 20);
            this.buttonJumpNextBookmark.TabIndex = 2;
            this.buttonJumpNextBookmark.Text = ">";
            this.buttonJumpNextBookmark.UseVisualStyleBackColor = true;
            this.buttonJumpNextBookmark.Click += new System.EventHandler(this.buttonJumpNextBookmark_Click);
            // 
            // checkBoxPartialplay
            // 
            this.checkBoxPartialplay.AutoSize = true;
            this.checkBoxPartialplay.Location = new System.Drawing.Point(311, 5);
            this.checkBoxPartialplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkBoxPartialplay.Name = "checkBoxPartialplay";
            this.checkBoxPartialplay.Size = new System.Drawing.Size(76, 16);
            this.checkBoxPartialplay.TabIndex = 3;
            this.checkBoxPartialplay.Text = "구간 재생";
            this.checkBoxPartialplay.UseVisualStyleBackColor = true;
            this.checkBoxPartialplay.CheckedChanged += new System.EventHandler(this.checkBoxPartialPlay_CheckedChanged);
            // 
            // labelPartialplayOption
            // 
            this.labelPartialplayOption.AutoSize = true;
            this.labelPartialplayOption.Location = new System.Drawing.Point(394, 7);
            this.labelPartialplayOption.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelPartialplayOption.Name = "labelPartialplayOption";
            this.labelPartialplayOption.Size = new System.Drawing.Size(79, 12);
            this.labelPartialplayOption.TabIndex = 4;
            this.labelPartialplayOption.Text = "* 재생 완료시";
            this.labelPartialplayOption.Visible = false;
            // 
            // radioPartialplayOptionJump
            // 
            this.radioPartialplayOptionJump.AutoSize = true;
            this.radioPartialplayOptionJump.Checked = true;
            this.radioPartialplayOptionJump.Location = new System.Drawing.Point(480, 5);
            this.radioPartialplayOptionJump.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.radioPartialplayOptionJump.Name = "radioPartialplayOptionJump";
            this.radioPartialplayOptionJump.Size = new System.Drawing.Size(71, 16);
            this.radioPartialplayOptionJump.TabIndex = 5;
            this.radioPartialplayOptionJump.TabStop = true;
            this.radioPartialplayOptionJump.Text = "다음으로";
            this.radioPartialplayOptionJump.UseVisualStyleBackColor = true;
            this.radioPartialplayOptionJump.Visible = false;
            // 
            // radioPartialplayOptionLoop
            // 
            this.radioPartialplayOptionLoop.AutoSize = true;
            this.radioPartialplayOptionLoop.Location = new System.Drawing.Point(559, 5);
            this.radioPartialplayOptionLoop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.radioPartialplayOptionLoop.Name = "radioPartialplayOptionLoop";
            this.radioPartialplayOptionLoop.Size = new System.Drawing.Size(47, 16);
            this.radioPartialplayOptionLoop.TabIndex = 6;
            this.radioPartialplayOptionLoop.Text = "반복";
            this.radioPartialplayOptionLoop.UseVisualStyleBackColor = true;
            this.radioPartialplayOptionLoop.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 15;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.labelBookmarkStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelBookmarkEnd, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartHour, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartMin, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkStartSec, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndHour, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndMin, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBookmarkEndSec, 12, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkAutoSeekToTime, 14, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetCurrentTimeToEnd, 13, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetCurrentTimeToStart, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(605, 24);
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
            this.label2.Location = new System.Drawing.Point(108, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = ":";
            // 
            // labelBookmarkEnd
            // 
            this.labelBookmarkEnd.Location = new System.Drawing.Point(218, 7);
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
            this.label4.Location = new System.Drawing.Point(303, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(9, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = ":";
            // 
            // numericBookmarkStartHour
            // 
            this.numericBookmarkStartHour.Location = new System.Drawing.Point(68, 3);
            this.numericBookmarkStartHour.Name = "numericBookmarkStartHour";
            this.numericBookmarkStartHour.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkStartHour.TabIndex = 4;
            this.numericBookmarkStartHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkStartHour.ValueChanged += new System.EventHandler(this.numericBookmarkStartHour_ValueChanged);
            // 
            // numericBookmarkStartMin
            // 
            this.numericBookmarkStartMin.Location = new System.Drawing.Point(123, 3);
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
            this.numericBookmarkStartSec.Location = new System.Drawing.Point(178, 3);
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
            this.numericBookmarkEndHour.Location = new System.Drawing.Point(263, 3);
            this.numericBookmarkEndHour.Name = "numericBookmarkEndHour";
            this.numericBookmarkEndHour.Size = new System.Drawing.Size(34, 21);
            this.numericBookmarkEndHour.TabIndex = 7;
            this.numericBookmarkEndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBookmarkEndHour.ValueChanged += new System.EventHandler(this.numericBookmarkEndHour_ValueChanged);
            // 
            // numericBookmarkEndMin
            // 
            this.numericBookmarkEndMin.Location = new System.Drawing.Point(318, 3);
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
            this.numericBookmarkEndSec.Location = new System.Drawing.Point(373, 3);
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
            // checkAutoSeekToTime
            // 
            this.checkAutoSeekToTime.AutoSize = true;
            this.checkAutoSeekToTime.Checked = true;
            this.checkAutoSeekToTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoSeekToTime.Location = new System.Drawing.Point(433, 5);
            this.checkAutoSeekToTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.checkAutoSeekToTime.Name = "checkAutoSeekToTime";
            this.checkAutoSeekToTime.Size = new System.Drawing.Size(136, 16);
            this.checkAutoSeekToTime.TabIndex = 10;
            this.checkAutoSeekToTime.Text = "시간수정시 자동이동";
            this.checkAutoSeekToTime.UseVisualStyleBackColor = true;
            // 
            // buttonSetCurrentTimeToEnd
            // 
            this.buttonSetCurrentTimeToEnd.Location = new System.Drawing.Point(413, 2);
            this.buttonSetCurrentTimeToEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.buttonSetCurrentTimeToEnd.Name = "buttonSetCurrentTimeToEnd";
            this.buttonSetCurrentTimeToEnd.Size = new System.Drawing.Size(14, 22);
            this.buttonSetCurrentTimeToEnd.TabIndex = 12;
            this.buttonSetCurrentTimeToEnd.Text = "]";
            this.buttonSetCurrentTimeToEnd.UseVisualStyleBackColor = true;
            this.buttonSetCurrentTimeToEnd.Click += new System.EventHandler(this.buttonSetCurrentTimeToEnd_Click);
            this.buttonSetCurrentTimeToEnd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSetCurrentTimeToEnd_MouseClick);
            this.buttonSetCurrentTimeToEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSetCurrentTimeToEnd_MouseUp);
            // 
            // buttonSetCurrentTimeToStart
            // 
            this.buttonSetCurrentTimeToStart.Location = new System.Drawing.Point(48, 2);
            this.buttonSetCurrentTimeToStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.buttonSetCurrentTimeToStart.Name = "buttonSetCurrentTimeToStart";
            this.buttonSetCurrentTimeToStart.Size = new System.Drawing.Size(14, 22);
            this.buttonSetCurrentTimeToStart.TabIndex = 11;
            this.buttonSetCurrentTimeToStart.Text = "[";
            this.buttonSetCurrentTimeToStart.UseVisualStyleBackColor = true;
            this.buttonSetCurrentTimeToStart.Click += new System.EventHandler(this.buttonSetCurrentTimeToStart_Click);
            this.buttonSetCurrentTimeToStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSetCurrentTimeToStart_MouseClick);
            this.buttonSetCurrentTimeToStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonSetCurrentTimeToStart_MouseUp);
            // 
            // panelTagList
            // 
            this.panelTagList.AutoScroll = true;
            this.panelTagList.AutoScrollMinSize = new System.Drawing.Size(550, 0);
            this.panelTagList.ColumnCount = 2;
            this.panelTagList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.panelTagList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.panelTagList.Controls.Add(this.label6, 0, 0);
            this.panelTagList.Controls.Add(this.textBoxTagInput, 1, 0);
            this.panelTagList.Location = new System.Drawing.Point(3, 59);
            this.panelTagList.Name = "panelTagList";
            this.panelTagList.RowCount = 1;
            this.panelTagList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTagList.Size = new System.Drawing.Size(605, 42);
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
            this.label6.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label6_MouseDoubleClick);
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
            this.buttonLoadBookmark.Location = new System.Drawing.Point(159, 13);
            this.buttonLoadBookmark.Name = "buttonLoadBookmark";
            this.buttonLoadBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadBookmark.TabIndex = 16;
            this.buttonLoadBookmark.Text = "불러오기";
            this.buttonLoadBookmark.UseVisualStyleBackColor = true;
            this.buttonLoadBookmark.Click += new System.EventHandler(this.buttonLoadBookmark_Click);
            // 
            // buttonSaveBookmark
            // 
            this.buttonSaveBookmark.Location = new System.Drawing.Point(78, 13);
            this.buttonSaveBookmark.Name = "buttonSaveBookmark";
            this.buttonSaveBookmark.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveBookmark.TabIndex = 17;
            this.buttonSaveBookmark.Text = "저장";
            this.buttonSaveBookmark.UseVisualStyleBackColor = true;
            this.buttonSaveBookmark.Click += new System.EventHandler(this.buttonSaveBookmark_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.buttonExportBandicut);
            this.groupBox1.Controls.Add(this.buttonParse);
            this.groupBox1.Controls.Add(this.buttonSaveBookmark);
            this.groupBox1.Controls.Add(this.buttonLoadBookmark);
            this.groupBox1.Location = new System.Drawing.Point(12, 468);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 71);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "책갈피";
            // 
            // buttonExportBandicut
            // 
            this.buttonExportBandicut.Location = new System.Drawing.Point(78, 43);
            this.buttonExportBandicut.Name = "buttonExportBandicut";
            this.buttonExportBandicut.Size = new System.Drawing.Size(156, 23);
            this.buttonExportBandicut.TabIndex = 19;
            this.buttonExportBandicut.Text = "반디컷 프로젝트로";
            this.buttonExportBandicut.UseVisualStyleBackColor = true;
            this.buttonExportBandicut.Click += new System.EventHandler(this.buttonExportBandicut_Click);
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(6, 13);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(69, 53);
            this.buttonParse.TabIndex = 18;
            this.buttonParse.Text = "책갈피\r\n자동생성";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonQuit.Location = new System.Drawing.Point(134, 411);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(116, 23);
            this.buttonQuit.TabIndex = 19;
            this.buttonQuit.Text = "종료";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSeekPrev
            // 
            this.buttonSeekPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSeekPrev.Location = new System.Drawing.Point(134, 439);
            this.buttonSeekPrev.Name = "buttonSeekPrev";
            this.buttonSeekPrev.Size = new System.Drawing.Size(55, 23);
            this.buttonSeekPrev.TabIndex = 20;
            this.buttonSeekPrev.Text = "앞으로";
            this.buttonSeekPrev.UseVisualStyleBackColor = true;
            this.buttonSeekPrev.Click += new System.EventHandler(this.buttonSeekPrev_Click);
            // 
            // buttonSeekNext
            // 
            this.buttonSeekNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSeekNext.Location = new System.Drawing.Point(195, 439);
            this.buttonSeekNext.Name = "buttonSeekNext";
            this.buttonSeekNext.Size = new System.Drawing.Size(55, 23);
            this.buttonSeekNext.TabIndex = 21;
            this.buttonSeekNext.Text = "뒤로";
            this.buttonSeekNext.UseVisualStyleBackColor = true;
            this.buttonSeekNext.Click += new System.EventHandler(this.buttonSeekNext_Click);
            // 
            // numericSeekTimeAmount
            // 
            this.numericSeekTimeAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericSeekTimeAmount.Location = new System.Drawing.Point(12, 439);
            this.numericSeekTimeAmount.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericSeekTimeAmount.Name = "numericSeekTimeAmount";
            this.numericSeekTimeAmount.Size = new System.Drawing.Size(48, 21);
            this.numericSeekTimeAmount.TabIndex = 22;
            this.numericSeekTimeAmount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // comboBoxSeekType
            // 
            this.comboBoxSeekType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSeekType.FormattingEnabled = true;
            this.comboBoxSeekType.Items.AddRange(new object[] {
            "초",
            "분",
            "시간"});
            this.comboBoxSeekType.Location = new System.Drawing.Point(66, 440);
            this.comboBoxSeekType.Name = "comboBoxSeekType";
            this.comboBoxSeekType.Size = new System.Drawing.Size(62, 20);
            this.comboBoxSeekType.TabIndex = 23;
            this.comboBoxSeekType.Text = "초";
            // 
            // panelMediaPlayer
            // 
            this.panelMediaPlayer.AutoSize = true;
            this.panelMediaPlayer.Location = new System.Drawing.Point(258, 122);
            this.panelMediaPlayer.Name = "panelMediaPlayer";
            this.panelMediaPlayer.Size = new System.Drawing.Size(611, 348);
            this.panelMediaPlayer.TabIndex = 24;
            // 
            // trackBarVideoProgress
            // 
            this.trackBarVideoProgress.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.trackBarVideoProgress.Enabled = false;
            this.trackBarVideoProgress.Location = new System.Drawing.Point(0, 0);
            this.trackBarVideoProgress.Maximum = 1000;
            this.trackBarVideoProgress.Name = "trackBarVideoProgress";
            this.trackBarVideoProgress.Size = new System.Drawing.Size(611, 45);
            this.trackBarVideoProgress.TabIndex = 25;
            this.trackBarVideoProgress.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // panelTrackbarBackground
            // 
            this.panelTrackbarBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTrackbarBackground.Controls.Add(this.trackBarVideoProgress);
            this.panelTrackbarBackground.Location = new System.Drawing.Point(259, 472);
            this.panelTrackbarBackground.Name = "panelTrackbarBackground";
            this.panelTrackbarBackground.Size = new System.Drawing.Size(612, 38);
            this.panelTrackbarBackground.TabIndex = 26;
            // 
            // timerDisplayPlaytime
            // 
            this.timerDisplayPlaytime.Enabled = true;
            this.timerDisplayPlaytime.Tick += new System.EventHandler(this.timerDisplayPlaytime_Tick);
            // 
            // buttonRemoveBookmark
            // 
            this.buttonRemoveBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveBookmark.Location = new System.Drawing.Point(12, 354);
            this.buttonRemoveBookmark.Name = "buttonRemoveBookmark";
            this.buttonRemoveBookmark.Size = new System.Drawing.Size(116, 23);
            this.buttonRemoveBookmark.TabIndex = 27;
            this.buttonRemoveBookmark.Text = "삭제";
            this.buttonRemoveBookmark.UseVisualStyleBackColor = true;
            this.buttonRemoveBookmark.Click += new System.EventHandler(this.buttonRemoveBookmark_Click);
            // 
            // trackBarVolumeControl
            // 
            this.trackBarVolumeControl.Enabled = false;
            this.trackBarVolumeControl.Location = new System.Drawing.Point(0, 0);
            this.trackBarVolumeControl.Maximum = 100;
            this.trackBarVolumeControl.Name = "trackBarVolumeControl";
            this.trackBarVolumeControl.Size = new System.Drawing.Size(104, 45);
            this.trackBarVolumeControl.TabIndex = 28;
            this.trackBarVolumeControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolumeControl.Value = 50;
            // 
            // panelVolumeControl
            // 
            this.panelVolumeControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelVolumeControl.Controls.Add(this.trackBarVolumeControl);
            this.panelVolumeControl.Location = new System.Drawing.Point(764, 511);
            this.panelVolumeControl.Name = "panelVolumeControl";
            this.panelVolumeControl.Size = new System.Drawing.Size(107, 36);
            this.panelVolumeControl.TabIndex = 29;
            // 
            // checkAutoloadBookmark
            // 
            this.checkAutoloadBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkAutoloadBookmark.AutoSize = true;
            this.checkAutoloadBookmark.Checked = true;
            this.checkAutoloadBookmark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoloadBookmark.Location = new System.Drawing.Point(136, 386);
            this.checkAutoloadBookmark.Name = "checkAutoloadBookmark";
            this.checkAutoloadBookmark.Size = new System.Drawing.Size(116, 16);
            this.checkAutoloadBookmark.TabIndex = 30;
            this.checkAutoloadBookmark.Text = "책갈피 자동 읽기";
            this.checkAutoloadBookmark.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "책갈피 시간 보정";
            // 
            // checkBoxBookmarkTimeModifyHead
            // 
            this.checkBoxBookmarkTimeModifyHead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxBookmarkTimeModifyHead.AutoSize = true;
            this.checkBoxBookmarkTimeModifyHead.Location = new System.Drawing.Point(134, 304);
            this.checkBoxBookmarkTimeModifyHead.Name = "checkBoxBookmarkTimeModifyHead";
            this.checkBoxBookmarkTimeModifyHead.Size = new System.Drawing.Size(36, 16);
            this.checkBoxBookmarkTimeModifyHead.TabIndex = 32;
            this.checkBoxBookmarkTimeModifyHead.Text = "전";
            this.checkBoxBookmarkTimeModifyHead.UseVisualStyleBackColor = true;
            // 
            // checkBoxBookmarkTimeModifyTail
            // 
            this.checkBoxBookmarkTimeModifyTail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxBookmarkTimeModifyTail.AutoSize = true;
            this.checkBoxBookmarkTimeModifyTail.Location = new System.Drawing.Point(171, 304);
            this.checkBoxBookmarkTimeModifyTail.Name = "checkBoxBookmarkTimeModifyTail";
            this.checkBoxBookmarkTimeModifyTail.Size = new System.Drawing.Size(36, 16);
            this.checkBoxBookmarkTimeModifyTail.TabIndex = 33;
            this.checkBoxBookmarkTimeModifyTail.Text = "후";
            this.checkBoxBookmarkTimeModifyTail.UseVisualStyleBackColor = true;
            // 
            // numericBookmarkTimeModifyValue
            // 
            this.numericBookmarkTimeModifyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericBookmarkTimeModifyValue.Location = new System.Drawing.Point(134, 327);
            this.numericBookmarkTimeModifyValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericBookmarkTimeModifyValue.Name = "numericBookmarkTimeModifyValue";
            this.numericBookmarkTimeModifyValue.Size = new System.Drawing.Size(38, 21);
            this.numericBookmarkTimeModifyValue.TabIndex = 34;
            this.numericBookmarkTimeModifyValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // comboBoxBookmarkTimeModifyType
            // 
            this.comboBoxBookmarkTimeModifyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBookmarkTimeModifyType.FormattingEnabled = true;
            this.comboBoxBookmarkTimeModifyType.Items.AddRange(new object[] {
            "초",
            "분",
            "시간"});
            this.comboBoxBookmarkTimeModifyType.Location = new System.Drawing.Point(179, 327);
            this.comboBoxBookmarkTimeModifyType.Name = "comboBoxBookmarkTimeModifyType";
            this.comboBoxBookmarkTimeModifyType.Size = new System.Drawing.Size(71, 20);
            this.comboBoxBookmarkTimeModifyType.TabIndex = 35;
            this.comboBoxBookmarkTimeModifyType.Text = "초";
            // 
            // buttonModifyFixedTag
            // 
            this.buttonModifyFixedTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModifyFixedTag.Location = new System.Drawing.Point(134, 354);
            this.buttonModifyFixedTag.Name = "buttonModifyFixedTag";
            this.buttonModifyFixedTag.Size = new System.Drawing.Size(116, 23);
            this.buttonModifyFixedTag.TabIndex = 36;
            this.buttonModifyFixedTag.Text = "고정태그 편집";
            this.buttonModifyFixedTag.UseVisualStyleBackColor = true;
            this.buttonModifyFixedTag.Click += new System.EventHandler(this.buttonModifyFixedTag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 551);
            this.Controls.Add(this.buttonModifyFixedTag);
            this.Controls.Add(this.comboBoxBookmarkTimeModifyType);
            this.Controls.Add(this.numericBookmarkTimeModifyValue);
            this.Controls.Add(this.checkBoxBookmarkTimeModifyTail);
            this.Controls.Add(this.checkBoxBookmarkTimeModifyHead);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkAutoloadBookmark);
            this.Controls.Add(this.panelVolumeControl);
            this.Controls.Add(this.buttonRemoveBookmark);
            this.Controls.Add(this.panelTrackbarBackground);
            this.Controls.Add(this.panelMediaPlayer);
            this.Controls.Add(this.buttonBookmark);
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
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Sceneclipse";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoProgress)).EndInit();
            this.panelTrackbarBackground.ResumeLayout(false);
            this.panelTrackbarBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeControl)).EndInit();
            this.panelVolumeControl.ResumeLayout(false);
            this.panelVolumeControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBookmarkTimeModifyValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.TextBox textBoxOpenFileName;
        private System.Windows.Forms.Label labelPlayTime;
        private System.Windows.Forms.Label labelOpenFileName;
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
        private System.Windows.Forms.Button buttonSetCurrentTimeToStart;
        private System.Windows.Forms.Button buttonSetCurrentTimeToEnd;
        private System.Windows.Forms.Panel panelMediaPlayer;
        private Vlc.DotNet.Forms.VlcControl vlcMediaPlayer;
        private System.Windows.Forms.TrackBar trackBarVideoProgress;
        private System.Windows.Forms.Panel panelTrackbarBackground;
        private System.Windows.Forms.Timer timerDisplayPlaytime;
        private System.Windows.Forms.Button buttonRemoveBookmark;
        private System.Windows.Forms.TrackBar trackBarVolumeControl;
        private System.Windows.Forms.Panel panelVolumeControl;
        private System.Windows.Forms.CheckBox checkAutoloadBookmark;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button buttonJumpPrevBookmark;
        private System.Windows.Forms.Button buttonJumpNextBookmark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxBookmarkTimeModifyHead;
        private System.Windows.Forms.CheckBox checkBoxBookmarkTimeModifyTail;
        private System.Windows.Forms.NumericUpDown numericBookmarkTimeModifyValue;
        private System.Windows.Forms.ComboBox comboBoxBookmarkTimeModifyType;
        private System.Windows.Forms.Button buttonModifyFixedTag;
        private System.Windows.Forms.CheckBox checkBoxPartialplay;
        private System.Windows.Forms.Label labelPartialplayOption;
        private System.Windows.Forms.RadioButton radioPartialplayOptionJump;
        private System.Windows.Forms.RadioButton radioPartialplayOptionLoop;
    }
}

