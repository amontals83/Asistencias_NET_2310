CREATE PROC EliminarPersonal
@Id_personal int
AS
UPDATE Personal SET Estado = 'Eliminado' WHERE Id_personal = @Id_personal