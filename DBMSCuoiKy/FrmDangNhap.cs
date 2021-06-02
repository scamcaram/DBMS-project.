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
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        int dem;
        DataKetnoiDataContext db = new DataKetnoiDataContext();
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if ((db.Kiemtra_Dangnhap(txttaikhoan.Text, txtmatkhau.Text)) == 1)
            {
                if (db.Select_MaVaiTrotuTaiKhoan(txttaikhoan.Text) == 1)
                {
                    FrmAdmin b = new FrmAdmin();

                    DialogResult dl = MessageBox.Show("Admin đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    b.Show();
                    txttaikhoan.ResetText();
                    txtmatkhau.ResetText();
                }
                else
                {
                    FrmKhachHang a = new FrmKhachHang();
                    a.temp = txttaikhoan.Text;
                    DialogResult dl = MessageBox.Show("Chào người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    a.Show();
                    txttaikhoan.ResetText();
                    txtmatkhau.ResetText();

                }
            }
            else
            {
                dem++;
                DialogResult dl = MessageBox.Show("Đăng nhập thất bại vui lòng đăng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txttaikhoan.Focus();

                if (dem == 3)
                {
                    btndangnhap.Enabled = false;
                    FrmDangnhapThatbai c = new FrmDangnhapThatbai();
                    c.Show();
                }
            }
        }

        private void linklblDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDangKy a = new FrmDangKy();
            a.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblQuenmatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDoimk a = new FrmDoimk();
            a.Show();
        }
    }
}
