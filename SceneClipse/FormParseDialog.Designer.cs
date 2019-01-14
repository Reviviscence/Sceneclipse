namespace SceneClipse
{
    partial class FormParseDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericModifySec = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericSec = new System.Windows.Forms.NumericUpDown();
            this.textBoxInputBookmark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGetTimeDataFromFilename = new System.Windows.Forms.Button();
            this.groupModifyTime = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericHour = new System.Windows.Forms.NumericUpDown();
            this.checkModifyTime = new System.Windows.Forms.CheckBox();
            this.checkBoxModifyHead = new System.Windows.Forms.CheckBox();
            this.checkBoxModifyTail = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericModifySec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSec)).BeginInit();
            this.groupModifyTime.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "영상의 시작 시점의 시각을 입력해 주세요.";
            // 
            // numericModifySec
            // 
            this.numericModifySec.Location = new System.Drawing.Point(89, 17);
            this.numericModifySec.Name = "numericModifySec";
            this.numericModifySec.Size = new System.Drawing.Size(44, 21);
            this.numericModifySec.TabIndex = 1;
            this.numericModifySec.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // numericMin
            // 
            this.numericMin.Location = new System.Drawing.Point(81, 29);
            this.numericMin.Maximum = new decimal(new int[] {
            61,
            0,
            0,
            0});
            this.numericMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericMin.Name = "numericMin";
            this.numericMin.Size = new System.Drawing.Size(44, 21);
            this.numericMin.TabIndex = 1;
            this.numericMin.ValueChanged += new System.EventHandler(this.numericMin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(9, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = ":";
            // 
            // numericSec
            // 
            this.numericSec.Location = new System.Drawing.Point(147, 29);
            this.numericSec.Maximum = new decimal(new int[] {
            61,
            0,
            0,
            0});
            this.numericSec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericSec.Name = "numericSec";
            this.numericSec.Size = new System.Drawing.Size(44, 21);
            this.numericSec.TabIndex = 1;
            this.numericSec.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericSec.ValueChanged += new System.EventHandler(this.numericSec_ValueChanged);
            // 
            // textBoxInputBookmark
            // 
            this.textBoxInputBookmark.Location = new System.Drawing.Point(15, 110);
            this.textBoxInputBookmark.Multiline = true;
            this.textBoxInputBookmark.Name = "textBoxInputBookmark";
            this.textBoxInputBookmark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputBookmark.Size = new System.Drawing.Size(229, 292);
            this.textBoxInputBookmark.TabIndex = 3;
            this.textBoxInputBookmark.Text = "14 Dec 2018 13:08\r\n14 Dec 2018 13:19\r\n14 Dec 2018 13:28\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "책갈피 시간 정보를 입력해 주세요.";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(15, 532);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "확인";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(97, 532);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "취소";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonGetTimeDataFromFilename
            // 
            this.buttonGetTimeDataFromFilename.Location = new System.Drawing.Point(15, 57);
            this.buttonGetTimeDataFromFilename.Name = "buttonGetTimeDataFromFilename";
            this.buttonGetTimeDataFromFilename.Size = new System.Drawing.Size(193, 23);
            this.buttonGetTimeDataFromFilename.TabIndex = 8;
            this.buttonGetTimeDataFromFilename.Text = "파일명에서 시간정보 가져오기";
            this.buttonGetTimeDataFromFilename.UseVisualStyleBackColor = true;
            this.buttonGetTimeDataFromFilename.Click += new System.EventHandler(this.buttonGetTimeDataFromFilename_Click);
            // 
            // groupModifyTime
            // 
            this.groupModifyTime.Controls.Add(this.groupBox2);
            this.groupModifyTime.Controls.Add(this.label6);
            this.groupModifyTime.Controls.Add(this.label5);
            this.groupModifyTime.Controls.Add(this.numericModifySec);
            this.groupModifyTime.Location = new System.Drawing.Point(15, 432);
            this.groupModifyTime.Name = "groupModifyTime";
            this.groupModifyTime.Size = new System.Drawing.Size(229, 94);
            this.groupModifyTime.TabIndex = 9;
            this.groupModifyTime.TabStop = false;
            this.groupModifyTime.Text = "시간 보정";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxModifyTail);
            this.groupBox2.Controls.Add(this.checkBoxModifyHead);
            this.groupBox2.Location = new System.Drawing.Point(9, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 40);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "보정 위치";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "초";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "보정할 시간 : ";
            // 
            // numericHour
            // 
            this.numericHour.Location = new System.Drawing.Point(17, 29);
            this.numericHour.Name = "numericHour";
            this.numericHour.Size = new System.Drawing.Size(44, 21);
            this.numericHour.TabIndex = 1;
            this.numericHour.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // checkModifyTime
            // 
            this.checkModifyTime.AutoSize = true;
            this.checkModifyTime.Checked = true;
            this.checkModifyTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkModifyTime.Location = new System.Drawing.Point(15, 410);
            this.checkModifyTime.Name = "checkModifyTime";
            this.checkModifyTime.Size = new System.Drawing.Size(104, 16);
            this.checkModifyTime.TabIndex = 10;
            this.checkModifyTime.Text = "시간 보정 사용";
            this.checkModifyTime.UseVisualStyleBackColor = true;
            this.checkModifyTime.CheckedChanged += new System.EventHandler(this.checkModifyTime_CheckedChanged);
            // 
            // checkBoxModifyHead
            // 
            this.checkBoxModifyHead.AutoSize = true;
            this.checkBoxModifyHead.Checked = true;
            this.checkBoxModifyHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModifyHead.Location = new System.Drawing.Point(19, 18);
            this.checkBoxModifyHead.Name = "checkBoxModifyHead";
            this.checkBoxModifyHead.Size = new System.Drawing.Size(76, 16);
            this.checkBoxModifyHead.TabIndex = 5;
            this.checkBoxModifyHead.Text = "시작 시간";
            this.checkBoxModifyHead.UseVisualStyleBackColor = true;
            // 
            // checkBoxModifyTail
            // 
            this.checkBoxModifyTail.AutoSize = true;
            this.checkBoxModifyTail.Checked = true;
            this.checkBoxModifyTail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxModifyTail.Location = new System.Drawing.Point(110, 18);
            this.checkBoxModifyTail.Name = "checkBoxModifyTail";
            this.checkBoxModifyTail.Size = new System.Drawing.Size(64, 16);
            this.checkBoxModifyTail.TabIndex = 6;
            this.checkBoxModifyTail.Text = "끝 시간";
            this.checkBoxModifyTail.UseVisualStyleBackColor = true;
            // 
            // FormParseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 567);
            this.Controls.Add(this.checkModifyTime);
            this.Controls.Add(this.groupModifyTime);
            this.Controls.Add(this.buttonGetTimeDataFromFilename);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.numericHour);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxInputBookmark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericSec);
            this.Controls.Add(this.numericMin);
            this.Controls.Add(this.label1);
            this.Name = "FormParseDialog";
            this.Text = "책갈피 시간정보 입력";
            ((System.ComponentModel.ISupportInitialize)(this.numericModifySec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSec)).EndInit();
            this.groupModifyTime.ResumeLayout(false);
            this.groupModifyTime.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericModifySec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericSec;
        private System.Windows.Forms.TextBox textBoxInputBookmark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonGetTimeDataFromFilename;
        private System.Windows.Forms.GroupBox groupModifyTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericHour;
        private System.Windows.Forms.CheckBox checkModifyTime;
        private System.Windows.Forms.CheckBox checkBoxModifyTail;
        private System.Windows.Forms.CheckBox checkBoxModifyHead;
    }
}