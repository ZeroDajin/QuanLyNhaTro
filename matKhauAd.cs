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
    public partial class matKhauAd : Form
    {
        public matKhauAd()
        {
            InitializeComponent();
            label2.Text = "";

        }
        modify mod = new modify();

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập  đúng Email!");
            }
            else
            {
                string query = "Select * from TaikhoanAD where Email ='" + email + "'";
                if (mod.TaikhoanADs(query).Count != 0)
                {

                    label2.ForeColor = Color.Blue;
                    label2.Text = "Mat Khau: " + mod.TaikhoanADs(query)[0].Matkhauad;
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
            Form2 f2=new Form2();
            this.Hide();
            f2.ShowDialog();
        }
    }
}
