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
    public partial class TaburcuFormu: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public string dosyaNoVerisi; // Diğer formdan dosya numarasını almak için
        public TaburcuFormu()
        {
            InitializeComponent();
        }

        private void TaburcuFormu_Load(object sender, EventArgs e)
        {
            txtDosyaNo.Text = dosyaNoVerisi;
            // ComboBox içine ödeme seçeneklerini ekleyelim
            cmbOdemeSekli.Items.Add("Nakit");
            cmbOdemeSekli.Items.Add("Kredi Kartı - Taksitli");
            cmbOdemeSekli.Items.Add("Kredi Kartı - Tek Çekim");
            cmbOdemeSekli.Items.Add("Senet");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // SQL'de o hastanın o sevkine ait ödeme bilgilerini güncelle
                string sql = "UPDATE cikis SET odeme = @p1, cikissaati = @p2, toplamtutar = @p5 WHERE dosyano = @p3 AND CAST(sevktarihi AS DATE) = CAST(@p4 AS DATE)";

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@p1", cmbOdemeSekli.Text);
                komut.Parameters.AddWithValue("@p2", dtCikisTarihi.Value.ToShortTimeString()); // Saati kaydeder
                komut.Parameters.AddWithValue("@p3", txtDosyaNo.Text);
                komut.Parameters.AddWithValue("@p4", dtSevkTarihi.Value.Date);
                komut.Parameters.AddWithValue("@p5", txtToplamTutar.Text);


                komut.ExecuteNonQuery();
                MessageBox.Show("Taburcu işlemi başarıyla tamamlandı.");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }
    }
}
