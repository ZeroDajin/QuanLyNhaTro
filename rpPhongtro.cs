using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace DOAN
{
    public partial class rpphongtro : Form
    {
        public rpphongtro()
        {
            InitializeComponent();
        }
        modify mod = new modify();
        private void rpphongtro_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath= "..//..//Report1.rdlc";
            ReportDataSource RDS = new ReportDataSource("DataSet1");
            RDS.Value = mod.Table("Select * From TRO WHERE TinhTrang=N'Đang thuê'and Conno>0");
            reportViewer1.LocalReport.DataSources.Add(RDS);
            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void hệThốngPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phongTro pt = new phongTro();
            this.Hide();
            pt.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trangChu tc = new trangChu();
            this.Hide();
            tc.ShowDialog();
        }
    }
}
