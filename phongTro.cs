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
    public partial class phongTro : Form
    {
        public phongTro()
        {
            InitializeComponent();
        }
        public bool checknum(string num) 
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
        QLTRO tro;
        modify mod = new modify();
        private void getvaluetextboxes()
        {
                string idp = textBox1.Text;
                string cmnd = textBox2.Text;
                string tinhtrang = comboBox1.Text;
                double tc = double.Parse(textBox4.Text);
                double tt = double.Parse(textBox5.Text);
                double tdn =double.Parse(textBox6.Text);
                tro = new QLTRO(idp, cmnd, tinhtrang, tc, tt, tdn);
        }
        private void Home_Load(object sender, EventArgs e)
        {
            textBox2.Text = "000000000";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            comboBox1.SelectedIndex = 1;
            try
            {
                dataGridView1.DataSource = mod.Table("Select * from TRO "); 
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

            getvaluetextboxes();
            if (textBox1.Text != "")
            {
                if (checknum(textBox2.Text))
                {
                    try
                    {
                        string query = "INSERT INTO TRO VALUES(N'" + tro.Idp + "',N'" + tro.Cmnd + "',N'" + tro.Tinhtrang + "'," + tro.Tc + "," + tro.Tt + "," + tro.Tdn + "," + tro.conno() + ")";
                        mod.Command(query);
                        MessageBox.Show("Thêm thành công!");
                        Home_Load(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("CMND/CCCD nhập sai, xin vui lòng nhập lại", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("chưa nhập ID phòng, xin vui lòng nhập lại", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getvaluetextboxes();
            string query = "UPDATE TRO SET CMND=N'"+tro.Cmnd+"',Tinhtrang=N'"+tro.Tinhtrang+"',Tiencoc="+tro.Tc+",TienThue="+tro.Tt+",Tiendn="+tro.Tdn +",Conno="+tro.conno()+"";
            query += "WHERE ID='" + tro.Idp + "'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Sửa thành công!");
                Home_Load(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            string query = "DELETE FROM TRO WHERE ID=N'"+textBox1.Text+"'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Xóa thành công!");
                Home_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }

        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            unlock();
        }
        private void lockdown()
        {
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            groupBox2.Enabled = false;
        }
        private void unlock()
        {
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            groupBox2.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            getvaluetextboxes();
            if (textBox1.Text=="")
            {
                MessageBox.Show("Vui lòng nhập ID cần tìm!");
                Home_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM TRO WHERE ID=N'" + tro.Idp + "'";
                dataGridView1.DataSource = mod.Table(query);
                lockdown();
            }
        }
        bool checkisnumber(string c)
        {
            int value;
            bool isnumber = int.TryParse(c, out value);
            if (isnumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void hệThốngQuảnLýPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachKhach IK = new danhSachKhach();
            this.Hide();
            IK.ShowDialog();
        }

        private void hệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();
            this.Hide();
            f1.ShowDialog();
        }
        private void tạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dangKyAd f3 = new dangKyAd();
            this.Hide();
            f3.ShowDialog();
        }

        private void quênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matKhauAd f4 = new matKhauAd();
            this.Hide();
            f4.ShowDialog();
        }

        private void tàiKhoảnADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachTKAd ttad = new danhSachTKAd();
            this.Hide();
            ttad.ShowDialog();
        }

        private void tàiKhoảnKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachTKKhach ttkhach = new danhSachTKKhach();
            this.Hide();
            ttkhach.ShowDialog();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpphongtro rpt = new rpphongtro();
            this.Hide();
            rpt.ShowDialog();
        }
    }
}
