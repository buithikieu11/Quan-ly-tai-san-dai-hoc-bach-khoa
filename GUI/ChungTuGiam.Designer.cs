namespace QuanLyTaiSanDHBK.GUI
{
    partial class ChungTuGiam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChungTuGiam));
            this.textBoxNoiDung = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownSoLuong = new System.Windows.Forms.NumericUpDown();
            this.textBoxThanhTien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerGhiGiam = new System.Windows.Forms.DateTimePicker();
            this.textBoxMaCTG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.cbbTenTS = new System.Windows.Forms.ComboBox();
            this.cbbKhoa = new System.Windows.Forms.ComboBox();
            this.cbbPhong = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNoiDung
            // 
            this.textBoxNoiDung.Location = new System.Drawing.Point(127, 166);
            this.textBoxNoiDung.Name = "textBoxNoiDung";
            this.textBoxNoiDung.Size = new System.Drawing.Size(200, 20);
            this.textBoxNoiDung.TabIndex = 101;
            this.textBoxNoiDung.TextChanged += new System.EventHandler(this.textBoxNoiDung_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "Nội dung";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 98;
            this.label8.Text = "Tên tài sản";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // numericUpDownSoLuong
            // 
            this.numericUpDownSoLuong.Location = new System.Drawing.Point(437, 220);
            this.numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            this.numericUpDownSoLuong.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownSoLuong.TabIndex = 95;
            this.numericUpDownSoLuong.ValueChanged += new System.EventHandler(this.numericUpDownSoLuong_ValueChanged);
            // 
            // textBoxThanhTien
            // 
            this.textBoxThanhTien.Enabled = false;
            this.textBoxThanhTien.Location = new System.Drawing.Point(127, 267);
            this.textBoxThanhTien.Name = "textBoxThanhTien";
            this.textBoxThanhTien.Size = new System.Drawing.Size(200, 20);
            this.textBoxThanhTien.TabIndex = 94;
            this.textBoxThanhTien.TextChanged += new System.EventHandler(this.textBoxThanhTien_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Thành tiền";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxGhiChu
            // 
            this.textBoxGhiChu.Location = new System.Drawing.Point(127, 220);
            this.textBoxGhiChu.Name = "textBoxGhiChu";
            this.textBoxGhiChu.Size = new System.Drawing.Size(200, 20);
            this.textBoxGhiChu.TabIndex = 92;
            this.textBoxGhiChu.TextChanged += new System.EventHandler(this.textBoxGhiChu_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Ghi chú";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(465, 328);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 30);
            this.buttonCancel.TabIndex = 90;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 328);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(93, 30);
            this.buttonOK.TabIndex = 89;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Ngày ghi giảm";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimePickerGhiGiam
            // 
            this.dateTimePickerGhiGiam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerGhiGiam.Location = new System.Drawing.Point(437, 167);
            this.dateTimePickerGhiGiam.Name = "dateTimePickerGhiGiam";
            this.dateTimePickerGhiGiam.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerGhiGiam.TabIndex = 85;
            this.dateTimePickerGhiGiam.ValueChanged += new System.EventHandler(this.dateTimePickerGhiGiam_ValueChanged);
            // 
            // textBoxMaCTG
            // 
            this.textBoxMaCTG.Location = new System.Drawing.Point(437, 112);
            this.textBoxMaCTG.Name = "textBoxMaCTG";
            this.textBoxMaCTG.ReadOnly = true;
            this.textBoxMaCTG.Size = new System.Drawing.Size(200, 20);
            this.textBoxMaCTG.TabIndex = 84;
            this.textBoxMaCTG.TextChanged += new System.EventHandler(this.textBoxMaCTG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Mã CT Giảm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Location = new System.Drawing.Point(348, 227);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(49, 13);
            this.labelSoLuong.TabIndex = 82;
            this.labelSoLuong.Text = "Số lượng";
            this.labelSoLuong.Click += new System.EventHandler(this.labelSoLuong_Click);
            // 
            // cbbTenTS
            // 
            this.cbbTenTS.FormattingEnabled = true;
            this.cbbTenTS.Location = new System.Drawing.Point(127, 107);
            this.cbbTenTS.Name = "cbbTenTS";
            this.cbbTenTS.Size = new System.Drawing.Size(200, 21);
            this.cbbTenTS.TabIndex = 110;
            this.cbbTenTS.SelectedIndexChanged += new System.EventHandler(this.cbbTenTS_SelectedIndexChanged);
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.FormattingEnabled = true;
            this.cbbKhoa.Location = new System.Drawing.Point(127, 47);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(200, 21);
            this.cbbKhoa.TabIndex = 112;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbbKhoa_SelectedIndexChanged);
            // 
            // cbbPhong
            // 
            this.cbbPhong.FormattingEnabled = true;
            this.cbbPhong.Location = new System.Drawing.Point(437, 51);
            this.cbbPhong.Name = "cbbPhong";
            this.cbbPhong.Size = new System.Drawing.Size(200, 21);
            this.cbbPhong.TabIndex = 113;
            this.cbbPhong.SelectedIndexChanged += new System.EventHandler(this.cbbPhong_SelectedIndexChanged);
            this.cbbPhong.SelectedValueChanged += new System.EventHandler(this.cbbPhong_SelectedValueChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(49, 54);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(32, 13);
            this.label.TabIndex = 114;
            this.label.Text = "Khoa";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Phòng";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ChungTuGiam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cbbPhong);
            this.Controls.Add(this.cbbKhoa);
            this.Controls.Add(this.cbbTenTS);
            this.Controls.Add(this.textBoxNoiDung);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownSoLuong);
            this.Controls.Add(this.textBoxThanhTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxGhiChu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerGhiGiam);
            this.Controls.Add(this.textBoxMaCTG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSoLuong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChungTuGiam";
            this.Text = "Chia Ve Khoa";
            this.Load += new System.EventHandler(this.ChungTuGiam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNoiDung;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownSoLuong;
        private System.Windows.Forms.TextBox textBoxThanhTien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerGhiGiam;
        private System.Windows.Forms.TextBox textBoxMaCTG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.ComboBox cbbTenTS;
        private System.Windows.Forms.ComboBox cbbKhoa;
        private System.Windows.Forms.ComboBox cbbPhong;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
    }
}