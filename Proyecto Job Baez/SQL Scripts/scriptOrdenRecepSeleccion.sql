SELECT orreID,
		cliID,
		(SELECT cliNombre
		 FROM tClientes cli 
		 WHERE cli.cliID=ord.cliID) AS cliNombre,
		orreFecha,
		orreControl,
		orreResponsable,
		orreFact,
		orreAbono 
FROM tOrdenRecep ord