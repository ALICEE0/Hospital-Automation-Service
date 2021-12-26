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
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void deneme_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar  where hastatc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", label4.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label1.Text = dr[0].ToString();
                label2.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
            
        }
    }
}
