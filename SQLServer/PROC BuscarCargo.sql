CREATE PROC BuscarCargo
@Buscador varchar(50)
AS
SELECT Id_cargo, Cargo, SueldoPorHora AS [Sueldo por hora] FROM Cargo
WHERE Cargo LIKE '%' + @Buscador + '%'