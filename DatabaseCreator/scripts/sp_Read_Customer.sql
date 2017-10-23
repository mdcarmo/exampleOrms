
CREATE PROCEDURE [dbo].[sp_Read_Customers]
	@LastName NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	  SELECT [Id]
	  ,[FirstName]
	  ,[LastName]
	  ,[IsActive]
	  ,[EmailAddress]
  FROM [dbo].[Customers]
  WHERE LastName LIKE @LastName  + '%' 

END
