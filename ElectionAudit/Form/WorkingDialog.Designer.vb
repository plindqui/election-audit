<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkingDialog
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
        Me.lblRetrieving = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblRetrieving
        '
        Me.lblRetrieving.AutoSize = True
        Me.lblRetrieving.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetrieving.Location = New System.Drawing.Point(23, 23)
        Me.lblRetrieving.Name = "lblRetrieving"
        Me.lblRetrieving.Size = New System.Drawing.Size(303, 20)
        Me.lblRetrieving.TabIndex = 0
        Me.lblRetrieving.Text = "Retrieving ballot images for display..."
        '
        'WorkingDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(347, 65)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblRetrieving)
        Me.Name = "WorkingDialog"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRetrieving As System.Windows.Forms.Label
End Class
