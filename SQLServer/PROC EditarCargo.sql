CREATE PROC EditarCargo
@Id int,
@Cargo varchar(max),
@SueldoPorhora numeric(18,2)
AS
IF EXISTS(SELECT Cargo FROM Cargo WHERE Cargo = @Cargo AND Id_cargo<>@Id)
RAISERROR('Ya existe un cargo con este nombre. Ingrese de nuevo', 16,1)
ELSE
UPDATE Cargo SET Cargo=@Cargo, SueldoPorHora=@SueldoPorhora
WHERE Id_cargo = @Id