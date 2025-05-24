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
    public partial class anaForm : Form
    {
        SqlConnection baglanti=new SqlConnection("Data Source=LAPTOP-CUTRTV5B\\SQLEXPRESS;Initial Catalog=APARTMAN_PROJESİ;Integrated Security=True;");
        public anaForm()
        {
            InitializeComponent();
        }

      

        private void btnKisiler_Click(object sender, EventArgs e)
        {
            KisilerForm kisilerForm = new KisilerForm();
            kisilerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KisilerForm kisilerForm = new KisilerForm();
            kisilerForm.Show();
        }

        private void btnDaireler_Click(object sender, EventArgs e)
        {
            DairelerForm dairelerForm = new DairelerForm();
            dairelerForm.Show();
        }

        private void btnBloklar_Click(object sender, EventArgs e)
        {
            BloklarForm bloklarForm=new BloklarForm();
            bloklarForm.Show();
        }

        private void btnKiralamaGecmisi_Click(object sender, EventArgs e)
        {
            KiralamaGecmisiForm kiralamaGecmisiForm=new KiralamaGecmisiForm();
            kiralamaGecmisiForm.Show();
        }
    }
}







    
