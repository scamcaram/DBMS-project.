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
    public partial class FrmDoimk : Form
    {
        public FrmDoimk()
        {
            InitializeComponent();
        }
        public string temp;
        
        DataKetnoiDataContext db = new DataKetnoiDataContext();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhcong_Click(object sender, EventArgs e)

        { 
            if (db.Kiemtra_Matkhau(temp, txtmatkhaucu.Text) == 1)
            {
                db.Update_Matkhau(temp, txtmatkhaucu.Text, txtmatkhaumoi.Text);
                DialogResult a = MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (a == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    //
                }
            }
            else
            {
                DialogResult a = MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void FrmDoimk_Load(object sender, EventArgs e)
        {
            txtten.Text = temp;
        }
    }
}
