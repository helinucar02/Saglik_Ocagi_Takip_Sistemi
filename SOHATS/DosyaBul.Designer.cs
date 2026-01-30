namespace SOHATS
{
    partial class DosyaBul
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKriter = new System.Windows.Forms.ComboBox();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.btnBul = new System.Windows.Forms.Button();
            this.dgListe = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBul);
            this.groupBox1.Controls.Add(this.txtArama);
            this.groupBox1.Controls.Add(this.cmbKriter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Arama Kriteri";
            // 
            // cmbKriter
            // 
            this.cmbKriter.FormattingEnabled = true;
            this.cmbKriter.Items.AddRange(new object[] {
            "Hasta Adı Soyadı",
            "Kimlik No",
            "Kurum Sicil No",
            "Dosya No"});
            this.cmbKriter.Location = new System.Drawing.Point(117, 28);
            this.cmbKriter.Name = "cmbKriter";
            this.cmbKriter.Size = new System.Drawing.Size(193, 24);
            this.cmbKriter.TabIndex = 1;
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(373, 28);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(399, 22);
            this.txtArama.TabIndex = 2;
            // 
            // btnBul
            // 
            this.btnBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBul.Location = new System.Drawing.Point(788, 12);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(84, 48);
            this.btnBul.TabIndex = 5;
            this.btnBul.Text = "Bul";
            this.btnBul.UseVisualStyleBackColor = true;
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // dgListe
            // 
            this.dgListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListe.Location = new System.Drawing.Point(0, 75);
            this.dgListe.Name = "dgListe";
            this.dgListe.RowHeadersWidth = 51;
            this.dgListe.RowTemplate.Height = 24;
            this.dgListe.Size = new System.Drawing.Size(900, 375);
            this.dgListe.TabIndex = 1;
            this.dgListe.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListe_CellDoubleClick);
            // 
            // DosyaBul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.dgListe);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "DosyaBul";
            this.Text = "DosyaBul";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBul;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.ComboBox cmbKriter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgListe;
    }
}