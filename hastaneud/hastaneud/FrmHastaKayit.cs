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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        // metot altında aşağıdaki kodlar çalışmadığı için metot dışına yazılmışlardır örnek oluşturması için yorum satırı olarak bırakıldılar.
        //private void stringcontrol()
        //{
        //    if(txtad.Text=="")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else if (txtcinsiyet.Text == "")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else if (txtsifre.Text == "")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else if (txtsoyad.Text == "")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else if (txttckimlik.Text == "")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else if (txttelefon.Text == "")
        //    {
        //        MessageBox.Show("Hatalı veri girişi");
        //    }
        //    else
        //    {
        //        stringcontrol();
        //        SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
        //        komut.Parameters.AddWithValue("@p1", txtad.Text);
        //        komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
        //        komut.Parameters.AddWithValue("@p3", txttckimlik.Text);
        //        komut.Parameters.AddWithValue("@p4", txttelefon.Text);
        //        komut.Parameters.AddWithValue("@p5", txtsifre.Text);
        //        komut.Parameters.AddWithValue("@p6", txtcinsiyet.Text);
        //        komut.ExecuteNonQuery();

        //        bgl.baglanti().Close();
        //        MessageBox.Show("Kaydınız başarıyla tamamlandı giriş yapabilirsiniz. Şifreniz: " + txtsifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //    }
        //}
        private void button1_Click(object sender, EventArgs e)
        {
        if (txtad.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else if (txtcinsiyet.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else if (txtsifre.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else if (txtsoyad.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else if (txttckimlik.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else if (txttelefon.Text == "")
        {
            MessageBox.Show("Hatalı veri girişi");
        }
        else
        {
            
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", txttckimlik.Text);
            komut.Parameters.AddWithValue("@p4", txttelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", txtcinsiyet.Text);
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız başarıyla tamamlandı giriş yapabilirsiniz. Şifreniz: " + txtsifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

    }
    }
}
