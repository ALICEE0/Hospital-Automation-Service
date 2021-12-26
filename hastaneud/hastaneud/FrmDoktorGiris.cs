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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmterminal frm = new frmterminal();
            frm.Show();
            this.Hide();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komutgiris = new SqlCommand("Select * From Tbl_Doktorlar Where @p1 = DoktorTC and @p2 = DoktorSifre", bgl.baglanti());
            komutgiris.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            komutgiris.Parameters.AddWithValue("@p2", textBox1.Text);
            SqlDataReader dr = komutgiris.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay dt = new FrmDoktorDetay();
                dt.doktorad = dr[1].ToString();
                dt.doktorsoyad = dr[2].ToString();
                dt.doktortc = dr[4].ToString();
                dt.doktorbrans = dr[3].ToString();
                dt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre veya TC hatalı", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
