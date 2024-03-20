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
    public partial class danhSachTKKhach : Form
    {
        public danhSachTKKhach()
        {
            InitializeComponent();
        }
        modify mod = new modify();
        private void TTTaikhoanKhach_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewACKHACH.DataSource = mod.Table("Select * From TaiKhoanK");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Delete FROM TaiKhoanK WHERE Gmail='" + textBox1.Text + "'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Xóa thành công !");
                TTTaikhoanKhach_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void hệThốngPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongTro hm = new phongTro();
            this.Hide();
            hm.ShowDialog();
        }

        private void hệThốngThôngTinKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachKhach IK = new danhSachKhach();
            this.Hide();
            IK.ShowDialog();
        }

        private void trởVềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();
            this.Hide();
            f1.ShowDialog();
        }

        private void danhSáchTàiKhoảnChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachTKAd ttad = new danhSachTKAd();
            this.Hide();
            ttad.ShowDialog();
        }
    }
}
