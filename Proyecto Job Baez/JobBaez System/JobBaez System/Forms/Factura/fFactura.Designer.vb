<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fFactura
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fFactura))
        Me.txtfac_IdOrden = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtfac_Total = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtfac_ITBIS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtfac_Subtotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtfac_Abono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtfac_Adeudado = New System.Windows.Forms.TextBox()
        Me.rtxtfac_Descripcion = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtfac_NombreCli = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtord_IdFijo = New System.Windows.Forms.TextBox()
        Me.txtfac_IdCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfac_Codigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bnavFacturacion = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.btsBorrar = New System.Windows.Forms.ToolStripButton()
        Me.btsBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btsPrimero = New System.Windows.Forms.ToolStripButton()
        Me.btsAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btsSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.btsUltimo = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btsNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btsEditar = New System.Windows.Forms.ToolStripButton()
        Me.btsAceptar = New System.Windows.Forms.ToolStripButton()
        Me.btsCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btsReporte = New System.Windows.Forms.ToolStripButton()
        Me.btsSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbfac_NCF = New System.Windows.Forms.ComboBox()
        Me.JobBaezDBDataSet = New JobBaez_System.JobBaezDBDataSet()
        Me.TNCFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TNCFTableAdapter = New JobBaez_System.JobBaezDBDataSetTableAdapters.tNCFTableAdapter()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.mtxtfac_NCF = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.bnavFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnavFacturacion.SuspendLayout()
        CType(Me.JobBaezDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNCFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtfac_IdOrden
        '
        Me.txtfac_IdOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_IdOrden.ForeColor = System.Drawing.Color.Black
        Me.txtfac_IdOrden.Location = New System.Drawing.Point(354, 15)
        Me.txtfac_IdOrden.Name = "txtfac_IdOrden"
        Me.txtfac_IdOrden.ReadOnly = True
        Me.txtfac_IdOrden.Size = New System.Drawing.Size(91, 21)
        Me.txtfac_IdOrden.TabIndex = 27
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(246, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 17)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Código orden:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfac_Total)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtfac_ITBIS)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtfac_Subtotal)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtfac_Abono)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtfac_Adeudado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(720, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 176)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la factura"
        '
        'txtfac_Total
        '
        Me.txtfac_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_Total.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtfac_Total.Location = New System.Drawing.Point(98, 140)
        Me.txtfac_Total.MaxLength = 21
        Me.txtfac_Total.Name = "txtfac_Total"
        Me.txtfac_Total.ReadOnly = True
        Me.txtfac_Total.Size = New System.Drawing.Size(155, 21)
        Me.txtfac_Total.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(42, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Total:"
        '
        'txtfac_ITBIS
        '
        Me.txtfac_ITBIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_ITBIS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtfac_ITBIS.Location = New System.Drawing.Point(98, 113)
        Me.txtfac_ITBIS.MaxLength = 21
        Me.txtfac_ITBIS.Name = "txtfac_ITBIS"
        Me.txtfac_ITBIS.ReadOnly = True
        Me.txtfac_ITBIS.Size = New System.Drawing.Size(155, 21)
        Me.txtfac_ITBIS.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(42, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "ITBIS:"
        '
        'txtfac_Subtotal
        '
        Me.txtfac_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_Subtotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtfac_Subtotal.Location = New System.Drawing.Point(98, 83)
        Me.txtfac_Subtotal.MaxLength = 21
        Me.txtfac_Subtotal.Name = "txtfac_Subtotal"
        Me.txtfac_Subtotal.ReadOnly = True
        Me.txtfac_Subtotal.Size = New System.Drawing.Size(155, 21)
        Me.txtfac_Subtotal.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Subtotal:"
        '
        'txtfac_Abono
        '
        Me.txtfac_Abono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_Abono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtfac_Abono.Location = New System.Drawing.Point(98, 56)
        Me.txtfac_Abono.MaxLength = 21
        Me.txtfac_Abono.Name = "txtfac_Abono"
        Me.txtfac_Abono.ReadOnly = True
        Me.txtfac_Abono.Size = New System.Drawing.Size(155, 21)
        Me.txtfac_Abono.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(33, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 17)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Abono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Adeudado:"
        '
        'txtfac_Adeudado
        '
        Me.txtfac_Adeudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_Adeudado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtfac_Adeudado.Location = New System.Drawing.Point(98, 27)
        Me.txtfac_Adeudado.MaxLength = 21
        Me.txtfac_Adeudado.Name = "txtfac_Adeudado"
        Me.txtfac_Adeudado.ReadOnly = True
        Me.txtfac_Adeudado.Size = New System.Drawing.Size(155, 21)
        Me.txtfac_Adeudado.TabIndex = 1
        '
        'rtxtfac_Descripcion
        '
        Me.rtxtfac_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtfac_Descripcion.Location = New System.Drawing.Point(123, 97)
        Me.rtxtfac_Descripcion.MaxLength = 250
        Me.rtxtfac_Descripcion.Name = "rtxtfac_Descripcion"
        Me.rtxtfac_Descripcion.ReadOnly = True
        Me.rtxtfac_Descripcion.Size = New System.Drawing.Size(591, 103)
        Me.rtxtfac_Descripcion.TabIndex = 33
        Me.rtxtfac_Descripcion.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(28, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Descripción:"
        '
        'txtfac_NombreCli
        '
        Me.txtfac_NombreCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_NombreCli.ForeColor = System.Drawing.Color.Black
        Me.txtfac_NombreCli.Location = New System.Drawing.Point(123, 70)
        Me.txtfac_NombreCli.MaxLength = 100
        Me.txtfac_NombreCli.Name = "txtfac_NombreCli"
        Me.txtfac_NombreCli.ReadOnly = True
        Me.txtfac_NombreCli.Size = New System.Drawing.Size(591, 21)
        Me.txtfac_NombreCli.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Nombre cliente:"
        '
        'txtord_IdFijo
        '
        Me.txtord_IdFijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtord_IdFijo.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtord_IdFijo.Location = New System.Drawing.Point(563, 15)
        Me.txtord_IdFijo.Name = "txtord_IdFijo"
        Me.txtord_IdFijo.ReadOnly = True
        Me.txtord_IdFijo.Size = New System.Drawing.Size(24, 21)
        Me.txtord_IdFijo.TabIndex = 35
        Me.txtord_IdFijo.Text = "12"
        Me.txtord_IdFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtfac_IdCliente
        '
        Me.txtfac_IdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_IdCliente.ForeColor = System.Drawing.Color.Black
        Me.txtfac_IdCliente.Location = New System.Drawing.Point(591, 15)
        Me.txtfac_IdCliente.Name = "txtfac_IdCliente"
        Me.txtfac_IdCliente.ReadOnly = True
        Me.txtfac_IdCliente.Size = New System.Drawing.Size(123, 21)
        Me.txtfac_IdCliente.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(451, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 17)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Código cliente:"
        '
        'txtfac_Codigo
        '
        Me.txtfac_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfac_Codigo.ForeColor = System.Drawing.Color.Black
        Me.txtfac_Codigo.Location = New System.Drawing.Point(123, 17)
        Me.txtfac_Codigo.Name = "txtfac_Codigo"
        Me.txtfac_Codigo.ReadOnly = True
        Me.txtfac_Codigo.Size = New System.Drawing.Size(117, 21)
        Me.txtfac_Codigo.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(63, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Código:"
        '
        'bnavFacturacion
        '
        Me.bnavFacturacion.AddNewItem = Nothing
        Me.bnavFacturacion.BackColor = System.Drawing.Color.Gainsboro
        Me.bnavFacturacion.CountItem = Me.BindingNavigatorCountItem
        Me.bnavFacturacion.DeleteItem = Me.btsBorrar
        Me.bnavFacturacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnavFacturacion.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bnavFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btsBuscar, Me.ToolStripSeparator1, Me.btsPrimero, Me.btsAnterior, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.btsSiguiente, Me.btsUltimo, Me.BindingNavigatorSeparator2, Me.btsNuevo, Me.btsEditar, Me.btsBorrar, Me.btsAceptar, Me.btsCancelar, Me.ToolStripSeparator2, Me.btsReporte, Me.btsSalir})
        Me.bnavFacturacion.Location = New System.Drawing.Point(0, 219)
        Me.bnavFacturacion.MoveFirstItem = Me.btsPrimero
        Me.bnavFacturacion.MoveLastItem = Me.btsUltimo
        Me.bnavFacturacion.MoveNextItem = Me.btsSiguiente
        Me.bnavFacturacion.MovePreviousItem = Me.btsAnterior
        Me.bnavFacturacion.Name = "bnavFacturacion"
        Me.bnavFacturacion.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnavFacturacion.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.bnavFacturacion.Size = New System.Drawing.Size(1002, 42)
        Me.bnavFacturacion.Stretch = True
        Me.bnavFacturacion.TabIndex = 34
        Me.bnavFacturacion.Text = "Navegador"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 39)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'btsBorrar
        '
        Me.btsBorrar.Enabled = False
        Me.btsBorrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsBorrar.Image = CType(resources.GetObject("btsBorrar.Image"), System.Drawing.Image)
        Me.btsBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsBorrar.Name = "btsBorrar"
        Me.btsBorrar.RightToLeftAutoMirrorImage = True
        Me.btsBorrar.Size = New System.Drawing.Size(47, 39)
        Me.btsBorrar.Text = "Borrar"
        Me.btsBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsBuscar
        '
        Me.btsBuscar.BackColor = System.Drawing.Color.Transparent
        Me.btsBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsBuscar.ForeColor = System.Drawing.Color.Black
        Me.btsBuscar.Image = CType(resources.GetObject("btsBuscar.Image"), System.Drawing.Image)
        Me.btsBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsBuscar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btsBuscar.Name = "btsBuscar"
        Me.btsBuscar.Size = New System.Drawing.Size(48, 39)
        Me.btsBuscar.Text = "Buscar"
        Me.btsBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btsBuscar.ToolTipText = "Buscar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.BackColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'btsPrimero
        '
        Me.btsPrimero.Enabled = False
        Me.btsPrimero.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsPrimero.Image = CType(resources.GetObject("btsPrimero.Image"), System.Drawing.Image)
        Me.btsPrimero.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsPrimero.Name = "btsPrimero"
        Me.btsPrimero.RightToLeftAutoMirrorImage = True
        Me.btsPrimero.Size = New System.Drawing.Size(37, 39)
        Me.btsPrimero.Text = "Prim"
        Me.btsPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsAnterior
        '
        Me.btsAnterior.Enabled = False
        Me.btsAnterior.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsAnterior.Image = CType(resources.GetObject("btsAnterior.Image"), System.Drawing.Image)
        Me.btsAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsAnterior.Name = "btsAnterior"
        Me.btsAnterior.RightToLeftAutoMirrorImage = True
        Me.btsAnterior.Size = New System.Drawing.Size(31, 39)
        Me.btsAnterior.Text = "Ant"
        Me.btsAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.BackColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator.ForeColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 42)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.BackColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator1.ForeColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'btsSiguiente
        '
        Me.btsSiguiente.Enabled = False
        Me.btsSiguiente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsSiguiente.Image = CType(resources.GetObject("btsSiguiente.Image"), System.Drawing.Image)
        Me.btsSiguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsSiguiente.Name = "btsSiguiente"
        Me.btsSiguiente.RightToLeftAutoMirrorImage = True
        Me.btsSiguiente.Size = New System.Drawing.Size(28, 39)
        Me.btsSiguiente.Text = "Sig"
        Me.btsSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsUltimo
        '
        Me.btsUltimo.Enabled = False
        Me.btsUltimo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsUltimo.Image = CType(resources.GetObject("btsUltimo.Image"), System.Drawing.Image)
        Me.btsUltimo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsUltimo.Name = "btsUltimo"
        Me.btsUltimo.RightToLeftAutoMirrorImage = True
        Me.btsUltimo.Size = New System.Drawing.Size(28, 39)
        Me.btsUltimo.Text = "Ult"
        Me.btsUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.BackColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator2.ForeColor = System.Drawing.Color.Black
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'btsNuevo
        '
        Me.btsNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsNuevo.Image = CType(resources.GetObject("btsNuevo.Image"), System.Drawing.Image)
        Me.btsNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btsNuevo.Name = "btsNuevo"
        Me.btsNuevo.Size = New System.Drawing.Size(48, 39)
        Me.btsNuevo.Text = "Nuevo"
        Me.btsNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsEditar
        '
        Me.btsEditar.Enabled = False
        Me.btsEditar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsEditar.Image = CType(resources.GetObject("btsEditar.Image"), System.Drawing.Image)
        Me.btsEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btsEditar.Name = "btsEditar"
        Me.btsEditar.Size = New System.Drawing.Size(43, 39)
        Me.btsEditar.Text = "Editar"
        Me.btsEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsAceptar
        '
        Me.btsAceptar.Enabled = False
        Me.btsAceptar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsAceptar.Image = CType(resources.GetObject("btsAceptar.Image"), System.Drawing.Image)
        Me.btsAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsAceptar.Name = "btsAceptar"
        Me.btsAceptar.RightToLeftAutoMirrorImage = True
        Me.btsAceptar.Size = New System.Drawing.Size(55, 39)
        Me.btsAceptar.Text = "Aceptar"
        Me.btsAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsCancelar
        '
        Me.btsCancelar.Enabled = False
        Me.btsCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsCancelar.Image = CType(resources.GetObject("btsCancelar.Image"), System.Drawing.Image)
        Me.btsCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsCancelar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btsCancelar.Name = "btsCancelar"
        Me.btsCancelar.Size = New System.Drawing.Size(58, 39)
        Me.btsCancelar.Text = "Cancelar"
        Me.btsCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.BackColor = System.Drawing.Color.Black
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'btsReporte
        '
        Me.btsReporte.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsReporte.Image = Global.JobBaez_System.My.Resources.Resources.Print_fw
        Me.btsReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsReporte.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btsReporte.Name = "btsReporte"
        Me.btsReporte.Size = New System.Drawing.Size(57, 39)
        Me.btsReporte.Text = "Reporte"
        Me.btsReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btsSalir
        '
        Me.btsSalir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btsSalir.Image = CType(resources.GetObject("btsSalir.Image"), System.Drawing.Image)
        Me.btsSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btsSalir.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btsSalir.Name = "btsSalir"
        Me.btsSalir.Size = New System.Drawing.Size(35, 39)
        Me.btsSalir.Text = "Salir"
        Me.btsSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(23, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 17)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Tipo de NCF:"
        '
        'cbfac_NCF
        '
        Me.cbfac_NCF.DataSource = Me.TNCFBindingSource
        Me.cbfac_NCF.DisplayMember = "ncf"
        Me.cbfac_NCF.Enabled = False
        Me.cbfac_NCF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbfac_NCF.ForeColor = System.Drawing.Color.Black
        Me.cbfac_NCF.FormattingEnabled = True
        Me.cbfac_NCF.Location = New System.Drawing.Point(123, 44)
        Me.cbfac_NCF.Name = "cbfac_NCF"
        Me.cbfac_NCF.Size = New System.Drawing.Size(233, 23)
        Me.cbfac_NCF.TabIndex = 38
        '
        'JobBaezDBDataSet
        '
        Me.JobBaezDBDataSet.DataSetName = "JobBaezDBDataSet"
        Me.JobBaezDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TNCFBindingSource
        '
        Me.TNCFBindingSource.DataMember = "tNCF"
        Me.TNCFBindingSource.DataSource = Me.JobBaezDBDataSet
        '
        'TNCFTableAdapter
        '
        Me.TNCFTableAdapter.ClearBeforeFill = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(372, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 17)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "No. NCF:"
        '
        'mtxtfac_NCF
        '
        Me.mtxtfac_NCF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtfac_NCF.Location = New System.Drawing.Point(441, 46)
        Me.mtxtfac_NCF.Name = "mtxtfac_NCF"
        Me.mtxtfac_NCF.ReadOnly = True
        Me.mtxtfac_NCF.Size = New System.Drawing.Size(273, 21)
        Me.mtxtfac_NCF.TabIndex = 40
        '
        'fFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(1002, 261)
        Me.Controls.Add(Me.mtxtfac_NCF)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cbfac_NCF)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtfac_IdOrden)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtxtfac_Descripcion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtfac_NombreCli)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtord_IdFijo)
        Me.Controls.Add(Me.txtfac_IdCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtfac_Codigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bnavFacturacion)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fFactura"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Facturación"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.bnavFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnavFacturacion.ResumeLayout(False)
        Me.bnavFacturacion.PerformLayout()
        CType(Me.JobBaezDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNCFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtfac_IdOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtfac_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtfac_ITBIS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtfac_Subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtfac_Abono As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtfac_Adeudado As System.Windows.Forms.TextBox
    Friend WithEvents rtxtfac_Descripcion As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfac_NombreCli As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtord_IdFijo As System.Windows.Forms.TextBox
    Friend WithEvents txtfac_IdCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfac_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bnavFacturacion As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btsBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btsPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btsSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btsNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btsReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents btsSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbfac_NCF As System.Windows.Forms.ComboBox
    Friend WithEvents JobBaezDBDataSet As JobBaez_System.JobBaezDBDataSet
    Friend WithEvents TNCFBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TNCFTableAdapter As JobBaez_System.JobBaezDBDataSetTableAdapters.tNCFTableAdapter
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents mtxtfac_NCF As System.Windows.Forms.MaskedTextBox
End Class
