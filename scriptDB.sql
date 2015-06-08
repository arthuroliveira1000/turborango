USE [TurboRango_dev]
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 03/06/2015 16:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Site] [nvarchar](50) NULL,
	[Telefone] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Localizacao]    Script Date: 03/06/2015 16:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localizacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Logradouro] [nvarchar](50) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Restaurante]    Script Date: 03/06/2015 16:24:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Capacidade] [int] NOT NULL,
	[Nome] [nvarchar](50) NULL,
	[Categoria] [nvarchar](50) NOT NULL,
	[ContatoId] [int] NOT NULL,
	[LocalizacaoId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Restaurante]  WITH CHECK ADD  CONSTRAINT [FK_Restaurante_Contato] FOREIGN KEY([ContatoId])
REFERENCES [dbo].[Contato] ([Id])
GO
ALTER TABLE [dbo].[Restaurante] CHECK CONSTRAINT [FK_Restaurante_Contato]
GO
ALTER TABLE [dbo].[Restaurante]  WITH CHECK ADD  CONSTRAINT [FK_Restaurante_Localizacao] FOREIGN KEY([LocalizacaoId])
REFERENCES [dbo].[Localizacao] ([Id])
GO
ALTER TABLE [dbo].[Restaurante] CHECK CONSTRAINT [FK_Restaurante_Localizacao]
GO