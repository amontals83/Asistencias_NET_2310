USE [ASISTENCIAS]
GO
/****** Object:  StoredProcedure [dbo].[MostrarPersonal]    Script Date: 23/10/2023 2:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[MostrarPersonal] --mostraremos X numero de personas en la paginacion determinado por el 'desde' y 'hasta'
@Desde int,
@Hasta int
AS
SET NOCOUNT ON; --enumeramos cada una de las filas para asi no contar con el 'Id_personal' por si se ha borrado alguno
SELECT
Id_personal, Nombre, DNI, SueldoPorHora, Cargo, Id_cargo, Estado, Codigo
FROM
(SELECT Id_personal, Nombre, DNI, Personal.SueldoPorHora, Cargo.Cargo, Personal.Id_cargo, Estado, Codigo,
ROW_NUMBER() OVER(ORDER BY Id_personal) 'Numero_de_fila'
FROM Personal
INNER JOIN Cargo ON Cargo.Id_cargo = Personal.Id_cargo)
AS Paginado
WHERE 
(Paginado.Numero_de_fila >= @Desde) 
AND 
(Paginado.Numero_de_fila <= @Hasta)