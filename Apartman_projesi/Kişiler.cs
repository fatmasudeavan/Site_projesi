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
    public partial class KisilerForm : Form
    {
        SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-CUTRTV5B\\SQLEXPRESS;Initial Catalog=APARTMAN_PROJESİ;Integrated Security=True");
        public KisilerForm()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("INSERT INTO Kisiler (AdSoyad, Telefon, Email, Rol) VALUES (@p1, @p2, @p3, @p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p2", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p3", txtEmail.Text);
                komut.Parameters.AddWithValue("@p4", cmbRol.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kişi eklendi.");
                KisiListele();
                Temizle();
            }
        }
        private void Kisiler_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Add("Yönetici");
            cmbRol.Items.Add("Kiracı");
            KisiListele();
            Temizle();
        }

        void KisiListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kisiler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridKisiler.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Kisiler WHERE KisiID=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKisiID.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kişi silindi.");
                KisiListele();
                Temizle();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("UPDATE Kisiler SET AdSoyad=@p1, Telefon=@p2, Email=@p3, Rol=@p4 WHERE KisiID=@p5", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p2", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p3", txtEmail.Text);
                komut.Parameters.AddWithValue("@p4", cmbRol.Text);
                komut.Parameters.AddWithValue("@p5", txtKisiID.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kişi güncellendi.");
                KisiListele();
                Temizle();
            }

        }
        private void Temizle()
        {
            txtKisiID.Clear();
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            cmbRol.SelectedIndex = -1; // ComboBox sıfırlama
        }
        private void dataGridKisiler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    txtKisiID.Text = dataGridKisiler.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtAdSoyad.Text = dataGridKisiler.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtTelefon.Text = dataGridKisiler.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtEmail.Text = dataGridKisiler.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cmbRol.Text = dataGridKisiler.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
        }
    }
}
