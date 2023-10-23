CREATE PROC EditarPersonal
@Id_personal int,
@Nombre varchar(max),
@DNI varchar(max),
@Pais varchar(max),
@Id_cargo int,
@SueldoPorHora numeric(18,2)
AS
IF Exists(SELECT DNI FROM Personal WHERE DNI = @DNI AND Id_personal <> @Id_personal)
RAISERROR('Ya existe un registro con ese DNI',16,1)
ELSE
UPDATE Personal
SET Nombre = @Nombre, DNI = @DNI, Pais = @Pais, Id_cargo = @Id_cargo, SueldoPorHora = @SueldoPorHora
WHERE Id_personal = @Id_personal