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
    public partial class Frmbilgiduzenle : Form
    {
        public string tcnos;
        public Frmbilgiduzenle()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void Frmbilgiduzenle_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnos;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                txttelefon.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                txtcinsiyet.Text = dr[6].ToString();
            }
            
            bgl.baglanti().Close();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar Set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p4,HastaSifre=@p5,HastaCinsiyet=@p6 where HastaTC=@p7", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtad.Text);
            komut2.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p4", txttelefon.Text);
            komut2.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut2.Parameters.AddWithValue("@p7", lbltc.Text);
            komut2.Parameters.AddWithValue("@p6", txtcinsiyet.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz başarıyla güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        

        }
    }
}
