CREATE DATABASE QuanLyPhongNet
GO

USE QuanLyPhongNet
GO
-- ADMIN
-- TAIKHOAN
-- MAY
-- THUC AN
-- THUC UONG

CREATE TABLE ADMIN
(
	UserName NVARCHAR(20) NOT NULL PRIMARY KEY,
	Pass NVARCHAR(1000) NOT NULL
)
GO

CREATE TABLE TaiKhoan
(
	UserName NVARCHAR(20) NOT NULL PRIMARY KEY,
	Pass NVARCHAR(1000) NOT NULL DEFAULT N'123',
	SDT NVARCHAR(10),
	CMND NVARCHAR(12),
	TIEN NCHAR(10)
)
GO

CREATE TABLE MAY
(
	MAY NVARCHAR(10) NOT NULL PRIMARY KEY,
	LOAI NVARCHAR(5) NOT NULL,
	TRANGTHAI BIT NOT NULL DEFAULT 0,
	UserName NVARCHAR(20),
	GIA NCHAR(10) NOT NULL,
	FOREIGN KEY (UserName) REFERENCES dbo.TaiKhoan(UserName)
)
GO

CREATE TABLE THUCAN
(
	TEN NVARCHAR(100) NOT NULL,
	GIA FLOAT NOT NULL
)
GO

CREATE TABLE THUCUONG
(
	TEN NVARCHAR(100) NOT NULL,
	GIA FLOAT NOT NULL
)
GO
SELECT * FROM dbo.ADMIN 
SELECT * FROM dbo.TaiKhoan 
SELECT * FROM dbo.MAY 
SELECT * FROM dbo.THUCAN 
SELECT * FROM dbo.THUCUONG 

INSERT INTO dbo.ADMIN
        ( UserName ,
          Pass 
        )
VALUES  ( N'admin' , -- UserName - nvarchar(20)
          N'admin'  -- Pass - nvarchar(1000)
        )

INSERT INTO dbo.TaiKhoan
        ( UserName ,
          SDT ,
          CMND 
        )
VALUES  ( N'hcmue' , -- UserName - nvarchar(20)
          N'0123456789' , -- SDT - nvarchar(10)
          N'101202303'  -- CMND - nvarchar(12)
        )
INSERT INTO dbo.TaiKhoan
        ( UserName ,
          SDT ,
          CMND 
        )
VALUES  ( N'hcmup' , -- UserName - nvarchar(20)
          N'0123789456' , -- SDT - nvarchar(10)
          N'202101303'  -- CMND - nvarchar(12)
        )
INSERT INTO dbo.TaiKhoan
        ( UserName ,
          SDT ,
          CMND 
        )
VALUES  ( N'abc' , -- UserName - nvarchar(20)
          N'0989111222' , -- SDT - nvarchar(10)
          N'026032213'  -- CMND - nvarchar(12)
        )
GO 
