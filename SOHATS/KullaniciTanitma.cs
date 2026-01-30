using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    

namespace SOHATS
{
    public partial class KullaniciTanitma: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public KullaniciTanitma()
        {
            InitializeComponent();
        }

        private void cmbKullaniciKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM kullanici WHERE kodu=@kod", baglanti);
                    komut.Parameters.AddWithValue("@kod", txtKullaniciKod.Text);
                    SqlDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        // Eğer kayıt varsa formdaki diğer alanları dolduracağız
                        MessageBox.Show("Kullanıcı bilgileri getirildi.");
                    }
                    else
                    {
                        // Kayıt yoksa  'Yeni kayıt açayım mı?' sorusu
                        DialogResult dr = MessageBox.Show("Bu kodla bir kullanıcı bulunamadı. Yeni kayıt açmak ister misiniz?", "SOHATS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            // Yeni kullanıcı ekleme butonuna veya ilgili alana odaklan
                        }
                    }
                    oku.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally { baglanti.Close(); }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // SQL tablandaki sütun isimlerine göre sorguyu kuruyoruz
                string sql = @"IF EXISTS (SELECT * FROM kullanici WHERE kodu=@p1)
                       UPDATE kullanici SET ad=@p2, soyad=@p3, sifre=@p4, yetki=@p5, evtel=@p6, ceptel=@p7, 
                       adres=@p8, unvan=@p9, isebaslama=@p10, maas=@p11, dogumyeri=@p12, annead=@p13, 
                       babaad=@p14, cinsiyet=@p15, kangrubu=@p16, medenihal=@p17, dogumtarihi=@p18, tckimlikno=@p19,username=@p20 
                       WHERE kodu=@p1
                       ELSE
                       INSERT INTO kullanici (kodu, ad, soyad, sifre, yetki, evtel, ceptel, adres, unvan, isebaslama, maas, dogumyeri, annead, babaad, cinsiyet, kangrubu, medenihal, dogumtarihi, tckimlikno,username) 
                       VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19,@p20)";

                SqlCommand komut = new SqlCommand(sql, baglanti);

                komut.Parameters.AddWithValue("@p1", txtKullaniciKod.Text);
                komut.Parameters.AddWithValue("@p2", txtAd.Text);
                komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtSifre.Text);
                komut.Parameters.AddWithValue("@p5", chkYetkili.Checked ? "True" : "False"); // Yetki durumu
                komut.Parameters.AddWithValue("@p6", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p7", txtGsm.Text);
                komut.Parameters.AddWithValue("@p8", txtAdres.Text);
                komut.Parameters.AddWithValue("@p9", cmbUnvan.Text);
                komut.Parameters.AddWithValue("@p10", dtIseBaslama.Value);
                komut.Parameters.AddWithValue("@p11", txtMaas.Text);
                komut.Parameters.AddWithValue("@p12", txtDogumYeri.Text);
                komut.Parameters.AddWithValue("@p13", txtAnneAdi.Text);
                komut.Parameters.AddWithValue("@p14", txtBabaAdi.Text);
                komut.Parameters.AddWithValue("@p15", cmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@p16", cmbKanGrubu.Text);
                komut.Parameters.AddWithValue("@p17", cmbMedeniHal.Text);
                komut.Parameters.AddWithValue("@p18", dtDogumTarihi.Value);
                komut.Parameters.AddWithValue("@p19", txtTC.Text);
                komut.Parameters.AddWithValue("@p20", txtKullaniciAdi.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı bilgileri başarıyla kaydedildi/güncellendi.");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Tüm kontrolleri temizlemek için pratik bir döngü
            foreach (Control item in this.Controls) { if (item is TextBox || item is RichTextBox) item.Text = ""; }
            chkYetkili.Checked = false;
            cmbUnvan.SelectedIndex = -1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM kullanici WHERE kodu=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKullaniciKod.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı silindi.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
