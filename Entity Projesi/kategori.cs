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
    public partial class kategori : Form
    {
        public kategori()
        {
            InitializeComponent();
        }
        SatisyapEntities db = new SatisyapEntities();

        void listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_kategori
                                        select new
                                        {
                                            x.KategoriId,
                                            x.KategoriAd
                                        }).ToList();
        }
        private void kategori_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.tbl_kategori.ToList();

           listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_kategori ekle = new tbl_kategori();

            ekle.KategoriAd = textBox2.Text;
            db.tbl_kategori.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Kategori eklenmiştir.");
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sil = int.Parse(textBox1.Text);
            var kategori = db.tbl_kategori.Find(sil);
            db.tbl_kategori.Remove(kategori);
            db.SaveChanges();
            MessageBox.Show("Kategori silinmiştir");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int guncelle = int.Parse(textBox1.Text);
            var kategori = db.tbl_kategori.Find(guncelle);
            kategori.KategoriAd = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellenmiştir");
            listele();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Close();
        }
    }
}
