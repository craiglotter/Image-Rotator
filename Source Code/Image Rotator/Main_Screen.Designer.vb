<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.cancelAsyncButton = New System.Windows.Forms.Button
        Me.startAsyncButton = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Flip2 = New System.Windows.Forms.CheckBox
        Me.Flip1 = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Rotate1 = New System.Windows.Forms.RadioButton
        Me.Rotate2 = New System.Windows.Forms.RadioButton
        Me.Rotate3 = New System.Windows.Forms.RadioButton
        Me.RotateDirection = New System.Windows.Forms.ComboBox
        Me.Rotate4 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(389, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.Button1, "Select gallery image source folder (Non-recursive)")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextBox1.Location = New System.Drawing.Point(18, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(365, 20)
        Me.TextBox1.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Gallery image source folder (Non-recursive)")
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select the folder containing the images to be used for the gallery."
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.Enabled = False
        Me.cancelAsyncButton.ForeColor = System.Drawing.Color.Black
        Me.cancelAsyncButton.Location = New System.Drawing.Point(410, 146)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(58, 23)
        Me.cancelAsyncButton.TabIndex = 40
        Me.cancelAsyncButton.Text = "Cancel"
        Me.cancelAsyncButton.UseVisualStyleBackColor = True
        '
        'startAsyncButton
        '
        Me.startAsyncButton.ForeColor = System.Drawing.Color.Black
        Me.startAsyncButton.Location = New System.Drawing.Point(346, 146)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(58, 23)
        Me.startAsyncButton.TabIndex = 39
        Me.startAsyncButton.Text = "Begin"
        Me.startAsyncButton.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(30, 146)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(310, 23)
        Me.ProgressBar1.TabIndex = 41
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 184)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(497, 22)
        Me.StatusStrip1.TabIndex = 42
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Rotate:"
        Me.ToolTip1.SetToolTip(Me.Label2, "Set the thumbnail height or width (Proportions constrained)")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Flip2)
        Me.GroupBox1.Controls.Add(Me.Flip1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 119)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Inputs"
        '
        'Flip2
        '
        Me.Flip2.AutoSize = True
        Me.Flip2.Location = New System.Drawing.Point(110, 90)
        Me.Flip2.Name = "Flip2"
        Me.Flip2.Size = New System.Drawing.Size(33, 17)
        Me.Flip2.TabIndex = 65
        Me.Flip2.Text = "Y"
        Me.Flip2.UseVisualStyleBackColor = True
        '
        'Flip1
        '
        Me.Flip1.AutoSize = True
        Me.Flip1.Location = New System.Drawing.Point(63, 90)
        Me.Flip1.Name = "Flip1"
        Me.Flip1.Size = New System.Drawing.Size(33, 17)
        Me.Flip1.TabIndex = 64
        Me.Flip1.Text = "X"
        Me.Flip1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Rotate1)
        Me.Panel1.Controls.Add(Me.Rotate2)
        Me.Panel1.Controls.Add(Me.Rotate3)
        Me.Panel1.Controls.Add(Me.RotateDirection)
        Me.Panel1.Controls.Add(Me.Rotate4)
        Me.Panel1.Location = New System.Drawing.Point(6, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(450, 34)
        Me.Panel1.TabIndex = 63
        '
        'Rotate1
        '
        Me.Rotate1.AutoSize = True
        Me.Rotate1.Location = New System.Drawing.Point(57, 8)
        Me.Rotate1.Name = "Rotate1"
        Me.Rotate1.Size = New System.Drawing.Size(41, 17)
        Me.Rotate1.TabIndex = 54
        Me.Rotate1.Text = "90°"
        Me.Rotate1.UseVisualStyleBackColor = True
        '
        'Rotate2
        '
        Me.Rotate2.AutoSize = True
        Me.Rotate2.Location = New System.Drawing.Point(104, 8)
        Me.Rotate2.Name = "Rotate2"
        Me.Rotate2.Size = New System.Drawing.Size(47, 17)
        Me.Rotate2.TabIndex = 55
        Me.Rotate2.Text = "180°"
        Me.Rotate2.UseVisualStyleBackColor = True
        '
        'Rotate3
        '
        Me.Rotate3.AutoSize = True
        Me.Rotate3.Location = New System.Drawing.Point(152, 8)
        Me.Rotate3.Name = "Rotate3"
        Me.Rotate3.Size = New System.Drawing.Size(47, 17)
        Me.Rotate3.TabIndex = 56
        Me.Rotate3.Text = "270°"
        Me.Rotate3.UseVisualStyleBackColor = True
        '
        'RotateDirection
        '
        Me.RotateDirection.FormattingEnabled = True
        Me.RotateDirection.Items.AddRange(New Object() {"Clockwise", "Anti-clockwise"})
        Me.RotateDirection.Location = New System.Drawing.Point(262, 7)
        Me.RotateDirection.Name = "RotateDirection"
        Me.RotateDirection.Size = New System.Drawing.Size(96, 21)
        Me.RotateDirection.TabIndex = 57
        '
        'Rotate4
        '
        Me.Rotate4.AutoSize = True
        Me.Rotate4.Checked = True
        Me.Rotate4.Location = New System.Drawing.Point(205, 8)
        Me.Rotate4.Name = "Rotate4"
        Me.Rotate4.Size = New System.Drawing.Size(51, 17)
        Me.Rotate4.TabIndex = 58
        Me.Rotate4.TabStop = True
        Me.Rotate4.Text = "None"
        Me.Rotate4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Flip:"
        Me.ToolTip1.SetToolTip(Me.Label1, "Set the thumbnail height or width (Proportions constrained)")
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 206)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Controls.Add(Me.startAsyncButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(505, 240)
        Me.MinimumSize = New System.Drawing.Size(505, 240)
        Me.Name = "Main_Screen"
        Me.Text = "Image Rotator"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Friend WithEvents startAsyncButton As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Rotate3 As System.Windows.Forms.RadioButton
    Friend WithEvents Rotate2 As System.Windows.Forms.RadioButton
    Friend WithEvents Rotate1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Rotate4 As System.Windows.Forms.RadioButton
    Friend WithEvents RotateDirection As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Flip2 As System.Windows.Forms.CheckBox
    Friend WithEvents Flip1 As System.Windows.Forms.CheckBox

End Class
