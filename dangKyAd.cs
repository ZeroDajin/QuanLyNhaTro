using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DOAN
{
    public partial class dangKyAd : Form
    {
        public dangKyAd()
        {
            InitializeComponent();
        }
        public bool checkad(string ac)
        {
            return Regex.IsMatch(ac,"^[a-zA-Z0-9]{6,24}$");

        }
        public bool checkEmail(string em)
        {
            return Regex.IsMatch(em, "^[a-zA-Z0-9_.]{3,20}@gmail.com|@yahoo.com(.vn|)$");
        }
        modify mod = new modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string newtk =textBox1.Text;
            if(!checkad(newtk))
            {
                MessageBox.Show("tài khoản dài 6-24,gồm ký tự chữ và số");
                return;
            }
        
            
                
            string newmk = textBox2.Text;
            if (!checkad(newmk))
            {
                MessageBox.Show("mật khẩu dài 6-24,gồm ký tự chữ và số");
                return;
            }
            string renewmk = textBox3.Text;
            if (!checkad(renewmk))
            {
                MessageBox.Show("xác nhận mật khẩu dài 6-24,gồm ký tự chữ và số");
                return;
            }
            string email = textBox4.Text;
            if(!checkEmail(email))
            {
                MessageBox.Show("xin viết đúng dịnh dạng email");
                return;
            }
            if(mod.TaikhoanADs("Select * from TaikhoanAD where Email = '"+email+"'").Count!=0)
            {
                MessageBox.Show("Email đã tồn tại!");
            }
            else
            {
                try
                {
                    string query = "Insert into TaikhoanAD values('" + newtk + "','" + newmk + "','" + email + "')";
                    mod.Command(query);
                    MessageBox.Show("Đăng kí thành công");
                }
                catch
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");

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
