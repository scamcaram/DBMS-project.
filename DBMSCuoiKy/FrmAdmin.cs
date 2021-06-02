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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        DataKetnoiDataContext db = new DataKetnoiDataContext();
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close(); //nut exit
        }
        //mo menu
        private void btnMenuExpand_Click(object sender, EventArgs e)
        {
            sidemenu.Visible = false;
            sidemenu.Width = 210;
            btnMenuExpand.Visible = false;
            sidemenuAnimate.ShowSync(sidemenu);
            LogoAnimate.Hide(pcLogomin);
        }
        //keo menu
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            LogoAnimate.ShowSync(pcLogomin);
            sidemenu.Visible = false;
            sidemenu.Width = 50;
            sidemenuAnimate.ShowSync(sidemenu);
            btnMenuExpand.Visible = true;
        }
        //Thong ke
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Thống kê");
            grbThongke.Visible = true;
           
        }
        //San Pham
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Sản phẩm");
            //load
            dtgSanpham.DataSource = db.Select_ThongtinSanPham();
            cbtrangthaisp.DisplayMember = "TenTrangThai";
            cbtrangthaisp.ValueMember = "MaTrangThai";
            cbtrangthaisp.DataSource = db.Select_Trangthai();
        }
        //Khach hang
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Khách hàng");
            //load
            dtgKhachHang.DataSource = db.Select_KhachHang();
            cbVaitro.DataSource = db.Select_Vaitro();
            cbVaitro.DisplayMember = "MaVaiTro";
            cbVaitro.ValueMember = "VaiTro";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmDangNhap a = new FrmDangNhap();
            a.Show();
            this.Close();
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            dtNgaysinh.Visible = true;
            txtSDT.Enabled = true;
            txtDiachi.Enabled = true;
            txtMatkhau.Enabled = true;
            txtTaikhoan.Enabled = true;
            txtTen.Enabled = true;
            cbGioitinh.Enabled = true;
            cbVaitro.Enabled = true;
            txtTen.Clear();
           // txtNgaySinh.Clear();
            txtTaikhoan.Clear();
            txtMatkhau.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
           // txtNgaySinh.Visible = false;
          //  btnDone_Them.Visible = true;
          //  btnDone_Sua.Visible = false;
            //btnDone_Xoa.Visible = false;
        }
        //Hoa don
        private void btnHoadon_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Hóa đơn");
            //thay Form_Load
            dtgquanlyhoadon.DataSource = db.Select_DonHang();
            cbtrangthaihd.DisplayMember = "TenTTDH";
            cbtrangthaihd.ValueMember = "MaTTDH";
            cbtrangthaihd.DataSource = db.Select_TrangThaiDH();
            lbMa.DataBindings.Clear();
            lbMa.DataBindings.Add("Text", dtgquanlyhoadon.DataSource, "HoTen");
            lbTong.DataBindings.Clear();
            lbTong.DataBindings.Add("Text", dtgquanlyhoadon.DataSource, "TongTien");
            txtMa.DataBindings.Clear();
            txtMa.DataBindings.Add("Text", dtgquanlyhoadon.DataSource, "MaDH");
            cbtrangthaihd.DataBindings.Clear();
            cbtrangthaihd.DataBindings.Add("Text", dtgquanlyhoadon.DataSource, "TenTTDH");
        }

        private void btndoitrangthai_Click(object sender, EventArgs e)
        {
            btnluu.Visible = true;
            btndoitrangthai.Visible = false;
            cbtrangthaihd.Enabled = true;
        }
        //Luu hoa don
        private void btnluu_Click(object sender, EventArgs e)
        {
            db.Update_TrangThaiDH(Convert.ToInt32(txtMa.Text), Convert.ToInt32(cbtrangthaihd.SelectedValue));
            DialogResult dl = MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
                btnluu.Visible = false;
            btndoitrangthai.Visible = true;
            cbtrangthaihd.Enabled = false;
            txtMa.Clear();
            dtgquanlyhoadon.Refresh();
            dtgquanlyhoadon.DataSource = db.Select_DonHang();
            btnHoadon_Click(sender, e);
        }
        //Xoa hoa don
        private void btnxoahd_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có muốn xóa đơn hàng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                if ((db.Kiemtra_TrangThai(cbtrangthaihd.Text)) == 1)
                {
                    db.Xoa_DonHangCTDH(Convert.ToInt32(txtMa.Text));
                    db.Xoa_DonHangDH(Convert.ToInt32(txtMa.Text));
                    txtMa.Clear();
                    dtgquanlyhoadon.DataSource = db.Select_DonHang();
                    DialogResult a = MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else if ((db.Kiemtra_TrangThai(cbtrangthaihd.Text)) == 2)
                {
                    DialogResult b = MessageBox.Show("Đơn hàng đang được xác nhận nên không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult b = MessageBox.Show("Đơn hàng đang được giao nên không thể xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //Hoa don
        private void dtgquanlyhoadon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                lbMa.Text = dtgquanlyhoadon.Rows[numrow].Cells[0].Value.ToString();
                lbTong.Text = dtgquanlyhoadon.Rows[numrow].Cells[3].Value.ToString();
                txtMa.Text = dtgquanlyhoadon.Rows[numrow].Cells[2].Value.ToString();
                cbtrangthaihd.Text = dtgquanlyhoadon.Rows[numrow].Cells[5].Value.ToString();
             }
            catch { }
        }
        //San Pham
        private void btnThemsp_Click(object sender, EventArgs e)
        {
            txttensanpham.Clear();
            txthangsanxuat.Clear();
            txtdongia.Clear();
            txtsoluong.Clear();
            txtnhacungcap.Clear();
            txtAnh.Clear();
            txttensanpham.ReadOnly = false;
            txthangsanxuat.ReadOnly = false;
            txtdongia.ReadOnly = false;
            txtsoluong.ReadOnly = false;
            txtnhacungcap.ReadOnly = false;
            txtAnh.ReadOnly = false;
            btnAnh.Visible = true;
            anhsp.Visible = true;
            cbtrangthaisp.Enabled = true;
            btnDone_Themsp.Visible = true;
            btnDone_Suasp.Visible = false;
            btnDone_Xoasp.Visible = false;
        }

        private void btnXoasp_Click(object sender, EventArgs e)
        {
            txttensanpham.ReadOnly = false;
            txthangsanxuat.ReadOnly = false;
            txtdongia.ReadOnly = false;
            txtsoluong.ReadOnly = false;
            txtnhacungcap.ReadOnly = false;
            txtAnh.ReadOnly = false;
            cbtrangthaisp.Enabled = true;
            btnAnh.Visible = true;
            anhsp.Visible = true;
            btnDone_Themsp.Visible = false;
            btnDone_Suasp.Visible = false;
            btnDone_Xoasp.Visible = true;
        }

        private void btnSuasp_Click(object sender, EventArgs e)
        {
            txttensanpham.ReadOnly = false;
            txthangsanxuat.ReadOnly = false;
            txtdongia.ReadOnly = false;
            txtsoluong.ReadOnly = false;
            txtnhacungcap.ReadOnly = false;
            txtAnh.ReadOnly = false;
            btnAnh.Visible = true;
            anhsp.Visible = true;
            cbtrangthaisp.Enabled = true;
            btnDone_Themsp.Visible = false;
            btnDone_Suasp.Visible = true;
            btnDone_Xoasp.Visible = false;
        }

        private void btnDone_Xoasp_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có chắc muốn xóa " + txttensanpham.Text + " này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                db.Xoa_SanPham(txttensanpham.Text);
                DialogResult a = MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (a == DialogResult.OK)
                    txttensanpham.ReadOnly = true;
                txthangsanxuat.ReadOnly = true;
                txtdongia.ReadOnly = true;
                txtsoluong.ReadOnly = true;
                txtnhacungcap.ReadOnly = true;
                cbtrangthaisp.Enabled = false;
                txtAnh.ReadOnly = true;
                btnDone_Xoasp.Visible = false;
                btnAnh.Visible = false;
                txtAnh.Enabled = false;
                txttensanpham.Clear();
                txthangsanxuat.Clear();
                txtdongia.Clear();
                txtsoluong.Clear();
                txtnhacungcap.Clear();
                cbtrangthaisp.ResetText();
                txtAnh.Clear();
                dtgSanpham.DataSource = db.Select_ThongtinSanPham();
                dtgSanpham.Refresh();
;            }
        }

        private void btnDone_Suasp_Click(object sender, EventArgs e)
        {
            db.Update_SanPham(txttensanpham.Text, txthangsanxuat.Text, Convert.ToInt32(txtdongia.Text), Convert.ToInt32(txtsoluong.Text), txtnhacungcap.Text, Convert.ToInt32(cbtrangthaisp.SelectedValue), txtAnh.Text);
            DialogResult dl = MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
                txttensanpham.ReadOnly = true;
            txthangsanxuat.ReadOnly = true;
            txtdongia.ReadOnly = true;
            txtsoluong.ReadOnly = true;
            txtnhacungcap.ReadOnly = true;
            cbtrangthaisp.Enabled = false;
            txtAnh.ReadOnly = true;
            btnDone_Suasp.Visible = false;
            btnAnh.Visible = false;
            txtAnh.Enabled = false;
            txttensanpham.Clear();
            txthangsanxuat.Clear();
            txtdongia.Clear();
            txtsoluong.Clear();
            txtnhacungcap.Clear();
            cbtrangthaisp.ResetText();
            txtAnh.Clear();
            dtgSanpham.DataSource = db.Select_ThongtinSanPham();
            dtgSanpham.Refresh();
        }

        private void btnDone_Themsp_Click(object sender, EventArgs e)
        {
            if (db.Kiemtra_SanPham(txttensanpham.Text) == 1)
            {
                MessageBox.Show("Sản Phẩm Nãy Đã Có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                db.Them_SanPham(txttensanpham.Text, txthangsanxuat.Text, Convert.ToInt32(txtdongia.Text), Convert.ToInt32(txtsoluong.Text), txtnhacungcap.Text, Convert.ToInt32(cbtrangthaisp.SelectedValue));
                db.Them_AnhSanPham(txttensanpham.Text, txtAnh.Text);
                DialogResult dl = MessageBox.Show("Đã thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dl == DialogResult.OK)
                    txttensanpham.ReadOnly = true; 
                txthangsanxuat.ReadOnly = true;
                txtdongia.ReadOnly = true;
                txtsoluong.ReadOnly = true;
                txtnhacungcap.ReadOnly = true;
                cbtrangthaisp.Enabled = false;
                txtAnh.ReadOnly = true;
                txttensanpham.Clear();
                txthangsanxuat.Clear();
                txtdongia.Clear();
                txtsoluong.Clear();
                txtnhacungcap.Clear();
                cbtrangthaisp.ResetText();
                txtAnh.Clear(); 
                btnDone_Themsp.Visible = false;
                btnAnh.Visible = false;
                txtAnh.Enabled = false;
            }
            dtgSanpham.DataSource = db.Select_ThongtinSanPham();
            dtgSanpham.Refresh();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = null;
                OpenFileDialog ofdImages = new OpenFileDialog();
                PictureBox objpt = new PictureBox();
                if (ofdImages.ShowDialog() == DialogResult.OK)
                {
                    filepath = ofdImages.FileName;
                }
                pbAnhSanPham.Image = Image.FromFile(filepath.ToString());
                txtAnh.Text = filepath.ToString();
            }
            catch { }
        }
        //Quanly khach hang
        private void btnThemkh_Click(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtNgaySinh.Clear();
            txtTaikhoan.Clear();
            txtMatkhau.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
            txtNgaySinh.ReadOnly = false;
            dtNgaysinh.Enabled = true;
            txtSDT.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txtMatkhau.ReadOnly = false;
            txtTaikhoan.ReadOnly = false;
            txtTen.ReadOnly = false;
            cbGioitinh.Enabled = true;
            cbVaitro.Enabled = true;
            btnDone_Themkh.Visible = true;
            btnDone_Suakh.Visible = false;
            btnDone_Xoakh.Visible = false;
        }

        private void btnXoakh_Click(object sender, EventArgs e)
        {
            txtNgaySinh.Visible = false;
            dtNgaysinh.Visible = true;
            txtSDT.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txtMatkhau.ReadOnly = false;
            txtTaikhoan.ReadOnly = false;
            txtTen.ReadOnly = false;
            cbGioitinh.Enabled = true;
            cbVaitro.Enabled = true;
            btnDone_Themkh.Visible = false;
            btnDone_Suakh.Visible = false;
            btnDone_Xoakh.Visible = true;
        }

        private void btnSuakh_Click(object sender, EventArgs e)
        {
            txtNgaySinh.Visible = false;
            dtNgaysinh.Visible = true;
            txtSDT.ReadOnly = false;
            txtDiachi.ReadOnly = false;
            txtMatkhau.ReadOnly = false;
            txtTaikhoan.ReadOnly = false;
            txtTen.ReadOnly = false;
            cbGioitinh.Enabled = true;
            cbVaitro.Enabled = true;
            btnDone_Themkh.Visible = false;
            btnDone_Suakh.Visible = true;
            btnDone_Xoakh.Visible = false;
        }

        private void btnDone_Themkh_Click(object sender, EventArgs e)
        {
            if (db.Them_KhachHang(txtTen.Text, txtTaikhoan.Text, txtMatkhau.Text, cbGioitinh.Text, dtNgaysinh.Value, txtDiachi.Text, txtSDT.Text, Convert.ToInt32(cbVaitro.Text)) == '1')
            {
                MessageBox.Show("Trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                db.Them_KhachHang(txtTen.Text, txtTaikhoan.Text, txtMatkhau.Text, cbGioitinh.Text, dtNgaysinh.Value, txtDiachi.Text, txtSDT.Text, Convert.ToInt32(cbVaitro.Text));
            DialogResult dl = MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
                txtTen.ReadOnly = true;
            txtTaikhoan.ReadOnly = true;
            txtMatkhau.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            cbGioitinh.Enabled = false;
            cbVaitro.Enabled = false;
            btnDone_Themkh.Visible = false;
            dtgKhachHang.Refresh();
            dtgKhachHang.DataSource = db.Select_KhachHang();
        }

        private void btnDone_Xoakh_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có chắc muốn xóa tài khoản " + txtTaikhoan.Text + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                db.Xoa_KhachHang(txtTaikhoan.Text);
                DialogResult a = MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (a == DialogResult.OK)
                    txtTen.Enabled = false;
                txtTaikhoan.Enabled = false;
                txtMatkhau.Enabled = false;
                txtDiachi.Enabled = false;
                txtSDT.Enabled = false;
                dtNgaysinh.Visible = false;
                cbGioitinh.Enabled = false;
                cbVaitro.Enabled = false;
                btnDone_Xoakh.Visible = false;
            }
            dtgKhachHang.DataSource = db.Select_KhachHang();
            dtgKhachHang.Refresh();
        }

        private void btnDone_Suakh_Click(object sender, EventArgs e)
        {
            db.Update_KhachHang(txtTen.Text, txtTaikhoan.Text, txtMatkhau.Text, cbGioitinh.Text, dtNgaysinh.Value, txtDiachi.Text, txtSDT.Text, Convert.ToInt32(cbVaitro.Text));
            DialogResult dl = MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
                txtTen.Enabled = false;
            txtTaikhoan.Enabled = false;
            txtMatkhau.Enabled = false;
            //txtNgaySinh.Visible = true;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            dtNgaysinh.Visible = false;
            cbGioitinh.Enabled = false;
            cbVaitro.Enabled = false;
            btnDone_Suakh.Visible = false;
            dtgKhachHang.DataSource = db.Select_KhachHang();
            dtgKhachHang.Refresh();
        }

        private void dtgKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                txtTen.Text = dtgKhachHang.Rows[numrow].Cells[0].Value.ToString();
                txtTaikhoan.Text = dtgKhachHang.Rows[numrow].Cells[1].Value.ToString();
                txtMatkhau.Text = dtgKhachHang.Rows[numrow].Cells[2].Value.ToString();
                txtDiachi.Text = dtgKhachHang.Rows[numrow].Cells[5].Value.ToString();
                txtNgaySinh.Text = dtgKhachHang.Rows[numrow].Cells[4].Value.ToString();
                txtSDT.Text = dtgKhachHang.Rows[numrow].Cells[6].Value.ToString();
                cbGioitinh.Text = dtgKhachHang.Rows[numrow].Cells[3].Value.ToString();
                cbVaitro.Text = dtgKhachHang.Rows[numrow].Cells[7].Value.ToString();
            }
            catch { }
        }
        private void dtgSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int numrow;
                numrow = e.RowIndex;
                txttensanpham.Text = dtgSanpham.Rows[numrow].Cells[1].Value.ToString();
                txthangsanxuat.Text = dtgSanpham.Rows[numrow].Cells[3].Value.ToString();
                txtdongia.Text = dtgSanpham.Rows[numrow].Cells[4].Value.ToString();
                txtsoluong.Text = dtgSanpham.Rows[numrow].Cells[5].Value.ToString();
                txtnhacungcap.Text = dtgSanpham.Rows[numrow].Cells[7].Value.ToString();
                cbtrangthaisp.Text = dtgSanpham.Rows[numrow].Cells[9].Value.ToString();
                txtAnh.Text = dtgSanpham.Rows[numrow].Cells[10].Value.ToString();
                pbAnhSanPham.Image = Image.FromFile(txtAnh.Text);
            }
            catch { }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
