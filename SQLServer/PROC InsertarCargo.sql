CREATE PROC InsertarCargo
@Cargo varchar(max),
@SueldoPorhora numeric(18,2)
AS
IF EXISTS(SELECT Cargo FROM Cargo WHERE Cargo = @Cargo)
RAISERROR('Ya existe un cargo con este nombre. Ingrese de nuevo', 16,1)
ELSE
INSERT INTO Cargo VALUES (@Cargo, @SueldoPorhora) 