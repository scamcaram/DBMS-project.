using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSCuoiKy
{
    public partial class FrmDangnhapThatbai : Form
    {
        public FrmDangnhapThatbai()
        {
            InitializeComponent();
        }

        int i, n;

        private void FrmDangnhapThatbai_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            i = 100;
            n = i;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Maximum = n;
            i--;
            this.lbdemlui.Text = "Thời gian còn lại " + i.ToString() + " giây";

            if (i >= 0)
            {
                progressBar1.Value = i;
            }

            if (i < 0)
            {
                this.timer1.Enabled = false;
                FrmDangNhap c = new FrmDangNhap();
                c.Show();
                this.Close();
            }
        }
    }
}
