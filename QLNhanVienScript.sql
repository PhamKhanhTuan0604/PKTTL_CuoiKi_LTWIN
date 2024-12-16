USE [master]
GO
/****** Object:  Database [QLNhanVien]    Script Date: 12/16/2024 5:22:45 PM ******/
CREATE DATABASE [QLNhanVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLNhanVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLNhanVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLNhanVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLNhanVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLNhanVien] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhanVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhanVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhanVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhanVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhanVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhanVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhanVien] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLNhanVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhanVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhanVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhanVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhanVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhanVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhanVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhanVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhanVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLNhanVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhanVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhanVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhanVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhanVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhanVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhanVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhanVien] SET RECOVERY FULL 
GO
ALTER DATABASE [QLNhanVien] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhanVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhanVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhanVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhanVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLNhanVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLNhanVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNhanVien', N'ON'
GO
ALTER DATABASE [QLNhanVien] SET QUERY_STORE = OFF
GO
USE [QLNhanVien]
GO
/****** Object:  Table [dbo].[ChiTietNghiPhep]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietNghiPhep](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [varchar](20) NULL,
	[NgayNghi] [date] NULL,
	[LyDo] [nvarchar](255) NULL,
 CONSTRAINT [PK_ChiTietNghiPhep] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [varchar](20) NOT NULL,
	[TenChucVu] [nvarchar](100) NULL,
	[MaPhongBan] [varchar](20) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDanh]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDanh](
	[MaDiemDanh] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NULL,
	[NgayDiemDanh] [date] NULL,
 CONSTRAINT [PK_DiemDanh] PRIMARY KEY CLUSTERED 
(
	[MaDiemDanh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[SoHD] [int] NOT NULL,
	[NgayKy] [datetime] NULL,
	[HeSoLuong] [float] NULL,
	[MaNV] [varchar](20) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](20) NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](150) NULL,
	[Luong] [real] NULL,
	[MaPhongBan] [varchar](20) NULL,
	[TenTKhoan] [varchar](50) NULL,
	[MaChucVu] [varchar](20) NULL,
	[SoHD] [int] NULL,
	[PhuCap] [float] NULL,
	[TongLuongThang] [float] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhongBan] [varchar](20) NOT NULL,
	[TenPhongBan] [nvarchar](100) NOT NULL,
	[SiSo] [smallint] NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenTKhoan] [varchar](50) NOT NULL,
	[MatKhau] [varbinary](max) NULL,
	[Email] [varchar](50) NULL,
	[RamdomKey] [varchar](50) NULL,
	[OTP] [varchar](50) NULL,
	[OPTDateSend] [datetime] NULL,
	[DateCreated] [datetime] NULL,
	[DateActive] [datetime] NULL,
	[Active] [bit] NULL,
	[LevelID] [int] NULL,
 CONSTRAINT [PK_TaiKhoan_1] PRIMARY KEY CLUSTERED 
(
	[TenTKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TangCa]    Script Date: 12/16/2024 5:22:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TangCa](
	[IDTangCa] [varchar](50) NOT NULL,
	[MaNV] [varchar](20) NULL,
	[SoGioTC] [int] NULL,
	[LuongTC] [int] NULL,
 CONSTRAINT [PK_TangCa] PRIMARY KEY CLUSTERED 
(
	[IDTangCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChiTietNghiPhep] ON 

INSERT [dbo].[ChiTietNghiPhep] ([ID], [MaNV], [NgayNghi], [LyDo]) VALUES (1, N'NV0010', CAST(N'2024-12-15' AS Date), N'Bệnh')
INSERT [dbo].[ChiTietNghiPhep] ([ID], [MaNV], [NgayNghi], [LyDo]) VALUES (2, N'NV0001', CAST(N'2024-12-16' AS Date), N'Vợ đẻ')
INSERT [dbo].[ChiTietNghiPhep] ([ID], [MaNV], [NgayNghi], [LyDo]) VALUES (3, N'NV0012', CAST(N'2024-12-16' AS Date), N'Nhà có tang')
INSERT [dbo].[ChiTietNghiPhep] ([ID], [MaNV], [NgayNghi], [LyDo]) VALUES (13, N'NV1111', CAST(N'2024-12-18' AS Date), N'Bệnh sốt')
SET IDENTITY_INSERT [dbo].[ChiTietNghiPhep] OFF
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MaPhongBan]) VALUES (N'CV1', N'Nhân Viên', N'10A1')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MaPhongBan]) VALUES (N'CV2', N'Phó Phòng', N'10A2')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MaPhongBan]) VALUES (N'CV3', N'Trưởng Phòng', N'10A3')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MaPhongBan]) VALUES (N'CV4', N'Trưởng VS', N'10A4')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [MaPhongBan]) VALUES (N'CV5', N'Trưởng CNTT', N'10A5')
GO
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'1', N'NV0001', CAST(N'2003-10-10' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'2YvzciAtq45vqVECjpvE', N'NV0002', CAST(N'2024-05-20' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'4oP28aAkUdZvMQKoxcIG', N'NV0008', CAST(N'2024-12-12' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'8FzvAm8qjOdqxRDzyveZ', N'NV0003', CAST(N'2024-05-20' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'AusPWDqWrCW3HYdLG2UW', N'NV00011', CAST(N'2024-12-11' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'bEVrCBVOr3fniV1mezEy', N'NV0004', CAST(N'2024-05-18' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'Bi7gEnN5jzZLwSbnf9ha', N'NV1111', CAST(N'2024-12-12' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'BM7WRHRIc9SzaZQYA6BN', N'NV1111', CAST(N'2024-12-13' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'fhfIilfwDX49M6uFuwRx', N'NV0012', CAST(N'2024-12-15' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'GCQbBmJIIOUtSqNyzM3R', N'NV0009', CAST(N'2024-12-09' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'GSNBcUiU1NSYv6X2mH2U', N'NV0006', CAST(N'2024-05-18' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'h43z00FvTYjo1cnQwiG5', N'NV0004', CAST(N'2024-05-20' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'ixXHZkiiCuYVYsY04o6n', N'NV0006', CAST(N'2024-12-11' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'JvkOt2XOM2BYbPjJsjST', N'NV1111', CAST(N'2024-12-12' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'nWJZjxeT5vuJH8DJXBR4', N'NV00011', CAST(N'2024-12-07' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'RI967XanUP7tQYfNCL4y', N'NV0002', CAST(N'2024-12-07' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'uIVGbzHvGhZWZbG7HGyj', N'NV0007', CAST(N'2024-05-18' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'W6Xy16Obx13s01cblNdo', N'NV0001', CAST(N'2024-05-18' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'Wy4UivvPtwsUl7l89aRd', N'NV1111', CAST(N'2024-12-14' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'XAuNw902N9AmmTAbHEe2', N'NV0002', CAST(N'2024-05-18' AS Date))
INSERT [dbo].[DiemDanh] ([MaDiemDanh], [MaNV], [NgayDiemDanh]) VALUES (N'ZsZG7aBF1ZRy59UpGYnJ', N'NV0012', CAST(N'2024-12-12' AS Date))
GO
INSERT [dbo].[HopDong] ([SoHD], [NgayKy], [HeSoLuong], [MaNV], [NgayBatDau], [NgayKetThuc]) VALUES (222, CAST(N'1995-02-11T00:00:00.000' AS DateTime), 2, N'NV0001', CAST(N'1995-02-12T00:00:00.000' AS DateTime), CAST(N'2000-02-11T00:00:00.000' AS DateTime))
INSERT [dbo].[HopDong] ([SoHD], [NgayKy], [HeSoLuong], [MaNV], [NgayBatDau], [NgayKetThuc]) VALUES (223, CAST(N'1995-03-11T00:00:00.000' AS DateTime), 4, N'NV0002', CAST(N'1995-03-12T00:00:00.000' AS DateTime), CAST(N'2030-03-12T00:00:00.000' AS DateTime))
INSERT [dbo].[HopDong] ([SoHD], [NgayKy], [HeSoLuong], [MaNV], [NgayBatDau], [NgayKetThuc]) VALUES (224, CAST(N'1995-02-11T00:00:00.000' AS DateTime), 3, N'NV0003', CAST(N'1995-02-12T00:00:00.000' AS DateTime), CAST(N'2000-02-11T00:00:00.000' AS DateTime))
INSERT [dbo].[HopDong] ([SoHD], [NgayKy], [HeSoLuong], [MaNV], [NgayBatDau], [NgayKetThuc]) VALUES (225, CAST(N'2024-12-12T10:16:42.847' AS DateTime), 2, N'NV0014', CAST(N'2024-12-15T10:16:42.000' AS DateTime), CAST(N'2030-12-14T10:16:42.000' AS DateTime))
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0001', N'Nguyễn Thanh Tùng', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'123 Ký Con, Q12', 5, N'10A1', NULL, N'CV1', 222, 100, 7300000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV00011', N'Nguyễn Thanh Tùng', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'123 Ký Con, Q12', 3, N'10A3', NULL, N'CV4', 223, 100, 7300000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0002', N'Lê Thanh Thủy', CAST(N'1995-02-23T00:00:00.000' AS DateTime), N'456 Lê Lợi, Q1', 5, N'10A1', NULL, N'CV1', 222, 100, 7300000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0003', N'Trần Ngọc Thanh', CAST(N'1990-01-30T20:53:44.000' AS DateTime), N'222 Lê Văn Sỹ, Quận 3, TpHCM', 5, N'10A1', NULL, N'CV1', 222, 100, 7000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0004', N'Lương Ngọc Hân Hoan', CAST(N'2011-05-26T19:57:49.097' AS DateTime), N'175/1 Nguyễn Huỳnh Đức, P.Khánh Hậu, Tp Tân An, Long An', 5, N'10A1', NULL, N'CV1', 223, 100, 7000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0005', N'Nguyễn Thanh Ty', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'123 Ký Con, Q12', 5, N'10A1', NULL, N'CV5', 224, 100, 11100000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0006', N'Nguyễn Thanh Tùng Đinh', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'123 Ký Con, Q12', 7, N'10A2', NULL, N'CV2', 222, 100, 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0007', N'Lương Ngọc Hân Hoan Quá', CAST(N'2011-05-26T19:57:49.097' AS DateTime), N'175/1 Nguyễn Huỳnh Đức, P.Khánh Hậu, Tp Tân An, Long An', 5, N'10A1', NULL, N'CV2', 223, 100, 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0008', N'Nguyễn Thanh Tùng Chùa', CAST(N'1995-02-11T00:00:00.000' AS DateTime), N'123 Ký Con, Q12', 7, N'10A2', NULL, N'CV2', 222, 100, 0)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0009', N'Lê Thanh Thủy', CAST(N'1995-02-23T00:00:00.000' AS DateTime), N'456 Lê Lợi, Q1', 8, N'10A2', NULL, N'CV3', 224, 100, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0010', N'Trịnh Trần Phương Tuấn', CAST(N'1997-06-11T16:43:20.000' AS DateTime), N'123, Bến Nghé, Q1, TP HCM', 5, N'10A1', NULL, N'CV4', 224, 100, 7600000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0012', N'Châu Văn Bùi', CAST(N'2024-12-11T14:34:41.653' AS DateTime), N'33, CMT8, Q8', 6, N'10A5', N'Chau0012', N'CV5', 222, 100, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0013', N'Phạm Nguyễn Minh Khoa', CAST(N'2004-12-12T10:09:11.000' AS DateTime), N'Q5, TPHCM', 5, N'10A3', N'Khoa Nguyen', N'CV3', 222, 100, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV0014', N'Nguyễn Minh Khoa', CAST(N'2004-06-20T10:15:35.000' AS DateTime), N'P4, Q5, HCM', 6, N'10A1', N'Khoa Pham', N'CV1', 225, 100, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [NgaySinh], [DiaChi], [Luong], [MaPhongBan], [TenTKhoan], [MaChucVu], [SoHD], [PhuCap], [TongLuongThang]) VALUES (N'NV1111', N'Phạm Khánh Tuấn', CAST(N'2004-06-24T21:27:55.000' AS DateTime), N'432, Rừng Sác, Cần Giờ', 9, N'10A2', N'Tu?n T?ng', N'CV3', 224, 100, 19900000)
GO
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [SiSo]) VALUES (N'10A1', N'Văn phòng', 30)
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [SiSo]) VALUES (N'10A2', N'Giám đốc', 10)
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [SiSo]) VALUES (N'10A3', N'Kế hoạch', 22)
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [SiSo]) VALUES (N'10A4', N'Vệ sinh', 5)
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [SiSo]) VALUES (N'10A5', N'CNTT', 10)
GO
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Chau0012', 0x4B2143D37CE24EF6AEEBD4FB3566049F, N'phamkhanhtuan2004@gmial.com', N'1498', N'8743', CAST(N'2024-12-14T20:40:49.260' AS DateTime), CAST(N'2024-12-11T14:04:32.803' AS DateTime), NULL, 0, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Chi Dan', 0xF6D94851C039071937BA7AD185DF4F83, N'anh3@gmail.com', N'4225', N'9942', CAST(N'2024-12-09T17:47:08.407' AS DateTime), CAST(N'2024-12-08T17:06:48.353' AS DateTime), NULL, 0, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Khoa Nguyen', 0x13863990910DEC301496DEA9131E6612, N'khoaphamnguyenminh@gmail.com', N'3883', N'6622', CAST(N'2024-12-15T21:10:06.280' AS DateTime), CAST(N'2024-12-12T10:01:54.197' AS DateTime), CAST(N'2024-12-12T10:02:34.887' AS DateTime), 1, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Khoa Pham', 0x67D9D085873919987C710440F0652F03, N'khoapnm2004@gmail.com', N'9930', N'2156', CAST(N'2024-12-14T20:11:23.803' AS DateTime), CAST(N'2024-12-12T10:14:53.840' AS DateTime), CAST(N'2024-12-12T10:15:28.547' AS DateTime), 1, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Minh Khoa', 0x449B28AE42809941326C439733B9DA18, N'khoaphamnguyenminh@gmail.com', N'4578', N'6973', CAST(N'2024-12-09T17:55:24.033' AS DateTime), CAST(N'2024-12-09T17:55:13.680' AS DateTime), NULL, 0, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Thanh Phat', 0xB0382F841FC1DA496C17EFB09F55FE39, N'sgoku6806@gmail.com', N'8516', N'3571', CAST(N'2024-12-09T17:57:02.820' AS DateTime), CAST(N'2024-12-09T17:56:55.570' AS DateTime), NULL, 0, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Thuong Dan', 0x5004476F3A3D124C7EEC18B3D76D375A, N'phamkhanhtuan2004@gmail.com', N'1728', N'7306', CAST(N'2024-12-10T17:11:03.313' AS DateTime), CAST(N'2024-12-10T17:09:14.513' AS DateTime), CAST(N'2024-12-10T17:12:30.500' AS DateTime), 1, 0)
INSERT [dbo].[TaiKhoan] ([TenTKhoan], [MatKhau], [Email], [RamdomKey], [OTP], [OPTDateSend], [DateCreated], [DateActive], [Active], [LevelID]) VALUES (N'Tu?n T?ng', 0x64A90D59C01EB4AE2F33169513B72068, N'phamkhanhtuan2004@gmail.com', N'5816', N'2881', CAST(N'2024-12-09T17:45:17.713' AS DateTime), CAST(N'2024-12-08T17:03:10.060' AS DateTime), CAST(N'2024-12-09T17:45:34.550' AS DateTime), 1, 1)
GO
INSERT [dbo].[TangCa] ([IDTangCa], [MaNV], [SoGioTC], [LuongTC]) VALUES (N'ID001', N'NV1111', 6, 600000)
INSERT [dbo].[TangCa] ([IDTangCa], [MaNV], [SoGioTC], [LuongTC]) VALUES (N'ID002', N'NV0001', 5, 500000)
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF_TaiKhoan_LevelID]  DEFAULT ((0)) FOR [LevelID]
GO
ALTER TABLE [dbo].[ChiTietNghiPhep]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietNghiPhep_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTietNghiPhep] CHECK CONSTRAINT [FK_ChiTietNghiPhep_NhanVien]
GO
ALTER TABLE [dbo].[ChucVu]  WITH CHECK ADD  CONSTRAINT [FK_ChucVu_PhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBan] ([MaPhongBan])
GO
ALTER TABLE [dbo].[ChucVu] CHECK CONSTRAINT [FK_ChucVu_PhongBan]
GO
ALTER TABLE [dbo].[DiemDanh]  WITH CHECK ADD  CONSTRAINT [FK_DiemDanh_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DiemDanh] CHECK CONSTRAINT [FK_DiemDanh_NhanVien]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_HopDong] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HopDong] ([SoHD])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_HopDong]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBan] ([MaPhongBan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([TenTKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenTKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[TangCa]  WITH CHECK ADD  CONSTRAINT [FK_TangCa_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[TangCa] CHECK CONSTRAINT [FK_TangCa_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [QLNhanVien] SET  READ_WRITE 
GO
