IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'OptixServiceServiceAPIContext')
BEGIN
    PRINT 'Database already exists. Exiting...'
END
ELSE

begin

CREATE DATABASE [OptixServiceServiceAPIContext]
 
USE [OptixServiceServiceAPIContext]
GO
/****** Object:  Table [dbo].[Tbl_Movies]    Script Date: 29/10/2024 08:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[ReleaseDate] [datetime] NULL,
	[Overview] [nvarchar](200) NULL,
	[Popularity] [decimal](18, 6) NULL,
	[Vote_Count] [int] NULL,
	[Vote_Average] [decimal](18, 6) NULL,
	[Original_Language] [nvarchar](5) NULL,
	[Genre] [nvarchar](5) NULL,
	[Poster_Url] [nvarchar](150) NULL,
 CONSTRAINT [PK_Tbl_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_MoviesActors]    Script Date: 29/10/2024 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_MoviesActors](
	[ActorID] [int] IDENTITY(10000,1) NOT NULL,
	[ActorName] [nvarchar](50) NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_Tbl_MoviesActors] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_MoviesGenre]    Script Date: 29/10/2024 08:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_MoviesGenre](
	[GenreID] [int] IDENTITY(10000,1) NOT NULL,
	[Genre] [nvarchar](5) NULL,
 CONSTRAINT [PK_Tbl_MoviesGenre] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Movies]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Movies_Tbl_MoviesGenre] FOREIGN KEY([Genre])
REFERENCES [dbo].[Tbl_MoviesGenre] ([Genre])
GO
ALTER TABLE [dbo].[Tbl_Movies] CHECK CONSTRAINT [FK_Tbl_Movies_Tbl_MoviesGenre]
GO
ALTER TABLE [dbo].[Tbl_MoviesActors]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_MoviesActors_Tbl_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Tbl_Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Tbl_MoviesActors] CHECK CONSTRAINT [FK_Tbl_MoviesActors_Tbl_Movies]
GO


end