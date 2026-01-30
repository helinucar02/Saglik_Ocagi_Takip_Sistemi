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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.\\SQLEXPRESS02;Initial Catalog=SOHATS;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // Formun ekranın ortasında açılmasını sağlar
            this.StartPosition = FormStartPosition.CenterScreen;

            // Şifre karakterini gizler 
            txtSifre.PasswordChar = '*';
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKullanici.Text = "";
            txtSifre.Text = "";
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM kullanici WHERE username=@user AND sifre=@pass", baglanti);
                komut.Parameters.AddWithValue("@user", txtKullanici.Text);
                komut.Parameters.AddWithValue("@pass", txtSifre.Text);

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    // Giriş başarılıysa yetkiyi kontrol edip AnaForm'a geçiyoruz
                    AnaForm.IsAdmin = Convert.ToBoolean(oku["yetki"]);

                    AnaForm ana = new AnaForm();
                    ana.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yanlış kullanıcı adı ve/veya şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
