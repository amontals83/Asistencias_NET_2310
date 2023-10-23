CREATE PROC BuscarPersonal
@Desde int,
@Hasta int,
@Buscador varchar(50)
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
AND
(Nombre + DNI LIKE '%' + @Buscador + '%')