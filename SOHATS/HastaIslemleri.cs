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
using System.Drawing.Printing;

namespace SOHATS
{
    public partial class HastaIslemleri: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public HastaIslemleri()
        {
            InitializeComponent();
        }

        private void txtDosyaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    // SQL'den verileri çekiyoruz
                    SqlCommand komut = new SqlCommand("SELECT ad, soyad, kurumadi FROM hasta WHERE dosyano=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", txtDosyaNo.Text);

                    SqlDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        txtAd.Text = oku["ad"].ToString();
                        txtSoyad.Text = oku["soyad"].ToString();
                        txtKurumAdi.Text = oku["kurumadi"].ToString();

                        MessageBox.Show("Hasta Bilgileri Getirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Bu numarada bir hasta bulunamadı!");
                        // Bulunamadıysa kutuları temizle
                        txtAd.Clear();
                        txtSoyad.Clear();
                        txtKurumAdi.Clear();
                    }
                    oku.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }
        public static string secilenDosyaNo = ""; // DosyaBul.cs içinde en üstte yazmalıyız

        private void btnBul_Click(object sender, EventArgs e)
        {
            DosyaBul frm = new DosyaBul();
            frm.ShowDialog(); // Formu aç

            // Form kapandığında bir numara seçilmişse onu kutuya yaz
            if (!string.IsNullOrEmpty(DosyaBul.secilenDosyaNo))
            {
                txtDosyaNo.Text = DosyaBul.secilenDosyaNo;
                // Enter'a basılmış gibi bilgileri otomatik doldurması için Leave olayını tetikle
                txtDosyaNo_Leave(null, null);
            }
        }

        private void HastaIslemleri_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // Poliklinik tablosundaki adları çekiyoruz
                SqlCommand komut = new SqlCommand("SELECT poliklinikadi FROM poliklinik", baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    // Verileri ComboBox'a tek tek ekliyoruz
                    cmbPoliklinik.Items.Add(oku["poliklinikadi"].ToString());
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliklinikler yüklenirken hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            // Sistem saatini ve tarihini otomatik yazar
            dateTimePicker1.Value = DateTime.Now; // DateTimePicker kullanıyoruz diye
            cmbDrKodu.Items.Add("D001-Ahmet");
            cmbDrKodu.Items.Add("D002-Mehmet");
            cmbDrKodu.Items.Add("D003-Ayşe");
        }
        private void ToplamHesapla()
        {
            decimal toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Hücrelerin boş olup olmadığını kontrol ediyoruz
                if (dataGridView1.Rows[i].Cells[5].Value != null && dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    decimal miktar = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                    decimal fiyat = Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    toplam += miktar * fiyat;
                }
            }
            // Toplam tutarı gösterdiğin label'ın ismi neyse onu yaz (Örn: lblToplamTutar)
            labelToplam.Text = "Toplam Tutar : " + toplam.ToString() + " YTL";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // 1. ÖNCE TABLOYA (GRIDE) EKLEME YAPIYORUZ 
            dataGridView1.Rows.Add(
                cmbPoliklinik.Text,
                txtSiraNo.Text,
                DateTime.Now.ToShortTimeString(),
                cmbYapilanIslem.Text,
                cmbDrKodu.Text,
                numericUpDown1.Value.ToString(),
                txtBirimFiyat.Text
            );

            // 2. ŞİMDİ AYNI VERİYİ SQL'E KAYDEDİYORUZ
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                
                SqlCommand komut = new SqlCommand("INSERT INTO sevk (sevktarihi, dosyano, poliklinik, saat, yapilanislem, drkod, miktar, birimfiyat, sira, toplamtutar) VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", baglanti);

                komut.Parameters.AddWithValue("@p1", dateTimePicker1.Value); // sevktarihi
                komut.Parameters.AddWithValue("@p2", txtDosyaNo.Text);       // dosyano
                komut.Parameters.AddWithValue("@p3", cmbPoliklinik.Text);    // poliklinik
                komut.Parameters.AddWithValue("@p4", DateTime.Now.ToShortTimeString()); // saat
                komut.Parameters.AddWithValue("@p5", cmbYapilanIslem.Text);  // yapilanislem
                komut.Parameters.AddWithValue("@p6", cmbDrKodu.Text);       // drkod
                komut.Parameters.AddWithValue("@p7", numericUpDown1.Value); // miktar
                komut.Parameters.AddWithValue("@p8", txtBirimFiyat.Text);   // birimfiyat
                komut.Parameters.AddWithValue("@p9", txtSiraNo.Text);       // sira

                // Toplam tutarı hesaplayıp gönderiyoruz
                decimal t_tutar = numericUpDown1.Value * Convert.ToDecimal(txtBirimFiyat.Text);
                komut.Parameters.AddWithValue("@p10", t_tutar);             // toplamtutar

                komut.ExecuteNonQuery(); 

                // Toplamı yeniden hesapla
                ToplamHesapla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına kaydedilirken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnSecSil_Click(object sender, EventArgs e)
        {
            // Eğer tabloda seçili bir satır varsa
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçili satırı sil
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                // Satır silindiği için toplam tutarı tekrar hesaplat
                ToplamHesapla();

                MessageBox.Show("Seçilen işlem başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı en soldaki başlık kısmından seçin!");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            // Tüm metin kutularını temizler
            txtDosyaNo.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtKurumAdi.Clear();
            txtSiraNo.Clear();
            txtBirimFiyat.Clear();

            // ComboBox'lardaki seçimleri sıfırlar (Kutuları boş gösterir)
            cmbPoliklinik.SelectedIndex = -1;
            cmbYapilanIslem.SelectedIndex = -1;
            cmbDrKodu.SelectedIndex = -1;

            // DataGridView içindeki tüm satırları siler (Tabloyu boşaltır)
            dataGridView1.Rows.Clear();

            // Toplam tutar etiketini ilk haline getirir
            labelToplam.Text = "Toplam Tutar : 0 YTL";

            // Odak noktasını en başa, yani Dosya No kutusuna getirir
            txtDosyaNo.Focus();

            MessageBox.Show("Yeni kayıt için form temizlendi.");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            // Mevcut formu kapatır
            this.Close();
        }

        private void cmbPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir seçim yapıldıysa
            if (cmbPoliklinik.SelectedIndex != -1)
            {
                //test için her seçimde 1 ile 100 arası rastgele numara veriyoruz
                Random rastgele = new Random();
                txtSiraNo.Text = rastgele.Next(1, 100).ToString();
            }
        }

        private void btnTaburcu_Click(object sender, EventArgs e)
        {
            TaburcuFormu frm = new TaburcuFormu();
            frm.dosyaNoVerisi = txtDosyaNo.Text; // Dosya numarasını yeni forma aktarır
            frm.ShowDialog();
        }

        private void btnBaskiOnizleme_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // Direkt yazıcıya gönderir
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Kağıt üzerine başlık ve hasta bilgilerini yazdırıyoruz
            Font baslikFont = new Font("Arial", 14, FontStyle.Bold);
            Font icerikFont = new Font("Arial", 12);
            SolidBrush firca = new SolidBrush(Color.Black);

            e.Graphics.DrawString("SAĞLIK OCAĞI HASTA TAKİP SİSTEMİ", baslikFont, firca, 250, 50);
            e.Graphics.DrawString("Dosya No: " + txtDosyaNo.Text, icerikFont, firca, 50, 100);
            e.Graphics.DrawString("Hasta Adı: " + txtAd.Text + " " + txtSoyad.Text, icerikFont, firca, 50, 130);
            e.Graphics.DrawString("Sevk Tarihi: " + dateTimePicker1.Value.ToShortDateString(), icerikFont, firca, 50, 160);
            e.Graphics.DrawString("------------------------------------------------------------------", icerikFont, firca, 50, 190);

            // DataGridView içeriğini yazdırmak için tablo başlıkları
            e.Graphics.DrawString("Poliklinik", icerikFont, firca, 50, 220);
            e.Graphics.DrawString("Yapılan İşlem", icerikFont, firca, 250, 220);
            e.Graphics.DrawString("Fiyat", icerikFont, firca, 500, 220);

            // Tablodaki satırları döngüyle yazdırıyoruz
            int y = 250;
            foreach (DataGridViewRow satir in dataGridView1.Rows)
            {
                if (satir.Cells[0].Value != null)
                {
                    e.Graphics.DrawString(satir.Cells[0].Value.ToString(), icerikFont, firca, 50, y);
                    e.Graphics.DrawString(satir.Cells[3].Value.ToString(), icerikFont, firca, 250, y);
                    e.Graphics.DrawString(satir.Cells[6].Value.ToString() + " TL", icerikFont, firca, 500, y);
                    y += 30;
                }
            }
        }

        private void btnHastaBilgileri_Click(object sender, EventArgs e)
        {
            HastaBilgileri frm = new HastaBilgileri();
            frm.ShowDialog();
        }

        private void txtDosyaNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosyaNo.Text)) return;

            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // SQL'den hasta bilgilerini çekiyoruz
                SqlCommand komut = new SqlCommand("SELECT ad, soyad, kurumadi FROM hasta WHERE dosyano=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", txtDosyaNo.Text);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    //TextBoxlara verileri yazdırıyoruz
                    txtAd.Text = oku["ad"].ToString();
                    txtSoyad.Text = oku["soyad"].ToString();
                    txtKurumAdi.Text = oku["kurumadi"].ToString();
                }
                else
                {
                    MessageBox.Show("Bu dosya numarasına ait hasta bulunamadı!");
                }
                oku.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }
    }
}
