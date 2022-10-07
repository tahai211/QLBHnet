CREATE DATABASE QLBH
GO
USE QLBH
go 
CREATE TABLE Data_User(
    Id INT IDENTITY PRIMARY KEY,
	Group_ int ,
    UserName NVARCHAR(255),
	PassWord NVARCHAR(MAX),
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT

)


CREATE TABLE NHANVIEN(
    Id INT IDENTITY PRIMARY KEY,
	UserId INT,--xác định user qua id
    MaNV NVARCHAR(255),
    TenNV NVARCHAR(255) NOT NULL,
    Gioitinh INT NOT NULL,
    Ngaysinh DATE CHECK (Ngaysinh < getdate()) NOT NULL,
    Diachi NVARCHAR(MAX) NOT NULL,
    Sdt VARCHAR(255) NOT NULL,
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT

)

CREATE TABLE KHACHHANG(
	Id INT IDENTITY PRIMARY KEY,
	UserId INT,--xác định user qua id
	LoaiKH INT,
    MaKH VARCHAR(255) ,
    TenKH NVARCHAR(255) NOT NULL,
    Diachi NVARCHAR(MAX) NOT NULL,
    Sdt VARCHAR(255)NOT NULL,
    Email VARCHAR(255)NOT NULL,
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT
)

CREATE TABLE HANGHOA(
	Id INT IDENTITY PRIMARY KEY,
    MaMH VARCHAR(255),
    TenMH NVARCHAR(255) NOT NULL,
    Xuatxu NVARCHAR(255)NOT NULL,
    Gianhap INT NOT NULL,
    Giaban INT NOT NULL,
    NSX DATE NOT NULL,
    HSD DATE  NOT NULL,
    Soluong INT NOT NULL ,
    Conlai INT NOT NULL,
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT
)

CREATE TABLE HANGHOA_GIA( -- Với mỗi loại kh thì có giá khác nhau. Hoặc với số lượng khác nhau thì giá khác nhau
	Id INT IDENTITY PRIMARY KEY,
    MHID INT,--xác định mặt hàng qua id
    LoaiKH INT, -- Loại KH để có giá này
    MinSoluong INT, -- Số lượng tối thiểu để có giá này
    DonGia INT NOT NULL,
    Conlai INT NOT NULL,
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT
)


CREATE TABLE HOADON(
	Id INT IDENTITY PRIMARY KEY,
    HDID INT,
    NVID INT,
    KHID INT,
	ThanhTien DECIMAL(18,4) NOT NULL, -- k có cũng đc
	ChietKhau  DECIMAL(18,4) NOT NULL, --hoặc khuyến mãi
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT
)
CREATE TABLE CHITIETHOADON(
    MaHD INT,
    MaMH INT,
    GIAID INT, --?
    Soluong int NOT NULL,
    DonGia int NOT NULL,
    ThanhTien DECIMAL(18,4) NOT NULL, -- k có cũng đc
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT
)

CREATE TABLE MasterData(
    Id INT IDENTITY PRIMARY KEY,
	GroupId INT, -- Là Id của nhóm- Những thằng gốc thì cho = 0
    Name NVARCHAR(255) NOT NULL,
	OrderNo INT ,
	Description NVARCHAR(MAX),
	NgayTao DATETIME,
	NguoiTao INT,
	NgaySua DATETIME,
	NguoiSua INT

)
SET IDENTITY_INSERT MasterData ON
INSERT INTO dbo.MasterData
        ( 
		Id,
          GroupId ,
          Name ,
          Description ,
          NgayTao ,
          NguoiTao 
        )
VALUES  ( 1,
          0 , -- GroupId - int
          N'Loại KH' , -- Name - nvarchar(255)
          N'' , -- Description - nvarchar(max)
          GETDATE() , -- NgayTao - datetime
          0  -- NguoiTao - int
        )
SET IDENTITY_INSERT MasterData OFF

INSERT INTO dbo.MasterData
        ( 
          GroupId ,
          Name ,
          Description ,
          NgayTao ,
          NguoiTao 
        )
VALUES  ( 
          1 , -- GroupId - int
          N'KH VIP' , -- Name - nvarchar(255)
          N'' , -- Description - nvarchar(max)
          GETDATE() , -- NgayTao - datetime
          0  -- NguoiTao - int
        )

INSERT INTO dbo.MasterData
        ( 
          GroupId ,
          Name ,
          Description ,
          NgayTao ,
          NguoiTao 
        )
VALUES  ( 
          1 , -- GroupId - int
          N'KH sỉ' , -- Name - nvarchar(255)
          N'' , -- Description - nvarchar(max)
          GETDATE() , -- NgayTao - datetime
          0  -- NguoiTao - int
        )

		INSERT INTO dbo.MasterData
        ( 
          GroupId ,
          Name ,
          Description ,
          NgayTao ,
          NguoiTao 
        )
VALUES  ( 
          1 , -- GroupId - int
          N'KH Vãng lai' , -- Name - nvarchar(255)
          N'' , -- Description - nvarchar(max)
          GETDATE() , -- NgayTao - datetime
          0  -- NguoiTao - int
        )
select * From HOADON

-- INSERT Into NHANVIEN VALUES('A1', N'Lê văn Tám', N'Nam','1965-02-03', N'45 Trần Phú','86452345')
--INSERT Into NHANVIEN VALUES('B2',	N'Trần thị Lan',	N'Nữ',	'1970-10-20',	N'15 Nguyễn Trãi Q5','0987465321')	
--INSERT Into NHANVIEN VALUES('C3',	N'Tạ thành Tâm',	N'Nam',	'1965-12-10', N'Võ thị Sáu',	'85656666')
--INSERT Into NHANVIEN VALUES('D4',	N'Ngô Thanh Sơn', N'Nam',	'1950-06-12',	N'122 Trần Phú',	'0356241325')
--INSERT Into NHANVIEN VALUES('E5',	N'Lê thị	Thủy',	N'Nữ',	'1970-01-26',	N'25 Ngô Quyền',	'97654123')

--INSERT Into KHACHHANG VALUES('B145',	N'Cửa Hàng số 2 Q4',	N'20 Trần Phú Q2',	'86547893')
--INSERT Into KHACHHANG VALUES('D100',	N'Công Ty Cổ Phần Đầu tư',	N'22 Ngô Quyền Q5',	'86123564')
--INSERT Into KHACHHANG VALUES('L010',	N'Cửa Hàng Bách Hóa Q1',	N'155 Trần Hưng Đạo',	'85456123')
--INSERT Into KHACHHANG VALUES('S001',	N'Công Ty XNK Hoa Hồng',	N'123 Trần Phú',	'8356423')
--INSERT Into KHACHHANG VALUES('S002',	N'Công Ty VHP Tân Bình',	N'10 Lý thường Kiệt',	'8554545')

INSERT Into HANGHOA(MaMH,TenMH,Xuatxu,Giaban,Gianhap,NSX,HSD,Soluong,Conlai) VALUES('B01',N'Bia 33', N'Hà nội' ,4000, 4500,'2022-10-02','2022-12-29',40,20)
INSERT Into HANGHOA(MaMH,TenMH,Xuatxu,Giaban,Gianhap,NSX,HSD,Soluong,Conlai) VALUES('B02', N'Bia Tiger',N'Nam Định' ,	5000 ,6000,'2022-01-09','2022-11-26',90,10)
INSERT Into HANGHOA(MaMH,TenMH,Xuatxu,Giaban,Gianhap,NSX,HSD,Soluong,Conlai) VALUES('B03',	N'Bia Heneken',	N'Sài Gòn',	6000,9000,'2021-04-22','2023-06-14',110,20)
INSERT Into HANGHOA(MaMH,TenMH,Xuatxu,Giaban,Gianhap,NSX,HSD,Soluong,Conlai) VALUES('R01',	N'Rượu Bình tây',N'Hà nội',	20000,35000,'2022-11-18','2024-10-25',5,2)
INSERT Into HANGHOA(MaMH,TenMH,Xuatxu,Giaban,Gianhap,NSX,HSD,Soluong,Conlai) VALUES('R02',	N'Rượu Napoleon',N'Hà nội',	15000,30000,'2022-12-04','2026-11-29',10,8)

--INSERT Into HOADON VALUES(1,'A1', 'S001',	'2022-08-04')
--INSERT Into HOADON VALUES(2,'B2', 'L010',	'2022-11-04')
--INSERT Into HOADON VALUES(3,	'A1', 'S002',	'2022-10-07')
--INSERT Into HOADON VALUES(4,'D4', 'B145',	'2022-03-15')
--INSERT Into HOADON VALUES(5,'C3', 'D100',	'2022-12-24')
--INSERT Into HOADON VALUES(6,'B2', 'S001',	'2022-09-18')

--INSERT Into CHITIETHOADON VALUES(1,	'B01',	48)
--INSERT Into CHITIETHOADON VALUES(1,	'R01',	10)
--INSERT Into CHITIETHOADON VALUES(2,	'B01',	25)
--INSERT Into CHITIETHOADON VALUES(2,	'B02',	90)
--INSERT Into CHITIETHOADON VALUES(2,	'B03',	25)
--INSERT Into CHITIETHOADON VALUES(2,	'R02',	20)
--INSERT Into CHITIETHOADON VALUES(3,	'B01',	10)
--INSERT Into CHITIETHOADON VALUES(4,	'B01',	15)
--INSERT Into CHITIETHOADON VALUES(4,	'R01',	20)
--INSERT Into CHITIETHOADON VALUES(4,	'R02',	15)
--INSERT Into CHITIETHOADON VALUES(5,	'B01',	10)
INSERT Into Data_User(UserName,[PassWord],Group_) VALUES('tahai','123',1)
SELECT * FROM Data_User WHERE UserName = 'tahai' AND [PassWord] = '123'
--Login_Account
CREATE PROCEDURE  Login_Account
    (@UserName nvarchar(50),
    @PassWord nvarchar(50))
	 
    AS

	DECLARE @cc int
	
        BEGIN
        
        if ((SELECT COUNT(*)  FROM Data_User WHERE UserName = @UserName And [PassWord] = @PassWord) > 0)
         
    	    
			SELECT sum(Group_)  FROM Data_User WHERE UserName = @UserName And [PassWord] = @PassWord 
			
        else 
            
            select 0
		
        END;
EXEC Login_Account 'taai','47bce5c74f589f4867dbd57e9ca9f808'

DROP PROCEDURE Login_Account
--Create_Account
CREATE PROCEDURE Create_Account 
    (@UserName nvarchar(50),
    @PassWord nvarchar(50))
    AS
        BEGIN
        
        if ((SELECT COUNT(*)  FROM Data_User WHERE UserName = @UserName) > 0)
         
    	    SELECT '1'
        else 
            INSERT INTO Data_User(UserName,[Password]) VALUES(@UserName,@PassWord)
            SELECT '0'
        END;
DROP PROCEDURE Create_Account
EXEC Create_Account 'abc','123'

--Update_Nhanvien
CREATE PROCEDURE Update_Nhanvien
    (@UserName nvarchar(50) ,--xác định user qua id
    @MaNV NVARCHAR(255),
    @TenNV NVARCHAR(255),
    @Gioitinh INT ,
    @Ngaysinh DATE ,
    @Diachi NVARCHAR(MAX) ,
    @Sdt VARCHAR(255) )
    AS
    DECLARE @id int;
    SET @id = (Select Id From Data_User WHERE UserName = @UserName);
        BEGIN
            INSERT Into NHANVIEN(UserId,MaNV,TenNV ,Gioitinh ,Ngaysinh ,Diachi ,Sdt ) VALUES (
                @id,@MaNV,@TenNV,@Gioitinh,@Ngaysinh,@Diachi,@Sdt
            )
        
        END;
DROP PROCEDURE Update_Nhanvien
EXEC Update_Nhanvien 'def','123','ta hai',1,'2001-12-22','phutho','34253'

SELECT * FROM NHANVIEN


--List_goods

CREATE PROCEDURE List_goods 
    
    AS
        BEGIN
            SELECT * FROM HANGHOA
        END;



