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
    public partial class khachNo : Form
    {
        public khachNo()
        {
            InitializeComponent();
        }


        
        modify mod = new modify();
        private void HomeK_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = mod.Table("Select TRO.ID,Customer.name,TRO.Tienthue,TRO.Tiendn,TRO.Conno from TRO inner join Customer on TRO.CMND=Customer.CMND WHERE TRO.Conno>0");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu f1 = new trangChu();

            this.Hide();
            f1.ShowDialog();
            this.Close();


        }
    }
}
