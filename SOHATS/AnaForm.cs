using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOHATS
{
    
    public partial class AnaForm: Form
    {
        public static bool IsAdmin = false;
        public AnaForm()
        {
            InitializeComponent();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // Eğer giriş yapan kişi admin değilse Referanslar menüsünü gizle
            if (!IsAdmin)
            {
                referanslarToolStripMenuItem.Visible = false;
            }
        }

        private void poliklinikTanıtmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PoliklinikTanitma frm = new PoliklinikTanitma();
            frm.MdiParent = this; // Ana formun (gri alan) içinde hapsolmasını sağlar
            frm.Show(); // Formu görünür yapar
        }

        private void kullanıcıTanıtmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciTanitma frm = new KullaniciTanitma();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hastaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Yeni bir Hasta İşlemleri formu nesnesi oluşturuyoruz
            HastaIslemleri h = new HastaIslemleri();

            // Bu formun AnaForm (MDI) içinde açılmasını sağlıyoruz
            h.MdiParent = this;

            // Formu ekranda gösteriyoruz
            h.Show();
            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mevcut ana formu gizle
            this.Hide();

            // Giriş formunu (Form1) yeniden oluştur ve göster
            // Not: Giriş formunun adı sende farklıysa (örn: KullaniciGiris) onu yazmalısın.
            Form1 giris = new Form1();
            giris.Show();
        }

        private void cikisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
