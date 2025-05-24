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

namespace Apartman_projesi
{
    public partial class BloklarForm : Form
    {
        SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-CUTRTV5B\\SQLEXPRESS;Initial Catalog=APARTMAN_PROJESİ;Integrated Security=True;");
        public BloklarForm()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            BloklariListele();
        }
        private void BloklarForm_Load(object sender, EventArgs e)
        {
            BloklariListele();
        }
        void BloklariListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bloklar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            txtBlokID.Clear();
            txtBlokAdi.Clear();
            txtKatSayisi.Clear();
            txtDaireSayisi.Clear();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                {
                    txtBlokID.Text = dataGridView1.CurrentRow.Cells["BlokID"].Value.ToString();
                    txtBlokAdi.Text = dataGridView1.CurrentRow.Cells["BlokAdi"].Value.ToString();
                    txtKatSayisi.Text = dataGridView1.CurrentRow.Cells["KatSayisi"].Value.ToString();
                    txtDaireSayisi.Text = dataGridView1.CurrentRow.Cells["DaireSayisi"].Value.ToString();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("UPDATE Bloklar SET BlokAdi = @adi, KatSayisi = @kat, DaireSayisi = @daire WHERE BlokID = @id", baglanti);
                    komut.Parameters.AddWithValue("@adi", txtBlokAdi.Text);
                    komut.Parameters.AddWithValue("@kat", txtKatSayisi.Text);
                    komut.Parameters.AddWithValue("@daire", txtDaireSayisi.Text);
                    komut.Parameters.AddWithValue("@id", txtBlokID.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Blok güncellendi.");
                    BloklariListele();
                    Temizle();
                }

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            {
                {
                    if (txtBlokID.Text != "")
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("DELETE FROM Bloklar WHERE BlokID = @id", baglanti);
                        komut.Parameters.AddWithValue("@id", txtBlokID.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Blok silindi.");
                        BloklariListele();
                        Temizle();
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("INSERT INTO Bloklar (BlokAdi, KatSayisi, DaireSayisi) VALUES (@adi, @kat, @daire)", baglanti);
                    komut.Parameters.AddWithValue("@adi", txtBlokAdi.Text);
                    komut.Parameters.AddWithValue("@kat", txtKatSayisi.Text);
                    komut.Parameters.AddWithValue("@daire", txtDaireSayisi.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Blok kaydedildi.");
                    BloklariListele();
                    Temizle();
                }
            }
        }
    }
}
