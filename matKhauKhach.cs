using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN
{
    public partial class matKhauKhach : Form
    {
        public matKhauKhach()
        {
            InitializeComponent();
            label2.Text = "";
        }
        modify mod = new modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string mail = textBox1.Text;
            if(mail.Trim()=="")
            {
                MessageBox.Show("Vui lòng nhập  đúng Email!");
            }
            else
            {
                string query = "Select * from TaiKhoanK where Gmail='"+mail+"'";
                if (mod.TaikhoanKs(query).Count!=0)
                {
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Mat Khau: " + mod.TaikhoanKs(query)[0].Matkhauk;
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Email này chưa được đăng ký!";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }
    }
}
