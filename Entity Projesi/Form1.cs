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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategori kt=new kategori();
            kt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musteri m = new musteri();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Urun ur = new Urun();
            ur.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Satis sat = new Satis();
            sat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            İstatistik fr = new İstatistik();
            fr.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Hoşgeldiniz "+Login.mesaj.ToString();
        }
    }
}
