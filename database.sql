USE [Crud1]
GO
/****** Object:  Table [dbo].[productss]    Script Date: 25-04-2023 02:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[producttitle] [nchar](100) NULL,
	[image] [nchar](1000) NULL,
	[stock] [int] NULL,
	[price] [nchar](10) NULL,
 CONSTRAINT [PK_productss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Deleteproduct]    Script Date: 25-04-2023 02:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Deleteproduct]  
(    
 @Id integer    
)    
as     
Begin    
 Delete productss where Id=@Id;    
End
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateproducts]    Script Date: 25-04-2023 02:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[InsertUpdateproducts]    
(    
@Id integer,    
@producttitle nvarchar(50),    
@image nvarchar(1000),    
@stock int,    
@price int,    
@Action varchar(10)    
)    
As    
Begin    
if @Action='Insert'    
Begin    
 Insert into productss(producttitle,[image],stock,price) values(@producttitle,@image,@stock,@price);    
End    
if @Action='Update'    
Begin    
 Update productss set producttitle=@producttitle,stock=@stock,[image]=@image,price=@price where Id=@Id;    
End      
End  
GO
/****** Object:  StoredProcedure [dbo].[Selectproduct]    Script Date: 25-04-2023 02:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create Procedure [dbo].[Selectproduct]
as     
Begin    
Select * from productss;    
End 
GO
