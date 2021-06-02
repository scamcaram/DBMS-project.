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
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }
        DataKetnoiDataContext db = new DataKetnoiDataContext();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step2");

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step1");
            cb1.Checked = false;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step3");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step2");
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
           //if(DK thanh cong)
            bunifuPages1.SetPage("Step4");
            cb4.Checked = cb4.Enabled = true;
            bunifuPages1.SetPage("Step4");
            pcSuccess.Visible = true;
            pcThatbai.Visible = false;
            lbThanhcong.Visible = true;
            lbThatbai.Visible = false;
            btnThanhcong.Visible = true;
            btnThatbai.Visible = false;
            //else
            //bunifuPages1.SetPage("Step4");
            //pcSuccess.Visible = false;
            //pcThatbai.Visible = true;
            //lbThanhcong.Visible = false;
            //lbThatbai.Visible = true;
            //btnThanhcong.Visible = false;
            //btnThatbai.Visible = true;

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step3");
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            //submit
            this.Close();
        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (bunifuPages1.SelectedIndex)
            {
                case 1:
                    cb1.Checked = cb1.Enabled = true;
                    break;
                case 2:
                    cb2.Checked = cb2.Enabled = true;
                    break;
              
            }
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            //bunifuPages1.SetPage("Step4");
            //pcSuccess.Visible = false;
            //pcThatbai.Visible = true;
            //lbThanhcong.Visible = false;
            //lbThatbai.Visible = true;
            //btnThanhcong.Visible = false;
            //btnThatbai.Visible = true;
        }

        private void btnThatbai_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step1");
            cb1.Checked = false;
            cb2.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   FrmThongbao.
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtXacNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNext3_Click_1(object sender, EventArgs e)
        {
            if (db.Kiemtra_Dangky(txttaikhoan.Text, txtsdt.Text) == -1) //Không thành công
            {
                DialogResult dl = MessageBox.Show("Trùng tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bunifuPages1.SetPage("Step4");
                pcSuccess.Visible = false;
                pcThatbai.Visible = true;
                lbThanhcong.Visible = false;
                lbThatbai.Visible = true;
                btnThanhcong.Visible = false;
                btnThatbai.Visible = true;
            }
            else if (db.Kiemtra_Dangky(txttaikhoan.Text, txtsdt.Text) == -2)    //Không thành công
            {
               // errorProvider1.SetError(txtsdt, "Lỗi");
                bunifuPages1.SetPage("Step4");
                pcSuccess.Visible = false;
                pcThatbai.Visible = true;
                lbThanhcong.Visible = false;
                lbThatbai.Visible = true;
                btnThanhcong.Visible = false;
                btnThatbai.Visible = true;
                DialogResult dl = MessageBox.Show("Trùng số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else //thành công
            {
                bunifuPages1.SetPage("Step4");
                cb4.Checked = cb4.Enabled = true;
                bunifuPages1.SetPage("Step4");
                pcSuccess.Visible = true;
                pcThatbai.Visible = false;
                lbThanhcong.Visible = true;
                lbThatbai.Visible = false;
                btnThanhcong.Visible = true;
                btnThatbai.Visible = false;
                db.Dangky(txthoten.Text, txttaikhoan.Text, txtmatkhau.Text, dtngaysinh.Value, txtsdt.Text, txtdiachi.Text,cbGiotinh.Text,2);
            }
        }

        private void bunifuButton3_Click_2(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Step4");
            pcSuccess.Visible = false;
            pcThatbai.Visible = true;
            lbThanhcong.Visible = false;
            lbThatbai.Visible = true;
            btnThanhcong.Visible = false;
            btnThatbai.Visible = true;
        }
    }
}
