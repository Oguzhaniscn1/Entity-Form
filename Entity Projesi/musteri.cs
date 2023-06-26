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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }

        SatisyapEntities db = new SatisyapEntities();
        void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_musteri
                                        select new
                                        {
                                            x.MusteriId,
                                            x.MusteriAdSoyad,
                                            x.MusteriMeslek,
                                            x.TC,
                                            x.Adres,
                                            x.Yas,
                                            x.Sehir,
                                            x.TelNo
                                        }).ToList();
        }
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            
        }
        private void musteri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_musteri ekle = new tbl_musteri();
            ekle.MusteriAdSoyad = textBox2.Text;
            ekle.MusteriMeslek = textBox3.Text;
            ekle.TC = textBox4.Text;
            ekle.Adres = textBox5.Text;
            ekle.Yas = int.Parse(textBox6.Text);
            ekle.Sehir = textBox7.Text;
            ekle.TelNo = textBox8.Text;
            db.tbl_musteri.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Yeni müşteri eklenmiştir.");
            listele();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sil = int.Parse(textBox1.Text);
            var bul = db.tbl_musteri.Find(sil);
            db.tbl_musteri.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Müşteri silindi");
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
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_musteri.Find(id);
            bul.MusteriAdSoyad = textBox2.Text;
            bul.MusteriMeslek = textBox3.Text;
            bul.TC = textBox4.Text;
            bul.Adres = textBox5.Text;
            bul.Yas = int.Parse(textBox6.Text);
            bul.Sehir = textBox7.Text;
            bul.TelNo = textBox8.Text;
            db.SaveChanges();
            MessageBox.Show("Müşteri güncelleme işlemi gerçekleşti");
            listele();
            temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Close();
        }
    }
}
