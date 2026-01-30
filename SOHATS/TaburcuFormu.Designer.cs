namespace SOHATS
{
    partial class TaburcuFormu
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
            this.txtDosyaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.dtCikisTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtSevkTarihi = new System.Windows.Forms.DateTimePicker();
            this.cmbOdemeSekli = new System.Windows.Forms.ComboBox();
            this.btnVazgec = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dosya No:";
            // 
            // txtDosyaNo
            // 
            this.txtDosyaNo.Location = new System.Drawing.Point(199, 49);
            this.txtDosyaNo.Name = "txtDosyaNo";
            this.txtDosyaNo.Size = new System.Drawing.Size(224, 22);
            this.txtDosyaNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sevk Tarihi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Çıkış Tarihi :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ödeme Şekli :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Toplam Tutar :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.btnVazgec);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Location = new System.Drawing.Point(199, 182);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.Size = new System.Drawing.Size(224, 22);
            this.txtToplamTutar.TabIndex = 1;
            // 
            // dtCikisTarihi
            // 
            this.dtCikisTarihi.Location = new System.Drawing.Point(199, 116);
            this.dtCikisTarihi.Name = "dtCikisTarihi";
            this.dtCikisTarihi.Size = new System.Drawing.Size(224, 22);
            this.dtCikisTarihi.TabIndex = 3;
            // 
            // dtSevkTarihi
            // 
            this.dtSevkTarihi.Location = new System.Drawing.Point(199, 79);
            this.dtSevkTarihi.Name = "dtSevkTarihi";
            this.dtSevkTarihi.Size = new System.Drawing.Size(224, 22);
            this.dtSevkTarihi.TabIndex = 3;
            // 
            // cmbOdemeSekli
            // 
            this.cmbOdemeSekli.FormattingEnabled = true;
            this.cmbOdemeSekli.Location = new System.Drawing.Point(199, 151);
            this.cmbOdemeSekli.Name = "cmbOdemeSekli";
            this.cmbOdemeSekli.Size = new System.Drawing.Size(224, 24);
            this.cmbOdemeSekli.TabIndex = 4;
            // 
            // btnVazgec
            // 
            this.btnVazgec.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVazgec.Location = new System.Drawing.Point(22, 12);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(100, 50);
            this.btnVazgec.TabIndex = 0;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.UseVisualStyleBackColor = false;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnKaydet.Location = new System.Drawing.Point(350, 12);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(100, 50);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // TaburcuFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(471, 330);
            this.Controls.Add(this.cmbOdemeSekli);
            this.Controls.Add(this.dtSevkTarihi);
            this.Controls.Add(this.dtCikisTarihi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtToplamTutar);
            this.Controls.Add(this.txtDosyaNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "TaburcuFormu";
            this.Text = "SAHOTS - Taburcu";
            this.Load += new System.EventHandler(this.TaburcuFormu_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDosyaNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVazgec;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.DateTimePicker dtCikisTarihi;
        private System.Windows.Forms.DateTimePicker dtSevkTarihi;
        private System.Windows.Forms.ComboBox cmbOdemeSekli;
        private System.Windows.Forms.Button btnKaydet;
    }
}