Imports System.Data.SqlClient
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fOrdenRecep

#Region "Metodos"
    Private Sub LimpiarControles()
        Me.txtord_Codigo.Clear()
        Me.txtord_IdCliente.Clear()
        Me.txtord_NombreCli.Clear()
        Me.txtord_Responsable.Clear()
        Me.txtord_Factura.Clear()
        Me.txtord_Abono.Clear()
        Me.dtpord_Fecha.Refresh()
        Me.cbord_Control.Checked = False
        Me.BindingNavigatorPositionItem.Clear()
        Me.BindingNavigatorCountItem.Text = ""
    End Sub

    Private Sub PropertyReadOnlyOn()
        Me.txtord_Codigo.ReadOnly = True
        Me.txtord_IdCliente.ReadOnly = True
        Me.txtord_NombreCli.ReadOnly = True
        Me.txtord_Responsable.ReadOnly = True
        Me.txtord_Factura.ReadOnly = True
        Me.txtord_Abono.ReadOnly = True
        Me.dtpord_Fecha.Enabled = False
        Me.cbord_Control.Enabled = False
    End Sub

    Private Sub PropertyReadOnlyOff()
        Me.txtord_Codigo.ReadOnly = False
        Me.txtord_IdCliente.ReadOnly = False
        Me.txtord_NombreCli.ReadOnly = False
        Me.txtord_Responsable.ReadOnly = False
        Me.txtord_Factura.ReadOnly = False
        Me.txtord_Abono.ReadOnly = False
        Me.dtpord_Fecha.Enabled = True
        Me.cbord_Control.Enabled = True
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
        DS = New DataSet

        Adap = New SqlDataAdapter("SELECT * FROM tOrdenRecep", Conexion)
        Dim Query As New SqlCommandBuilder(Adap)
        Adap.Fill(DS, "tOrdenRecep")

        Adap1 = New SqlDataAdapter("SELECT * FROM tClientes", Conexion)
        Dim Query1 As New SqlCommandBuilder(Adap1)
        Adap.Fill(DS, "tClientes")

        Me.posicion = 0

    End Sub

    Private Sub DataLoad()
        Dim drOrdenRecep As DataRow
        Dim drOrdClientes As DataRow

        drOrdenRecep = DS.Tables("tOrdenRecep").Rows(Me.posicion)
        Me.txtord_Codigo.Text = drOrdenRecep("orreID")
        Me.txtord_IdCliente.Text = drOrdenRecep("cliID")
        Me.cbord_Control.Checked = drOrdenRecep("orreControl")
        Me.txtord_Responsable.Text = drOrdenRecep("orreResponsable")
        Me.dtpord_Fecha.Text = drOrdenRecep("orreFecha")
        Me.txtord_Factura.Text = drOrdenRecep("orreFact")
        Me.txtord_Abono.Text = drOrdenRecep("orreAbono")

        drOrdClientes = DS.Tables("tClientes").Rows(Me.posicion)
        Me.txtord_NombreCli.Text = drOrdClientes("cliNombre")

        Me.BindingNavigatorPositionItem.Text = Me.posicion + 1
        Me.BindingNavigatorCountItem.Text = DS.Tables("tOrdenRecep").Rows.Count()
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
            Me.txtord_Codigo.Focus()

            With Me.txtord_Codigo
                .Enabled = True
                .BackColor = Color.AliceBlue
            End With

            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            Me.txtord_Codigo.ReadOnly = False
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
        If Me.posicion = DS.Tables("tOrdenRecep").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion += 1
            Me.DataLoad()
        End If
    End Sub

    Private Sub btsUltimo_Click(sender As Object, e As EventArgs) Handles btsUltimo.Click
        Me.posicion = (DS.Tables("tOrdenRecep").Rows.Count - 1)
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
            Me.txtord_Codigo.Focus()
            PropertyReadOnlyOff()
            Me.txtord_Codigo.ReadOnly = True

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New SqlCommand("SELECT MAX(orreID) + 1 AS ID FROM tOrdenRecep", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader

                If Reader.Read Then
                    Me.txtord_Codigo.Text = Reader("ID")
                    Me.txtord_IdCliente.Focus()
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
            Me.txtord_IdCliente.Focus()
            Me.txtord_Codigo.ReadOnly = True
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
            Me.txtord_Codigo.ReadOnly = False
            Me.txtord_IdCliente.Focus()
            '------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
        End If
    End Sub

    Private Sub btsAceptar_Click(sender As Object, e As EventArgs) Handles btsAceptar.Click
        '=====================================> BUSCAR <=====================================
        If Not Me.proBuscar = False Then
            If Me.txtord_Codigo.Text = "" Then
                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com2 As New SqlCommand("SELECT MAX(orreID) AS ID FROM tOrdenRecep", Conexion)
                    Dim Com1 As New SqlCommand("SELECT * FROM tOrdenRecep,tClientes", Conexion)

                    Dim Reader1 As SqlDataReader
                    Dim Reader2 As SqlDataReader

                    Reader1 = Com1.ExecuteReader()
                    Reader2 = Com2.ExecuteReader()

                    If Reader1.Read Then
                        Me.txtord_Codigo.Text = Reader1("orreID")
                        Me.txtord_IdCliente.Text = Reader1("cliID")
                        Me.txtord_NombreCli.Text = Reader1("cliNombre")
                        Me.cbord_Control.Checked = Reader1("orreControl")
                        Me.txtord_Responsable.Text = Reader1("orreResponsable")
                        Me.dtpord_Fecha.Text = Reader1("orreFecha")
                        Me.txtord_Factura.Text = Reader1("orreFact")
                        Me.txtord_Abono.Text = Reader1("orreAbono")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader1("orreID"))

                        Me.txtord_Codigo.BackColor = Color.White

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

            '    Try
            '        If Not Conexion.State = ConnectionState.Open Then
            '            Conexion.Open()
            '        End If

            '        Dim Com As New SqlCommand("SELECT ord.orreID,cli.cliID,ord.orreFecha,ord.orreControl,ord.orreResponsable," & _
            '                                  "ord.orreFact,ord.orreAbono,cli.cliNombre FROM tOrdenRecep ord,tClientes cli" & _
            '                                  "WHERE ord.cliID=" + Me.txtord_IdCliente.Text.Trim + " AND cli.cliID=ord.cliID", Conexion)
            '        Dim Reader As SqlDataReader

            '        Reader = Com.ExecuteReader()

            '        If Reader.Read Then
            '            Me.txtord_Codigo.Text = Reader("ord.orreID")
            '            Me.txtord_IdCliente.Text = Reader("ord.cliID")
            '            Me.txtord_NombreCli.Text = Reader("cli.cliNombre")
            '            Me.cbord_Control.Checked = Reader("ord.orreControl")
            '            Me.txtord_Responsable.Text = Reader("ord.orreResponsable")
            '            Me.dtpord_Fecha.Text = Reader("ord.orreFecha")
            '            Me.txtord_Factura.Text = Reader("ord.orreFact")
            '            Me.txtord_Abono.Text = Reader("ord.orreAbono")
            '            Me.BindingNavigatorPositionItem.Text = CStr(Reader("ord.orreID"))

            '            Me.txtord_Codigo.BackColor = Color.White
            '            Reader.Close()

            '        Else
            '            LimpiarControles()
            '            Me.txtord_Codigo.Focus()
            '            MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

            '        End If

            '        If Conexion.State = ConnectionState.Open Then
            '            Conexion.Close()
            '        End If

            '        ControlsOn()
            '        Me.btsAceptar.Enabled = False
            '        Me.btsCancelar.Enabled = False
            '        Me.txtord_Codigo.ReadOnly = True

            '    Catch ex As Exception
            '        Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
            '    Finally
            '        Desconectar()
            '    End Try

            '    '------------------------------
            '    Me.proBuscar = False
            '    '------------------------------
            'End If
            ''=====================================> NUEVO <=====================================
            'If Not Me.proNuevo = False Then

            '    Try
            '        Dim Sql As String = "INSERT INTO tOrdenRecep(cliID,orreFecha,orreControl,orreResponsable,orreFact,orreAbono) VALUES (" + _
            '                         Me.txtord_IdCliente.Text.Trim + ",'" + Me.dtpord_Fecha.Text.Trim + "'," + Me.cbord_Control.Checked + _
            '                         ",'" + Me.txtord_Responsable.Text.Trim + "'," + Me.txtord_Factura.Text.Trim + "," + Me.txtord_Abono.Text.Trim + ")"
            '        If Insertar(Sql) Then
            '            PropertyReadOnlyOn()
            '            ControlsOn()
            '            Me.txtord_Codigo.Focus()
            '            Me.btsAceptar.Enabled = False
            '            Me.btsCancelar.Enabled = False
            '            Me.proNuevo = False
            '            DS.Clear()
            '            ActualizarAdap()
            '        End If

            '    Catch ex As Exception
            '        Throw New Exception("ERROR AL INSERTAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

            '    Finally
            '        Desconectar()
            '    End Try

            'End If
            ''=====================================> EDITAR <=====================================
            'If Not Me.proEditar = False Then
            '    Try
            '        Dim Campos As String = "cliID=" + Me.txtord_IdCliente.Text.Trim + ",orreFecha='" + Me.dtpord_Fecha.Text.Trim + _
            '        "',orreControl=" + Me.cbord_Control.Text.Trim + ",orreResponsable='" + Me.txtord_Responsable.Text.Trim + _
            '        "',orreFact=" + Me.txtord_Factura.Text.Trim + ",orreAbono=" + Me.txtord_Abono.Text.Trim + "'"

            '        If Actualizar("tOrdenRecep", Campos, "orreID=" + Me.txtord_Codigo.Text.Trim + "") Then
            '            PropertyReadOnlyOn()
            '            ControlsOn()
            '            Me.txtord_Codigo.Focus()
            '            Me.btsAceptar.Enabled = False
            '            Me.btsCancelar.Enabled = False
            '            Me.proEditar = False
            '        End If
            '    Catch ex As Exception
            '        Throw New Exception("ERROR AL EDITAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

            '    Finally
            '        Desconectar()
            '    End Try
            'End If
            ''=====================================> ELIMINAR <=====================================
            'If Not Me.proEliminar = False Then
            '    Try
            '        If Borrar("tOrdenRecep", "orreID=" + Me.txtord_Codigo.Text.Trim + "") Then
            '            PropertyReadOnlyOn()
            '            ControlsOn()
            '            LimpiarControles()
            '            Me.txtord_Codigo.Focus()
            '            Me.btsAceptar.Enabled = False
            '            Me.btsCancelar.Enabled = False
            '            Me.proEliminar = False
            '        End If
            '    Catch ex As Exception
            '        Throw New Exception("ERROR AL ELIMINAR EL DATO REQUERIDO, #ERROR: " & ex.Message)

            '    Finally
            '        Desconectar()
            '    End Try
        End If
    End Sub

    Private Sub btsCancelar_Click(sender As Object, e As EventArgs) Handles btsCancelar.Click
        ControlsOff()
        With Me.txtord_Codigo
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

    Private Sub txtord_Codigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtord_Codigo.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    '=====================================> BUSCAR <=====================================
        '    If Not Me.proBuscar = False Then
        '        If Me.txtord_Codigo.Text = "" Then
        '            Try
        '                If Not Conexion.State = ConnectionState.Open Then
        '                    Conexion.Open()
        '                End If

        '                Dim Com2 As New SqlCommand("SELECT MAX(orreID) AS ID FROM tOrdenRecep", Conexion)
        '                Dim Com1 As New SqlCommand("SELECT * FROM tOrdenRecep", Conexion)
        '                Dim Com3 As New SqlCommand("SELECT cliNombre FROM tClientes WHERE cliID=" + Me.txtord_IdCliente.Text.Trim + "", Conexion)
        '                Dim Reader1 As SqlDataReader
        '                Dim Reader2 As SqlDataReader
        '                Dim Reader3 As SqlDataReader

        '                Reader1 = Com1.ExecuteReader()
        '                Reader2 = Com2.ExecuteReader()
        '                Reader3 = Com3.ExecuteReader()

        '                If Reader1.Read Then
        '                    Me.txtord_Codigo.Text = Reader1("orreID")
        '                    Me.txtord_IdCliente.Text = Reader1("cliID")
        '                    Me.cbord_Control.Checked = Reader1("orreControl")
        '                    Me.txtord_Responsable.Text = Reader1("orreResponsable")
        '                    Me.dtpord_Fecha.Text = Reader1("orreFecha")
        '                    Me.txtord_Factura.Text = Reader1("orreFact")
        '                    Me.txtord_Abono.Text = Reader1("orreAbono")
        '                    Me.BindingNavigatorPositionItem.Text = CStr(Reader1("orreID"))

        '                    Me.txtord_Codigo.BackColor = Color.White

        '                    Reader1.Close()
        '                End If

        '                If Reader2.Read Then
        '                    Me.BindingNavigatorCountItem.Text = "de " + CStr(Reader2("ID"))
        '                    Reader2.Close()
        '                End If

        '                If Reader3.Read Then
        '                    Me.txtord_IdCliente.Text = Reader3("cliNombre")
        '                    Reader3.Close()
        '                End If

        '            Catch ex As Exception
        '                Throw New Exception("ERROR AL BUSCAR TODOS LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
        '            Finally
        '                Conexion.Close()
        '            End Try
        '        End If

        '        Try
        '            If Not Conexion.State = ConnectionState.Open Then
        '                Conexion.Open()
        '            End If

        '            Dim Com As New SqlCommand("SELECT * FROM tOrdenRecep WHERE orreID='" + Me.txtord_Codigo.Text.Trim() + "'", Conexion)
        '            Dim Com4 As New SqlCommand("SELECT cliNombre FROM tClientes WHERE cliID=" + Me.txtord_IdCliente.Text.Trim + "", Conexion)
        '            Dim Reader As SqlDataReader
        '            Dim Reader4 As SqlDataReader

        '            Reader = Com.ExecuteReader()
        '            Reader4 = Com.ExecuteReader()

        '            If Reader.Read Then
        '                Me.txtord_Codigo.Text = Reader("orreID")
        '                Me.txtord_IdCliente.Text = Reader("cliID")
        '                Me.cbord_Control.Checked = Reader("orreControl")
        '                Me.txtord_Responsable.Text = Reader("orreResponsable")
        '                Me.dtpord_Fecha.Text = Reader("orreFecha")
        '                Me.txtord_Factura.Text = Reader("orreFact")
        '                Me.txtord_Abono.Text = Reader("orreAbono")
        '                Me.BindingNavigatorPositionItem.Text = CStr(Reader("orreID"))

        '                Me.txtord_Codigo.BackColor = Color.White
        '                Reader.Close()
        '            Else
        '                LimpiarControles()
        '                Me.txtord_Codigo.Focus()
        '                MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

        '            End If

        '            If Reader4.Read Then
        '                Me.txtord_IdCliente.Text = Reader4("cliNombre")
        '                Reader4.Close()
        '            End If

        '            If Conexion.State = ConnectionState.Open Then
        '                Conexion.Close()
        '            End If

        '            ControlsOn()
        '            Me.btsAceptar.Enabled = False
        '            Me.btsCancelar.Enabled = False
        '            Me.txtord_Codigo.ReadOnly = True



        '        Catch ex As Exception
        '            Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)
        '        Finally
        '            Desconectar()
        '        End Try

        '        '------------------------------
        '        Me.proBuscar = False
        '        '------------------------------
        '    End If
        '    '=====================================> NUEVO <=====================================
        '    If Not Me.proNuevo = False Then

        '        Try
        '            Dim Sql As String = "INSERT INTO tOrdenRecep(cliID,orreFecha,orreControl,orreResponsable,orreFact,orreAbono) VALUES (" + _
        '                             Me.txtord_IdCliente.Text.Trim + ",'" + Me.dtpord_Fecha.Text.Trim + "'," + Me.cbord_Control.Checked + _
        '                             ",'" + Me.txtord_Responsable.Text.Trim + "'," + Me.txtord_Factura.Text.Trim + "," + Me.txtord_Abono.Text.Trim + ")"
        '            If Insertar(Sql) Then
        '                PropertyReadOnlyOn()
        '                ControlsOn()
        '                Me.txtord_Codigo.Focus()
        '                Me.btsAceptar.Enabled = False
        '                Me.btsCancelar.Enabled = False
        '                Me.proNuevo = False
        '                DS.Clear()
        '                ActualizarAdap()
        '            End If

        '        Catch ex As Exception
        '            Throw New Exception("ERROR AL INSERTAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

        '        Finally
        '            Desconectar()
        '        End Try

        '    End If
        '    '=====================================> EDITAR <=====================================
        '    If Not Me.proEditar = False Then
        '        Try
        '            Dim Campos As String = "cliID=" + Me.txtord_IdCliente.Text.Trim + ",orreFecha='" + Me.dtpord_Fecha.Text.Trim + _
        '            "',orreControl=" + Me.cbord_Control.Text.Trim + ",orreResponsable='" + Me.txtord_Responsable.Text.Trim + _
        '            "',orreFact=" + Me.txtord_Factura.Text.Trim + ",orreAbono=" + Me.txtord_Abono.Text.Trim + "'"

        '            If Actualizar("tOrdenRecep", Campos, "orreID=" + Me.txtord_Codigo.Text.Trim + "") Then
        '                PropertyReadOnlyOn()
        '                ControlsOn()
        '                Me.txtord_Codigo.Focus()
        '                Me.btsAceptar.Enabled = False
        '                Me.btsCancelar.Enabled = False
        '                Me.proEditar = False
        '            End If
        '        Catch ex As Exception
        '            Throw New Exception("ERROR AL EDITAR LOS DATOS REQUERIDOS, #ERROR: " & ex.Message)

        '        Finally
        '            Desconectar()
        '        End Try
        '    End If
        '    '=====================================> ELIMINAR <=====================================
        '    If Not Me.proEliminar = False Then
        '        Try
        '            If Borrar("tOrdenRecep", "orreID=" + Me.txtord_Codigo.Text.Trim + "") Then
        '                PropertyReadOnlyOn()
        '                ControlsOn()
        '                LimpiarControles()
        '                Me.txtord_Codigo.Focus()
        '                Me.btsAceptar.Enabled = False
        '                Me.btsCancelar.Enabled = False
        '                Me.proEliminar = False
        '            End If
        '        Catch ex As Exception
        '            Throw New Exception("ERROR AL ELIMINAR EL DATO REQUERIDO, #ERROR: " & ex.Message)

        '        Finally
        '            Desconectar()
        '        End Try
        '    End If
        'End If
    End Sub
End Class