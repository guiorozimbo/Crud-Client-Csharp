USE [master]
GO
/****** Object:  Database [Projeto-Moveleiro]    Script Date: 11/12/2022 21:00:44 ******/
CREATE DATABASE [Projeto-Moveleiro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Projeto-Moveleiro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Projeto-Moveleiro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Projeto-Moveleiro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Projeto-Moveleiro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Projeto-Moveleiro] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Projeto-Moveleiro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Projeto-Moveleiro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ARITHABORT OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Projeto-Moveleiro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Projeto-Moveleiro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Projeto-Moveleiro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Projeto-Moveleiro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Projeto-Moveleiro] SET  MULTI_USER 
GO
ALTER DATABASE [Projeto-Moveleiro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Projeto-Moveleiro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Projeto-Moveleiro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Projeto-Moveleiro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Projeto-Moveleiro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Projeto-Moveleiro] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Projeto-Moveleiro] SET QUERY_STORE = OFF
GO
USE [Projeto-Moveleiro]
GO
/****** Object:  Table [dbo].[tblCliente]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sexo] [bit] NOT NULL,
	[LimiteCompra] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspClienteAlter]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[uspClienteAlter]
	@IdCliente int,
	@nome varchar(100),
	@DataNascimento datetime,
	@Sexo bit,
	@LimiteCompra decimal(18,2)
as
begin
	update
	tblCliente
	set
	Nome = @nome,
	DataNascimento =@DataNascimento,
	Sexo=@Sexo,
	LimiteCompra=@LimiteCompra
	where
	IdCliente = @IdCliente

	select @IdCliente as retorno
end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorId]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[uspClienteConsultarPorId]
	@IdCliente int
as 
begin

	select 
	IdCliente,
	nome,
	DataNascimento,
	Sexo,
	LimiteCompra
	from
	tblCliente
	where
	IdCliente=@IdCliente
end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteConsultarPorNome]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[uspClienteConsultarPorNome]
	@Nome varchar(100)
as 
begin

	select 
	IdCliente,
	nome,
	DataNascimento,
	Sexo,
	LimiteCompra
	from
	tblCliente
	where
	Nome like '%' + @Nome + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteExcluir]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspClienteExcluir]
	@IdCliente int
as 
begin

	delete from
	tblCliente
	where 
	IdCliente = @IdCliente

	select @IdCliente as Retorno
end
GO
/****** Object:  StoredProcedure [dbo].[uspClienteInserir]    Script Date: 11/12/2022 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspClienteInserir]
	@nome varchar(100),
	@DataNascimento datetime,
	@Sexo bit,
	@LimiteCompra decimal(18,2)
as
begin

insert into tblCliente
(
	Nome,
	DataNascimento,
	Sexo,
	LimiteCompra
)
values
(
@nome,
@DataNascimento,
@Sexo,
@LimiteCompra
)
select @@IDENTITY as Retorno

end
GO
USE [master]
GO
ALTER DATABASE [Projeto-Moveleiro] SET  READ_WRITE 
GO
