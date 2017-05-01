Imports System.Data.SqlClient
Imports System.Data
Public Class ConnectionQuerysClass
#Region "Conexion"
    Public Shared Sub Conectar()
        Try
            If Not Conexion.State = ConnectionState.Open Then
                Conexion.Open()
            End If
        Catch ex As Exception
            Throw New Exception("ERROR AL CONECTAR CON LA BASE DE DATOS,#TimeOut: " & ex.Message)
        End Try
    End Sub
    Public Shared Sub Desconectar()
        Try
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        Catch ex As Exception
            Throw New Exception("ERROR AL TRATAR DE DESCONECTAR LA BASE DE DATOS,#5005: " & ex.Message)
        End Try
    End Sub
#End Region
#Region "Select"
    Public Shared Sub Seleccionar(Sql As String, Tabla As String)
        Try
            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL CONECTAR CON LA BASE DE DATOS,#TimeOut: " & ex.Message)
            End Try

            DS.Clear()
            Adap = New SqlDataAdapter(Sql, Conexion)
            Dim Com As New SqlCommandBuilder(Adap)
            Adap.Fill(DS, Tabla)

            Conexion.Close()

        Catch ex As Exception
            Throw New Exception("ERROR AL TRATAR DE SELECCIONAR LOS DATOS,#5006: " & ex.Message)
        Finally
            Conexion.Close()
        End Try
    End Sub
#End Region
#Region "Insert"
    Public Shared Function Insertar(Sql As String) As Boolean
        Try
            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL CONECTAR CON LA BASE DE DATOS,#TimeOut: " & ex.Message)
            End Try

            Dim Com As New SqlCommand(Sql, Conexion)
            Dim Conteo As Integer = Com.ExecuteNonQuery()
            Conexion.Close()

            If Conteo > 0 Then
                Return True
            Else
                Return False
            End If

            'Catch ex As Exception
            '    Throw New Exception("ERROR AL TRATAR DE INSERTAR LOS DATOS,#5007: " & ex.Message)
        Finally
            Conexion.Close()
        End Try
    End Function
#End Region
#Region "Update"
    Public Shared Function Actualizar(Tabla As String, Campos As String, Condicion As String) As Boolean
        Try
            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL CONECTAR CON LA BASE DE DATOS,#TimeOut: " & ex.Message)
            End Try

            Dim Sql As String = "UPDATE " & Tabla & " SET " & Campos & " WHERE " & Condicion
            Dim Com As New SqlCommand(Sql, Conexion)
            Dim Conteo As Integer = Com.ExecuteNonQuery()
            Conexion.Close()

            If Conteo > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ERROR AL TRATAR DE ACTUALIZAR LOS DATOS,#5008: " & ex.Message)
        Finally
            Conexion.Close()
        End Try
    End Function
#End Region
#Region "Delete"
    Public Shared Function Borrar(Tabla As String, Condicion As String)
        Try
            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL CONECTAR CON LA BASE DE DATOS,#TimeOut: " & ex.Message)
            End Try

            Dim Sql As String = "DELETE FROM " & Tabla & " WHERE " & Condicion
            Dim Com As New SqlCommand(Sql, Conexion)
            Dim Conteo As Integer = Com.ExecuteNonQuery()

            Conexion.Close()
            If Conteo > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("ERROR AL TRATAR DE BORRAR LOS DATOS,#5009: " & ex.Message)
        Finally
            Conexion.Close()
        End Try
    End Function
#End Region
End Class
