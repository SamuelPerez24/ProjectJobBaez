Imports System.Data.SqlClient
Imports System.Data
Imports JobBaez_System.ConnectionQuerysClass
Imports JobBaez_System.modVariables

Public Class fMenuPrincipal

    Dim mdiChildForm As New Form

    Private Sub FondoMDI()
        Dim Cont As Control
        For Each Cont In Me.Controls
            If TypeOf (Cont) Is MdiClient Then
                Cont.BackColor = System.Drawing.Color.White
            End If
        Next
    End Sub


    Private Sub fMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fLogin.Show()

        IsMdiContainer = True
        mdiChildForm.MdiParent = Me
        FondoMDI()

    End Sub

    Private Sub ToolStripLabel6_Click(sender As Object, e As EventArgs) Handles ToolStripLabel6.Click
        Application.Exit()
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        fClientes.MdiParent = Me
        fClientes.Show()
    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        frepFactura.MdiParent = Me
        frepFactura.Show()
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        frepPreFact.MdiParent = Me
        frepPreFact.Show()
    End Sub

    Private Sub ToolStripLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripLabel4.Click
        frepIngreso.MdiParent = Me
        frepIngreso.Show()
    End Sub

    Private Sub ToolStripLabel5_Click(sender As Object, e As EventArgs) Handles ToolStripLabel5.Click, ToolStripLabel7.Click
        fOrdenRecep.MdiParent = Me
        fOrdenRecep.Show()
    End Sub
End Class