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
namespace hastaneud
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        public string doktortc, doktorad, doktorsoyad, doktorbrans;

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBigiDuzenle dbd = new FrmDoktorBigiDuzenle();
            dbd.doktortc = lbltc.Text;
            dbd.Show();
        }

        private void btnduyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular du = new FrmDuyurular();
            du.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = doktortc;
            lbladsoyad.Text = doktorad + " " + doktorsoyad;
            label2.Text = doktorbrans;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor ='" + lbladsoyad.Text +  "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            bgl.baglanti().Close();
            
            
            
        }
    }
}
