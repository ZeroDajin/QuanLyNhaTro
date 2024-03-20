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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }
        modify mod= new modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string mk = textBox2.Text;
            
            if (tk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }
            else if (mk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            else
            {
                if(comboBox1.SelectedItem.ToString()=="Chủ")
                {
                    string query = "Select * from TaiKhoanAD where tkad='" + tk + "'and mkad='" + mk + "'";
                    if (mod.TaikhoanADs(query).Count() > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        phongTro hm = new phongTro();
                        this.Hide();
                        hm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
                else if(comboBox1.SelectedItem.ToString()=="Khách")
                {
                    string query = "Select * from TaiKhoanK where tkk='" + tk + "'and mkk='" + mk + "'";
                    if (mod.TaikhoanKs(query).Count() > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        khachNo hmk = new khachNo();
                        this.Hide();
                        hmk.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại!");
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();
            this.Hide();
            f1.ShowDialog();
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Chủ")
            {
                matKhauAd mad = new matKhauAd();
                this.Hide();
                mad.ShowDialog();
            }
            else if(comboBox1.SelectedItem.ToString() == "Khách")
            {
                matKhauKhach lk = new matKhauKhach();
                this.Hide();
                lk.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dangkyK dk = new dangkyK();
            this.Hide();
            dk.ShowDialog();    
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
