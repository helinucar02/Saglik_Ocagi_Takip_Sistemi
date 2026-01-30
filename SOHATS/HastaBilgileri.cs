using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOHATS
{
    public partial class HastaBilgileri: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public HastaBilgileri()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // SQL: Dosya No varsa güncelle, yoksa ekle
                string sql = @"IF EXISTS (SELECT * FROM hasta WHERE dosyano=@p1)
                       UPDATE hasta SET tckimlikno=@p2, ad=@p3, soyad=@p4, dogumyeri=@p5, dogumtarihi=@p6, 
                       babaad=@p7, annead=@p8, cinsiyet=@p9, kangrubu=@p10, medenihal=@p11, adres=@p12, 
                       tel=@p13, yakintel=@p14, kurumsicilno=@p15, kurumadi=@p16 WHERE dosyano=@p1
                       ELSE
                       INSERT INTO hasta (dosyano, tckimlikno, ad, soyad, dogumyeri, dogumtarihi, babaad, annead, cinsiyet, kangrubu, medenihal, adres, tel, yakintel, kurumsicilno, kurumadi) 
                       VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16)";

                SqlCommand komut = new SqlCommand(sql, baglanti);

                komut.Parameters.AddWithValue("@p1", txtDosyaNo.Text);
                komut.Parameters.AddWithValue("@p2", txtTC.Text);
                komut.Parameters.AddWithValue("@p3", txtAd.Text);
                komut.Parameters.AddWithValue("@p4", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p5", txtDogumYeri.Text);
                komut.Parameters.AddWithValue("@p6", dtDogumTarihi.Value);
                komut.Parameters.AddWithValue("@p7", txtBabaAdi.Text);
                komut.Parameters.AddWithValue("@p8", txtAnneAdi.Text);
                komut.Parameters.AddWithValue("@p9", cmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@p10", cmbKanGrubu.Text);
                komut.Parameters.AddWithValue("@p11", cmbMedeniHal.Text);
                komut.Parameters.AddWithValue("@p12", txtAdres.Text);
                komut.Parameters.AddWithValue("@p13", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p14", txtYakinTelefon.Text);
                komut.Parameters.AddWithValue("@p15", txtKurumSicilNo.Text);
                komut.Parameters.AddWithValue("@p16", txtKurumAdi.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Hasta bilgileri başarıyla kaydedildi.");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            // Formdaki tüm TextBox ve RichTextBoxları temizle
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is RichTextBox) item.Text = "";
                if (item is ComboBox) ((ComboBox)item).SelectedIndex = -1;
            }
            txtDosyaNo.Focus();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDosyaNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaNo.Text)) return;

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM hasta WHERE dosyano=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", txtDosyaNo.Text);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    txtTC.Text = oku["tckimlikno"].ToString();
                    txtAd.Text = oku["ad"].ToString();
                    txtSoyad.Text = oku["soyad"].ToString();
                    txtDogumYeri.Text = oku["dogumyeri"].ToString();
                    dtDogumTarihi.Value = Convert.ToDateTime(oku["dogumtarihi"]);
                    txtBabaAdi.Text = oku["babaad"].ToString();
                    txtAnneAdi.Text = oku["annead"].ToString();
                    cmbCinsiyet.Text = oku["cinsiyet"].ToString();
                    cmbKanGrubu.Text = oku["kangrubu"].ToString();
                    cmbMedeniHal.Text = oku["medenihal"].ToString();
                    txtAdres.Text = oku["adres"].ToString();
                    txtTelefon.Text = oku["tel"].ToString();
                    txtYakinTelefon.Text = oku["yakintel"].ToString();
                    txtKurumSicilNo.Text = oku["kurumsicilno"].ToString();
                    txtKurumAdi.Text = oku["kurumadi"].ToString();
                }
                oku.Close();
            }
            catch (Exception ex) { MessageBox.Show("Veri getirme hatası: " + ex.Message); }
            finally { baglanti.Close(); }
        }
    }
}
