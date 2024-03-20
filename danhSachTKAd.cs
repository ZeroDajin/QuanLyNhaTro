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
    public partial class danhSachTKAd : Form
    {
        public danhSachTKAd()
        {
            InitializeComponent();
        }
        modify mod = new modify();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TTtaikhoanAD_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewAD.DataSource = mod.Table("Select * from TaiKhoanAD ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete FROM TaikhoanAD WHERE Email='"+textBox1.Text+"'";
            try
            {
                mod.Command(query);
                MessageBox.Show("Xóa thành công!");
                TTtaikhoanAD_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void trởVềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();
            this.Hide();
            f1.ShowDialog(); 
        }

        private void hệThốngPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongTro hm = new phongTro();
            this.Hide();
            hm.ShowDialog();
        }

        private void hệThôngTinKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachKhach IK = new danhSachKhach();
            this.Hide();
            IK.ShowDialog();
        }

        private void danhSáchTàiKhoảnKháchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            danhSachTKKhach ttkhach = new danhSachTKKhach();
            this.Hide();
            ttkhach.ShowDialog();
        }
    }
}
