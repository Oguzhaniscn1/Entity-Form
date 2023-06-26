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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string mesaj;
        DataSet1TableAdapters.tbl_loginTableAdapter ds = new DataSet1TableAdapters.tbl_loginTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            var kontrol = ds.Login(textBox1.Text, textBox2.Text);
            if(kontrol != null)
            {
                Form1 fr = new Form1();
                mesaj = textBox1.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz hatalı.Lütfen Kontrol ediniz");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
