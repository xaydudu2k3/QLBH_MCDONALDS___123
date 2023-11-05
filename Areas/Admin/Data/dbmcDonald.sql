
create database QLCuaHangMcDonald
go 
use QLCuaHangMcDonald

create table NhaCungCap(
	MaNCC varchar(20) primary key,
	TenNCC nvarchar(40),
	DiaChi nvarchar(50),
	SDT varchar(12),
	Email varchar(30),
);

create table DonNhapHang(
	MaDonHang varchar(10) primary key,
	MaNCC varchar(20),
	NgayNhapHang date,
);

create table ChiTietDonNhapHang(
	MaDonHang varchar(10),
	MaNL varchar(20),
	SoLuongNguyenLieu float,
	primary key(MaDonHang, MaNL),
); 

create table NguyenLieu(
	MaNL varchar(20) primary key,
	TenNL nvarchar(50),
	DonViTinh nvarchar(20),
	Gia int,
	SoLuong float,
);

create table DanhMucCheBien(
	MaNL varchar(20),
	MaSP varchar(20),
	DonViChuyenDoi float,
	primary key(MaNL, MaSP)
);

create table SanPham(
	MaSP varchar(20) primary key,
	MaLoai varchar(20),
	TenSP nvarchar(50),
	Gia int,
	SoLuong int,
	DonViTinh nvarchar(20),
);

create table LoaiSP(
	MaLoai varchar(20) primary key,
	TenLoai nvarchar(30),
);
create table ChiTietHoaDon(
	MaSP varchar(20),
	MaHoaDon varchar(10),
	SoLuongSP int,
	primary key(MaSP, MaHoaDon)
);

create table HoaDon(
	MaHoaDon varchar(10) primary key,
	TrangThai int,
	NgayLapHD date,
);

--Tạo Khóa ngoại

alter table DonNhapHang
add constraint FK_DonNhapHang_NhaCungCap
foreign key(MaNCC)
references  NhaCungCap(MaNCC)

alter table ChiTietDonNhapHang
add constraint FK_ChiTietDonNhapHang_DonNhapHang
foreign key(MaDonHang)
references  DonNhapHang(MaDonHang)

alter table ChiTietDonNhapHang
add constraint FK_ChiTietDonNhapHang_NguyenLieu
foreign key(MaNL)
references  NguyenLieu(MaNL)

alter table DanhMucCheBien
add constraint FK_DanhMucCheBien_NguyenLieu
foreign key(MaNL)
references  NguyenLieu(MaNL)

alter table DanhMucCheBien
add constraint FK_DanhMucCheBien_SanPham
foreign key(MaSP)
references SanPham(MaSP)

alter table SanPham
add constraint FK_SanPham_LoaiSP
foreign key(MaLoai)
references LoaiSP(MaLoai)

alter table ChiTietHoaDon
add constraint FK_ChiTietHoaDon_SanPham
foreign key(MaSP)
references SanPham(MaSP)

alter table ChiTietHoaDon
add constraint FK_ChiTietHoaDon_HoaDon
foreign key(MaHoaDon)
references HoaDon(MaHoaDon)

INSERT INTO LoaiSP (MaLoai, TenLoai)
VALUES
    ('ga', N'Gà'),
    ('khoaitay', N'Khoai tây'),
    ('nuoc', N'Nước giải khát');

select * from LoaiSP

INSERT INTO SanPham (MaLoai, MaSP, TenSP, Gia, DonViTinh, SoLuong)
VALUES
    ('ga', 'ga_dui', N'Đùi gà', 15000, N'cái', 500),
    ('ga', 'ga_canh', N'Cánh gà', 10000, N'cái', 500),
    ('khoaitay', 'ktay_chien', N'Khoai tây chiên', 10000, N'phần', 400),
    ('khoaitay', 'ktay_nghien', N'Khoai tây nghiền', 20000, N'phần', 300),
    ('nuoc', 'nuoc_coca', N'Coca cola', 7000, N'chai', 200),
    ('nuoc', 'nuoc_pepsi', N'Pepsi', 7000, N'chai', 200);


INSERT INTO NguyenLieu (MaNL, TenNL, DonViTinh, Gia, SoLuong)
VALUES
    ('duong', N'Đường', N'kg', 3000, 500),
    ('muoi', N'Muối', N'kg', 3500, 500),
    ('bot', N'Bột', N'kg', 3000, 500),
    ('khoaitay', N'Khoai tây', N'kg', 10000, 300),
    ('dauan', N'Dầu ăn', N'lit', 5000, 300),
    ('nuoc_coca', N'Coca cola', N'chai', 4000, 1000),
    ('nuoc_pepsi', N'Pepsi', N'chai', 4000, 1000),
    ('ga_dui', N'Đùi gà', N'cái', 3000, 700),
    ('ga_canh', N'Cánh gà', N'cái', 2000, 800);

select * from NguyenLieu

INSERT INTO DanhMucCheBien (MaSP, MaNL, DonViChuyenDoi)
VALUES
    ('ga_dui', 'ga_dui', 1.0),
    ('ga_dui', 'duong', 0.005),
    ('ga_dui', 'muoi', 0.005),
    ('ga_dui', 'bot', 0.004),
    ('ga_dui', 'dauan', 0.001),
    ('ga_canh', 'ga_canh', 1.0),
    ('ga_canh', 'duong', 0.005),
    ('ga_canh', 'muoi', 0.005),
    ('ga_canh', 'bot', 0.004),
    ('ga_canh', 'dauan', 0.001),
    ('nuoc_coca', 'nuoc_coca', 1.0),
    ('nuoc_pepsi', 'nuoc_pepsi', 1.0),
    ('ktay_chien', 'khoaitay', 0.01),
    ('ktay_chien', 'muoi', 0.002),
    ('ktay_chien', 'dauan', 0.001),
    ('ktay_nghien', 'khoaitay', 0.05),
    ('ktay_nghien', 'muoi', 0.005),
    ('ktay_nghien', 'duong', 0.005);

INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SDT, Email)
VALUES
    ('cty_nuoc', N'Công ty nước giải khát A', N'Đường xyz0', '0123456780', 'ct_a@gmail.com'),
    ('cty_nl1', N'Công ty nguyên liệu B', N'Đường xyz1', '0123456781', 'ct_b@gmail.com'),
    ('cty_nl2', N'Công ty nguyên liệu C', N'Đường xyz2', '0123456782', 'ct_c@gmal.com'),
    ('cty_ga', N'Công ty gà D', N'Đường xyz3', '0123456783', 'ct_d@gmal.com'),
    ('cty_raucu', N'Công ty rau củ E', N'Đường xyz4', '0123456784', 'ct_e@gmail.com');

select * from NhaCungCap

INSERT INTO DonNhapHang (MaDonHang, MaNCC, NgayNhapHang)
VALUES
    ('0001', 'cty_nuoc', CONVERT(DATE, '01/01/2023', 101)),
    ('0002', 'cty_nl1', CONVERT(DATE, '01/01/2023', 101)),
    ('0003', 'cty_nl2', CONVERT(DATE, '01/02/2023', 101)),
    ('0004', 'cty_ga', CONVERT(DATE, '01/02/2023', 101)),
    ('0005', 'cty_raucu', CONVERT(DATE, '01/02/2023', 101)),
    ('0006', 'cty_nl2', CONVERT(DATE, '02/01/2023', 101)),
    ('0007', 'cty_ga', CONVERT(DATE, '02/01/2023', 101));
select * from DonNhapHang

INSERT INTO ChiTietDonNhapHang (MaDonHang, MaNL, SoLuongNguyenLieu)
VALUES
    ('0001', 'nuoc_coca', 300),
    ('0001', 'nuoc_pepsi', 300),
    ('0002', 'muoi', 500),
    ('0002', 'duong', 300),
    ('0003', 'muoi', 100),
    ('0003', 'bot', 500),
    ('0003', 'dauan', 500),
    ('0004', 'ga_dui', 700),
    ('0004', 'ga_canh', 700),
    ('0005', 'khoaitay', 500),
    ('0006', 'muoi', 500),
    ('0006', 'dauan', 100),
    ('0007', 'ga_dui', 200);
select * from ChiTietDonNhapHang

INSERT INTO HoaDon
VALUES
    ('0001', 1, '01/01/2023'),
    ('0002', 0, '01/01/2023'),
    ('0003', 0, '01/02/2023')
INSERT INTO ChiTietHoaDon
VALUES
    ('ktay_chien', '0001',  3),
    ('ga_dui', '0002', 2),
    ('nuoc_coca', '0002', 1),
	('ga_canh', '0003', 4),
	('ktay_nghien', '0003', 2)
select * from DonNhapHang
select * from ChiTietHoaDon
