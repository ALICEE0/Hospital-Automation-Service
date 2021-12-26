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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void label2_Click(object sender, EventArgs e)
        {

        }
        public string tc;
        public string ad;
        
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            lbladsoyad.Text = ad;
            //branş data grid view doldurma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Brans",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //doktorları data grid view e çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //branşları combobox'a çekme.
            SqlCommand komutbrans = new SqlCommand("Select Bransad from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr = komutbrans.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
            
        }
        public string randevuid, randevutarih, randevusaat, randevubrans, randevudoktor, randevutc, randevudurum;
        
        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            Frmbranslar brans = new Frmbranslar();
            brans.Show();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular d = new FrmDuyurular();
            d.Show();
        }

        private void btnrandevuolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into tbl_randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", txttarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", txtsaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu kaydedildi.");
            
        
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            cmbdoktor.Text = "";
            SqlCommand komutdoktor = new SqlCommand("Select Doktorad,Doktorsoyad from Tbl_Doktorlar where Doktorbrans = @p1", bgl.baglanti());
            komutdoktor.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr = komutdoktor.ExecuteReader();
            while (dr.Read())
            {
                cmbdoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnrandevuguncelle_Click(object sender, EventArgs e)
        {
            //branş data grid view doldurma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Brans", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //doktorları data grid view e çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //branşları combobox'a çekme.
            cmbbrans.Items.Clear();
            SqlCommand komutbrans = new SqlCommand("Select Bransad from Tbl_Brans", bgl.baglanti());
            SqlDataReader dr = komutbrans.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            Frmdoktorpaneli dp = new Frmdoktorpaneli();
            dp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand duyuru = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@p1)",bgl.baglanti());
            duyuru.Parameters.AddWithValue("@p1", richTextBox1.Text);
            duyuru.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru başarıyla yayınlandı");
        }

        private void btnrandevulistesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi rl = new FrmRandevuListesi();
            rl.Show();
        }
    }
}
