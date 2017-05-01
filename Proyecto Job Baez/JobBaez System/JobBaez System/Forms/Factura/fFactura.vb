Imports System.Data.SqlClient
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fFactura

#Region "Metodos"
    Private Sub LimpiarControles()
        Me.txtfac_Codigo.Clear()
        Me.txtfac_IdCliente.Clear()
        Me.txtfac_NombreCli.Clear()
        Me.txtfac_IdOrden.Clear()
        Me.txtfac_Adeudado.Clear()
        Me.txtfac_Abono.Clear()
        Me.txtfac_Subtotal.Clear()
        Me.txtfac_ITBIS.Clear()
        Me.txtfac_Total.Clear()
        Me.rtxtfac_Descripcion.Clear()
        Me.cbfac_NCF.SelectedValue() = 0
        Me.mtxtfac_NCF.Clear()
        Me.BindingNavigatorPositionItem.Clear()
        Me.BindingNavigatorCountItem.Text = ""
    End Sub

    Private Sub PropertyReadOnlyOn()
        Me.txtfac_Codigo.ReadOnly = True
        Me.txtfac_IdOrden.ReadOnly = True
        Me.txtfac_IdCliente.ReadOnly = True
        Me.txtfac_NombreCli.ReadOnly = True
        Me.txtfac_Adeudado.ReadOnly = True
        Me.txtfac_Abono.ReadOnly = True
        Me.txtfac_Subtotal.ReadOnly = True
        Me.txtfac_ITBIS.ReadOnly = True
        Me.txtfac_Total.ReadOnly = True
        Me.rtxtfac_Descripcion.ReadOnly = True
        Me.mtxtfac_NCF.ReadOnly = True
        Me.cbfac_NCF.Enabled = True
    End Sub

    Private Sub PropertyReadOnlyOff()
        Me.txtfac_Codigo.ReadOnly = False
        Me.txtfac_IdOrden.ReadOnly = False
        Me.rtxtfac_Descripcion.ReadOnly = False
        Me.mtxtfac_NCF.ReadOnly = False
        Me.cbfac_NCF.Enabled = False
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
        Adap = New SqlDataAdapter("SELECT * FROM tFactura", Conexion)
        Dim Query As New SqlCommandBuilder(Adap)
        DS = New DataSet
        Adap.Fill(DS, "tFactura")
        Desconectar()
        Me.posicion = 0

    End Sub

    Private Sub DataLoad()
        Dim drFact As DataRow

        drFact = DS.Tables("tFactura").Rows(Me.posicion)
        Me.txtfac_Codigo.Text = drFact("factID")
        Me.txtfac_IdOrden.Text = drFact("orreID")
        Me.txtfac_IdCliente.Text = drFact("cliID")
        Me.txtfac_Subtotal.Text = drFact("factSubTotal")
        Me.txtfac_ITBIS.Text = drFact("factITBIS")
        Me.txtfac_Total.Text = drFact("factTotal")
        Me.rtxtfac_Descripcion.Text = drFact("factDescripcion")
        Me.mtxtfac_NCF.Text = drFact("factNCF")

        Me.BindingNavigatorPositionItem.Text = Me.posicion + 1
        Me.BindingNavigatorCountItem.Text = DS.Tables("tFactura").Rows.Count()
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

    Private Sub fFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JobBaezDBDataSet.tNCF' table. You can move, or remove it, as needed.
        Me.TNCFTableAdapter.Fill(Me.JobBaezDBDataSet.tNCF)

        ActualizarAdap()
        Me.DataLoad()

        LimpiarControles()

    End Sub

    Private Sub btsSalir_Click(sender As Object, e As EventArgs) Handles btsSalir.Click
        Me.Close()
    End Sub

    Private Sub btsBuscar_Click(sender As Object, e As EventArgs) Handles btsBuscar.Click
        Me.btsBuscar.Enabled = False

        If Not Me.btsBuscar.Enabled = True Then
            Me.txtprefac_Codigo.Focus()

            With Me.txtprefac_Codigo
                .Enabled = True
                .BackColor = Color.AliceBlue
            End With

            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            Me.txtprefac_Codigo.ReadOnly = False
            '------------------------------
            Me.proBuscar = True
            '------------------------------
            LimpiarControles()

        End If
    End Sub

    Private Sub btsPrimero_Click(sender As Object, e As EventArgs) Handles btsPrimero.Click
        If Me.posicion = 0 Then
            MessageBox.Show("Este es el primer registro.")
        Else
            Me.posicion -= 1
            Me.DataLoad()

            Try
                Conectar()

                Dim Com As New SqlCommand("SELECT cliNombre FROM tClientes cli WHERE cli.cliID='" + Me.txtprefac_IdCliente.Text.Trim + "'", Conexion)
                Dim ReaderCliId As SqlDataReader

                ReaderCliId = Com.ExecuteReader()

                If ReaderCliId.Read Then
                    Me.txtprefac_NombreCli.Text = ReaderCliId("cliNombre")
                    ReaderCliId.Close()
                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL BUSCAR EL CAMPO DE NOMBRE DE CLIENTE EN LA BASE DE DATOS, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try
        End If
    End Sub

    Private Sub btsAnterior_Click(sender As Object, e As EventArgs) Handles btsAnterior.Click
        If Me.posicion = 0 Then
            MessageBox.Show("Este es el primer registro.")
        Else
            Me.posicion -= 1
            Me.DataLoad()

            Try
                Conectar()

                Dim Com As New SqlCommand("SELECT cliNombre FROM tClientes cli WHERE cli.cliID='" + Me.txtprefac_IdCliente.Text.Trim + "'", Conexion)
                Dim ReaderCliId As SqlDataReader

                ReaderCliId = Com.ExecuteReader()

                If ReaderCliId.Read Then
                    Me.txtprefac_NombreCli.Text = ReaderCliId("cliNombre")
                    ReaderCliId.Close()
                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL BUSCAR EL CAMPO DE NOMBRE DE CLIENTE EN LA BASE DE DATOS, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try
        End If
    End Sub

    Private Sub btsSiguiente_Click(sender As Object, e As EventArgs) Handles btsSiguiente.Click
        If Me.posicion = DS.Tables("tpreFact").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion += 1
            Me.DataLoad()

            Try
                Conectar()

                Dim Com As New SqlCommand("SELECT cliNombre FROM tClientes cli WHERE cli.cliID='" + Me.txtprefac_IdCliente.Text.Trim + "'", Conexion)
                Dim ReaderCliId As SqlDataReader

                ReaderCliId = Com.ExecuteReader()

                If ReaderCliId.Read Then
                    Me.txtprefac_NombreCli.Text = ReaderCliId("cliNombre")
                    ReaderCliId.Close()
                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL BUSCAR EL CAMPO DE NOMBRE DE CLIENTE EN LA BASE DE DATOS, #ERROR: " & ex.Message)

            Finally
                Desconectar()
            End Try
        End If
    End Sub

    Private Sub btsUltimo_Click(sender As Object, e As EventArgs) Handles btsUltimo.Click
        Me.posicion = (DS.Tables("tpreFact").Rows.Count - 1)
        Me.DataLoad()

        Try
            Conectar()

            Dim Com As New SqlCommand("SELECT cliNombre FROM tClientes cli WHERE cli.cliID='" + Me.txtprefac_IdCliente.Text.Trim + "'", Conexion)
            Dim ReaderCliId As SqlDataReader

            ReaderCliId = Com.ExecuteReader()

            If ReaderCliId.Read Then
                Me.txtprefac_NombreCli.Text = ReaderCliId("cliNombre")
                ReaderCliId.Close()
            End If

        Catch ex As Exception
            Throw New Exception("ERROR AL BUSCAR EL CAMPO DE NOMBRE DE CLIENTE EN LA BASE DE DATOS, #ERROR: " & ex.Message)

        Finally
            Desconectar()
        End Try
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
            Me.txtprefac_Codigo.Focus()
            PropertyReadOnlyOff()
            Me.txtprefac_Codigo.ReadOnly = True

            Try
                Conectar()

                Dim Com As New SqlCommand("SELECT MAX(prefactID) + 1 AS ID FROM tpreFact", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader

                If Reader.Read Then
                    Me.txtprefac_Codigo.Text = Reader("ID")
                    Me.txtprefac_IdOrden.Focus()
                    PropertyReadOnlyOff()

                End If

            Catch ex As Exception
                Throw New Exception("ERROR AL TRATAR DE INSERTAR EL ID, #ERROR: " & ex.Message)
            Finally
                Desconectar()
            End Try

        End If
    End Sub

    Private Sub btsEditar_Click(sender As Object, e As EventArgs) Handles btsEditar.Click
        Me.btsEditar.Enabled = False

        If Not Me.btsEditar.Enabled = True Then
            Me.proEditar = True
            PropertyReadOnlyOff()
            Me.txtprefac_IdOrden.Focus()
            Me.txtprefac_Codigo.ReadOnly = True
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
            Me.txtprefac_Codigo.ReadOnly = False
            Me.txtprefac_Codigo.Focus()
            '------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True

        End If
    End Sub

    Private Sub btsAceptar_Click(sender As Object, e As EventArgs) Handles btsAceptar.Click
        '=====================================> BUSCAR <=====================================
        If Not Me.proBuscar = False Then
            If Me.txtprefac_Codigo.Text = "" Then
                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com2 As New SqlCommand("SELECT MAX(prefactID) AS ID FROM tpreFact", Conexion)
                    Dim Com1 As New SqlCommand("SELECT prefactID,orreID,cliID,prefactDescripcion," & _
                                               "(SELECT orreFact FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactFactOrre," & _
                                               "(SELECT orreAbono FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactAbonoOrre," & _
                                               "prefactSubTotal,prefactITBIS,prefactTotal FROM tpreFact preFact", Conexion)

                    Dim Reader1 As SqlDataReader
                    Dim Reader2 As SqlDataReader

                    Reader1 = Com1.ExecuteReader()
                    Reader2 = Com2.ExecuteReader()

                    If Reader1.Read Then
                        Me.txtprefac_Codigo.Text = Reader1("prefactID")
                        Me.txtprefac_IdOrden.Text = Reader1("orreID")
                        Me.txtprefac_IdCliente.Text = Reader1("cliID")
                        Me.txtprefac_Adeudado.Text = Reader1("prefactFactOrre")
                        Me.txtprefac_Abono.Text = Reader1("prefactAbonoOrre")
                        Me.txtprefac_Subtotal.Text = Reader1("prefactSubTotal")
                        Me.txtprefac_ITBIS.Text = Reader1("prefactITBIS")
                        Me.txtprefac_Total.Text = Reader1("prefactTotal")
                        Me.rtxtprefac_Descripcion.Text = Reader1("prefactDescripcion")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader1("prefactID"))

                        Me.txtprefac_Codigo.BackColor = Color.White

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

                Dim Com As New SqlCommand("SELECT prefactID,orreID,cliID,prefactDescripcion," & _
                                          "(SELECT cliNombre FROM tClientes cli WHERE cli.cliID=preFact.cliID) AS cliNombre," & _
                                          "(SELECT orreFact FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactFactOrre," & _
                                          "(SELECT orreAbono FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactAbonoOrre," & _
                                          "prefactSubTotal,prefactITBIS,prefactTotal FROM tpreFact preFact" & _
                                          " WHERE preFact.prefactID=" & Me.txtprefac_Codigo.Text.Trim & "", Conexion)
                Dim Reader As SqlDataReader

                Reader = Com.ExecuteReader()

                If Reader.Read Then
                    Me.txtprefac_Codigo.Text = Reader("prefactID")
                    Me.txtprefac_IdOrden.Text = Reader("orreID")
                    Me.txtprefac_IdCliente.Text = Reader("cliID")
                    Me.txtprefac_NombreCli.Text = Reader("cliNombre")
                    Me.txtprefac_Adeudado.Text = Reader("prefactFactOrre")
                    Me.txtprefac_Abono.Text = Reader("prefactAbonoOrre")
                    Me.txtprefac_Subtotal.Text = Reader("prefactSubTotal")
                    Me.txtprefac_ITBIS.Text = Reader("prefactITBIS")
                    Me.txtprefac_Total.Text = Reader("prefactTotal")
                    Me.rtxtprefac_Descripcion.Text = Reader("prefactDescripcion")
                    Me.BindingNavigatorPositionItem.Text = CStr(Reader("prefactID"))

                    Me.txtprefac_Codigo.BackColor = Color.White
                    Reader.Close()

                Else
                    LimpiarControles()
                    Me.txtprefac_Codigo.Focus()
                    MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")


                End If

                If Conexion.State = ConnectionState.Open Then
                    Conexion.Close()
                End If

                ControlsOn()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.txtprefac_Codigo.ReadOnly = True

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
                Dim Sql As String = "INSERT INTO tpreFact(prefactID,orreID,cliID,prefactDescripcion,prefactSubTotal,prefactITBIS,prefactTotal)" & _
                                    " VALUES ('" & Me.txtprefac_Codigo.Text.Trim & "','" & Me.txtprefac_IdOrden.Text.Trim & _
                                    "','" & Me.txtprefac_IdCliente.Text.Trim & "','" & Me.rtxtprefac_Descripcion.Text.Trim & _
                                    "','" & Me.txtprefac_Subtotal.Text.Trim & "','" & Me.txtprefac_ITBIS.Text.Trim & _
                                    "','" & Me.txtprefac_Total.Text.Trim & "')"

                If Insertar(Sql) Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtprefac_Codigo.Focus()
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
        ''=====================================> EDITAR <=====================================
        If Not Me.proEditar = False Then
            Try
                Dim Campos As String = "cliID='" & Me.txtprefac_IdCliente.Text.Trim & "',prefactDescripcion='" & Me.rtxtprefac_Descripcion.Text.Trim & "'"

                If Actualizar("tpreFact", Campos, "prefactID='" + Me.txtprefac_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    Me.txtprefac_Codigo.Focus()
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
                If Borrar("tpreFact", "prefactID='" + Me.txtprefac_Codigo.Text.Trim + "'") Then
                    PropertyReadOnlyOn()
                    ControlsOn()
                    LimpiarControles()
                    Me.txtprefac_Codigo.Focus()
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
        With Me.txtprefac_Codigo
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

    Private Sub txtfac_Codigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtfac_Codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            '=====================================> BUSCAR <=====================================
            If Not Me.proBuscar = False Then
                If Me.txtprefac_Codigo.Text = "" Then
                    Try
                        If Not Conexion.State = ConnectionState.Open Then
                            Conexion.Open()
                        End If

                        Dim Com2 As New SqlCommand("SELECT MAX(prefactID) AS ID FROM tpreFact", Conexion)
                        Dim Com1 As New SqlCommand("SELECT prefactID,orreID,cliID,prefactDescripcion," & _
                                                   "(SELECT orreFact FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactFactOrre," & _
                                                   "(SELECT orreAbono FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactAbonoOrre," & _
                                                   "prefactSubTotal,prefactITBIS,prefactTotal FROM tpreFact preFact", Conexion)

                        Dim Reader1 As SqlDataReader
                        Dim Reader2 As SqlDataReader

                        Reader1 = Com1.ExecuteReader()
                        Reader2 = Com2.ExecuteReader()

                        If Reader1.Read Then
                            Me.txtprefac_Codigo.Text = Reader1("prefactID")
                            Me.txtprefac_IdOrden.Text = Reader1("orreID")
                            Me.txtprefac_IdCliente.Text = Reader1("cliID")
                            Me.txtprefac_Adeudado.Text = Reader1("prefactFactOrre")
                            Me.txtprefac_Abono.Text = Reader1("prefactAbonoOrre")
                            Me.txtprefac_Subtotal.Text = Reader1("prefactSubTotal")
                            Me.txtprefac_ITBIS.Text = Reader1("prefactITBIS")
                            Me.txtprefac_Total.Text = Reader1("prefactTotal")
                            Me.rtxtprefac_Descripcion.Text = Reader1("prefactDescripcion")
                            Me.BindingNavigatorPositionItem.Text = CStr(Reader1("prefactID"))

                            Me.txtprefac_Codigo.BackColor = Color.White

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

                    Dim Com As New SqlCommand("SELECT prefactID,orreID,cliID,prefactDescripcion," & _
                                              "(SELECT cliNombre FROM tClientes cli WHERE cli.cliID=preFact.cliID) AS cliNombre," & _
                                              "(SELECT orreFact FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactFactOrre," & _
                                              "(SELECT orreAbono FROM tOrdenRecep ord WHERE ord.orreID = preFact.orreID) AS prefactAbonoOrre," & _
                                              "prefactSubTotal,prefactITBIS,prefactTotal FROM tpreFact preFact" & _
                                              " WHERE preFact.prefactID=" & Me.txtprefac_Codigo.Text.Trim & "", Conexion)
                    Dim Reader As SqlDataReader

                    Reader = Com.ExecuteReader()

                    If Reader.Read Then
                        Me.txtprefac_Codigo.Text = Reader("prefactID")
                        Me.txtprefac_IdOrden.Text = Reader("orreID")
                        Me.txtprefac_IdCliente.Text = Reader("cliID")
                        Me.txtprefac_NombreCli.Text = Reader("cliNombre")
                        Me.txtprefac_Adeudado.Text = Reader("prefactFactOrre")
                        Me.txtprefac_Abono.Text = Reader("prefactAbonoOrre")
                        Me.txtprefac_Subtotal.Text = Reader("prefactSubTotal")
                        Me.txtprefac_ITBIS.Text = Reader("prefactITBIS")
                        Me.txtprefac_Total.Text = Reader("prefactTotal")
                        Me.rtxtprefac_Descripcion.Text = Reader("prefactDescripcion")
                        Me.BindingNavigatorPositionItem.Text = CStr(Reader("prefactID"))

                        Me.txtprefac_Codigo.BackColor = Color.White
                        Reader.Close()

                    Else
                        LimpiarControles()
                        Me.txtprefac_Codigo.Focus()
                        MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")


                    End If

                    If Conexion.State = ConnectionState.Open Then
                        Conexion.Close()
                    End If

                    ControlsOn()
                    Me.btsAceptar.Enabled = False
                    Me.btsCancelar.Enabled = False
                    Me.txtprefac_Codigo.ReadOnly = True

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
                    Dim Sql As String = "INSERT INTO tpreFact(prefactID,orreID,cliID,prefactDescripcion,prefactSubTotal,prefactITBIS,prefactTotal)" & _
                                        " VALUES ('" & Me.txtprefac_Codigo.Text.Trim & "','" & Me.txtprefac_IdOrden.Text.Trim & _
                                        "','" & Me.txtprefac_IdCliente.Text.Trim & "','" & Me.rtxtprefac_Descripcion.Text.Trim & _
                                        "','" & Me.txtprefac_Subtotal.Text.Trim & "','" & Me.txtprefac_ITBIS.Text.Trim & _
                                        "','" & Me.txtprefac_Total.Text.Trim & "')"

                    If Insertar(Sql) Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtprefac_Codigo.Focus()
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
            ''=====================================> EDITAR <=====================================
            If Not Me.proEditar = False Then
                Try
                    Dim Campos As String = "cliID='" & Me.txtprefac_IdCliente.Text.Trim & "',prefactDescripcion='" & Me.rtxtprefac_Descripcion.Text.Trim & "'"

                    If Actualizar("tpreFact", Campos, "prefactID='" + Me.txtprefac_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        Me.txtprefac_Codigo.Focus()
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
                    If Borrar("tpreFact", "prefactID='" + Me.txtprefac_Codigo.Text.Trim + "'") Then
                        PropertyReadOnlyOn()
                        ControlsOn()
                        LimpiarControles()
                        Me.txtprefac_Codigo.Focus()
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

    Private Sub rtxtfac_Descripcion_Leave(sender As Object, e As EventArgs) Handles rtxtfac_Descripcion.Leave
        Dim valor1, valor2 As String

        '===============================> Buscando el Adeudado & el Abono <======================
        Try
            Conectar()

            Dim comNuevo As New SqlCommand("SELECT orreFact,orreAbono FROM tOrdenRecep WHERE orreID ='" & Me.txtprefac_IdOrden.Text.Trim & "'", Conexion)
            Dim readerNuevo As SqlDataReader

            readerNuevo = comNuevo.ExecuteReader()

            If readerNuevo.Read Then
                Me.txtprefac_Adeudado.Text = readerNuevo("orreFact")
                Me.txtprefac_Abono.Text = readerNuevo("orreAbono")
                readerNuevo.Close()
            End If

            valor1 = Me.txtprefac_Adeudado.Text
            valor2 = Me.txtprefac_Abono.Text

            valor1 = Replace(valor1, "RD$", "").Replace(",", "")
            valor2 = Replace(valor2, "RD$", "").Replace(",", "")

            Me.txtprefac_Subtotal.Text = Val(valor1) + Val(valor2)
            Me.txtprefac_ITBIS.Text = Val(Me.txtprefac_Subtotal.Text) * 0.1
            Me.txtprefac_Total.Text = Val(Me.txtprefac_Subtotal.Text) + Val(Me.txtprefac_ITBIS.Text)

            Me.txtprefac_Subtotal.Text = Format(CType(Me.txtprefac_Subtotal.Text, Decimal), "RD$###,###,###,###.00")
            Me.txtprefac_ITBIS.Text = Format(CType(Me.txtprefac_ITBIS.Text, Decimal), "RD$###,###,###,###.00")
            Me.txtprefac_Total.Text = Format(CType(Me.txtprefac_Total.Text, Decimal), "RD$###,###,###,###.00")

        Catch ex As Exception
            Throw New Exception("ERROR AL BUSCAR EL ADEUDADO/ABONO EN LA BASE DE DATOS, #ERROR: " & ex.Message)
        Finally
            Desconectar()
        End Try

        '============================>Fin de buscar el adeudado & el abono<======================
    End Sub
End Class