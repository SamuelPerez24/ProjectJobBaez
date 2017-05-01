CREATE TABLE tpreFact(
	prefactID INT PRIMARY KEY,
	orreID INT NOT NULL,
	cliID INT NOT NULL,
	prefactDescripcion VARCHAR(250),
	prefactSubTotal VARCHAR(21) NOT NULL,
	prefactITBIS VARCHAR(21) NOT NULL,
	prefactTotal VARCHAR(21) NOT NULL,
	FOREIGN KEY(orreID,cliID) REFERENCES tOrdenRecep(orreID,cliID)
)