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
    public partial class PoliklinikTanitma: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public PoliklinikTanitma()
        {
            InitializeComponent();
        }


        private void cmbPoliklinik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT * FROM poliklinik WHERE poliklinikadi=@adi", baglanti);
                    komut.Parameters.AddWithValue("@adi", cmbPoliklinik.Text);
                    SqlDataReader oku = komut.ExecuteReader();

                    if (oku.Read())
                    {
                        // Kayıt varsa CheckBox'ı (geçerli/geçersiz) doldur 
                        chkGecerli.Checked = (oku["gecerli"].ToString() == "True");
                    }
                    else
                    {
                       // Kayıt yoksa hocanın istediği uyarıyı ver 
                        DialogResult dr = MessageBox.Show("Böyle bir kayıt bulunamadı, yeni kayıt açayım mı?", "SOHATS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            // Alttaki komponente (CheckBox'a) geçiş yap 
                            chkGecerli.Focus();
                        }
                        else
                        {
                            cmbPoliklinik.Text = ""; // Formu temizle 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
        }

        private void PoliklinikTanitma_Load(object sender, EventArgs e)
        {
            // Form açılırken poliklinik isimlerini veritabanından çekip ComboBox'a doldurur
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT poliklinikadi FROM poliklinik", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    cmbPoliklinik.Items.Add(oku["poliklinikadi"].ToString());
                }
                oku.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // SQL: Eğer bu isimde poliklinik varsa güncelliyoruz, yoksa yeni ekliyoruz
                // 'durum' sütununa CheckBox işaretli ise 'Geçerli' değilse 'Geçersiz' yazıyoruz
                string sql = @"IF EXISTS (SELECT * FROM poliklinik WHERE poliklinikadi=@p1)
                       UPDATE poliklinik SET gecerli=@p2, aciklama=@p3 WHERE poliklinikadi=@p1
                       ELSE
                       INSERT INTO poliklinik (poliklinikadi, durum, aciklama) VALUES (@p1, @p2, @p3)";

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@p1", cmbPoliklinik.Text);
                komut.Parameters.AddWithValue("@p2", chkGecerli.Checked ? "Geçerli" : "Geçersiz");
                komut.Parameters.AddWithValue("@p3", txtAciklama.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("İşlem başarıyla tamamlandı.");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu polikliniği silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                    SqlCommand komut = new SqlCommand("DELETE FROM poliklinik WHERE poliklinikadi=@p1", baglanti);
                    komut.Parameters.AddWithValue("@p1", cmbPoliklinik.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Poliklinik silindi.");

                    // Temizlik
                    cmbPoliklinik.Text = "";
                    txtAciklama.Clear();
                    chkGecerli.Checked = false;
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                finally { baglanti.Close(); }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM poliklinik WHERE poliklinikadi=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", cmbPoliklinik.Text);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    txtAciklama.Text = oku["aciklama"].ToString();
                    chkGecerli.Checked = (oku["durum"].ToString() == "Geçerli");
                }
                oku.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }
    }
}
