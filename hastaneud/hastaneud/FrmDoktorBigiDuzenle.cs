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
    public partial class FrmDoktorBigiDuzenle : Form
    {
        public FrmDoktorBigiDuzenle()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtad.Text);
            guncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("@p3", cmbbrans.Text);
            guncelle.Parameters.AddWithValue("@p4", txtsifre.Text);
            guncelle.Parameters.AddWithValue("@p5", label5.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
        public string doktortc;
        private void FrmDoktorBigiDuzenle_Load(object sender, EventArgs e)
        {
            label5.Text = doktortc;
            SqlCommand brans = new SqlCommand("Select Bransad From Tbl_Brans", bgl.baglanti());
            SqlDataReader dr = brans.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
