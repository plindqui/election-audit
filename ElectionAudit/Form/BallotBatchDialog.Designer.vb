<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BallotBatchDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BallotBatchDialog))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pnlFirst = New System.Windows.Forms.Panel()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.pnlMidway = New System.Windows.Forms.Panel()
        Me.lblMidway = New System.Windows.Forms.Label()
        Me.pnlFinished = New System.Windows.Forms.Panel()
        Me.lblFinished = New System.Windows.Forms.Label()
        Me.lblFirstStep1 = New System.Windows.Forms.Label()
        Me.lblFirstStep2 = New System.Windows.Forms.Label()
        Me.lblFirstStep3 = New System.Windows.Forms.Label()
        Me.pnlFirst.SuspendLayout()
        Me.pnlMidway.SuspendLayout()
        Me.pnlFinished.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(583, 348)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'pnlFirst
        '
        Me.pnlFirst.Controls.Add(Me.lblFirstStep3)
        Me.pnlFirst.Controls.Add(Me.lblFirstStep2)
        Me.pnlFirst.Controls.Add(Me.lblFirstStep1)
        Me.pnlFirst.Controls.Add(Me.lblFirst)
        Me.pnlFirst.Location = New System.Drawing.Point(0, 0)
        Me.pnlFirst.Name = "pnlFirst"
        Me.pnlFirst.Size = New System.Drawing.Size(646, 330)
        Me.pnlFirst.TabIndex = 2
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirst.Location = New System.Drawing.Point(12, 9)
        Me.lblFirst.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(547, 60)
        Me.lblFirst.TabIndex = 4
        Me.lblFirst.Text = "Ballots will be displayed automatically in batches of 25 at a uniform cadence. It" & _
    " will pause after the first ballot is displayed to give you a chance to take the" & _
    " following actions:"
        '
        'pnlMidway
        '
        Me.pnlMidway.Controls.Add(Me.lblMidway)
        Me.pnlMidway.Location = New System.Drawing.Point(0, 0)
        Me.pnlMidway.Name = "pnlMidway"
        Me.pnlMidway.Size = New System.Drawing.Size(646, 330)
        Me.pnlMidway.TabIndex = 3
        Me.pnlMidway.Visible = False
        '
        'lblMidway
        '
        Me.lblMidway.AutoSize = True
        Me.lblMidway.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMidway.Location = New System.Drawing.Point(25, 12)
        Me.lblMidway.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblMidway.Name = "lblMidway"
        Me.lblMidway.Size = New System.Drawing.Size(550, 80)
        Me.lblMidway.TabIndex = 5
        Me.lblMidway.Text = resources.GetString("lblMidway.Text")
        '
        'pnlFinished
        '
        Me.pnlFinished.Controls.Add(Me.lblFinished)
        Me.pnlFinished.Location = New System.Drawing.Point(0, 0)
        Me.pnlFinished.Name = "pnlFinished"
        Me.pnlFinished.Size = New System.Drawing.Size(646, 330)
        Me.pnlFinished.TabIndex = 4
        Me.pnlFinished.Visible = False
        '
        'lblFinished
        '
        Me.lblFinished.AutoSize = True
        Me.lblFinished.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinished.Location = New System.Drawing.Point(12, 9)
        Me.lblFinished.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblFinished.Name = "lblFinished"
        Me.lblFinished.Size = New System.Drawing.Size(545, 20)
        Me.lblFinished.TabIndex = 0
        Me.lblFinished.Text = "That was the last ballot. Please confirm everyone agrees about the vote tally."
        '
        'lblFirstStep1
        '
        Me.lblFirstStep1.AutoSize = True
        Me.lblFirstStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstStep1.Location = New System.Drawing.Point(40, 79)
        Me.lblFirstStep1.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblFirstStep1.Name = "lblFirstStep1"
        Me.lblFirstStep1.Size = New System.Drawing.Size(541, 40)
        Me.lblFirstStep1.TabIndex = 5
        Me.lblFirstStep1.Text = "Confirm the correct polling place name is displayed. If not please click Open to " & _
    "find the correct ballots."
        '
        'lblFirstStep2
        '
        Me.lblFirstStep2.AutoSize = True
        Me.lblFirstStep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstStep2.Location = New System.Drawing.Point(40, 141)
        Me.lblFirstStep2.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblFirstStep2.Name = "lblFirstStep2"
        Me.lblFirstStep2.Size = New System.Drawing.Size(547, 40)
        Me.lblFirstStep2.TabIndex = 6
        Me.lblFirstStep2.Text = "Zoom in, if needed, by clicking and dragging to select the portion of the ballot " & _
    "to zoom into." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblFirstStep3
        '
        Me.lblFirstStep3.AutoSize = True
        Me.lblFirstStep3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstStep3.Location = New System.Drawing.Point(40, 198)
        Me.lblFirstStep3.MaximumSize = New System.Drawing.Size(550, 0)
        Me.lblFirstStep3.Name = "lblFirstStep3"
        Me.lblFirstStep3.Size = New System.Drawing.Size(329, 20)
        Me.lblFirstStep3.TabIndex = 7
        Me.lblFirstStep3.Text = "After you are ready to proceed, click Resume."
        '
        'BallotBatchDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 383)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlFirst)
        Me.Controls.Add(Me.pnlMidway)
        Me.Controls.Add(Me.pnlFinished)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "BallotBatchDialog"
        Me.pnlFirst.ResumeLayout(False)
        Me.pnlFirst.PerformLayout()
        Me.pnlMidway.ResumeLayout(False)
        Me.pnlMidway.PerformLayout()
        Me.pnlFinished.ResumeLayout(False)
        Me.pnlFinished.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents pnlFirst As System.Windows.Forms.Panel
    Friend WithEvents pnlMidway As System.Windows.Forms.Panel
    Friend WithEvents pnlFinished As System.Windows.Forms.Panel
    Friend WithEvents lblFinished As System.Windows.Forms.Label
    Friend WithEvents lblFirst As System.Windows.Forms.Label
    Friend WithEvents lblMidway As System.Windows.Forms.Label
    Friend WithEvents lblFirstStep2 As System.Windows.Forms.Label
    Friend WithEvents lblFirstStep1 As System.Windows.Forms.Label
    Friend WithEvents lblFirstStep3 As System.Windows.Forms.Label
End Class
