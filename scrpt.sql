
GO
/****** Object:  Table [dbo].[Tipo_Producto]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Tipo_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[Medida_Producto]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medida_Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
    [detalle] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Medida_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[Producto]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_tipo_producto] [int]NOT NULL,
	[id_medida_producto] [int]NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[precio_compra] [int]NOT NULL,
	[cantidad_producto] [int]NOT NULL,
	[cantidad_disponible] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Tipo] FOREIGN KEY([id_tipo_producto])
REFERENCES [dbo].[Tipo_Producto] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Tipo]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Medida] FOREIGN KEY([id_medida_producto])
REFERENCES [dbo].[Medida_Producto] ([id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Medida]
GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[Procedimiento]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Procedimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
    [fecha] [Date] NULL,
 CONSTRAINT [PK_Procedimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[Detalle_Procedimiento]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detalle_Procedimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_procedimiento] [int]NOT NULL,
	[id_producto] [int]NOT NULL,
	[cantidad] [int]NOT NULL,
	[valor_cobrado] [int] NULL,
 CONSTRAINT [PK_Detalle_Procedimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Detalle_Procedimiento]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Procedimiento_Procedimiento] FOREIGN KEY([id_procedimiento])
REFERENCES [dbo].[Procedimiento] ([id])
GO
ALTER TABLE [dbo].[Detalle_Procedimiento] CHECK CONSTRAINT [FK_Detalle_Procedimiento_Procedimiento]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Detalle_Procedimiento]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Procedimiento_Producto] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Producto] ([id])
GO
ALTER TABLE [dbo].[Detalle_Procedimiento] CHECK CONSTRAINT [FK_Detalle_Procedimiento_Producto]
GO
SET ANSI_PADDING OFF

GO
/****** Object:  Table [dbo].[Usuario]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
    [correo] [varchar](100) NULL,
    [contrasenia] [varchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF

SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT INTO [dbo].[Usuario] ([id], [nombre], [correo], [contrasenia]) VALUES (1, N'Elvis Jose Sanchez Pineda', N'ejsp81@hotmail.com', N'COTONIELA')
INSERT INTO [dbo].[Usuario] ([id], [nombre], [correo], [contrasenia]) VALUES (2, N'Monica Juldrey Perez Flor', N'juldrey@hotmail.com', N'JULDREY')
SET IDENTITY_INSERT [dbo].[Usuario] OFF

