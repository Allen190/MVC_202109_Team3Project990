USE [master]
GO
/****** Object:  Database [db990Demo]    Script Date: 2021/8/26 下午 11:44:18 ******/
CREATE DATABASE [db990Demo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db990Demo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db990Demo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db990Demo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db990Demo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db990Demo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db990Demo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db990Demo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db990Demo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db990Demo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db990Demo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db990Demo] SET ARITHABORT OFF 
GO
ALTER DATABASE [db990Demo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db990Demo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db990Demo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db990Demo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db990Demo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db990Demo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db990Demo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db990Demo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db990Demo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db990Demo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db990Demo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db990Demo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db990Demo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db990Demo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db990Demo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db990Demo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db990Demo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db990Demo] SET RECOVERY FULL 
GO
ALTER DATABASE [db990Demo] SET  MULTI_USER 
GO
ALTER DATABASE [db990Demo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db990Demo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db990Demo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db990Demo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db990Demo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db990Demo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db990Demo', N'ON'
GO
ALTER DATABASE [db990Demo] SET QUERY_STORE = OFF
GO
USE [db990Demo]
GO
/****** Object:  Table [dbo].[tActivity]    Script Date: 2021/8/26 下午 11:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tActivity](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fName] [nvarchar](50) NULL,
	[fRestaurant] [nvarchar](50) NULL,
	[fAddress] [nvarchar](50) NULL,
	[fConfirmTime] [datetime] NULL,
	[fActivityTime] [datetime] NULL,
	[fInfo] [nvarchar](100) NULL,
	[fPCount] [int] NULL,
	[fGender] [int] NULL,
	[fCheckout] [int] NULL,
	[fHostId] [int] NULL,
	[fPoint] [int] NULL,
	[fPrice] [nvarchar](50) NULL,
	[fRInfo] [nvarchar](50) NULL,
	[fState] [int] NULL,
	[fImag] [nvarchar](50) NULL,
 CONSTRAINT [PK_tActivity] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tChatRoom]    Script Date: 2021/8/26 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChatRoom](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fActivityId] [int] NULL,
	[fMemberId] [int] NULL,
	[fDate] [nvarchar](50) NULL,
	[fMessage] [nvarchar](50) NULL,
 CONSTRAINT [PK_tChatRoom] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2021/8/26 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMember](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fUserId] [nvarchar](50) NULL,
	[fPWd] [nvarchar](50) NULL,
	[fName] [nvarchar](50) NULL,
	[fEmail] [nvarchar](50) NULL,
	[fTel] [nvarchar](10) NULL,
	[fGender] [nvarchar](50) NULL,
	[fAge] [nvarchar](50) NULL,
	[fAddress] [nvarchar](50) NULL,
	[fImg] [nvarchar](50) NULL,
	[fHobby] [nvarchar](50) NULL,
	[fFollow] [nvarchar](50) NULL,
	[fPoint] [int] NULL,
	[fLock] [nvarchar](50) NULL,
	[fRePwd] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tRestaurant]    Script Date: 2021/8/26 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tRestaurant](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fRId] [nvarchar](50) NULL,
	[fName] [nvarchar](50) NULL,
	[fAddress] [nvarchar](50) NULL,
	[fTel] [nchar](10) NULL,
	[fPrice] [nvarchar](50) NULL,
	[fDiscount] [nvarchar](50) NULL,
	[fData] [nvarchar](50) NULL,
	[fImg] [nvarchar](50) NULL,
	[fInfo] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSignUp]    Script Date: 2021/8/26 下午 11:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSignUp](
	[fId] [int] IDENTITY(1,1) NOT NULL,
	[fDate] [nvarchar](50) NULL,
	[fMember] [int] NULL,
	[fActivity] [int] NULL,
	[fState] [int] NULL,
	[fmessage] [nvarchar](50) NULL,
 CONSTRAINT [PK_tSignUp] PRIMARY KEY CLUSTERED 
(
	[fId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tActivity] ON 

INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (53, N'活動測試1', N'我家牛排', N'高雄市前鎮區中華五路789號', CAST(N'2021-09-05T18:28:00.000' AS DateTime), CAST(N'2021-09-06T18:28:00.000' AS DateTime), N'限女性喔~我請客!!', 2, 3, 3, 21, NULL, N'300~2000', NULL, 3, NULL)
INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (54, N'測試活動2', N'那一間義大利麵', N'高雄市苓雅區中華五路789號', CAST(N'2021-09-03T18:48:00.000' AS DateTime), CAST(N'2021-09-04T18:48:00.000' AS DateTime), N'揪是要一起吃飯聊天!!!', 2, 1, 2, 21, NULL, N'300~1000', NULL, 1, NULL)
INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (55, N'活動測試1', N'我家牛排', N'高雄市前鎮區中華五路789號', CAST(N'2021-09-10T19:05:00.000' AS DateTime), CAST(N'2021-09-11T19:05:00.000' AS DateTime), N'123123', 3, 2, 2, 21, NULL, N'300~1000', NULL, 2, NULL)
INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (56, N'活動測試4', N'夜泰美 左營富國店', N'高雄市左營區富國路129號', CAST(N'2021-09-09T19:19:00.000' AS DateTime), CAST(N'2021-09-10T19:19:00.000' AS DateTime), N'就是要泰式~~', 3, 1, 2, 22, NULL, N'300~2000', NULL, 1, NULL)
INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (57, N'活動測試5', N'碳佐麻里(高美店)', N'高雄市鼓山區美術東四路562號', CAST(N'2021-09-09T19:26:00.000' AS DateTime), CAST(N'2021-09-11T19:26:00.000' AS DateTime), N'吃飯聊天~~', 2, 2, 2, 22, NULL, N'300~2000', NULL, 1, NULL)
INSERT [dbo].[tActivity] ([fId], [fName], [fRestaurant], [fAddress], [fConfirmTime], [fActivityTime], [fInfo], [fPCount], [fGender], [fCheckout], [fHostId], [fPoint], [fPrice], [fRInfo], [fState], [fImag]) VALUES (58, N'活動測試6', N'DD餐酒館', N'高雄市鳳山區中正五路789號', CAST(N'2021-09-10T19:40:00.000' AS DateTime), CAST(N'2021-09-11T19:40:00.000' AS DateTime), N'揪起來!!!!', 4, 1, 2, 23, NULL, N'300~2000', NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[tActivity] OFF
GO
SET IDENTITY_INSERT [dbo].[tChatRoom] ON 

INSERT [dbo].[tChatRoom] ([fId], [fActivityId], [fMemberId], [fDate], [fMessage]) VALUES (1, 46, 21, N'2021/8/20 上午 02:26:12', N'嗨~大家好')
INSERT [dbo].[tChatRoom] ([fId], [fActivityId], [fMemberId], [fDate], [fMessage]) VALUES (2, 46, 22, N'2021/8/20 上午 02:27:12', N'你好你好記得來吃飯喔!!!')
INSERT [dbo].[tChatRoom] ([fId], [fActivityId], [fMemberId], [fDate], [fMessage]) VALUES (3, 46, 22, N'2021/8/26 下午 03:28:15', N'大家好，天氣多變記得帶傘')
INSERT [dbo].[tChatRoom] ([fId], [fActivityId], [fMemberId], [fDate], [fMessage]) VALUES (4, 53, 21, N'2021/8/26 下午 11:26:49', N'嗨嗨嗨大家好')
SET IDENTITY_INSERT [dbo].[tChatRoom] OFF
GO
SET IDENTITY_INSERT [dbo].[tMember] ON 

INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (9, N'tom', N'123', N'管理者', N'J123@gmail.com', N'0970123121', N'男', N'999', NULL, N'99.png', N'看書玩遊戲打籃球', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (21, N'a123', N'123', N'測試者1', N'123@hotmail.com', N'0970123456', N'男', N'25', NULL, N'001.jpg', N'看書', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (22, N'b123', N'123', N'測試者2', N'456@hotmail.com', N'0970123123', N'男', N'29', NULL, N'002.jpg', N'看書。玩遊戲。旅遊。', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (23, N'c123', N'123', N'測試者3', N'789@hotmail.com', N'0970123789', N'女', N'31', NULL, N'006.jpg', N'看電影，追劇，旅遊。', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (24, N'd123', N'123', N'測試者4', N'123123@hotmail.com', N'0970111111', N'女', N'22', NULL, N'003.jpg', N'旅遊。', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (25, N'e123', N'123', N'測試者5', N'11111@gmail.com', N'0970182334', N'男', N'24', NULL, N'99.png', N'看電影 打籃球 游泳', NULL, NULL, NULL, N'123')
INSERT [dbo].[tMember] ([fId], [fUserId], [fPWd], [fName], [fEmail], [fTel], [fGender], [fAge], [fAddress], [fImg], [fHobby], [fFollow], [fPoint], [fLock], [fRePwd]) VALUES (26, N'f123', N'123', N'測試者6', N'1212@gmail.com', N'0980101900', N'女', N'30', NULL, N'99.png', N'追劇 逛街', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tMember] OFF
GO
SET IDENTITY_INSERT [dbo].[tRestaurant] ON 

INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (3, N'R1', N'西堤牛排', N'高雄市新興區中山二路472號2樓', N'07-2820712', N'899~3999', N'兩人同行95折', N'午間：11:30~14:30 晚間：17:30~22:00', N'03.jpg', N'https://www.tasty.com.tw/index.html')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (16, NULL, N'碳佐麻里(高美店)', N'高雄市鼓山區美術東四路562號', N'07-5526555', N'899~3999', N'兩人同行95折', N'平日11:30AM-24:00 假日11:00AM-24:00', N'02.jpg', N'https://www.crun.com.tw')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (17, NULL, N'海底撈火鍋 高雄大遠百店', N'高雄市苓雅區三多四路21號8樓', N'07-3383073', N'899~3999', N'打卡送一樣菜', N'平日11:30AM-24:00PM 假日11:00AM-24:00', N'03.jpg', N'https://www.haidilao.com/zh/')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (18, NULL, N'Pizza Hot高雄瑞隆店', N' 高雄市前鎮區瑞隆路535號', N'07-7259838', N'899~1990', N'自取買大送大', N'平日11:30AM-24:00PM 假日11:00AM-24:00', N'04.jpg', N'https://www.pizzahut.com.tw/?fm=hbgtoh')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (19, NULL, N'八方雲集(高雄榮總店)', N'高雄市左營區榮總路143號', N'07-3420348', N'100~500', N'無', N'周一至周日09:00AM-20:00PM ', N'05.jpg', N'https://www.8way.com.tw/#/')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (20, NULL, N'肯德基(高雄十全餐廳)', N' 高雄市三民區十全一路161號1樓', N'07-3159845', N'199~1000', N'使用網路優惠卷!!', N'平日10:00-23:00假日09:00-23:00', N'06.png', N'https://www.kfcclub.com.tw/')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (21, NULL, N'Mövenpick Café夢時代', N'高雄市前鎮區中華五路789號8F', N'07-9705188', N'10000', N'官網早鳥優惠', N'午餐 12:00 – 15:00・晚餐 18:00 – 22:00 ', N'08.jpg', N'https://www.silks-club.com/zh-tw/restaurants/8/7')
INSERT [dbo].[tRestaurant] ([fId], [fRId], [fName], [fAddress], [fTel], [fPrice], [fDiscount], [fData], [fImg], [fInfo]) VALUES (22, NULL, N'Nooice 餐酒館', N'高雄市前鎮區桂林街132號', N'07-3388388', N'300~2000', N'外帶便當95折', N'下午6:00 - 上午1:00 假日下午6:00 - 上午2:00', N'20190425005953_23.jpg', N'https://www.facebook.com/nooice132')
SET IDENTITY_INSERT [dbo].[tRestaurant] OFF
GO
SET IDENTITY_INSERT [dbo].[tSignUp] ON 

INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (9, N'20210817153253', 10, 26, 1, N'    選我選我選我')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (10, N'20210817160359', 11, 26, 1, N'    ')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (11, N'20210818032819', 11, 31, 1, N'    選我選我選我~~~~~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (12, N'20210818033201', 10, 32, 1, N'    選我憶起吃飯:)')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (13, N'20210818034845', 12, 32, 1, N'    拜託拜託選我選我!!!!!')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (14, N'20210818034902', 12, 31, 1, N'    可以選我嗎!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (15, N'20210818133708', 9, 35, 1, N'  嗨嗨嗨 選我選我')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (16, N'20210818165931', 17, 33, 1, N'    111111')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (17, N'20210820020853', 22, 46, 2, N'    選我選我選我')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (18, N'20210820021315', 23, 46, 2, N'    可以選擇我嗎!!!拜託拜託~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (19, N'20210820021747', 24, 48, 2, N'    可以選我喔~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (20, N'20210820021815', 23, 47, 1, N'    yayaaya我在這!!!')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (21, N'20210820022059', 22, 48, 1, N'    選我一起吃飯')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (22, N'20210820022254', 22, 49, 2, N'    加1選我~~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (23, N'20210820022346', 24, 46, 4, N'    這時間我可以一起吃飯~選我選我!!')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (24, N'20210823155022', 24, 47, 1, N'    11111')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (25, N'20210823155044', 24, 51, 2, N'    121212')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (26, N'20210824132535', 21, 47, 1, N'    11111')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (27, N'20210824132712', 25, 49, 2, N'    11111')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (28, N'20210824132746', 25, 47, 1, N'    111111')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (29, N'20210826200749', 21, 56, 1, N'    選我選我選我~~~
')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (30, N'20210826224004', 21, 57, 1, N'選我選我!您最佳選擇')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (31, N'20210826224155', 21, 58, 1, N'您最佳選擇~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (32, N'20210826224242', 22, 54, 1, N'我是您最佳選擇~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (33, N'20210826224639', 22, 58, 1, N'選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (34, N'20210826224707', 23, 53, 2, N'123選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (35, N'20210826224725', 23, 54, 1, N'選我選我選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (36, N'20210826224741', 23, 56, 1, N'我是您最佳選擇~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (37, N'20210826224842', 25, 54, 1, N'選我選我選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (38, N'20210826224853', 25, 56, 1, N'選我選我!您最佳選擇')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (39, N'20210826224904', 25, 57, 1, N'選我選我!您最佳選擇')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (40, N'20210826224921', 25, 58, 1, N'123選我!!!!~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (41, N'20210826225003', 26, 53, 2, N'123456~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (42, N'20210826225012', 26, 54, 1, N'123選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (43, N'20210826225019', 26, 56, 1, N'選我選我選我選我~~~')
INSERT [dbo].[tSignUp] ([fId], [fDate], [fMember], [fActivity], [fState], [fmessage]) VALUES (44, N'20210826225032', 26, 58, 1, N'選我選我~~~')
SET IDENTITY_INSERT [dbo].[tSignUp] OFF
GO
USE [master]
GO
ALTER DATABASE [db990Demo] SET  READ_WRITE 
GO
