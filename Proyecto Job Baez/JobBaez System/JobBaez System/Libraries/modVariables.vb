Imports System.Data.SqlClient
Imports System.Data
Module modVariables
    'En la ruta, la base de datos se pueden usar: Database e Initial Catalog para cargarla.
    Public Ruta As String = "Server=localhost; Database=JobBaezDB; Integrated Security=SSPI; MultipleActiveResultSets=true;"
    Public Conexion As New SqlConnection(Ruta)
    Public DS As DataSet = New DataSet()
    Public Adap As SqlDataAdapter
    Public User As String
    Public FechaLog, HoraLog As Date
    Public isLoginOn As Boolean = True
    Public Adap1 As SqlDataAdapter

End Module
