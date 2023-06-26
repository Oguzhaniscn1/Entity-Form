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
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        SatisyapEntities db = new SatisyapEntities();
        void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_satis
                                        select new
                                        {

                                            x.SatisId,
                                            x.tbl_urun.UrunAd,
                                            x.tbl_musteri.MusteriAdSoyad,
                                            x.SatisFiyat,
                                            x.SatisTarih,
                                            x.SatisAdet
                                        }).ToList();
        }
        private void Satis_Load(object sender, EventArgs e)
        {
          
            textBox4.Text = "1";
            listele();

            var musteri = (from x in db.tbl_musteri
                            select new
                            {
                                x.MusteriId,
                                x.MusteriAdSoyad
                            }).ToList();
            comboBox1.ValueMember = "MusteriId";
            comboBox1.DisplayMember = "MusteriAdSoyad";
            comboBox1.DataSource = musteri;

            var urun = (from x in db.tbl_urun
                           select new
                           {
                               x.UrunId,
                               x.UrunAd
                           }).ToList();
            comboBox2.ValueMember = "UrunId";
            comboBox2.DisplayMember = "UrunAd";
            comboBox2.DataSource = urun;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Adet girilmelidir");
            }
            else
            {
                tbl_satis ekle = new tbl_satis();
              
                int id = int.Parse(comboBox2.SelectedValue.ToString());
                var stok = db.tbl_urun.Where(x => x.UrunId == id).Select(y => y.Stok).FirstOrDefault();
                if (stok>=int.Parse(textBox4.Text))
                { 
            ekle.UrunId = int.Parse(comboBox2.SelectedValue.ToString());
            ekle.MusteriId = int.Parse(comboBox1.SelectedValue.ToString());
            ekle.SatisTarih = dateTimePicker1.Value;
            if (ekle.SatisTarih == null)
            {
                ekle.SatisTarih = DateTime.Now;
            }
            ekle.SatisFiyat = Decimal.Parse(label9.Text);
            ekle.SatisAdet = int.Parse(textBox4.Text);
            db.tbl_satis.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Satışı yaptın Primi kaptın :)");
            listele();
            }
                else
                {
                    MessageBox.Show("Satılabilir maksimum ürün "+stok+" adettir.");
            }
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_satis.Find(id);
            db.tbl_satis.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Satış silindi");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var guncelle = db.tbl_satis.Find(id);
            guncelle.UrunId = int.Parse(comboBox2.SelectedValue.ToString());
            guncelle.MusteriId = int.Parse(comboBox1.SelectedValue.ToString());
            guncelle.SatisTarih = dateTimePicker1.Value;
            if (guncelle.SatisTarih == null)
            {
                guncelle.SatisTarih = DateTime.Now;
            }
            guncelle.SatisFiyat = Decimal.Parse(textBox2.Text);
            guncelle.SatisAdet = int.Parse(textBox4.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla güncellenmiştir");
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
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox2.SelectedValue.ToString());
            var fiyat = db.tbl_urun.Where(x => x.UrunId == id).Select(y => y.Fiyat).FirstOrDefault();
            int adet = int.Parse(textBox4.Text);
           var ttutar = fiyat * adet;
            textBox2.Text = fiyat.ToString();
            label9.Text = ttutar.ToString();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox4.Text))
            {
                if (comboBox2.SelectedValue == null)
                {
                    comboBox2.SelectedValue = "0";
                }
                else
                {
                    int id = int.Parse(comboBox2.SelectedValue.ToString());
                    var fiyat = db.tbl_urun.Where(x => x.UrunId == id).Select(y => y.Fiyat).FirstOrDefault();
                    int adet = int.Parse(textBox4.Text);
                    var ttutar = fiyat * adet;
                    textBox2.Text = fiyat.ToString();
                    label9.Text = ttutar.ToString();
                }
            }
        }
    }
}
