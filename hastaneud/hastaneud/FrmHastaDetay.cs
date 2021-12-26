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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        public string tc;

        private void cmbbrans_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Randevuid,RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum From Tbl_Randevular where RandevuBrans ='" + cmbbrans.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            bgl.baglanti().Close();


            

        }
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {

            string asd = label2.Text;
            lbltc.Text = tc;
            
            
            // ad soyad çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar Where HastaTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            // randevu
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTc =" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // branşları combobox'a çekmek
            SqlCommand komut2 = new SqlCommand("Select Bransad From Tbl_Brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
              
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        
        private void lnkbilgiduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frmbilgiduzenle bd = new Frmbilgiduzenle();
            bd.tcnos = lbltc.Text;
            bd.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            lblid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            cmbbrans.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            lbldoktor.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();

        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Text = "";
        }

        private void btnrandevual_Click(object sender, EventArgs e)
        {
            SqlCommand randevual = new SqlCommand("Update Tbl_Randevular Set RandevuDurum=@p1,HastaTc=@p2,HastaSikayet=@p3 Where Randevuid=@p4",bgl.baglanti());
            randevual.Parameters.AddWithValue("@p1", "True");
            randevual.Parameters.AddWithValue("@p2", lbltc.Text);
            randevual.Parameters.AddWithValue("@p3", txtsikayet.Text);
            randevual.Parameters.AddWithValue("@p4", lblid.Text);
            randevual.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Başarıyla Alındı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ad soyad çekme
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar Where HastaTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            // randevu
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTc =" + tc, bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // branşları combobox'a çekmek
            SqlCommand komut2 = new SqlCommand("Select Bransad From Tbl_Brans", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Randevuid,RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum From Tbl_Randevular where RandevuBrans ='" + cmbbrans.Text + "'", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();
        }
    }
}
