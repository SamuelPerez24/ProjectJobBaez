Imports System.Data.SqlClient
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fAdministracion

#Region "Metodos"
    Private Sub LimpiarControles()
        Me.txtadm_Codigo.Clear()
        Me.txtadm_Usuario.Clear()
        Me.txtadm_Password.Clear()
        Me.BindingNavigatorPositionItem.Clear()
        Me.BindingNavigatorCountItem.Text = ""
    End Sub

    Private Sub PropertyReadOnlyOn()
        Me.txtadm_Codigo.ReadOnly = True
        Me.txtadm_Usuario.ReadOnly = True
        Me.txtadm_Password.ReadOnly = True
    End Sub

    Private Sub PropertyReadOnlyOff()
        Me.txtadm_Codigo.ReadOnly = False
        Me.txtadm_Usuario.ReadOnly = False
        Me.txtadm_Password.ReadOnly = False
    End Sub

    Private Sub ControlsOff()
        Me.btsEditar.Enabled = False
        Me.btsBuscar.Enabled = False
        Me.btsPrimero.Enabled = False
        Me.btsAnterior.Enabled = False
        Me.btsSiguiente.Enabled = False
        Me.btsUltimo.Enabled = False
        Me.btsNuevo.Enabled = False
        Me.btsBorrar.Enabled = False
        Me.btsAceptar.Enabled = False
        Me.btsCancelar.Enabled = False
    End Sub

    Private Sub ControlsOn()
        Me.btsEditar.Enabled = True
        Me.btsBuscar.Enabled = True
        Me.btsPrimero.Enabled = True
        Me.btsAnterior.Enabled = True
        Me.btsSiguiente.Enabled = True
        Me.btsUltimo.Enabled = True
        Me.btsNuevo.Enabled = True
        Me.btsBorrar.Enabled = True
        Me.btsAceptar.Enabled = True
        Me.btsCancelar.Enabled = True
    End Sub

    Private Sub ActualizarAdap()
        Adap = New SqlDataAdapter("SELECT * FROM tLogin", Conexion)
        Dim Query As SqlCommandBuilder = New SqlCommandBuilder(Adap)
        DS = New DataSet
        Conexion.Open()
        Adap.Fill(DS, "tLogin")
        Conexion.Close()
        Me.posicion = 0
    End Sub

    Private Sub DataLoad()
        Dim drAdmin As DataRow
        drAdmin = DS.Tables("tLogin").Rows(Me.posicion)
        Me.txtadm_Codigo.Text = drAdmin("logID")
        Me.txtadm_Usuario.Text = drAdmin("logUser")
        Me.txtadm_Password.Text = drAdmin("logPassword")
        Me.BindingNavigatorPositionItem.Text = Me.posicion + 1
        Me.BindingNavigatorCountItem.Text = DS.Tables("tLogin").Rows.Count()
    End Sub
#End Region

#Region "Variables"
    Private proBuscar As Boolean = False
    Private proEditar As Boolean = False
    Private proNuevo As Boolean = False
    Private proEliminar As Boolean = False
    Private posicion As Integer
    'Private proImp As Boolean = False
#End Region

    Private Sub btsSalir_Click(sender As Object, e As EventArgs) Handles btsSalir.Click
        Me.Close()
    End Sub

    Private Sub btsBuscar_Click(sender As Object, e As EventArgs) Handles btsBuscar.Click
        Me.btsBuscar.Enabled = False

        If Not Me.btsBuscar.Enabled = True Then
            Me.txtadm_Codigo.Focus()

            With Me.txtadm_Codigo
                .Enabled = True
                .BackColor = Color.AliceBlue
            End With

            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            Me.txtadm_Codigo.ReadOnly = False
            '------------------------------
            Me.proBuscar = True
            '------------------------------
            LimpiarControles()
        End If
    End Sub

    Private Sub btsPrimero_Click(sender As Object, e As EventArgs) Handles btsPrimero.Click
        Me.posicion = 0
        Me.DataLoad()
    End Sub

    Private Sub btsAnterior_Click(sender As Object, e As EventArgs) Handles btsAnterior.Click
        If Me.posicion = 0 Then
            MessageBox.Show("Este es el primer registro.")
        Else
            Me.posicion -= 1
            Me.DataLoad()
        End If
    End Sub

    Private Sub btsSiguiente_Click(sender As Object, e As EventArgs) Handles btsSiguiente.Click
        If Me.posicion = DS.Tables("tLogin").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion += 1
            Me.DataLoad()
        End If
    End Sub

    Private Sub btsUltimo_Click(sender As Object, e As EventArgs) Handles btsUltimo.Click
        Me.posicion = (DS.Tables("tLogin").Rows.Count - 1)
        Me.DataLoad()
    End Sub

    Private Sub btsNuevo_Click(sender As Object, e As EventArgs) Handles btsNuevo.Click
        Me.btsNuevo.Enabled = False

        If Not Me.btsNuevo.Enabled = True Then
            LimpiarControles()
            Me.proNuevo = True
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            '-----------------------------------------
            Me.txtadm_Codigo.Focus()
            PropertyReadOnlyOff()
            Me.txtadm_Codigo.ReadOnly = True

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New SqlCommand("SELECT MAX(logID) + 1 AS ID FROM tLogin", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader

                If Reader.Read Then
                    Me.txtadm_Codigo.Text = Reader("ID")
                    Me.txtadm_Usuario.Focus()
                    PropertyReadOnlyOff()
                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL TRATAR DE INSERTAR EL ID, #ERROR: " & ex.Message)
            Finally
                Conexion.Close()
            End Try
        End If
    End Sub

    Private Sub btsEditar_Click(sender As Object, e As EventArgs) Handles btsEditar.Click
        Me.btsEditar.Enabled = False

        If Not Me.btsEditar.Enabled = True Then
            Me.proEditar = True
            PropertyReadOnlyOff()
            Me.txtadm_Usuario.Focus()
            Me.txtadm_Codigo.ReadOnly = True
            '-----------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
        End If
    End Sub

    Private Sub btsBorrar_Click(sender As Object, e As EventArgs) Handles btsBorrar.Click
        Me.btsBorrar.Enabled = False

        If Not Me.btsBorrar.Enabled = True Then
            Me.proEliminar = True
            PropertyReadOnlyOn()
            Me.txtadm_Codigo.ReadOnly = False
            Me.txtadm_Codigo.Focus()
            '------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
        End If
    End Sub

    Private Sub btsAceptar_Click(sender As Object, e As EventArgs) Handles btsAceptar.Click
        '=====================================> BUSCAR <=====================================
        If Not Me.proBuscar = False Then
            If Me.txtadm_Codigo.Text = "" Then
                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com2 As New SqlCommand("SELECT MAX(logID) AS ID FROM tLogin", Conexion)
                    Dim Com1 As New SqlCommand("SELECT * FROM tLogin", Conexion)
                    Dim Reader1 As SqlDataReader
                    Dim Reader2 As SqlDataReader

                    Reader1 = Com1.ExecuteReader()
                    Reader2 = Com2.ExecuteReader()

                    If Reader1.Read Then
                        Me.txtadm_Codigo.Text = Reader1("logID")
                        Me.txtadm_Usuario.Text = Reader1("logUser")
                        Me.txtadm_Password.Text = Reader1("logPassword")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader1("logID"))

                        Me.txtadm_Codigo.BackColor = Color.White

                        Reader1.Close()
                    End If

                    If Reader2.Read Then
                        Me.BindingNavigatorCountItem.Text = "de " + CStr(Reader2("ID"))
                        Reader2.Close()
                    End If

                Catch ex As Exception
                    Throw New Exception("ERROR AL BUSCAR TODOS LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
                Finally
                    Conexion.Close()
                End Try
            End If

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New SqlCommand("SELECT * FROM tLogin WHERE logID='" + Me.txtadm_Codigo.Text.Trim() + "'", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader()

                If Reader.Read Then
                    Me.txtadm_Codigo.Text = Reader("logID")
                    Me.txtadm_Usuario.Text = Reader("logUser")
                    Me.txtadm_Password.Text = Reader("logPassword")

                    Me.BindingNavigatorPositionItem.Text = CStr(Reader("logID"))

                    Me.txtadm_Codigo.BackColor = Color.White
                    Reader.Close()
                Else
                    LimpiarControles()
                    Me.txtadm_Codigo.Focus()
                    MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

                End If

                If Conexion.State = ConnectionState.Open Then
                    Conexion.Close()
                End If

                ControlsOn()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.txtadm_Codigo.ReadOnly = True



            Catch ex As Exception
                Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
            Finally
                Desconectar()
            End Try

            '------------------------------
            Me.proBuscar = False
            '------------------------------
        End If
        '=====================================> NUEVO <=====================================
        If Not Me.proNuevo = False Then

            Try
                Dim Sql As String = "INSERT INTO tLogin(logID,logUser,logPassword) VALUES ('" + _
                                 Me.txtadm_Codigo.Text.Trim + "','" + Me.txtadm_Usuario.Text.Trim + "','" + _
                                 Me.txtadm_Password.Text.Trim + "')"

                If Insertar(Sql) Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtadm_Codigo.Focus()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.proNuevo = False
                    DS.Clear()
                    ActualizarAdap()
                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL INSERTAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try

        End If
        '=====================================> EDITAR <=====================================
        If Not Me.proEditar = False Then
            Try
                Dim Campos As String = "logUser='" + Me.txtadm_Usuario.Text.Trim + _
                    "',logPassword='" + Me.txtadm_Password.Text.Trim + "'"

                If Actualizar("tLogin", Campos, "logID='" + Me.txtadm_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtadm_Codigo.Focus()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.proEditar = False
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL EDITAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try
        End If
        '=====================================> ELIMINAR <=====================================
        If Not Me.proEliminar = False Then
            Try
                If Borrar("tLogin", "logID='" + Me.txtadm_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    LimpiarControles()
                    Me.txtadm_Codigo.Focus()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.proEliminar = False
                End If
            Catch ex As Exception
                Throw New Exception("ERROR AL ELIMINAR EL DATO REQUERIDO, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try
        End If
    End Sub

    Private Sub btsCancelar_Click(sender As Object, e As EventArgs) Handles btsCancelar.Click
        ControlsOff()
        With Me.txtadm_Codigo
            .Focus()
            .BackColor = Color.White
        End With

        Me.btsBuscar.Enabled = True
        'Me.btsImprimir.Enabled = True
        Me.btsNuevo.Enabled = True
        PropertyReadOnlyOn()
        '------------------------------
        Me.proBuscar = False
        Me.proEditar = False
        Me.proEliminar = False
        'Me.proImp = False
        Me.proNuevo = False
        '------------------------------
        LimpiarControles()
    End Sub

    Private Sub txtadm_Codigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtadm_Codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            '=====================================> BUSCAR <=====================================
            If Not Me.proBuscar = False Then
                If Me.txtadm_Codigo.Text = "" Then
                    Try
                        If Not Conexion.State = ConnectionState.Open Then
                            Conexion.Open()
                        End If

                        Dim Com2 As New SqlCommand("SELECT MAX(logID) AS ID FROM tLogin", Conexion)
                        Dim Com1 As New SqlCommand("SELECT * FROM tLogin", Conexion)
                        Dim Reader1 As SqlDataReader
                        Dim Reader2 As SqlDataReader

                        Reader1 = Com1.ExecuteReader()
                        Reader2 = Com2.ExecuteReader()

                        If Reader1.Read Then
                            Me.txtadm_Codigo.Text = Reader1("logID")
                            Me.txtadm_Usuario.Text = Reader1("logUser")
                            Me.txtadm_Password.Text = Reader1("logPassword")
                            Me.BindingNavigatorPositionItem.Text = CStr(Reader1("logID"))

                            Me.txtadm_Codigo.BackColor = Color.White

                            Reader1.Close()
                        End If

                        If Reader2.Read Then
                            Me.BindingNavigatorCountItem.Text = "de " + CStr(Reader2("ID"))
                            Reader2.Close()
                        End If

                    Catch ex As Exception
                        Throw New Exception("ERROR AL BUSCAR TODOS LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
                    Finally
                        Conexion.Close()
                    End Try
                End If

                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com As New SqlCommand("SELECT * FROM tLogin WHERE logID='" + Me.txtadm_Codigo.Text.Trim() + "'", Conexion)
                    Dim Reader As SqlDataReader

                    Reader = Com.ExecuteReader()

                    If Reader.Read Then
                        Me.txtadm_Codigo.Text = Reader("logID")
                        Me.txtadm_Usuario.Text = Reader("logUser")
                        Me.txtadm_Password.Text = Reader("logPassword")

                        Me.BindingNavigatorPositionItem.Text = CStr(Reader("logID"))

                        Me.txtadm_Codigo.BackColor = Color.White
                        Reader.Close()
                    Else
                        LimpiarControles()
                        Me.txtadm_Codigo.Focus()
                        MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

                    End If

                    If Conexion.State = ConnectionState.Open Then
                        Conexion.Close()
                    End If

                    ControlsOn()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.txtadm_Codigo.ReadOnly = True



                Catch ex As Exception
                    Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
                Finally
                    Desconectar()
                End Try

                '------------------------------
                Me.proBuscar = False
                '------------------------------
            End If
            '=====================================> NUEVO <=====================================
            If Not Me.proNuevo = False Then

                Try
                    Dim Sql As String = "INSERT INTO tLogin(logID,logUser,logPassword) VALUES ('" + _
                                     Me.txtadm_Codigo.Text.Trim + "','" + Me.txtadm_Usuario.Text.Trim + "','" + _
                                     Me.txtadm_Password.Text.Trim + "')"

                    If Insertar(Sql) Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtadm_Codigo.Focus()
                        Me.btsAceptar.Enabled = False
                        Me.btsCancelar.Enabled = False
                        Me.proNuevo = False
                        DS.Clear()
                        ActualizarAdap()
                    End If

                Catch ex As Exception
                    Throw New Exception("ERROR AL INSERTAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

                Finally
                    Desconectar()
                End Try

            End If
            '=====================================> EDITAR <=====================================
            If Not Me.proEditar = False Then
                Try
                    Dim Campos As String = "logUser='" + Me.txtadm_Usuario.Text.Trim + _
                        "',logPassword='" + Me.txtadm_Password.Text.Trim + "'"

                    If Actualizar("tLogin", Campos, "logID='" + Me.txtadm_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtadm_Codigo.Focus()
                        Me.btsAceptar.Enabled = False
                        Me.btsCancelar.Enabled = False
                        Me.proEditar = False
                    End If
                Catch ex As Exception
                    Throw New Exception("ERROR AL EDITAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

                Finally
                    Desconectar()
                End Try
            End If
            '=====================================> ELIMINAR <=====================================
            If Not Me.proEliminar = False Then
                Try
                    If Borrar("tLogin", "logID='" + Me.txtadm_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        LimpiarControles()
                        Me.txtadm_Codigo.Focus()
                        Me.btsAceptar.Enabled = False
                        Me.btsCancelar.Enabled = False
                        Me.proEliminar = False
                    End If
                Catch ex As Exception
                    Throw New Exception("ERROR AL ELIMINAR EL DATO REQUERIDO, #ERROR: " & ex.Message)

                Finally
                    Desconectar()
                End Try
            End If
        End If
    End Sub

    Private Sub fAdministracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarAdap()
        Me.DataLoad()

        LimpiarControles()
    End Sub

    Private Sub btnadm_Ver_Click(sender As Object, e As EventArgs) Handles btnadm_Ver.Click
        If Not Me.txtadm_Password.UseSystemPasswordChar = True Then
            Me.txtadm_Password.UseSystemPasswordChar = True
        Else
            Me.txtadm_Password.UseSystemPasswordChar = False
        End If
    End Sub
End Class