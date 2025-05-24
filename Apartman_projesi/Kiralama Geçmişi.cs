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
    public partial class KiralamaGecmisiForm : Form
    {
        SqlConnection baglanti= new SqlConnection("Data Source=LAPTOP-CUTRTV5B\\SQLEXPRESS;Initial Catalog=APARTMAN_PROJESİ;Integrated Security=True;");
        public KiralamaGecmisiForm()
        {
            InitializeComponent();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            {
                {
                    if (txtKayitID.Text != "")
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("DELETE FROM KiralamaGecmisi WHERE KayitID = @id", baglanti);
                        komut.Parameters.AddWithValue("@id", txtKayitID.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Kayıt silindi.");
                        KiralamaListele();
                        Temizle();
                    }
                }
            }
        }
        private void KiralamaForm_Load(object sender, EventArgs e)
        {
            KiralamaListele();
            DaireleriYukle();
            KisileriYukle();
        }

        void DaireleriYukle()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT DaireID, DaireNo FROM Daireler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDaire.DataSource = dt;
            cmbDaire.DisplayMember = "DaireNo";
            cmbDaire.ValueMember = "DaireID";
            cmbDaire.SelectedIndex = -1;
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

        void KiralamaListele()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT KiralamaGecmisi.*, Daireler.DaireNo, Kisiler.AdSoyad " +
                "FROM KiralamaGecmisi " +
                "JOIN Daireler ON KiralamaGecmisi.DaireID = Daireler.DaireID " +
                "JOIN Kisiler ON KiralamaGecmisi.KisiID = Kisiler.KisiID", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            txtKayitID.Clear();
            cmbDaire.SelectedIndex = -1;
            cmbKisi.SelectedIndex = -1;
            dtBaslangic.Value = DateTime.Today;
            dtBitis.Value = DateTime.Today;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(
                        "UPDATE KiralamaGecmisi SET DaireID = @daire, KisiID = @kisi, BaslangicTarihi = @baslangic, BitisTarihi = @bitis " +
                        "WHERE KayitID = @id", baglanti);

                    komut.Parameters.AddWithValue("@daire", cmbDaire.SelectedValue);
                    komut.Parameters.AddWithValue("@kisi", cmbKisi.SelectedValue);
                    komut.Parameters.AddWithValue("@baslangic", dtBaslangic.Value);

                    if (dtBitis.Checked)
                        komut.Parameters.AddWithValue("@bitis", dtBitis.Value);
                    else
                        komut.Parameters.AddWithValue("@bitis", DBNull.Value);

                    komut.Parameters.AddWithValue("@id", txtKayitID.Text);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kayıt güncellendi.");
                    KiralamaListele();
                    Temizle();
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            {
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(
                        "INSERT INTO KiralamaGecmisi (DaireID, KisiID, BaslangicTarihi, BitisTarihi) " +
                        "VALUES (@daire, @kisi, @baslangic, @bitis)", baglanti);

                    komut.Parameters.AddWithValue("@daire", cmbDaire.SelectedValue);
                    komut.Parameters.AddWithValue("@kisi", cmbKisi.SelectedValue);
                    komut.Parameters.AddWithValue("@baslangic", dtBaslangic.Value);

                    if (dtBitis.Checked)
                        komut.Parameters.AddWithValue("@bitis", dtBitis.Value);
                    else
                        komut.Parameters.AddWithValue("@bitis", DBNull.Value);

                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kiralama kaydedildi.");
                    KiralamaListele();
                    Temizle();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                {
                    txtKayitID.Text = dataGridView1.CurrentRow.Cells["KayitID"].Value.ToString();
                    cmbDaire.Text = dataGridView1.CurrentRow.Cells["DaireNo"].Value.ToString();
                    cmbKisi.Text = dataGridView1.CurrentRow.Cells["AdSoyad"].Value.ToString();
                    dtBaslangic.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BaslangicTarihi"].Value);

                    if (dataGridView1.CurrentRow.Cells["BitisTarihi"].Value != DBNull.Value)
                    {
                        dtBitis.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BitisTarihi"].Value);
                        dtBitis.Checked = true;
                    }
                    else
                    {
                        dtBitis.Checked = false;
                    }
                }
            }
        }
    }
}
