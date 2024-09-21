<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBLctp = New System.Windows.Forms.Label()
        Me.LBLcts = New System.Windows.Forms.Label()
        Me.LBLptp = New System.Windows.Forms.Label()
        Me.LBLpts = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnread = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnset = New System.Windows.Forms.Button()
        Me.tbsetslvid = New System.Windows.Forms.TextBox()
        Me.cmbsetprty = New System.Windows.Forms.ComboBox()
        Me.cmbbdrt = New System.Windows.Forms.ComboBox()
        Me.cbprty = New System.Windows.Forms.CheckBox()
        Me.cbbdrt = New System.Windows.Forms.CheckBox()
        Me.cbslvid = New System.Windows.Forms.CheckBox()
        Me.tbslvid = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbprtprty = New System.Windows.Forms.ComboBox()
        Me.cmbprtbdrt = New System.Windows.Forms.ComboBox()
        Me.Cmbcom = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnportset = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PortSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 418)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(393, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(368, 302)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Read & Write CT & PT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.CheckBox1)
        Me.Panel5.Controls.Add(Me.Button8)
        Me.Panel5.Controls.Add(Me.CheckBox2)
        Me.Panel5.Controls.Add(Me.TextBox4)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.TextBox3)
        Me.Panel5.Location = New System.Drawing.Point(12, 135)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(325, 154)
        Me.Panel5.TabIndex = 80
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(189, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 16)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Sc"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 16)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Pr"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(77, 30)
        Me.TextBox1.MaxLength = 5
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(56, 31)
        Me.TextBox1.TabIndex = 74
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(15, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(52, 21)
        Me.CheckBox1.TabIndex = 69
        Me.CheckBox1.Text = "CT "
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(233, 119)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(87, 30)
        Me.Button8.TabIndex = 78
        Me.Button8.Text = "Set"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(15, 84)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(46, 21)
        Me.CheckBox2.TabIndex = 70
        Me.CheckBox2.Text = "PT"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(177, 78)
        Me.TextBox4.MaxLength = 6
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(56, 31)
        Me.TextBox4.TabIndex = 77
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(177, 30)
        Me.TextBox2.MaxLength = 5
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(56, 31)
        Me.TextBox2.TabIndex = 75
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(77, 78)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(56, 31)
        Me.TextBox3.TabIndex = 76
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LBLctp)
        Me.Panel1.Controls.Add(Me.LBLcts)
        Me.Panel1.Controls.Add(Me.LBLptp)
        Me.Panel1.Controls.Add(Me.LBLpts)
        Me.Panel1.Location = New System.Drawing.Point(12, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 78)
        Me.Panel1.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 22)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "CTp"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 22)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "CTs"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(170, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 22)
        Me.Label7.TabIndex = 57
        Me.Label7.Text = "PTp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(170, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 22)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "PTs"
        '
        'LBLctp
        '
        Me.LBLctp.AutoSize = True
        Me.LBLctp.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLctp.Location = New System.Drawing.Point(73, 9)
        Me.LBLctp.Name = "LBLctp"
        Me.LBLctp.Size = New System.Drawing.Size(26, 22)
        Me.LBLctp.TabIndex = 65
        Me.LBLctp.Text = " - "
        '
        'LBLcts
        '
        Me.LBLcts.AutoSize = True
        Me.LBLcts.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLcts.Location = New System.Drawing.Point(73, 46)
        Me.LBLcts.Name = "LBLcts"
        Me.LBLcts.Size = New System.Drawing.Size(26, 22)
        Me.LBLcts.TabIndex = 66
        Me.LBLcts.Text = " - "
        '
        'LBLptp
        '
        Me.LBLptp.AutoSize = True
        Me.LBLptp.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLptp.Location = New System.Drawing.Point(229, 9)
        Me.LBLptp.Name = "LBLptp"
        Me.LBLptp.Size = New System.Drawing.Size(26, 22)
        Me.LBLptp.TabIndex = 67
        Me.LBLptp.Text = " - "
        '
        'LBLpts
        '
        Me.LBLpts.AutoSize = True
        Me.LBLpts.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLpts.Location = New System.Drawing.Point(229, 44)
        Me.LBLpts.Name = "LBLpts"
        Me.LBLpts.Size = New System.Drawing.Size(26, 22)
        Me.LBLpts.TabIndex = 68
        Me.LBLpts.Text = " - "
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(11, 13)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 30)
        Me.Button4.TabIndex = 63
        Me.Button4.Text = "Read"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnread)
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabPage1.Size = New System.Drawing.Size(368, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configure PORT "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnread
        '
        Me.btnread.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnread.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnread.Location = New System.Drawing.Point(11, 12)
        Me.btnread.Name = "btnread"
        Me.btnread.Size = New System.Drawing.Size(75, 30)
        Me.btnread.TabIndex = 0
        Me.btnread.Text = "Read"
        Me.btnread.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnset)
        Me.Panel4.Controls.Add(Me.tbsetslvid)
        Me.Panel4.Controls.Add(Me.cmbsetprty)
        Me.Panel4.Controls.Add(Me.cmbbdrt)
        Me.Panel4.Controls.Add(Me.cbprty)
        Me.Panel4.Controls.Add(Me.cbbdrt)
        Me.Panel4.Controls.Add(Me.cbslvid)
        Me.Panel4.Location = New System.Drawing.Point(11, 52)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(339, 242)
        Me.Panel4.TabIndex = 23
        '
        'btnset
        '
        Me.btnset.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnset.Location = New System.Drawing.Point(238, 190)
        Me.btnset.Name = "btnset"
        Me.btnset.Size = New System.Drawing.Size(75, 32)
        Me.btnset.TabIndex = 21
        Me.btnset.Text = "Set"
        Me.btnset.UseVisualStyleBackColor = False
        '
        'tbsetslvid
        '
        Me.tbsetslvid.Location = New System.Drawing.Point(121, 23)
        Me.tbsetslvid.Name = "tbsetslvid"
        Me.tbsetslvid.Size = New System.Drawing.Size(121, 22)
        Me.tbsetslvid.TabIndex = 21
        '
        'cmbsetprty
        '
        Me.cmbsetprty.FormattingEnabled = True
        Me.cmbsetprty.Items.AddRange(New Object() {"None", "Odd", "Even"})
        Me.cmbsetprty.Location = New System.Drawing.Point(121, 130)
        Me.cmbsetprty.Name = "cmbsetprty"
        Me.cmbsetprty.Size = New System.Drawing.Size(121, 24)
        Me.cmbsetprty.TabIndex = 5
        '
        'cmbbdrt
        '
        Me.cmbbdrt.FormattingEnabled = True
        Me.cmbbdrt.Items.AddRange(New Object() {"1200", "2400", "4800", "9600"})
        Me.cmbbdrt.Location = New System.Drawing.Point(121, 77)
        Me.cmbbdrt.Name = "cmbbdrt"
        Me.cmbbdrt.Size = New System.Drawing.Size(121, 24)
        Me.cmbbdrt.TabIndex = 4
        '
        'cbprty
        '
        Me.cbprty.AutoSize = True
        Me.cbprty.Location = New System.Drawing.Point(15, 130)
        Me.cbprty.Name = "cbprty"
        Me.cbprty.Size = New System.Drawing.Size(67, 20)
        Me.cbprty.TabIndex = 2
        Me.cbprty.Text = "Parity"
        Me.cbprty.UseVisualStyleBackColor = True
        '
        'cbbdrt
        '
        Me.cbbdrt.AutoSize = True
        Me.cbbdrt.Location = New System.Drawing.Point(15, 81)
        Me.cbbdrt.Name = "cbbdrt"
        Me.cbbdrt.Size = New System.Drawing.Size(94, 20)
        Me.cbbdrt.TabIndex = 1
        Me.cbbdrt.Text = "Baud rate"
        Me.cbbdrt.UseVisualStyleBackColor = True
        '
        'cbslvid
        '
        Me.cbslvid.AutoSize = True
        Me.cbslvid.Location = New System.Drawing.Point(15, 26)
        Me.cbslvid.Name = "cbslvid"
        Me.cbslvid.Size = New System.Drawing.Size(86, 20)
        Me.cbslvid.TabIndex = 0
        Me.cbslvid.Text = "Slave ID"
        Me.cbslvid.UseVisualStyleBackColor = True
        '
        'tbslvid
        '
        Me.tbslvid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbslvid.Location = New System.Drawing.Point(105, 36)
        Me.tbslvid.Multiline = True
        Me.tbslvid.Name = "tbslvid"
        Me.tbslvid.Size = New System.Drawing.Size(44, 28)
        Me.tbslvid.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "SlaveID"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.cmbprtprty)
        Me.Panel3.Controls.Add(Me.cmbprtbdrt)
        Me.Panel3.Controls.Add(Me.Cmbcom)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.btnportset)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(9, 74)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(377, 343)
        Me.Panel3.TabIndex = 24
        '
        'cmbprtprty
        '
        Me.cmbprtprty.FormattingEnabled = True
        Me.cmbprtprty.Items.AddRange(New Object() {"None", "Odd", "Even"})
        Me.cmbprtprty.Location = New System.Drawing.Point(159, 171)
        Me.cmbprtprty.Name = "cmbprtprty"
        Me.cmbprtprty.Size = New System.Drawing.Size(101, 21)
        Me.cmbprtprty.TabIndex = 9
        '
        'cmbprtbdrt
        '
        Me.cmbprtbdrt.FormattingEnabled = True
        Me.cmbprtbdrt.Items.AddRange(New Object() {"1200", "4800", "9600"})
        Me.cmbprtbdrt.Location = New System.Drawing.Point(159, 122)
        Me.cmbprtbdrt.Name = "cmbprtbdrt"
        Me.cmbprtbdrt.Size = New System.Drawing.Size(101, 21)
        Me.cmbprtbdrt.TabIndex = 10
        '
        'Cmbcom
        '
        Me.Cmbcom.FormattingEnabled = True
        Me.Cmbcom.Location = New System.Drawing.Point(159, 75)
        Me.Cmbcom.Name = "Cmbcom"
        Me.Cmbcom.Size = New System.Drawing.Size(101, 21)
        Me.Cmbcom.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(86, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "PORT SETTINGS"
        '
        'btnportset
        '
        Me.btnportset.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnportset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnportset.Location = New System.Drawing.Point(182, 220)
        Me.btnportset.Name = "btnportset"
        Me.btnportset.Size = New System.Drawing.Size(75, 32)
        Me.btnportset.TabIndex = 6
        Me.btnportset.Text = "Set"
        Me.btnportset.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Parity"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(83, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Baud Rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(83, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "COM Port"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 82)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(25, 5)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(376, 335)
        Me.TabControl1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PortSettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(393, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PortSettingToolStripMenuItem
        '
        Me.PortSettingToolStripMenuItem.Name = "PortSettingToolStripMenuItem"
        Me.PortSettingToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.PortSettingToolStripMenuItem.Text = "Port Setting"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 440)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbslvid)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CT PT using MODBUS"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button8 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents LBLpts As Label
    Friend WithEvents LBLptp As Label
    Friend WithEvents LBLcts As Label
    Friend WithEvents LBLctp As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbprtprty As ComboBox
    Friend WithEvents cmbprtbdrt As ComboBox
    Friend WithEvents Cmbcom As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnportset As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnset As Button
    Friend WithEvents tbsetslvid As TextBox
    Friend WithEvents cmbsetprty As ComboBox
    Friend WithEvents cmbbdrt As ComboBox
    Friend WithEvents cbprty As CheckBox
    Friend WithEvents cbbdrt As CheckBox
    Friend WithEvents cbslvid As CheckBox
    Friend WithEvents btnread As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents tbslvid As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PortSettingToolStripMenuItem As ToolStripMenuItem
End Class
