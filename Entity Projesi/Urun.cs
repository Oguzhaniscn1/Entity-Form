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
    public partial class Urun : Form
    {
        public Urun()
        {
            InitializeComponent();
        }
        SatisyapEntities db = new SatisyapEntities();
        void listele()
        {
            var urun = (from x in db.tbl_urun
                        select new
                        {
                            x.UrunId,
                            x.UrunAd,
                            x.Marka,
                            x.Fiyat,
                            x.Stok,
                            x.tbl_kategori.KategoriAd
                        }).ToList();
            dataGridView1.DataSource = urun;
        }
        void kategorilistele()
        {
            var kategori = (from x in db.tbl_kategori
                            select new
                            {
                                x.KategoriId,
                                x.KategoriAd
                            }).ToList();
            comboBox1.ValueMember = "KategoriId";
            comboBox1.DisplayMember = "KategoriAd";
            comboBox1.DataSource = kategori;
        }
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void Urun_Load(object sender, EventArgs e)
        {
            listele();
            kategorilistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_urun ekle = new tbl_urun();
            ekle.UrunAd = textBox2.Text;
            ekle.Marka = textBox3.Text;
            ekle.Fiyat = Decimal.Parse(textBox4.Text);
            ekle.Stok = int.Parse(textBox5.Text);
            ekle.KategoriId = comboBox1.SelectedIndex + 1;
            db.tbl_urun.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla eklenmiştir");
            listele();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_urun.Find(id);
            db.tbl_urun.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi");
            listele();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = db.tbl_urun.Find(id);
            guncelle.UrunAd = textBox2.Text;
            guncelle.Marka = textBox3.Text;
            guncelle.Fiyat = Decimal.Parse(textBox4.Text);
            guncelle.Stok = int.Parse(textBox5.Text);
            guncelle.KategoriId = comboBox1.SelectedIndex + 1;
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellenmiştir.");
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
