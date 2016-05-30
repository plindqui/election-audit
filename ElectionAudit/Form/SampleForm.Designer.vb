<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SampleForm))
        Me.txtSampleBallots = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtInstructions = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtSampleBallots
        '
        Me.txtSampleBallots.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSampleBallots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSampleBallots.Location = New System.Drawing.Point(8, 95)
        Me.txtSampleBallots.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSampleBallots.Multiline = True
        Me.txtSampleBallots.Name = "txtSampleBallots"
        Me.txtSampleBallots.Size = New System.Drawing.Size(637, 265)
        Me.txtSampleBallots.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(593, 8)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(50, 21)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(593, 34)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(50, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(593, 60)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(50, 21)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtInstructions
        '
        Me.txtInstructions.BackColor = System.Drawing.SystemColors.Menu
        Me.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructions.Location = New System.Drawing.Point(9, 8)
        Me.txtInstructions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtInstructions.Multiline = True
        Me.txtInstructions.Name = "txtInstructions"
        Me.txtInstructions.Size = New System.Drawing.Size(574, 83)
        Me.txtInstructions.TabIndex = 4
        Me.txtInstructions.TabStop = False
        Me.txtInstructions.Text = resources.GetString("txtInstructions.Text")
        '
        'SampleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 367)
        Me.Controls.Add(Me.txtInstructions)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtSampleBallots)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "SampleForm"
        Me.Text = "Risk Limiting Audit Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSampleBallots As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents txtInstructions As TextBox
End Class
