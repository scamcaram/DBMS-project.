--tao bang
go
CREATE TABLE ChiTietDonHang (
    MaDH      INT          NULL,
    MaSP    INT          NULL,
    SoLuong       INT          NULL,
    DonGia DECIMAL (18,0) NULL,
);
go
CREATE TABLE DonHang (
    MaDH        INT            IDENTITY (1, 1) NOT NULL,
    MaKH        INT            NULL,
    NgayMua    DATETIME       NULL,
    TinhTrangDH  INT            NULL,
    Tongtien     DECIMAL (18)   NULL,
    PRIMARY KEY  (MaDH),
);
go
CREATE TABLE GioHang (
    MaKH     INT          NULL,
    MaSP     INT          NULL,
    SL       INT          NULL,
    TongTien DECIMAL (18,0) NULL,

);
go
CREATE TABLE HangSanXuat (
    HangSX     INT    NOT NULL,
    TenHang    NVARCHAR (30)  NULL,
    TruSoChinh NVARCHAR (MAX) NULL,
    QuocGia    NVARCHAR (50)  NULL,
    PRIMARY KEY (HangSX)
);
go
CREATE TABLE KhachHang(
MaKH INT IDENTITY(1,1)not null,
Email NVARCHAR (100) null,
MatKhau NVARCHAR(30) null,
HoTen NVARCHAR(30) null,
NgaySinh date null,
GioiTinh NVARCHAR(10) null,
DiaChi NVARCHAR(200) null,
DienThoai NVARCHAR(15) null,
MaVaiTro INT null,
PRIMARY KEY (MaKH),
);
go
CREATE TABLE NhaCungCap(
MaNCC INT not null,
TenNCC NVARCHAR(30) null,
DiaChi NVARCHAR(200) null,
DienThoai_NCC NVARCHAR(15) null,
Email NVARCHAR(100) null,
Website NVARCHAR(300) null,
PRIMARY KEY (MaNCC),
);
go
CREATE TABLE SanPham(
MaSP INT IDENTITY(1,1) not null,
TenSP NVARCHAR(30) null,
HangSX INT NULL,
DonGia DECIMAL(18, 0) NULL,
SoLuong INT NULL,
MaNCC INT NULL,
MaTrangThai INT NULL,
AnhDaiDien NVARCHAR(max) NULL,
PRIMARY KEY (MaSP),
);
go
CREATE TABLE ChiTietSanPham(
MaSP INT null,
Ram NVARCHAR(10),
DiaCung NVARCHAR(20),
VGA NVARCHAR(20),
ManHinh NVARCHAR(20),
CPU NVARCHAR (20),
);
go
CREATE TABLE TrangThai(
MaTrangThai INT not null,
TenTrangThai NVARCHAR(30) null,
PRIMARY KEY (MaTrangThai)
);
go
CREATE TABLE TrangThaiDH(
MaTTDH INT not null,
TenTTDH NVARCHAR(30) null,
PRIMARY KEY (MaTTDH)
);
go
CREATE TABLE PhanQuyen(
MaVaiTro int not null,
VaiTro nvarchar(30) not null,
PRIMARY KEY (MaVaiTro)
);

--lien ket cac bang
go
alter table ChiTietDonHang
add constraint fk_ChiTietDonHang_DonHang
foreign key (MaDH) references DonHang (MaDH) on delete cascade

go
alter table ChiTietDonHang
add constraint fk_ChiTietDonHang_SanPham
foreign key (MaSP) references SanPham (MaSP) on delete cascade

go
alter table ChiTietSanPham
add constraint fk_ChiTietSanPham_SanPham
foreign key (MaSP) references SanPham (MaSP) on delete cascade

go
alter table DonHang
add constraint fk_DonHang_KhachHang
foreign key (MaKH) references KhachHang (MaKH) on delete cascade

go
alter table DonHang
add constraint fk_DonHang_TrangThaiDH
foreign key (TinhTrangDH) references TrangThaiDH(MaTTDH) on delete cascade


alter table GioHang
add constraint fk_GioHang_KhachHang
foreign key (MaKH) references KhachHang(MaKH) on delete cascade

go
alter table GioHang
add constraint fk_GioHang_SanPham
foreign key (MaSP) references SanPham(MaSP) on delete cascade

go
alter table SanPham
add constraint fk_SanPham_NhaCungCap
foreign key (MaNCC) references NhaCungCap (MaNCC) on delete cascade

go
alter table SanPham
add constraint fk_SanPham_HangSanXuat
foreign key (HangSX) references HangSanXuat (HangSX) on delete cascade

go
alter table SanPham
add constraint fk_SanPham_TrangThai
foreign key (MaTrangThai) references TrangThai (MaTrangThai) on delete cascade

go
alter table KhachHang
add constraint fk_KhachHang_PhanQuyen
foreign key (MaVaiTro) references PhanQuyen (MaVaiTro) on delete cascade


--nhap du lieu vao bang
go
insert into TrangThaiDH(MaTTDH,TenTTDH) values (1,N'Chưa xác nhận')
insert into TrangThaiDH(MaTTDH,TenTTDH) values (2,N'Đã xác nhận')
insert into TrangThaiDH(MaTTDH,TenTTDH) values (3,N'Đang giao')
insert into TrangThaiDH(MaTTDH,TenTTDH) values (4,N'Hoàn Tất')
select * from TrangThaiDH

go
insert into TrangThai(MaTrangThai,TenTrangThai) values (1,N'Còn hàng')
insert into TrangThai(MaTrangThai,TenTrangThai) values (2,N'Hết hàng')
select * from TrangThai

go
insert into HangSanXuat(HangSX,TenHang,TruSoChinh,QuocGia) values (1,N'ASUS COMPANY',N'Mỹ',N'Mỹ')
insert into HangSanXuat(HangSX,TenHang,TruSoChinh,QuocGia) values (2,N'HP COMPANY',N'Anh',N'Anh')
select * from HangSanXuat

go
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,DienThoai_NCC,Email,Website) values (1,N'Phong Vũ',N'Q9',N'0909090909',N'phongvu@gmail.com',N'phongvu.com')
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,DienThoai_NCC,Email,Website) values (2,N'SPKT',N'Q9',N'0909091212',N'spkt@gmail.com',N'spkt.com')
insert into NhaCungCap(MaNCC,TenNCC,DiaChi,DienThoai_NCC,Email,Website) values (3,N'BX',N'Q9',N'090902332',N'bx@gmail.com',N'bx.com')
select * from NhaCungCap

go
insert into SanPham(TenSP,HangSX,DonGia,SoLuong,MaNCC,MaTrangThai,AnhDaiDien) values (N'ASUS',1,100000,5,1,1,N'C:\Ảnh\tải xuống.jpg')
insert into SanPham(TenSP,HangSX,DonGia,SoLuong,MaNCC,MaTrangThai,AnhDaiDien) values (N'DELL',2,200000,10,2,1,N'C:\Ảnh\images (1).jpg')
insert into SanPham(TenSP,HangSX,DonGia,SoLuong,MaNCC,MaTrangThai,AnhDaiDien) values (N'HP',2,300000,15,3,1,N'C:\Ảnh\images (2).jpg')
select * from SanPham

go
insert into ChiTietSanPham(MaSP,RAM,DiaCung,VGA,ManHinh,CPU) values (1,N'4GB',N'SSD',N'ASUS-GTX',N'Màn hình cong',N'Core i3')
insert into ChiTietSanPham(MaSP,RAM,DiaCung,VGA,ManHinh,CPU) values (2,N'8GB',N'HDD',N'GIGABYTE',N'Màn hình phẳng',N'Core i5')
insert into ChiTietSanPham(MaSP,Ram,DiaCung,VGA,ManHinh,CPU) values (3,N'16GB',N'SSD',N'MSI',N'Màn hình cong',N'Core i7')
select * from ChiTietSanPham
go
insert into PhanQuyen(MaVaiTro,VaiTro) values (1,N'Admin')
insert into PhanQuyen(MaVaiTro,VaiTro) values (2,N'User')
select * from PhanQuyen

go
insert into KhachHang(Email,MatKhau,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,MaVaiTro) values (N'an',N'123',N'DA','19820815',N'Nam',N'Bình Thạnh',N'0929381829',1)
insert into KhachHang(Email,MatKhau,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,MaVaiTro) values (N'qq',N'123',N'HT','19990312',N'Nữ',N'Q1',N'0923434323',2)
select * from KhachHang


