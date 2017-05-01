Imports System.Data.OleDb
Imports WindowsApplication3.QuerysClass
Imports WindowsApplication3.modVariables

Public Class Form1

#Region "Metodos"
    Private Sub LimpiarControles()
        Me.id.Clear()
        Me.prueba2.Clear()
        Me.prueba3.Clear()
        Me.prueba4.Clear()
        Me.prueba5.Clear()
        Me.prueba6.Clear()
        Me.BindingNavigatorPositionItem.Clear()
        Me.BindingNavigatorCountItem.Text = ""
    End Sub
    Private Sub PropertyReadOnlyOn()
        Me.id.ReadOnly = True
        Me.prueba2.ReadOnly = True
        Me.prueba3.ReadOnly = True
        Me.prueba4.ReadOnly = True
        Me.prueba5.ReadOnly = True
        Me.prueba6.ReadOnly = True
    End Sub
    Private Sub PropertyReadOnlyOff()
        Me.id.ReadOnly = False
        Me.prueba2.ReadOnly = False
        Me.prueba3.ReadOnly = False
        Me.prueba4.ReadOnly = False
        Me.prueba5.ReadOnly = False
        Me.prueba6.ReadOnly = False
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
        Me.btsImprimir.Enabled = False
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
        Me.btsImprimir.Enabled = True
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

    Private Sub btsBuscar_Click(sender As Object, e As EventArgs) Handles btsBuscar.Click
        Me.btsBuscar.Enabled = False

        If Not Me.btsBuscar.Enabled = True Then
            Me.id.Focus()
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            Me.id.ReadOnly = False
            '------------------------------
            Me.proBuscar = True
            '------------------------------
            LimpiarControles()
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Adap = New OleDbDataAdapter("SELECT * FROM tPrueba", Conexion)
        Dim Query As OleDbCommandBuilder = New OleDbCommandBuilder(Adap)
        DS = New DataSet
        Conexion.Open()
        Adap.Fill(DS, "tPrueba")
        Conexion.Close()
        Me.posicion = 0
        Me.DataLoad()

        LimpiarControles()
    End Sub

    Private Sub btsAceptar_Click(sender As Object, e As EventArgs) Handles btsAceptar.Click
        If Not Me.proBuscar = False Then
            If Me.id.Text = "" Then
                Try
                    If Not Conexion.State = ConnectionState.Open Then
                        Conexion.Open()
                    End If

                    Dim Com2 As New OleDbCommand("SELECT MAX(Idprueba1) AS ID FROM tPrueba", Conexion)
                    Dim Com1 As New OleDbCommand("SELECT * FROM tPrueba", Conexion)
                    Dim Reader1 As OleDbDataReader
                    Dim Reader2 As OleDbDataReader

                    Reader1 = Com1.ExecuteReader
                    Reader2 = Com2.ExecuteReader

                    If Reader1.Read Then
                        Me.id.Text = Reader1("Idprueba1")
                        Me.prueba2.Text = Reader1("prueba2")
                        Me.prueba3.Text = Reader1("prueba3")
                        Me.prueba4.Text = Reader1("prueba4")
                        Me.prueba5.Text = Reader1("prueba5")
                        Me.prueba6.Text = Reader1("prueba6")
                        Me.BindingNavigatorPositionItem.Text = Reader1("Idprueba1")
                    End If

                    If Reader2.Read Then
                        Me.BindingNavigatorCountItem.Text = "de " + CStr(Reader2("ID"))
                    End If

                Catch ex As Exception
                    Throw New Exception("ERROR AL BUSCAR TODOS LOS DATOS REQUERIDO, #ERROR: " & ex.Message)
                Finally
                    Conexion.Close()
                End Try
            End If

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New OleDbCommand("SELECT * FROM tPrueba WHERE Idprueba1=" + Me.id.Text.Trim() + "", Conexion)
                Dim Reader As OleDbDataReader

                Reader = Com.ExecuteReader()

                If Reader.Read Then
                    Me.id.Text = Reader("Idprueba1")
                    Me.prueba2.Text = Reader("prueba2")
                    Me.prueba3.Text = Reader("prueba3")
                    Me.prueba4.Text = Reader("prueba4")
                    Me.prueba5.Text = Reader("prueba5")
                    Me.prueba6.Text = Reader("prueba6")
                    Me.BindingNavigatorPositionItem.Text = Reader("Idprueba1")
                Else
                    LimpiarControles()
                    Me.id.Focus()
                    MsgBox("El campo que ha introducido no existe.", MsgBoxStyle.Critical, "ERROR")

                End If

                If Conexion.State = ConnectionState.Open Then
                    Conexion.Close()
                End If

                ControlsOn()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.id.ReadOnly = True

            Catch ex As Exception
                Throw New Exception("ERROR AL BUSCAR LOS DATOS REQUERIDO, #ERROR: " & ex.Message)
            Finally
                Conexion.Close()
            End Try

            '------------------------------
            Me.proBuscar = False
            '------------------------------
        End If

        If Not Me.proNuevo = False Then
            Dim Sql As String = "INSERT INTO tPrueba(Idprueba1,prueba2,prueba3,prueba4,prueba5,prueba6) VALUES (" + _
                                 Me.id.Text.Trim + ",'" + Me.prueba2.Text.Trim + "','" + Me.prueba3.Text.Trim + "','" + Me.prueba4.Text.Trim + _
                                 "','" + Me.prueba5.Text.Trim + "','" + Me.prueba6.Text.Trim + "')"
            If Insertar(Sql) Then
                PropertyReadOnlyOn()
                ControlsOn()
                Me.id.Focus()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.proNuevo = False
            End If
        End If

        If Not Me.proEditar = False Then
            Dim Campos As String = "prueba2='" + Me.prueba2.Text.Trim + "',prueba3='" + Me.prueba3.Text.Trim + "',prueba4='" + Me.prueba4.Text.Trim + _
                "',prueba5='" + Me.prueba5.Text.Trim + "', prueba6='" + Me.prueba6.Text.Trim + "'"

            If Actualizar("tPrueba", Campos, "Idprueba1=" + Me.id.Text.Trim + "") Then
                PropertyReadOnlyOn()
                ControlsOn()
                Me.id.Focus()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.proEditar = False
            End If
        End If

        If Not Me.proEliminar = False Then
            If Borrar("tPrueba", "Idprueba1=" + Me.id.Text.Trim + "") Then
                PropertyReadOnlyOn()
                ControlsOn()
                LimpiarControles()
                Me.id.Focus()
                Me.btsAceptar.Enabled = False
                Me.btsCancelar.Enabled = False
                Me.proEliminar = False
            End If
        End If

    End Sub

    Private Sub btsSalir_Click(sender As Object, e As EventArgs) Handles btsSalir.Click
        Application.Exit()
    End Sub

    Private Sub btsCancelar_Click(sender As Object, e As EventArgs) Handles btsCancelar.Click
        ControlsOff()
        Me.id.Focus()
        Me.btsBuscar.Enabled = True
        Me.btsImprimir.Enabled = True
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

    Private Sub btsNuevo_Click(sender As Object, e As EventArgs) Handles btsNuevo.Click
        Me.btsNuevo.Enabled = False

        If Not Me.btsNuevo.Enabled = True Then
            LimpiarControles()
            Me.proNuevo = True
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
            '-----------------------------------------
            Me.id.Focus()
            PropertyReadOnlyOff()
            Me.id.ReadOnly = True

            Try
                If Not Conexion.State = ConnectionState.Open Then
                    Conexion.Open()
                End If

                Dim Com As New OleDbCommand("SELECT MAX(Idprueba1) + 1 AS ID FROM tPrueba", Conexion)
                Dim Reader As OleDbDataReader

                Reader = Com.ExecuteReader

                If Reader.Read Then
                    Me.id.Text = Reader("ID")
                    Me.prueba2.Focus()
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
            Me.id.Focus()
            Me.id.ReadOnly = True
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
            Me.id.ReadOnly = False
            Me.id.Focus()
            '------------------------------------------
            ControlsOff()
            Me.btsAceptar.Enabled = True
            Me.btsCancelar.Enabled = True
        End If
    End Sub

    Private Sub DataLoad()
        Dim drPrueba As DataRow
        drPrueba = DS.Tables("tPrueba").Rows(Me.posicion)
        Me.id.Text = drPrueba("Idprueba1")
        Me.prueba2.Text = drPrueba("prueba2")
        Me.prueba3.Text = drPrueba("prueba3")
        Me.prueba4.Text = drPrueba("prueba4")
        Me.prueba5.Text = drPrueba("prueba5")
        Me.prueba6.Text = drPrueba("prueba6")
        Me.BindingNavigatorPositionItem.Text = Me.posicion + 1
        Me.BindingNavigatorCountItem.Text = DS.Tables("tPrueba").Rows.Count()

    End Sub

    Private Sub btsPrimero_Click(sender As Object, e As EventArgs) Handles btsPrimero.Click
        If Me.posicion = 0 Then
            MessageBox.Show("Este es el primer registro.")
        Else
            Me.posicion = 0
            Me.DataLoad()
        End If
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
        If Me.posicion = DS.Tables("tPrueba").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion += 1
            Me.DataLoad()
        End If
    End Sub

    Private Sub btsUltimo_Click(sender As Object, e As EventArgs) Handles btsUltimo.Click
        If Me.posicion = DS.Tables("tPrueba").Rows.Count - 1 Then
            MessageBox.Show("Este es el ultimo registro.")
        Else
            Me.posicion = (DS.Tables("tPrueba").Rows.Count - 1)
            Me.DataLoad()
        End If
    End Sub
End Class
