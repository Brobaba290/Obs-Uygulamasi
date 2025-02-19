USE [master]
GO
/****** Object:  Database [obssa]    Script Date: 17/06/2024 23:39:31 ******/
CREATE DATABASE [obssa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'obssa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\obssa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'obssa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\obssa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [obssa] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [obssa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [obssa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [obssa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [obssa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [obssa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [obssa] SET ARITHABORT OFF 
GO
ALTER DATABASE [obssa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [obssa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [obssa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [obssa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [obssa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [obssa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [obssa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [obssa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [obssa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [obssa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [obssa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [obssa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [obssa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [obssa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [obssa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [obssa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [obssa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [obssa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [obssa] SET  MULTI_USER 
GO
ALTER DATABASE [obssa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [obssa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [obssa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [obssa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [obssa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [obssa] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [obssa] SET QUERY_STORE = ON
GO
ALTER DATABASE [obssa] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [obssa]
GO
/****** Object:  User [NT AUTHORITY\NETWORK SERVICE]    Script Date: 17/06/2024 23:39:31 ******/
CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [kaand]    Script Date: 17/06/2024 23:39:31 ******/
CREATE USER [kaand] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\NETWORK SERVICE]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\NETWORK SERVICE]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 17/06/2024 23:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 17/06/2024 23:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DersAdı] [nvarchar](50) NULL,
	[OgrId] [int] NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duyuru]    Script Date: 17/06/2024 23:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duyuru](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Baslik] [varchar](50) NULL,
	[Icerik] [varchar](500) NULL,
	[Tarih] [datetime] NULL,
 CONSTRAINT [PK_Tarih] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Not]    Script Date: 17/06/2024 23:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Not](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vize1] [float] NULL,
	[Vize2] [float] NULL,
	[Final] [float] NULL,
	[GeçtiMiKaldiMi] [bit] NULL,
	[OgrId] [int] NULL,
	[DersId] [int] NULL,
 CONSTRAINT [PK_Not] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 17/06/2024 23:39:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](100) NULL,
	[No] [varchar](11) NULL,
	[Bolum] [varchar](50) NULL,
	[Mail] [varchar](100) NULL,
	[Tel] [nchar](11) NULL,
	[Address] [varchar](100) NULL,
	[Sifre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [AdSoyad], [Username], [Password]) VALUES (1, N'Kaan Demirtaş', N'bro', N'123')
INSERT [dbo].[Admin] ([Id], [AdSoyad], [Username], [Password]) VALUES (2, N'admin', N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([Id], [DersAdı], [OgrId]) VALUES (7, N'Web Programlama', 1013)
INSERT [dbo].[Ders] ([Id], [DersAdı], [OgrId]) VALUES (8, N'Görsel Programlama', 1013)
INSERT [dbo].[Ders] ([Id], [DersAdı], [OgrId]) VALUES (9, N'Web Programlama', 2012)
INSERT [dbo].[Ders] ([Id], [DersAdı], [OgrId]) VALUES (10, N'Görsel Programlama', 2012)
INSERT [dbo].[Ders] ([Id], [DersAdı], [OgrId]) VALUES (11, N'İşletim Sistemleri', 2012)
SET IDENTITY_INSERT [dbo].[Ders] OFF
GO
SET IDENTITY_INSERT [dbo].[Duyuru] ON 

INSERT [dbo].[Duyuru] ([Id], [Baslik], [Icerik], [Tarih]) VALUES (1008, N'Final Sinavi Hk', N'Yüksekokulumuz 2023-2024 Bahar Dönemi Final Sinavlari, Akademik Takvimimizde daha önce duyuruldugu üzere, 22-23 Haziran 2024 tarihlerinde, Yüksekokulumuzun bulundugu il olan Edirne’de, Trakya Üniversitesi Prof.Dr. Ahmet Karadeniz Yerleskesinde, Mühendislik Fakültesi Dersliklerinde yapilacaktir.', CAST(N'2024-06-09T01:11:10.817' AS DateTime))
SET IDENTITY_INSERT [dbo].[Duyuru] OFF
GO
SET IDENTITY_INSERT [dbo].[Not] ON 

INSERT [dbo].[Not] ([Id], [Vize1], [Vize2], [Final], [GeçtiMiKaldiMi], [OgrId], [DersId]) VALUES (6, 75, 80, 65, 1, 1013, 7)
INSERT [dbo].[Not] ([Id], [Vize1], [Vize2], [Final], [GeçtiMiKaldiMi], [OgrId], [DersId]) VALUES (7, 80, 90, 75, 1, 1013, 8)
INSERT [dbo].[Not] ([Id], [Vize1], [Vize2], [Final], [GeçtiMiKaldiMi], [OgrId], [DersId]) VALUES (8, 65, 75, 80, 0, 2012, 7)
INSERT [dbo].[Not] ([Id], [Vize1], [Vize2], [Final], [GeçtiMiKaldiMi], [OgrId], [DersId]) VALUES (9, 77, 85, 62, 1, 2012, 8)
INSERT [dbo].[Not] ([Id], [Vize1], [Vize2], [Final], [GeçtiMiKaldiMi], [OgrId], [DersId]) VALUES (10, 35, 45, 40, 1, 1013, 11)
SET IDENTITY_INSERT [dbo].[Not] OFF
GO
SET IDENTITY_INSERT [dbo].[Ogrenci] ON 

INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [No], [Bolum], [Mail], [Tel], [Address], [Sifre]) VALUES (1013, N'Serkan Sercan YILDIRIM', N'37063725250', N'Bilgisayar Programciligi', N'ssercanyildirim@trakya.edu.tr', N'5333946778 ', N'Sultangazi/Istanbul', N'5717336')
INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [No], [Bolum], [Mail], [Tel], [Address], [Sifre]) VALUES (2012, N'Kaan Demirtas', N'12345678912', N'Bilgisayar', N'kaan', N'5457440325 ', N'Ankara', N'123456')
INSERT [dbo].[Ogrenci] ([Id], [AdSoyad], [No], [Bolum], [Mail], [Tel], [Address], [Sifre]) VALUES (2013, N'Kaan Demirtas', N'12345645645', N'Bilisim', N'Kaan', N'5457878877 ', N'Ankara', N'12345')
SET IDENTITY_INSERT [dbo].[Ogrenci] OFF
GO
ALTER TABLE [dbo].[Duyuru] ADD  CONSTRAINT [DF_Tarih_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Ders]  WITH CHECK ADD  CONSTRAINT [FK_Ders_Ogrenci] FOREIGN KEY([OgrId])
REFERENCES [dbo].[Ogrenci] ([Id])
GO
ALTER TABLE [dbo].[Ders] CHECK CONSTRAINT [FK_Ders_Ogrenci]
GO
ALTER TABLE [dbo].[Not]  WITH CHECK ADD  CONSTRAINT [FK_Not_Ders] FOREIGN KEY([DersId])
REFERENCES [dbo].[Ders] ([Id])
GO
ALTER TABLE [dbo].[Not] CHECK CONSTRAINT [FK_Not_Ders]
GO
ALTER TABLE [dbo].[Not]  WITH CHECK ADD  CONSTRAINT [FK_Not_Ogrenci] FOREIGN KEY([OgrId])
REFERENCES [dbo].[Ogrenci] ([Id])
GO
ALTER TABLE [dbo].[Not] CHECK CONSTRAINT [FK_Not_Ogrenci]
GO
USE [master]
GO
ALTER DATABASE [obssa] SET  READ_WRITE 
GO
