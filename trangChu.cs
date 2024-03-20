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
    public partial class trangChu : Form
    {
        public trangChu()
        {
            InitializeComponent();
            
        }

        private void btnad_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
            this.Close();
            
        }

        private void btnkhach_Click(object sender, EventArgs e)
        {
            khachNo hk=new khachNo();
            this.Hide();
           
            hk.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        modify mod = new modify();
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = mod.Table("Select TRO.ID,TRO.TinhTrang,TRO.Tienthue from TRO where TRO.TinhTrang=N'Còn trống' ");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
