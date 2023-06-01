USE [master]
GO
/****** Object:  Database [CallApp]    Script Date: 6/1/2023 6:29:13 PM ******/
CREATE DATABASE [CallApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CallApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CallApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CallApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CallApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CallApp] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CallApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CallApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CallApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CallApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CallApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CallApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [CallApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CallApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CallApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CallApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CallApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CallApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CallApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CallApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CallApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CallApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CallApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CallApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CallApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CallApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CallApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CallApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CallApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CallApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CallApp] SET  MULTI_USER 
GO
ALTER DATABASE [CallApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CallApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CallApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CallApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CallApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CallApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CallApp] SET QUERY_STORE = ON
GO
ALTER DATABASE [CallApp] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CallApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/1/2023 6:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 6/1/2023 6:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NOT NULL,
	[PersonalNumber] [nchar](11) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/1/2023 6:29:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](256) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Profiles_UserId]    Script Date: 6/1/2023 6:29:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Profiles_UserId] ON [dbo].[Profiles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/1/2023 6:29:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_UserName]    Script Date: 6/1/2023 6:29:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [CallApp] SET  READ_WRITE 
GO
