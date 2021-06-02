-- STORED PROCEDURE
go
--1 Stored Procedure dang ky
create proc Dangky(
    @ten nvarchar (50),
    @taikhoan nvarchar(50),
	@matkhau nvarchar(50),
    @ngaysinh datetime,
	@SDT varchar(12),
	@diachi nvarchar(50),
	@gioitinh nvarchar(10),
	@vaitro int)
AS
begin
    begin
        insert into KhachHang(HoTen,Email,MatKhau,NgaySinh,DienThoai,DiaChi,GioiTinh,MaVaiTro)
        values (@ten,@taikhoan,@matKhau,@ngaysinh,@SDT,@diachi,@gioitinh,@vaitro)
        select SCOPE_IDENTITY()  
    end
end
go
--2 Stored Procedure	lay tat ca san pham
create proc Select_SanPham
as
begin
	select MaSP,TenSP, SanPham.HangSX,TenHang,DonGia,SoLuong from SanPham,HangSanXuat where SanPham.HangSX = HangSanXuat.HangSX
end
go
--3 Stored Procedure xoa khach hang
create proc Xoa_KhachHang(@taikhoan nvarchar(50))
as
begin
	delete from KhachHang where @taikhoan = Email
end
go
--4 Stored Procedure them khach hang
create proc Them_KhachHang(@ten nvarchar(50), @taikhoan nvarchar(50), @matkhau nvarchar(50), @gioitinh nvarchar(10), @ngaysinh datetime, @diachi nvarchar(100),@sdt nvarchar(15),@vaitro int)
as
begin
	if exists (select Email from KhachHang where Email = @taikhoan)
		print N'1'
	else
		insert into KhachHang(Email) values (@taikhoan)
		update KhachHang set HoTen = @ten, Email = @taikhoan, MatKhau = @matkhau, GioiTinh = @gioitinh, NgaySinh = @ngaysinh, DiaChi = @diachi, DienThoai = @sdt, MaVaiTro = @vaitro where MaKH = ident_current('KhachHang')
end
go
--5 Stored Procedure cap nhat khach hang
create proc Update_KhachHang(@ten nvarchar(50), @taikhoan nvarchar(50), @matkhau nvarchar(50), @gioitinh nvarchar(10), @ngaysinh datetime, @diachi nvarchar(100),@sdt nvarchar(15), @vaitro int)
as
begin
	update KhachHang set HoTen = @ten, Email = @taikhoan, MatKhau = @matkhau, GioiTinh = @gioitinh, NgaySinh = @ngaysinh, DiaChi = @diachi, DienThoai = @sdt, MaVaiTro = @vaitro where Email = @taikhoan
end
go
--6 Stored Procedure	lay tat ca khach hang
create proc Select_KhachHang
as
begin
	select HoTen,Email,MatKhau,GioiTinh,NgaySinh,DiaChi,DienThoai,KhachHang.MaVaiTro,PhanQuyen.VaiTro from KhachHang,PhanQuyen where KhachHang.MaVaiTro = PhanQuyen.MaVaiTro
end
go
--7 Stored Procedure cap nhat mat khau khi doi mat khau
create proc Update_Matkhau(@taikhoan nvarchar(50),@matkhau nvarchar(50),@matkhaumoi nvarchar(50))
as
begin
	update KhachHang set MatKhau = @matkhaumoi where Email = @taikhoan
end
go
--8 Stored Procedure lay thong tin khach hang (truyen ten tai khoan)
create proc Select_ThongtinKhachHang(@taikhoan nvarchar(50))
as
begin
	select HoTen,NgaySinh,DiaChi,DienThoai From KhachHang where @taikhoan = Email
end
go
--9 Stored Procedure cap nhat thong tin khach hang
create proc Update_ThongtinKhachHang(@taikhoan nvarchar(50),@hoten nvarchar(50),@ngaysinh datetime,@diachi nvarchar(100),@sdt nvarchar(15))
as
begin
	update KhachHang set HoTen = @hoten, NgaySinh = @ngaysinh, DiaChi = @diachi, DienThoai = @sdt where @taikhoan = Email
end
go
--10 Stored Procedure lay thong tin tat ca san pham
create proc Select_ThongtinSanPham
as
begin
	select SanPham.MaSP, SanPham.TenSP, SanPham.HangSX,HangSanXuat.TenHang, SanPham.DonGia, SanPham.SoLuong, SanPham.MaNCC, NhaCungCap.TenNCC, SanPham.MaTrangThai,TrangThai.TenTrangThai,SanPham.AnhDaiDien
	from SanPham, HangSanXuat, NhaCungCap, TrangThai
	where SanPham.MaNCC = NhaCungCap.MaNCC and SanPham.HangSX = HangSanXuat.HangSX and SanPham.MaTrangThai = TrangThai.MaTrangThai
end
go
--11 Stored Procedure them san pham
create proc Them_SanPham(@tensp nvarchar(50),@hangsx nvarchar(50),@dongia int,@soluong int,@nhacungcap nvarchar(30),@trangthai int)
as
begin
	insert into SanPham(TenSP) values (@tensp)
	if not exists (select TenNCC from NhaCungCap where TenNCC = @nhacungcap)
	begin
		insert into NhaCungCap(TenNCC) values (@nhacungcap)
	end
	if not exists (select TenHang from HangSanXuat where TenHang = @hangsx)
	begin
		insert into HangSanXuat(TenHang) values (@hangsx)
	end
	update SanPham set MaNCC = (select dbo.Select_MaNCC(@nhacungcap)),HangSX = (select dbo.Select_HangSX(@hangsx)),DonGia = @dongia,SoLuong = @soluong, MaTrangThai = @trangthai where MaSP = IDENT_CURRENT('SanPham')
end
go
--12 Stored Procedure them anh san pham
create proc Them_AnhSanPham(@tensp nvarchar(50),@anh nvarchar(max))
as
begin
	update SanPham set AnhDaiDien = @anh where TenSP = @tensp
end
go
--13 Stored Procedure cap nhat san pham
create proc Update_SanPham(@tensp nvarchar(50),@tenhang nvarchar(50),@dongia int,@soluong int,@tennhacungcap nvarchar(50),@trangthai int,@anh nvarchar(max))
as
begin
	update SanPham set MaNCC = (select dbo.Select_MaNCC(@tennhacungcap)),HangSX = (select dbo.Select_HangSX(@tenhang)),DonGia = @dongia, SoLuong = @soluong, MaTrangThai = @trangthai,AnhDaiDien = @anh where TenSP = @tensp
end
go
--14 Stored Procedure xoa san pham
create proc Xoa_SanPham(@tensp nvarchar(50))
as
begin
	delete from SanPham where TenSP = @tensp
end
go
--15 Stored Procedure lay vai tro 
create proc Select_Vaitro
as
begin
	select * from PhanQuyen
end
go
--16 Stored Procedure lay trang thai
create proc Select_Trangthai
as
begin
	select * from TrangThai
end
go
--17 Stored Procedure them san pham vao gio hang
create proc Select_ThemvaoGioHang(@taikhoan nvarchar(50),@tensp nvarchar(50))
as
begin
	if not exists (select MaSP from GioHang where GioHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaSP = (select dbo.Select_MaSP_SP(@tensp)))
	insert into GioHang(MaKH,MaSP,SL,TongTien) values ((select dbo.Select_MaKH_KH(@taikhoan)),(select dbo.Select_MaSP_SP(@tensp)),1,(select dbo.Select_TongtienSP(@tensp)))
	else update GioHang set SL=SL+1,TongTien=(SL+1)*(select dbo.Select_TongtienSP(@tensp)) where MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaSP = (select dbo.Select_MaSP_SP(@tensp))
end
go
--18 Stored Procedure lay thong tin gio hang
create proc Select_ThongtinGioHang(@taikhoan nvarchar(50))
as
begin
	select HoTen,TenSP,GioHang.SL,GioHang.TongTien
	from KhachHang,SanPham,GioHang
	where KhachHang.MaKH = GioHang.MaKH and SanPham.MaSP = GioHang.MaSP and KhachHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan))
end
go
--19 Stored Procedure xoa san pham trong gio hang
create proc Xoa_SanPhamGioHang(@taikhoan nvarchar(50),@tensp nvarchar(50))
as
begin
	delete from GioHang where MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaSP = (select dbo.Select_MaSP_SP(@tensp))
end
go
--20 Stored Procedure cap nhat so luong trong gio hang
create proc Update_SL(@taikhoan nvarchar(50),@tensp nvarchar(50),@soluong int)
as
begin
	update GioHang set SL = @soluong where GioHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaSP = (select dbo.Select_MaSP_SP(@tensp))
end
go
--21 Stored Procedure cap nhat tien thanh toan trong gio hang
create proc Update_TienThanhToan(@taikhoan nvarchar(50),@tensp nvarchar(50))
as
begin
	Update GioHang set TongTien = (SL)*(select dbo.Select_TongtienSP(@tensp)) where GioHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaSP = (select dbo.Select_MaSP_SP(@tensp))
end
go
--22 Stored Procedure them don hang
create proc Them_DonHang(@taikhoan nvarchar(50),@tongtien int, @trangthai int)
as
begin
	insert into DonHang(MaKH,NgayMua,Tongtien,TinhTrangDH) values ((select dbo.Select_MaKH_KH(@taikhoan)),GETDATE(),@tongtien,@trangthai)
end
go
--23 Stored Procedure them chi tiet don hang
create proc Them_ChitietDH(@taikhoan nvarchar(50))
as
begin
	insert into ChiTietDonHang(MaDH,MaSP,SoLuong,DonGia)
	select MaDH,MaSP,SL,DonHang.Tongtien
	from GioHang,DonHang where DonHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and GioHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan)) and MaDH = IDENT_CURRENT('DonHang')
end
go
--24 Stored Procedure xoa gio hang
create proc Xoa_GioHang(@taikhoan nvarchar(50))
as
begin
	delete from GioHang where MaKH = (select dbo.Select_MaKH_KH(@taikhoan))
end
go
--25 Stored Procedure lay don hang cua khach hang
create proc Select_DonHangKhachHang(@taikhoan nvarchar(50))
as
begin
	select MaDH,KhachHang.HoTen,KhachHang.DiaChi,KhachHang.DienThoai,NgayMua,Tongtien,TenTTDH
	from DonHang,KhachHang,TrangThaiDH
	where KhachHang.MaKH = DonHang.MaKH and DonHang.TinhTrangDH = TrangThaiDH.MaTTDH and KhachHang.MaKH = (select dbo.Select_MaKH_KH(@taikhoan))
end
go
--26 Stored Procedure lay thong tin don hang
create proc Select_ThongtinDonHang(@MaDH int)
as
begin
	select TenSP,TenHang,TenNCC,NhaCungCap.DiaChi,NhaCungCap.DienThoai_NCC,ChiTietDonHang.SoLuong,Tongtien
	from ChiTietDonHang,SanPham,DonHang,HangSanXuat,NhaCungCap
	where DonHang.MaDH = ChiTietDonHang.MaDH and SanPham.MaSP = ChiTietDonHang.MaSP and NhaCungCap.MaNCC = SanPham.MaNCC
	and HangSanXuat.HangSX = SanPham.HangSX and DonHang.MaDH = @MaDH
end
go
--27 Stored Procedure lay don hang
create proc Select_DonHang
as
begin
	select KhachHang.HoTen,KhachHang.MaKH,DonHang.MaDH,Tongtien,TrangThaiDH.MaTTDH,TrangThaiDH.TenTTDH from KhachHang,DonHang,TrangThaiDH where TrangThaiDH.MaTTDH = DonHang.TinhTrangDH and DonHang.MaKH = KhachHang.MaKH
end
go
--28 Stored Procedure lay tinh trang don hang
create proc Select_TrangThaiDH
as
begin
	select * from TrangThaiDH
end
go
--29 Stored Procedure cap nhat tinh trang don hang
create proc Update_TrangThaiDH(@MaDH int,@trangthai int)
as
begin
	update DonHang set TinhTrangDH = @trangthai where MaDH = @MaDH
end
go
--30 Stored Procedure xoa don hang trong bang chi tiet don hang
create proc Xoa_DonHangCTDH(@MaDH int)
as
begin
	delete from ChiTietDonHang where MaDH = @MaDH
end
go
--31 Stored Procedure xoa don hang trong bang don hang
create proc Xoa_DonHangDH(@MaDH int)
as
begin
	delete from DonHang where MaDH = @MaDH
end
go
--32 Stored Procedure cap nhat gio hang
create proc Update_GioHang(@masp int,@soluong int)
as
begin
	update SanPham set SoLuong = @soluong where MaSP = @masp
end
go
--FUNCTION

go
--1 Function lay ma vai tro tu tai khoan khach hang
create function Select_MaVaiTrotuTaiKhoan(@taikhoan nvarchar(50))
returns int
begin
declare @mavaitro int
set @mavaitro = (select MaVaiTro from KhachHang where Email = @taikhoan)
return @mavaitro
end
go
--2 Function kiem tra mat khau
create function Kiemtramatkhau(@taikhoan nvarchar(50),@matkhau nvarchar(50),@matkhaumoi nvarchar(50))
returns int
as
begin
declare @a int
declare @matkhauhientai nvarchar(50)
	set @matkhauhientai = (select Matkhau from KhachHang where Email = @taikhoan)
	if (@matkhauhientai = @matkhau)
		set @a = 1
	else 
		set @a = 2
	return @a
end
go
--3 Function lay ma trang thai san pham
create function Select_MaTrangThai(@tentrangthai nvarchar(20))
returns int
as
begin
	declare @a int
	set @a = (select MaTrangThai from TrangThai where TenTrangThai = @tentrangthai)
	return @a
end
go
--4 Function lay ma trang thai don hang
create function Select_MaTrangThaiDH(@tentrangthai nvarchar(20))
returns int
as
begin
	declare @a int
	set @a = (select MaTTDH from TrangThaiDH where TenTTDH = @tentrangthai)
	return @a
end
go
--5 Function lay ma nha cung cap
create function Select_MaNCC(@tenncc nvarchar(30))
returns int
as
begin
	declare @a int
	set @a = (select MaNCC from NhaCungCap where TenNCC = @tenncc)
	return @a
end
go
--6 Function lay ma hang san xuat
create function Select_HangSX(@tenhsx nvarchar(30))
returns int
as
begin
	declare @a int
	set @a = (select HangSX from HangSanXuat where TenHang = @tenhsx)
	return @a
end
go
--7 Function kiem tra san pham co trung ten hay khong
create function Kiemtra_SanPham(@tensp nvarchar(50))
returns int
as
begin
declare @a int
if exists (select TenSP from SanPham where TenSP = @tensp)
	set @a = 1
else
	set @a = 0 
return @a
end
go
--8 Function tim kiem thong tin san pham
create function Timkiem_ThongtinSanPham(@tensp nvarchar(50))
returns table
as
return
	select TenSP,HangSanXuat.TenHang,DonGia,SoLuong,TrangThai.TenTrangThai,NhaCungCap.TenNCC,NhaCungCap.DiaChi,NhaCungCap.DienThoai_NCC,AnhDaiDien,SanPham.MaSP,Ram,DiaCung,VGA,ManHinh,CPU
	from SanPham,HangSanXuat,NhaCungCap,TrangThai,ChiTietSanPham
	where TenSP like '%'+@tensp+'%' and SanPham.HangSX = HangSanXuat.HangSX and SanPham.MaNCC = NhaCungCap.MaNCC and SanPham.MaTrangThai = TrangThai.MaTrangThai
go
--9 Function lay ma khach hang tu bang khach hang
create function Select_MaKH_KH(@taikhoan nvarchar(50))
returns int
begin
	declare @a int
	set @a = (select MaKH from KhachHang where Email = @taikhoan)
	return @a
end
go
--10 Function lay ma san pham tu bang san pham
create function Select_MaSP_SP(@tensp nvarchar(50))
returns int
begin
	declare @a int
	set @a = (select MaSP from SanPham where TenSP = @tensp)
	return @a
end
go
--11 Function lay tong tien san pham
create function Select_TongtienSP(@tensp nvarchar(50))
returns int
as
begin
	return (select DonGia from SanPham where TenSP = @tensp)
end
go
--12 Function lay tong tien cua gio hang
create function Select_TongtienGH(@taikhoan nvarchar(50))
returns int
begin
	declare @a int
	set @a = (select Ma.Tien from (select MaKH,sum(TongTien) as Tien
			from GioHang
			where MaKH = (select dbo.Select_MaKH_KH(@taikhoan))
			group by MaKH) as Ma)
	return @a
end
go
--13 Function kiem tra trang thai don hang
create function Kiemtra_TrangThai(@ten nvarchar(50))
returns int
as
begin
	declare @a int
	if(((select dbo.Select_MaTrangThaiDH(@ten)) = 1) or ((select dbo.Select_MaTrangThaiDH(@ten)) = 4))
		set @a = 1
	else if ((select dbo.Select_MaTrangThaiDH(@ten)) = 2)
		set @a = 2
	else
		set @a = 3
	return @a
end
go
--14 Function tim kiem san pham theo ten
create function Timkiem_SanPham(@ten nvarchar(30)) returns table
as
return 
	select MaSP,TenSP,HangSX,DonGia,SoLuong
	from SanPham
	where TenSP like '%'+@ten+'%'
go
--15 Function kiem tra dang ky (khong duoc trung SDT hoac Email)
create function Kiemtra_Dangky(
    @taikhoan nvarchar (50),
    @sdt nvarchar (30))
returns int
as
begin
	Declare @a int
     
    if EXISTS(select Email FROM KhachHang WHERE Email = @taikhoan)
    begin
        set @a= -1  
    end
    ELSE IF EXISTS(select Email FROM KhachHang WHERE DienThoai = @sdt)
    begin
        set @a = -2   
    end
	return @a
end
go
--16 Function kiem tra dang nhap
create function Kiemtra_Dangnhap (@email nvarchar(100), @matkhau nvarchar(50))
returns int
as
begin
	declare @a int
	if @matkhau = (select matkhau from KhachHang where @email = Email)
		set @a = 1;
	else
		set @a = 0;
	return @a;
end
go
--17 Function kiem tra mat khau
create function Kiemtra_Matkhau(@taikhoan nvarchar(30),@matkhau nvarchar(30))
returns int
as
begin
	if @matkhau = (select MatKhau from KhachHang where Email =  @taikhoan)
		return 1
	return 0
end

 --TRIGGER

 go
 --1 Trigger cap nhat lai so luong san pham khi user dat hang
create trigger Dathang on ChiTietDonHang after insert as
begin
	update SanPham set SoLuong = SanPham.SoLuong - (select SoLuong from inserted where MaSP = SanPham.MaSP) from SanPham join inserted on SanPham.MaSP = inserted.MaSP
end
go
--2 Trigger cap nhat lai so luong san pham khi user huy don hang
create trigger HuyDathang on ChiTietDonHang after delete as
begin
	update SanPham set SoLuong = SanPham.SoLuong + (select SoLuong from deleted where MaSP =SanPham.MaSP) from SanPham join deleted on SanPham.MaSP = deleted.MaSP
end
go
--3 Trigger cap nhat lai so luong san pham khi user thay doi so luong trong gio hang
create trigger Update_Dathang on ChiTietDonHang after update as
begin
	update SanPham set SoLuong = SanPham.SoLuong - (select SoLuong from inserted where MaSP = SanPham.MaSP) + (select SoLuong from deleted where MaSP = SanPham.MaSP)
	from SanPham join deleted on SanPham.MaSP = deleted.MaSP
end
go
--4 Trigger neu so luong don hang lon hon trong kho thi don hang bi huy 
create trigger Kiemtra_SoLuong on GioHang after insert,update
as
begin
	declare @sl int,@masp int
	select @sl = inserted.SL,@masp = inserted.MaSP
	from inserted
	if exists (select SanPham.MaSP from SanPham where SanPham.MaSP = @masp and SanPham.SoLuong < @sl)
		begin
					print N'Số lượng sản phẩm trong kho không đủ đáp ứng đơn hàng'
					rollback tran
					end
end


