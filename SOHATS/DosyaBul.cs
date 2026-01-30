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
    public partial class DosyaBul: Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        public DosyaBul()
        {
            InitializeComponent();
        }


        private void btnBul_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                // Görseldeki kriterlere göre SQL sütun eşleştirmesi
                string sutun = "ad";
                if (cmbKriter.Text == "Kimlik No") sutun = "tckimlikno";
                else if (cmbKriter.Text == "Kurum Sicil No") sutun = "kurumsicilno";
                else if (cmbKriter.Text == "Dosya No") sutun = "dosyano";

                // SQL sorgusu: İçinde geçeni bulmak için LIKE kullanılır
                string sql = $"SELECT tckimlikno, dosyano, ad, soyad, dogumyeri FROM hasta WHERE {sutun} LIKE @p1";

                SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@p1", "%" + txtArama.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgListe.DataSource = dt; // Görseldeki tabloyu doldurur
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            finally { baglanti.Close(); }
        }
        public static string secilenDosyaNo = "";

        private void dgListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgListe.CurrentRow != null)
            {
                // Dosya No'yu static değişkene atıyoruz ki ana formdan erişebilelim
                DosyaBul.secilenDosyaNo = dgListe.CurrentRow.Cells["dosyano"].Value.ToString();
                this.Close(); // Bul ekranını kapat
            }
        }
    }
}
