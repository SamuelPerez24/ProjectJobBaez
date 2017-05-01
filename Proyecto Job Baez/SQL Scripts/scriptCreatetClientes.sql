CREATE TABLE tClientes(
	cliID int PRIMARY KEY,
	cliNombre varchar(100) NOT NULL,
	cliRNC char(11) NOT NULL,
	cliFechaIng date NOT NULL,
	cliCierre char(14) NULL
)