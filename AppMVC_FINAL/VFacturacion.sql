--Waldo TL--

Create Database VFacturacion
Go

Use VFacturacion
Go

Create Table Comprobante
(
Id int identity Primary key not null,
Cliente Varchar(50),
Igv decimal,
Total decimal,
FechaRegistro datetime
)
Go

Create Table ComprobanteDetalle
(
Id int identity Primary key not null,
ComprobanteId Int,
ProductoId int,
Cantidad int,
PrecioUitario decimal,
Monto decimal
)
Go

Create Table Usuario
(
Id int identity Primary key not null,
Nombres Varchar(50),
Usuario Varchar(50),
Clave Varchar(50)
)
Go


--insert into Clientes select top 10 * from Neptuno..Clientes
--select top 10 * into Productos from Neptuno..Productos
--insert into Productos select top 10 * from Neptuno..Productos

select * from Clientes
--truncate table Clientes
select * from Productos
--truncate table Clientes
select * from Comprobante
--truncate table Clientes
select * from ComprobanteDetalle
--truncate table Clientes

select * from Usuario
insert into Usuario values ('Jefferson T. L.','jeffer','@123456')
insert into Usuario values ('Juan Perez','jperez','123456')


--Agregar Detalle y DetalleCOmprobante
CREATE PROCEDURE [dbo].[Comprobante_Adicionar]
@Cliente nvarchar(50),
@Igv decimal,
@Total decimal,
@IdComprobante int output
AS
BEGIN

	INSERT INTO Comprobante
	VALUES
	(@Cliente,@Igv,@Total,Getdate())	  

	SET @IdComprobante = @@IDENTITY

END

Exec Comprobante_Adicionar 'Cliente 2',10,110,0


CREATE PROCEDURE [dbo].[ComprobanteDetalle_Adicionar]
@IdComprobante int,
@ProductoId int,
@Cantidad int,
@PrecioUnitario decimal,
@Monto decimal
AS
BEGIN

	INSERT INTO ComprobanteDetalle
	VALUES
	(@IdComprobante,@ProductoId,@Cantidad,@PrecioUnitario,@Monto)	 

END

Exec ComprobanteDetalle_Adicionar 3,6,20,50,500


--Listar Comprobante
CREATE PROCEDURE [dbo].[Comprobante_Listar]
AS
BEGIN
	SELECT c.Id As Codigo,c.Cliente,dc.ProductoId,p.NombreProducto,dc.Cantidad,dc.PrecioUitario,dc.Monto,c.Igv,c.Total,Convert(Varchar(10),c.FechaRegistro,103) as FechaVenta
	FROM   Comprobante c
	INNER JOIN ComprobanteDetalle dc on c.Id = dc.ComprobanteId
	INNER JOIN Productos p on p.IdProducto = dc.ProductoId
END

Exec Comprobante_Listar

--Buscar Detalle y DetalleCOmprobante x Codigo
CREATE PROCEDURE [dbo].[Comprobante_Buscar]
@IdComprobante int
AS
BEGIN
	SELECT c.Id As Codigo,c.Cliente,dc.ProductoId,p.NombreProducto,dc.Cantidad,dc.PrecioUitario,dc.Monto,c.Igv,c.Total,Convert(Varchar(10),c.FechaRegistro,103) as FechaVenta
	FROM   Comprobante c
	INNER JOIN ComprobanteDetalle dc on c.Id = dc.ComprobanteId
	INNER JOIN Productos p on p.IdProducto = dc.ProductoId
	Where c.Id = @IdComprobante
END

Exec Comprobante_Buscar 2

--Actualizar Detalle y DetalleCOmprobante
CREATE PROCEDURE [dbo].[Comprobante_Actualizar]
@IdComprobante int,
@Cliente nvarchar(50),
@Igv decimal,
@Total decimal
AS
BEGIN

	UPDATE Comprobante SET
	Cliente = @Cliente,
	Igv = @Igv,
	Total = @Total,
	FechaRegistro = GetDate()
	Where Id = @IdComprobante

END

Exec Comprobante_Actualizar 1,'Juduth Caceres',20,200

CREATE PROCEDURE [dbo].[ComprobanteDetalle_Actualizar]
@IdComprobante int,
@ProductoId int,
@Cantidad int,
@PrecioUnitario decimal,
@Monto nvarchar(20)
AS
BEGIN

	UPDATE ComprobanteDetalle SET
	ProductoId = @ProductoId,
	Cantidad = @Cantidad,
	PrecioUitario = @PrecioUnitario,
	Monto = @Monto
	Where ComprobanteId = @IdComprobante

END

Exec ComprobanteDetalle_Actualizar 1,5,10,30,220

--Elimnar Detalle y DetalleCOmprobante
CREATE PROCEDURE [dbo].[Comprobante_Eliminar]
@IdComprobante int
AS
BEGIN

	Delete From Comprobante   
	Where Id = @IdComprobante

	Delete From ComprobanteDetalle
	Where ComprobanteId = @IdComprobante

END

Exec Comprobante_Eliminar 1

--*****************************************************************************************
--Reportes
--*****************************************************************************************
--Buscar Detalle y DetalleCOmprobante x Fechas
CREATE PROCEDURE [dbo].[Comprobante_Buscar_Fechas]
@FechaIni Varchar(10),
@FechaFin Varchar(10)
AS
BEGIN
	SELECT c.Cliente,p.NombreProducto,dc.Cantidad,dc.PrecioUitario,
	SUM(dc.Monto) Monto, SUM(c.Igv) Igv,SUM(c.Total) Total,convert(varchar(10),c.FechaRegistro,103) as FechaVenta
	FROM   Comprobante c
	INNER JOIN ComprobanteDetalle dc on c.Id = dc.ComprobanteId
	INNER JOIN Productos p on p.IdProducto = dc.ProductoId
	Where convert(date,c.FechaRegistro) Between convert(date,@FechaIni) And convert(date,@FechaFin)
	Group By c.Cliente,p.NombreProducto,dc.Cantidad,dc.PrecioUitario,
	c.FechaRegistro
END

Exec Comprobante_Buscar_Fechas '2017/08/20','2017/08/30'


--Buscar Detalle y DetalleCOmprobante x Producto
CREATE PROCEDURE [dbo].[Comprobante_Buscar_Prod]
@Producto Varchar(50)
AS
BEGIN
	SELECT p.NombreProducto as Producto,dc.Cantidad,dc.PrecioUitario,dc.Monto,c.Igv,c.Total,convert(varchar(10),c.FechaRegistro,103) as FechaVenta
	FROM   Comprobante c
	INNER JOIN ComprobanteDetalle dc on c.Id = dc.ComprobanteId
	INNER JOIN Productos p on p.IdProducto = dc.ProductoId
	Where p.NombreProducto like @Producto + '%'
END

Exec Comprobante_Buscar_Prod 'Cer'


--Listar Producto
CREATE PROCEDURE [dbo].[Producto_Listar]
AS
BEGIN
	SELECT IdProducto, NombreProducto
	FROM   Productos
END

Exec Producto_Listar


CREATE PROCEDURE [dbo].[UsuarioValidar]
@Usuario varchar(20),
@Clave varchar(20)
AS
BEGIN
	SELECT *  
	FROM   Usuario
	where Usuario = @Usuario And Clave = @Clave
END

Exec UsuarioValidar 'rarmas','@123456'


--delete from Comprobante where id in (2,3,4,5,8)