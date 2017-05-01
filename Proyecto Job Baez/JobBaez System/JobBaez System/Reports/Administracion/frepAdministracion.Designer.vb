<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frepAdministracion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crvAdministracion = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.repAdministracion1 = New JobBaez_System.repAdministracion()
        Me.SuspendLayout()
        '
        'crvAdministracion
        '
        Me.crvAdministracion.ActiveViewIndex = 0
        Me.crvAdministracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvAdministracion.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvAdministracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvAdministracion.Location = New System.Drawing.Point(0, 0)
        Me.crvAdministracion.Name = "crvAdministracion"
        Me.crvAdministracion.ReportSource = Me.repAdministracion1
        Me.crvAdministracion.Size = New System.Drawing.Size(478, 261)
        Me.crvAdministracion.TabIndex = 0
        '
        'frepAdministracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 261)
        Me.Controls.Add(Me.crvAdministracion)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frepAdministracion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvAdministracion As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents repAdministracion1 As JobBaez_System.repAdministracion
End Class
