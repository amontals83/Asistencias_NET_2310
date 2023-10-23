CREATE PROC InsertarPersonal
@Nombre varchar(max),
@DNI varchar(max),
@Pais varchar(max),
@Id_cargo int,
@SueldoPorHora numeric(18,2)
AS
DECLARE @Estado varchar(MAX)
DECLARE @Codigo varchar(MAX)
DECLARE @Id_personal int --como el 'Codigo' va a representar el 'Id_personal', lo declaramos para que no se pida en la llamada del procedimiento
SET @Estado = 'ACTIVO' --por defecto damos un valor al 'Estado'
SET @Codigo = '-'

IF Exists(SELECT DNI FROM Personal WHERE DNI=@DNI) --condicional para comprobar si existe el 'dni'
RAISERROR('Ya existe un registro con esta identificación', 16,1) --generamos un error con un codigo '16,1'
ELSE
INSERT INTO Personal
VALUES(
	@Nombre,
	@DNI,
	@Pais,
	@Id_cargo,
	@SueldoPorHora,
	@Estado,
	@Codigo)
SELECT @Id_personal=SCOPE_IDENTITY()--funcion para capturar el id recien creado
UPDATE Personal SET Codigo=@Id_personal