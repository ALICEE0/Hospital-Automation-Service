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
    public partial class Frmdoktorpaneli : Form
    {
        public Frmdoktorpaneli()
        {
            InitializeComponent();
        }
        SQLbaglantisi bgl = new SQLbaglantisi();
        private void Frmdoktorpaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from tbl_doktorlar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlCommand komut = new SqlCommand("Select Bransad from tbl_brans", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txttc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("Update Tbl_Doktorlar Set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorTc=@p4,DoktorSifre=@p5 where DoktorTc=@p4", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtad.Text);
            guncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("@p3", cmbbrans.Text);
            guncelle.Parameters.AddWithValue("@p4", txttc.Text);
            guncelle.Parameters.AddWithValue("@p5", txtsifre.Text);
            guncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelendi");





        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            add.Parameters.AddWithValue("@p1", txtad.Text);
            add.Parameters.AddWithValue("@p2", txtsoyad.Text);
            add.Parameters.AddWithValue("@p3", cmbbrans.Text);
            add.Parameters.AddWithValue("@p4", txttc.Text);
            add.Parameters.AddWithValue("@p5", txtsifre.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor eklendi.");


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Doktorlar where doktortc = @p1",bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txttc.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor silindi");
        }
    }
}
