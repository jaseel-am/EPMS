USE [EPMS]
GO
/****** Object:  Table [dbo].[Tbl_Wells]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Wells](
	[Well_Id] [int] IDENTITY(1,1) NOT NULL,
	[Well_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_Wells] PRIMARY KEY CLUSTERED 
(
	[Well_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tbl_Wells_Details]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Wells_Details](
	[Well_Details_Id] [int] IDENTITY(1,1) NOT NULL,
	[Well_Id] [int] NULL,
	[X_Val] [decimal](18, 3) NULL,
	[Y_Val] [decimal](18, 3) NULL,
	[Z_Val] [decimal](18, 3) NULL,
PRIMARY KEY CLUSTERED 
(
	[Well_Details_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[GetWellDetails]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetWellDetails]
@FirstWellId INT
AS

SELECT 
	   W.Well_Name,
	   WD.Well_Details_Id
      ,WD.X_Val
      ,WD.Y_Val
      ,WD.Z_Val
FROM Tbl_Wells_Details AS WD
INNER JOIN Tbl_Wells W ON WD.Well_Id=W.Well_Id
WHERE WD.Well_Id=@FirstWellId

SELECT 
       W.Well_Name,
	   WD.Well_Details_Id
      ,WD.X_Val
      ,WD.Y_Val
      ,WD.Z_Val
FROM Tbl_Wells_Details AS WD
INNER JOIN Tbl_Wells W ON WD.Well_Id=W.Well_Id --WHERE WD.Well_Id!=@FirstWellId
GO
/****** Object:  StoredProcedure [dbo].[GetWells]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetWells]
AS
SELECT  [Well_Id]
      ,[Well_Name]
  FROM [Lexel].[dbo].[Tbl_Wells]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Truncate_Table]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Sp_Truncate_Table]
AS
TRUNCATE TABLE M_Calcimetry
TRUNCATE TABLE M_DrillingParameter
TRUNCATE TABLE M_HcIndicator
TRUNCATE TABLE M_InterPretedLithology
TRUNCATE TABLE M_LithologyPercent
TRUNCATE TABLE M_Rop
GO
/****** Object:  StoredProcedure [dbo].[WellDetailsInsUpDel]    Script Date: 07/12/2018 05:03:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WellDetailsInsUpDel]


@Well_Name NVARCHAR(50),
@X_Val decimal(18,2),
@Y_Val decimal(18,2),
@Z_Val decimal(18,2)

AS

DECLARE @WellId INT;
SET @WellId=(SELECT Well_Id FROM Tbl_Wells where  Well_Name=@Well_Name) 
IF(@WellId>0)
BEGIN

INSERT INTO Tbl_Wells_Details
           (
		    [Well_Id]
           ,[X_Val]
           ,[Y_Val]
           ,[Z_Val]
		   )
     VALUES
           (@WellId
           ,@X_Val
           ,@Y_Val
           ,@Z_Val);

END


GO
