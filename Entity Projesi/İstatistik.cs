using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Projesi
{
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }
        SatisyapEntities db = new SatisyapEntities();
        private void İstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tbl_kategori.Count().ToString();
            label3.Text = db.tbl_urun.Count().ToString();
            label5.Text = db.tbl_musteri.Count().ToString();
            label7.Text = db.tbl_urun.Count(x => x.KategoriId == 3).ToString();
            label15.Text = db.tbl_urun.Sum(x => x.Stok).ToString();
            label11.Text = db.tbl_urun.Max(x => x.Fiyat).ToString();
            label13.Text = db.tbl_urun.Min(x => x.Fiyat).ToString();
            label9.Text = (from x in db.tbl_musteri select x.Sehir).Distinct().Count().ToString();
            label19.Text = db.Urungetir().FirstOrDefault();
            label23.Text = db.tbl_satis.Sum(x => x.SatisFiyat).ToString();
            label21.Text = db.tbl_urun.Count(x => x.UrunAd == "Buzdolabı").ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
