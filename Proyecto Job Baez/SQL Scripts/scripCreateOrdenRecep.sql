CREATE TABLE tOrdenRecep(
	orreID int PRIMARY KEY,
	cliID int FOREIGN KEY REFERENCES tClientes(cliID) NOT NULL,
	orreFecha date NOT NULL,
	orreControl bit NULL,
	orreResponsable varchar(50) NOT NULL,
	orreFact decimal(9,2) NOT NULL,
	orreAbono decimal(9,2) NOT NULL,
	--FOREIGN KEY (cliID) REFERENCES tClientes(cliID)
	)