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

namespace Apartman_projesi
{
    public partial class DairelerForm : Form
    {
        SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-CUTRTV5B\\SQLEXPRESS;Initial Catalog=APARTMAN_PROJESİ;Integrated Security=True;");
        public DairelerForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                {
                    txtDaireID.Text = dataGridView1.CurrentRow.Cells["DaireID"].Value.ToString();
                    txtDaireNo.Text = dataGridView1.CurrentRow.Cells["DaireNo"].Value.ToString();
                    txtKatNo.Text = dataGridView1.CurrentRow.Cells["KatNo"].Value.ToString();
                    cmbDurum.Text = dataGridView1.CurrentRow.Cells["Durum"].Value.ToString();
                    cmbKisi.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
                    cmbBlok.Text = dataGridView1.CurrentRow.Cells["BlokAdi"].Value.ToString();
                }
            }
        }
        void BloklariYukle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT BlokID, BlokAdi FROM Bloklar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbBlok.DataSource = dt;
            cmbBlok.DisplayMember = "BlokAdi";
            cmbBlok.ValueMember = "BlokID";
            cmbBlok.SelectedIndex = -1;
        }
        private void DairelerForm_Load(object sender, EventArgs e)
        {
            DaireleriListele();
            DurumlariYukle();
            KisileriYukle();
            BloklariYukle();
        }
        void DurumlariYukle()
        {
            cmbDurum.Items.AddRange(new string[] { "Bos", "Kirada", "Sahip Oturuyor" });
        }


        void DaireleriListele()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT Daireler.*, Kisiler.AdSoyad, Bloklar.BlokAdi " +
                "FROM Daireler " +
                "LEFT JOIN Kisiler ON Daireler.KisiID = Kisiler.KisiID " +
                "JOIN Bloklar ON Daireler.BlokID = Bloklar.BlokID", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void KisileriYukle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT KisiID, AdSoyad FROM Kisiler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKisi.DataSource = dt;
            cmbKisi.DisplayMember = "AdSoyad";
            cmbKisi.ValueMember = "KisiID";
            cmbKisi.SelectedIndex = -1;
        }

        void Temizle()
        {
            txtDaireID.Clear();
            txtDaireNo.Clear();
            txtKatNo.Clear();
            cmbDurum.SelectedIndex = -1;
            cmbKisi.SelectedIndex = -1;
            cmbBlok.SelectedIndex = -1;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(
                        "INSERT INTO Daireler (DaireNo, KatNo, Durum, KisiID, BlokID) " +
                        "VALUES (@no, @kat, @durum, @kisi, @blok)", baglanti);

                    komut.Parameters.AddWithValue("@no", txtDaireNo.Text);
                    komut.Parameters.AddWithValue("@kat", txtKatNo.Text);
                    komut.Parameters.AddWithValue("@durum", cmbDurum.Text);
                    komut.Parameters.AddWithValue("@kisi", cmbKisi.SelectedValue ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@blok", cmbBlok.SelectedValue);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Daire kaydedildi.");
                    DaireleriListele();
                    Temizle();
                }
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            {
                {
                    if (txtDaireID.Text != "")
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("DELETE FROM Daireler WHERE DaireID = @id", baglanti);
                        komut.Parameters.AddWithValue("@id", txtDaireID.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Daire silindi.");
                        DaireleriListele();
                        Temizle();
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(
                        "UPDATE Daireler SET DaireNo = @no, KatNo = @kat, Durum = @durum, KisiID = @kisi, BlokID = @blok " +
                        "WHERE DaireID = @id", baglanti);

                    komut.Parameters.AddWithValue("@no", txtDaireNo.Text);
                    komut.Parameters.AddWithValue("@kat", txtKatNo.Text);
                    komut.Parameters.AddWithValue("@durum", cmbDurum.Text);
                    komut.Parameters.AddWithValue("@kisi", cmbKisi.SelectedValue ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@blok", cmbBlok.SelectedValue);
                    komut.Parameters.AddWithValue("@id", txtDaireID.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Daire güncellendi.");
                    DaireleriListele();
                    Temizle();
                }
            }
        }
    }
}
