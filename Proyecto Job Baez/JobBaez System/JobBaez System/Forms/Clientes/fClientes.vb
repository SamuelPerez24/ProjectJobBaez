Imports System.Data.SqlClient
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fClientes

#Region "Metodos"
    Private Sub LimpiarControles()
        Me.txtcli_Codigo.Clear()
        Me.mtxtcli_RNC.Clear()
        Me.txtcli_Nombre.Clear()
        Me.dtpcli_FechaIng.Refresh()
        Me.cbcli_Cierre.SelectedValue = 0
        Me.BindingNavigatorPositionItem.Clear()
        Me.BindingNavigatorCountItem.Text = ""
    End Sub

    Private Sub PropertyReadOnlyOn()
        Me.txtcli_Codigo.ReadOnly = True
        Me.mtxtcli_RNC.ReadOnly = True
        Me.txtcli_Nombre.ReadOnly = True
        Me.dtpcli_FechaIng.Enabled = False
        Me.cbcli_Cierre.Enabled = False
    End Sub

    Private Sub PropertyReadOnlyOff()
        Me.txtcli_Codigo.ReadOnly = False
        Me.mtxtcli_RNC.ReadOnly = False
        Me.txtcli_Nombre.ReadOnly = False
        Me.dtpcli_FechaIng.Enabled = True
        Me.cbcli_Cierre.Enabled = True
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
        Adap = New SqlDataAdapter("SELECT * FROM tClientes", Conexion)
        Dim Query As SqlCommandBuilder = New SqlCommandBuilder(Adap)
        DS = New DataSet
        Conexion.Open()
        Adap.Fill(DS, "tClientes")
        Conexion.Close()
        Me.posicion = 0
    End Sub

    Private Sub DataLoad()
        Dim drClientes As DataRow
        drClientes = DS.Tables("tClientes").Rows(Me.posicion)
        Me.txtcli_Codigo.Text = drClientes("cliID")
        Me.txtcli_Nombre.Text = drClientes("cliNombre")
        Me.mtxtcli_RNC.Text = drClientes("cliRNC")
        Me.dtpcli_FechaIng.Text = drClientes("cliFechaIng")
        Me.cbcli_Cierre.Text = drClientes("cliCierre")
        Me.BindingNavigatorPositionItem.Text = Me.posicion + 1
        Me.BindingNavigatorCountItem.Text = DS.Tables("tClientes").Rows.Count()
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
            Me.txtcli_Codigo.Focus()

            With Me.txtcli_Codigo
                .Enabled = True
                .BackColor = Color.AliceBlue
            End With

            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            Me.txtcli_Codigo.ReadOnly = False
            '------------------------------
            Me.proBuscar = True
            '------------------------------
            LimpiarControles()
        End If
    End Sub

    Private Sub btsPrimero_Click(sender As Object, e As EventArgs) Handles btsPrimero.Click
        'If Me.posicion = 0 Then
        '    MessageBox.Show("Este es el primer registro.")
        'Else
        Me.posicion = 0
        Me.DataLoad()
        'End If
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
        If Me.posicion = DS.Tables("tClientes").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion += 1
            Me.DataLoad()
        End If
    End Sub

    Private Sub btsUltimo_Click(sender As Object, e As EventArgs) Handles btsUltimo.Click
        'If Me.posicion = DS.Tables("tClientes").Rows.Count - 1 Then
        '    MessageBox.Show("Este es el ultimo registro.")
        'Else
        Me.posicion = (DS.Tables("tClientes").Rows.Count - 1)
        Me.DataLoad()
        'End If
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
            Me.txtcli_Codigo.Focus()
            PropertyReadOnlyOff()
            Me.txtcli_Codigo.ReadOnly = True

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New SqlCommand("SELECT MAX(cliID) + 1 AS ID FROM tClientes", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader

                If Reader.Read Then
                    Me.txtcli_Codigo.Text = Reader("ID")
                    Me.txtcli_Nombre.Focus()
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
            Me.txtcli_Nombre.Focus()
            Me.txtcli_Codigo.ReadOnly = True
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
            Me.txtcli_Codigo.ReadOnly = False
            Me.txtcli_Codigo.Focus()
            '------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
        End If
    End Sub

    Private Sub btsAceptar_Click(sender As Object, e As EventArgs) Handles btsAceptar.Click
        '=====================================> BUSCAR <=====================================
        If Not Me.proBuscar = False Then
            If Me.txtcli_Codigo.Text = "" Then
                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com2 As New SqlCommand("SELECT MAX(cliID) AS ID FROM tClientes", Conexion)
                    Dim Com1 As New SqlCommand("SELECT * FROM tClientes", Conexion)
                    Dim Reader1 As SqlDataReader
                    Dim Reader2 As SqlDataReader

                    Reader1 = Com1.ExecuteReader()
                    Reader2 = Com2.ExecuteReader()

                    If Reader1.Read Then
                        Me.txtcli_Codigo.Text = Reader1("cliID")
                        Me.mtxtcli_RNC.Text = Reader1("cliRNC")
                        Me.txtcli_Nombre.Text = Reader1("cliNombre")
                        Me.dtpcli_FechaIng.Text = Reader1("cliFechaIng")
                        Me.cbcli_Cierre.Text = Reader1("cliCierre")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader1("cliID"))

                        Me.txtcli_Codigo.BackColor = Color.White

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

                Dim Com As New SqlCommand("SELECT * FROM tClientes WHERE cliID='" + Me.txtcli_Codigo.Text.Trim() + "'", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader()

                If Reader.Read Then
                    Me.txtcli_Codigo.Text = Reader("cliID")
                    Me.mtxtcli_RNC.Text = Reader("cliRNC")
                    Me.txtcli_Nombre.Text = Reader("cliNombre")
                    Me.dtpcli_FechaIng.Text = Reader("cliFechaIng")
                    Me.cbcli_Cierre.Text = Reader("cliCierre")
                    Me.BindingNavigatorPositionItem.Text = CStr(Reader("cliID"))

                    Me.txtcli_Codigo.BackColor = Color.White
                    Reader.Close()
                Else
                    LimpiarControles()
                    Me.txtcli_Codigo.Focus()
                    MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

                End If

                If Conexion.State = ConnectionState.Open Then
                    Conexion.Close()
                End If

                ControlsOn()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.txtcli_Codigo.ReadOnly = True



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
                Dim Sql As String = "INSERT INTO tClientes(cliID,cliNombre,cliRNC,cliFechaIng,cliCierre) VALUES ('" + _
                                 Me.txtcli_Codigo.Text.Trim + "','" + Me.txtcli_Nombre.Text.Trim + "','" + Me.mtxtcli_RNC.Text.Trim + _
                                 "','" + Me.dtpcli_FechaIng.Text.Trim + "','" + Me.cbcli_Cierre.Text.Trim + "')"
                If Insertar(Sql) Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtcli_Codigo.Focus()
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
                Dim Campos As String = "cliNombre='" + Me.txtcli_Nombre.Text.Trim + "',cliRNC='" + Me.mtxtcli_RNC.Text.Trim + _
                "',cliFechaIng='" + Me.dtpcli_FechaIng.Text.Trim + "',cliCierre='" + Me.cbcli_Cierre.Text.Trim + "'"

                If Actualizar("tClientes", Campos, "cliID='" + Me.txtcli_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtcli_Codigo.Focus()
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
                If Borrar("tClientes", "cliID='" + Me.txtcli_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    LimpiarControles()
                    Me.txtcli_Codigo.Focus()
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
        With Me.txtcli_Codigo
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

    Private Sub fClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarAdap()
        Me.DataLoad()

        LimpiarControles()
    End Sub

    Private Sub txtcli_Codigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcli_Codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            '=====================================> BUSCAR <=====================================
            If Not Me.proBuscar = False Then
                If Me.txtcli_Codigo.Text = "" Then
                    Try
                        If Not Conexion.State = ConnectionState.Open Then
                            Conexion.Open()
                        End If

                        Dim Com2 As New SqlCommand("SELECT MAX(cliID) AS ID FROM tClientes", Conexion)
                        Dim Com1 As New SqlCommand("SELECT * FROM tClientes", Conexion)
                        Dim Reader1 As SqlDataReader
                        Dim Reader2 As SqlDataReader

                        Reader1 = Com1.ExecuteReader()
                        Reader2 = Com2.ExecuteReader()

                        If Reader1.Read Then
                            Me.txtcli_Codigo.Text = Reader1("cliID")
                            Me.mtxtcli_RNC.Text = Reader1("cliRNC")
                            Me.txtcli_Nombre.Text = Reader1("cliNombre")
                            Me.dtpcli_FechaIng.Text = Reader1("cliFechaIng")
                            Me.cbcli_Cierre.Text = Reader1("cliCierre")
                            Me.BindingNavigatorPositionItem.Text = CStr(Reader1("cliID"))

                            Me.txtcli_Codigo.BackColor = Color.White

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

                    Dim Com As New SqlCommand("SELECT * FROM tClientes WHERE cliID='" + Me.txtcli_Codigo.Text.Trim() + "'", Conexion)
                    Dim Reader As SqlDataReader

                    Reader = Com.ExecuteReader()

                    If Reader.Read Then
                        Me.txtcli_Codigo.Text = Reader("cliID")
                        Me.mtxtcli_RNC.Text = Reader("cliRNC")
                        Me.txtcli_Nombre.Text = Reader("cliNombre")
                        Me.dtpcli_FechaIng.Text = Reader("cliFechaIng")
                        Me.cbcli_Cierre.Text = Reader("cliCierre")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader("cliID"))

                        Me.txtcli_Codigo.BackColor = Color.White
                        Reader.Close()
                    Else
                        LimpiarControles()
                        Me.txtcli_Codigo.Focus()
                        MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")
                        Me.txtcli_Codigo.BackColor = Color.White
                    End If

                    If Conexion.State = ConnectionState.Open Then
                        Conexion.Close()
                    End If

                    ControlsOn()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.txtcli_Codigo.ReadOnly = True



                Catch ex As Exception
                    Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
                Finally
                    Conexion.Close()
                End Try

                '------------------------------
                Me.proBuscar = False
                '------------------------------
            End If
            '=====================================> NUEVO <=====================================
            If Not Me.proNuevo = False Then

                Try
                    Dim Sql As String = "INSERT INTO tClientes(cliID,cliNombre,cliRNC,cliFechaIng,cliCierre) VALUES ('" + _
                                     Me.txtcli_Codigo.Text.Trim + "','" + Me.txtcli_Nombre.Text.Trim + "','" + Me.mtxtcli_RNC.Text.Trim + _
                                     "','" + Me.dtpcli_FechaIng.Text.Trim + "','" + Me.cbcli_Cierre.Text.Trim + "')"
                    If Insertar(Sql) Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtcli_Codigo.Focus()
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
                    Dim Campos As String = "cliNombre='" + Me.txtcli_Nombre.Text.Trim + "',cliRNC='" + Me.mtxtcli_RNC.Text.Trim + _
                    "',cliFechaIng='" + Me.dtpcli_FechaIng.Text.Trim + "',cliCierre='" + Me.cbcli_Cierre.Text.Trim + "'"

                    If Actualizar("tClientes", Campos, "cliID='" + Me.txtcli_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtcli_Codigo.Focus()
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
                    If Borrar("tClientes", "cliID='" + Me.txtcli_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        LimpiarControles()
                        Me.txtcli_Codigo.Focus()
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
    
End Class