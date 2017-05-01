USE JobBaezDB
GO
--INSERT INTO tOrdenRecep(orreID,cliID,orreFecha,orreControl,orreResponsable,orreFact,orreAbono)
--VALUES (2,102,GETDATE(),NULL,'Manuel Nunez',10000.00,2500.00)
--GO
SELECT ord.orreID,cli.cliID,ord.orreFecha,ord.orreControl,ord.orreResponsable,ord.orreFact,ord.orreAbono,cli.cliNombre 
FROM tOrdenRecep ord,tClientes cli WHERE ord.cliID=101 AND cli.cliID=ord.cliID
--SELECT * 
--FROM tOrdenRecep ord,tClientes cli WHERE cli.cliID=ord.cliID
