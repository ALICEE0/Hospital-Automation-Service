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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmterminal form = new frmterminal();
            form.Show();
            this.Hide();
        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTc=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txttc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                frm.tc = txttc.Text;
                frm.ad = dr[1].ToString();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre veya TC No hatalı.", "Hata", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
                
        }

        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {
            txttc.Focus();
        }


    }
}
