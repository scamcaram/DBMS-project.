using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMSCuoiKy
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
            pnlThanhChay.Top = btnCuaHang.Top;
            pnlThanhChay.Height = btnCuaHang.Height;
        }
        public string temp;
        DataKetnoiDataContext db = new DataKetnoiDataContext();
        private void btnGioHang_Click(object sender, EventArgs e)
        {
            pnlThanhChay.Top = btnGioHang.Top;
            pnlThanhChay.Height = btnGioHang.Height;
            bunifuPages1.SetPage("Giỏ Hàng");
            //Frm_Load
            //Gio hang
            dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
            lbTengh.DataBindings.Clear();
            lbTengh.DataBindings.Add("Text", dtgGioHang.DataSource, "HoTen");
            lbSPdh.DataBindings.Clear();
            lbSPdh.DataBindings.Add("Text", dtgGioHang.DataSource, "TenSP");
            txtSPdh.DataBindings.Clear();
            txtSPdh.DataBindings.Add("Text", dtgGioHang.DataSource, "TenSP");
            lbSLdh.DataBindings.Clear();
            lbSLdh.DataBindings.Add("Text", dtgGioHang.DataSource, "SL");
            lbTT.Text = (db.Select_TongtienGH(linkuser.Text)).ToString() + " VNĐ";
            //pcAnhgiohang.Image = Image.FromFile(lbAnh.Text);
        }

        private void btnCuaHang_Click(object sender, EventArgs e)
        {
            pnlThanhChay.Top = btnCuaHang.Top;
            pnlThanhChay.Height = btnCuaHang.Height;
            bunifuPages1.SetPage("Cửa Hàng");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            FrmDoimk a = new FrmDoimk();
            a.Show();
        }

        //Cua Hang

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
           dtgSanPham.DataSource = db.Timkiem_SanPham(txtTimKiem.Text);
        }

        private void linkuser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnProfile_Click(sender, e);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("User");
            //frm_Load
            dataGridView1.DataSource = db.Select_ThongtinKhachHang(temp);
            txtTenprofile.DataBindings.Clear();
            txtTenprofile.DataBindings.Add("Text", dataGridView1.DataSource, "HoTen");
            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.DataBindings.Add("Text", dataGridView1.DataSource, "NgaySinh");
            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dataGridView1.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", dataGridView1.DataSource, "DienThoai");
            //txtGioitinh.DataBindings.Add("Text", dtg1.DataSource, "GioiTinh");
            //txtAnh.DataBindings.Add("Text", dtg1.DataSource, "Anh");
            //pbAnh.Image = Image.FromFile(txtAnh.Text);
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            pnlThanhChay.Top = btnAboutUs.Top;
            pnlThanhChay.Height = btnAboutUs.Height;
            bunifuPages1.SetPage("About us");
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            btnCuaHang_Click(sender, e);
        }
        //Them gio hang ben cuu hang
        private void btnthemvaogiohang_Click(object sender, EventArgs e)
        {
            try
            {
                db.Select_ThemvaoGioHang(linkuser.Text, SP.Text);
                DialogResult dl = MessageBox.Show("Đã thêm vào giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //Frm Gio hang
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            btnThayDoi.Visible = false;
            txtSL.Enabled = true;
            txtSL.Visible = true;
            lbSLdh.Visible = false;
        }

        private void btnXoagh_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult a = MessageBox.Show(" Bạn có muốn xóa sản phẩm này? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (a == DialogResult.OK)
                {
                    db.Xoa_SanPhamGioHang(linkuser.Text, txtSPdh.Text);
                    DialogResult b = MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    dtgGioHang.Refresh();
                    dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
                    btnGioHang_Click(sender, e);
                    lbTT.Text = (db.Select_TongtienGH(linkuser.Text)).ToString() + " VNĐ";
                    lbSLdh.DataBindings.Clear();
                    lbSLdh.DataBindings.Add("Text", dtgGioHang.DataSource, "SL");
                }
            }
            catch
            { }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult a = MessageBox.Show(" Bạn có muốn thanh toán? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (a == DialogResult.OK)
                {
                    db.Them_DonHang(linkuser.Text, db.Select_TongtienGH(linkuser.Text), 1);
                    db.Them_ChitietDH(linkuser.Text);
                    DialogResult b = MessageBox.Show(" Tạo đơn hàng thành công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (b == DialogResult.OK)
                        dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
                    db.Xoa_GioHang(linkuser.Text);
                    dtgSanPham.Update();
                    dtgSanPham.Refresh();
                    lbAnhgiohang.Text = "";
                    btnGioHang_Click(sender, e);
                }
            }
            catch(Exception)
            { }
            dtgSanPham.Refresh();
            dtgSanPham.DataSource = db.Select_SanPham();
        }
        private void dtgGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int numrow;
            //numrow = e.RowIndex;
            //try
            //{
            //    lbTen.Text = dtgGioHang.Rows[numrow].Cells[0].Value.ToString();
            //    lbSP.Text = dtgGioHang.Rows[numrow].Cells[1].Value.ToString();
            //    lbSL.Text = dtgGioHang.Rows[numrow].Cells[2].Value.ToString();
            //}
            //catch { Exception ex; }
        }
        //Profile
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            txtTenprofile.ReadOnly = false;
            dtNgaySinh.Visible = true;
            txtDiachi.ReadOnly = false;
            txtSDT.ReadOnly = false;
            btnDoneprofile.Visible = true;
        }

        private void btnDoneprofile_Click(object sender, EventArgs e)
        {
            db.Update_ThongtinKhachHang(temp, txtTenprofile.Text, dtNgaySinh.Value, txtDiachi.Text, txtSDT.Text);
            DialogResult dl = MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
            {
                btnDoneprofile.Visible = false;
                dtNgaySinh.Visible = false;
                txtNgaySinh.Visible = true;
                txtTenprofile.ReadOnly = true;
                txtDiachi.ReadOnly = true;
                txtSDT.ReadOnly = true;
                // btnAnh.Visible = false;
                // txtSex.Enabled = false;
                btnProfile_Click(sender, e);
            }
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            FrmDoimk a = new FrmDoimk();
            a.temp = linkuser.Text;
            a.Show();
        }
        //Don hang
        private void btnDonhang_Click(object sender, EventArgs e)
        {
            pnlThanhChay.Top = btnDonhang.Top;
            pnlThanhChay.Height = btnDonhang.Height;
            bunifuPages1.SetPage("Đơn hàng");
            dtgThongTin.DataSource = db.Select_DonHangKhachHang(linkuser.Text);
            lbTendh.DataBindings.Clear();
            lbTendh.DataBindings.Add("Text", dtgThongTin.DataSource, "HoTen");
            lbDiaChidh.DataBindings.Clear();
            lbDiaChidh.DataBindings.Add("Text", dtgThongTin.DataSource, "DiaChi");
            lbSDTdh.DataBindings.Clear();
            lbSDTdh.DataBindings.Add("Text", dtgThongTin.DataSource, "DienThoai");
            lbNgaydh.DataBindings.Clear();
            lbNgaydh.DataBindings.Add("Text", dtgThongTin.DataSource, "NgayMua");
            lbTongTiendh.DataBindings.Clear();
            lbTongTiendh.DataBindings.Add("Text", dtgThongTin.DataSource, "TongTien");

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            //frm_load
            linkuser.Text = temp;
            dtgSanPham.DataSource = db.Select_SanPham();
            dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
            dtgSanPham.Refresh();
            dtgGioHang.Refresh();
            dtgThongTin.Refresh();
            dtgSP.Refresh();
            //dtgThongTin.
        }

        private void dtgSanPham_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int numrow;
                numrow = e.RowIndex;
                txtTimKiem.Text = dtgSanPham.Rows[numrow].Cells[1].Value.ToString();
                SP.Text = txtTimKiem.Text;
                dataGridView1.DataSource = db.Timkiem_ThongtinSanPham(txtTimKiem.Text);
                lbAnh.DataBindings.Clear();
                lbAnh.DataBindings.Add("Text", dataGridView1.DataSource, "AnhDaiDien");
                pcAnhBia.Image = Image.FromFile(lbAnh.Text);
                lbGia.Text = dtgSanPham.Rows[numrow].Cells[4].Value.ToString() + " VND";
            }
            catch (Exception)
            { }
        }

        private void pbAnhSanPham_Click(object sender, EventArgs e)
        {

        }

        private void grbSanPham_Enter(object sender, EventArgs e)
        {

        }

        private void dtgThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                txtMaDH.Text = dtgThongTin.Rows[numrow].Cells[0].Value.ToString();
                lbTendh.Text = dtgThongTin.Rows[numrow].Cells[1].Value.ToString();
                lbDiaChidh.Text = dtgThongTin.Rows[numrow].Cells[2].Value.ToString();
                lbSDTdh.Text = dtgThongTin.Rows[numrow].Cells[3].Value.ToString();
                lbNgaydh.Text = dtgThongTin.Rows[numrow].Cells[4].Value.ToString();
                lbTongTiendh.Text = dtgThongTin.Rows[numrow].Cells[5].Value.ToString();
                cbtrangthaidh.Text = dtgThongTin.Rows[numrow].Cells[6].Value.ToString();
                dtgSP.DataSource = db.Select_ThongtinDonHang(Convert.ToInt32(txtMaDH.Text));
            }
            catch(Exception)
            { }
        }
        private void pcAnhBia_Click(object sender, EventArgs e)
        {
            //frm_Load chitietsanpham
            lbMaSP.Text = txtTimKiem.Text;
            lbTaikhoan.Text = linkuser.Text;
            dataGridView1.DataSource = db.Timkiem_ThongtinSanPham(txtTimKiem.Text);
            blmasp.DataBindings.Clear();
            pbAnhSanPham.Image = Image.FromFile(lbAnh.Text);
            blmasp.DataBindings.Add("Text", dataGridView1.DataSource, "MaSP");
            lbTen.DataBindings.Clear();
            lbTen.DataBindings.Add("Text", dataGridView1.DataSource, "TenSP");
            lbHangSX.DataBindings.Clear();
            lbHangSX.DataBindings.Add("Text", dataGridView1.DataSource, "TenHang");
            lbTinhTrang.DataBindings.Clear();
            lbTinhTrang.DataBindings.Add("Text", dataGridView1.DataSource, "TenTrangThai");
            lbNCC.DataBindings.Clear();
            lbNCC.DataBindings.Add("Text", dataGridView1.DataSource, "TenNCC");
            lbDiaChi.DataBindings.Clear();
            lbDiaChi.DataBindings.Add("Text", dataGridView1.DataSource, "DiaChi");
            lbSDT.DataBindings.Clear();
            lbSDT.DataBindings.Add("Text", dataGridView1.DataSource, "DienThoai_NCC");
            lbram.DataBindings.Clear();
            lbram.DataBindings.Add("Text", dataGridView1.DataSource, "RAM");
            lbdiacung.DataBindings.Clear();
            lbdiacung.DataBindings.Add("Text", dataGridView1.DataSource, "DiaCung");
            lbvga.DataBindings.Clear();
            lbvga.DataBindings.Add("Text", dataGridView1.DataSource, "VGA");
            lbmanhinh.DataBindings.Clear();
            lbmanhinh.DataBindings.Add("Text", dataGridView1.DataSource, "ManHinh");
            lbcpu.DataBindings.Clear();
            lbcpu.DataBindings.Add("Text", dataGridView1.DataSource, "CPU");
            bunifuPages1.SetPage("Chi tiết SP");
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            db.Select_ThemvaoGioHang(linkuser.Text, txtTimKiem.Text);
            DialogResult dl = MessageBox.Show("Đã thêm vào giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Đơn hàng");
        }

        private void dtgGioHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            try
            {
                txtHT.Text = dtgGioHang.Rows[numrow].Cells[0].Value.ToString();
                lbSPdh.Text = dtgGioHang.Rows[numrow].Cells[1].Value.ToString();
                lbSLdh.Text = dtgGioHang.Rows[numrow].Cells[2].Value.ToString();
                dataGridView1.DataSource = db.Timkiem_ThongtinSanPham(lbSPdh.Text);
                lbAnhgiohang.DataBindings.Clear();
                lbAnhgiohang.DataBindings.Add("Text", dataGridView1.DataSource, "AnhDaiDien");
                pcAnhgiohang.Image = Image.FromFile(lbAnhgiohang.Text);
            }
            catch (Exception)
            { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtSL.Text) == 0)
                {
                    DialogResult c = MessageBox.Show(" Bạn có muốn xóa sản phẩm này? ", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (c == DialogResult.OK)
                    {
                        db.Xoa_SanPhamGioHang(linkuser.Text, txtSPdh.Text);
                        DialogResult b = MessageBox.Show(" Xóa thành công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (b == DialogResult.OK)
                        {
                            btnLuu.Visible = false;
                            btnThayDoi.Visible = true;
                            txtSL.Visible = false;
                            lbSLdh.Visible = true;
                        }
                    }
                    dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
                    dtgGioHang.Refresh();
                }
                else
                {
                    db.Update_SL(linkuser.Text, txtSPdh.Text, Convert.ToInt32(txtSL.Text));
                    db.Update_TienThanhToan(linkuser.Text, txtSPdh.Text);
                    DialogResult a = MessageBox.Show(" Đổi thành công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (a == DialogResult.OK)
                    {
                        btnLuu.Visible = false;
                        btnThayDoi.Visible = true;
                        txtSL.Visible = false;
                        lbSLdh.Visible = true;

                        lbTT.Text = (db.Select_TongtienGH(linkuser.Text)).ToString() + " VNĐ";
                    }
                    dtgGioHang.DataSource = db.Select_ThongtinGioHang(linkuser.Text);
                    dtgGioHang.Refresh();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnxoadonhang_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn xóa đơn hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                if ((db.Kiemtra_TrangThai(cbtrangthaidh.Text)) == 1)
                {
                    db.Xoa_DonHangCTDH(Convert.ToInt32(txtMaDH.Text));
                    db.Xoa_DonHangDH(Convert.ToInt32(txtMaDH.Text));
                    DialogResult a = MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtgSanPham.DataSource = db.Select_SanPham();
                    dtgSanPham.Update();
                    dtgSanPham.Refresh();
                }
                else if ((db.Kiemtra_TrangThai(cbtrangthaidh.Text)) == 2)
                {
                    DialogResult b = MessageBox.Show("Đơn hàng đang được xác nhận nên không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult b = MessageBox.Show("Đơn hàng đang được giao nên không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtMaDH.Refresh();
            dtgSP.DataSource = db.Select_ThongtinDonHang(Convert.ToInt32(txtMaDH.Text));
            btnDonhang_Click(sender, e);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn đăng xuất " , "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            { 
                this.Close();
                }
        }
    }
}
