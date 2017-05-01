Imports System.Data.SqlClient
Imports System.Data
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        Try
            Conectar()
            Dim comLog As New SqlCommand("SELECT * FROM tLogin WHERE logUser='" + txtUsername.Text.Trim + "' AND logPassword='" + txtPassword.Text.Trim + "' ", Conexion)
            Dim readerLog As SqlDataReader

            User = Me.txtUsername.Text

            readerLog = comLog.ExecuteReader()

            If readerLog.HasRows = True Then
                Do While readerLog.Read()
                    MsgBox("Bienvenido Sr. " + txtUsername.Text.Trim, MsgBoxStyle.Information, "Bienvenida")
                    Me.Close()

                    fMenuPrincipal.Enabled = True

                    HoraLog = DateAndTime.TimeOfDay()
                    FechaLog = Date.Today()

                    fMenuPrincipal.tlsUsername.Text = "Usuario: " + User
                    fMenuPrincipal.tlsFecha.Text = "Fecha: " + FechaLog + " Hora: " + HoraLog

                    readerLog.Close()
                Loop
            Else
                Select Case MsgBox("Usuario/Password no registrado!, Por favor introduzca datos válidos.", MsgBoxStyle.YesNo, "Credenciales invalidas")
                    Case DialogResult.Yes
                        txtUsername.Focus()
                        txtUsername.Clear()
                        txtPassword.Clear()

                    Case DialogResult.No
                        MsgBox("Hasta luego!", MsgBoxStyle.Exclamation, "Credenciales invalidas")
                        Application.Exit()
                End Select
            End If
            Desconectar()

        Catch ex As Exception
            Throw New Exception("No se pudo conectar a la base de datos, #ERROR: " + ex.Message)
        Finally
            Conexion.Close()
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub btn_Ver_Click(sender As Object, e As EventArgs) Handles btn_Ver.Click
        If Not Me.txtPassword.UseSystemPasswordChar = True Then
            Me.txtPassword.UseSystemPasswordChar = True
        Else
            Me.txtPassword.UseSystemPasswordChar = False
        End If
    End Sub
End Class
