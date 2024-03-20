using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DOAN
{
    public partial class danhSachKhach : Form
    {
        public danhSachKhach()
        {
            InitializeComponent();
        }
        KHACH khach;
        modify mod = new modify();
        public bool checknum(string num) // tất cả là tại thằng Minh.
        {
            if (Regex.IsMatch(num, @"^[0-9]{12}$"))
            {
                return true;
            }
            else if (Regex.IsMatch(num, @"^[0-9]{9}$"))
            {
                return true;
            }
            else
                return false;
        }
        private void getvaluestextboxK()
        {
            string cmndk = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string sex = comboBox1.Text;
            string diachi = textBox5.Text;
            
            khach=new KHACH(cmndk,name,phone,sex,diachi);
        }
        private void InfoKHACH_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            try
            {
                dataGridViewKhach.DataSource = mod.Table("Select * from Customer");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public bool checkphone(string b)
        {
            return Regex.IsMatch(b, @"^(+84|0[3|5|7|8|9])+([0-9]{8})$");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (checknum(textBox1.Text))
                    if(textBox3.Text!=""&&checkphone(textBox3.Text))
                    {
                        {
                            getvaluestextboxK();
                            string query = "INSERT INTO Customer VALUES(N'" + khach.Cmndk + "',N'" + khach.Name + "',N'" + khach.Phone + "',N'" + khach.Sex + "',N'" + khach.Diachi + "')";
                            try
                            {
                                mod.Command(query);
                                MessageBox.Show("Thêm thành công!");
                                InfoKHACH_Load(sender, e);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đúng số điện thoaị", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng CMND/CCCD", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
            }
            else
            {
                MessageBox.Show("Vui lòng nhập CMND/CCCD", "Thông báo!", MessageBoxButtons.OK);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getvaluestextboxK();
            string query = "UPDATE Customer SET phone='"+textBox3.Text+"',DiaChi=N'"+textBox5.Text+"'";
            query += "WHERE CMND=N'"+khach.Cmndk+"'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Sửa thành công!");
                InfoKHACH_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
        private void lockdown()
        {
            comboBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        private void unlock()
        {
            comboBox1.Enabled = true;
            textBox2.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            getvaluestextboxK();
            string query = "DELETE FROM Customer WHERE CMND='"+khach.Cmndk+"'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Xóa thành công");
                InfoKHACH_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void dataGridViewKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lockdown();
            try
            {
                textBox1.Text = dataGridViewKhach.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridViewKhach.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridViewKhach.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridViewKhach.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridViewKhach.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getvaluestextboxK();
            if(khach.Name=="")
            {
                MessageBox.Show("Vui lòng nhập tên khách cần tìm!");
                InfoKHACH_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM Customer WHERE name=N'"+khach.Name+"'";
                dataGridViewKhach.DataSource = mod.Table(query);
            }
        }

        private void hệThốngNhàTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongTro hm=new phongTro();
            this.Hide();
            hm.ShowDialog();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();
            this.Hide();
            f1.ShowDialog();
        }

        private void dataGridViewKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            unlock();
        }
    }
}
