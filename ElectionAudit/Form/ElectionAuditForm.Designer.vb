Namespace Form
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ElectionAuditForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElectionAuditForm))
            Me.fldBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
            Me.stripTool = New System.Windows.Forms.ToolStrip()
            Me.btnOpen = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnPrev = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnNext = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnFit = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
            Me.lblImageCount = New System.Windows.Forms.ToolStripLabel()
            Me.lblFiller1 = New System.Windows.Forms.ToolStripLabel()
            Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnResume = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnPause = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnReplay = New System.Windows.Forms.ToolStripButton()
            Me.cbSpeed = New System.Windows.Forms.ToolStripComboBox()
            Me.btnMute = New System.Windows.Forms.ToolStripButton()
            Me.btnUnmute = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnSample = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnManifest = New System.Windows.Forms.ToolStripDropDownButton()
            Me.btnLoadManifest = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnSaveManifest = New System.Windows.Forms.ToolStripMenuItem()
            Me.scSplitter = New System.Windows.Forms.SplitContainer()
            Me.imgBallotFront = New ElectionAudit.ImageContainer()
            Me.imgBallotBack = New ElectionAudit.ImageContainer()
            Me.tmrBatchPlay = New System.Windows.Forms.Timer(Me.components)
            Me.openManifestFileDialog = New System.Windows.Forms.OpenFileDialog()
            Me.saveManifestFileDialog = New System.Windows.Forms.SaveFileDialog()
            Me.lblUCBerkley = New System.Windows.Forms.LinkLabel()
            Me.lblBatch = New System.Windows.Forms.Label()
            Me.stripTool.SuspendLayout()
            CType(Me.scSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.scSplitter.Panel1.SuspendLayout()
            Me.scSplitter.Panel2.SuspendLayout()
            Me.scSplitter.SuspendLayout()
            Me.SuspendLayout()
            '
            'fldBrowserDialog
            '
            Me.fldBrowserDialog.Description = "Browse Precinct Folder"
            Me.fldBrowserDialog.ShowNewFolderButton = False
            '
            'stripTool
            '
            Me.stripTool.BackColor = System.Drawing.SystemColors.ControlLight
            Me.stripTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.ToolStripSeparator1, Me.btnPrev, Me.ToolStripSeparator4, Me.btnNext, Me.ToolStripSeparator8, Me.btnFit, Me.ToolStripSeparator5, Me.lblImageCount, Me.lblFiller1, Me.ToolStripSeparator7, Me.ToolStripSeparator2, Me.btnResume, Me.ToolStripSeparator3, Me.btnPause, Me.ToolStripSeparator6, Me.btnReplay, Me.cbSpeed, Me.btnMute, Me.btnUnmute, Me.ToolStripSeparator9, Me.btnManifest, Me.ToolStripSeparator10, Me.btnSample, Me.ToolStripSeparator12})
            Me.stripTool.Location = New System.Drawing.Point(0, 0)
            Me.stripTool.Name = "stripTool"
            Me.stripTool.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
            Me.stripTool.Size = New System.Drawing.Size(1124, 28)
            Me.stripTool.TabIndex = 3
            '
            'btnOpen
            '
            Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnOpen.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOpen.Image = CType(resources.GetObject("btnOpen.Image"), System.Drawing.Image)
            Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.Size = New System.Drawing.Size(52, 25)
            Me.btnOpen.Text = "Open"
            Me.btnOpen.ToolTipText = "Open Precinct"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
            '
            'btnPrev
            '
            Me.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnPrev.Enabled = False
            Me.btnPrev.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
            Me.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnPrev.Name = "btnPrev"
            Me.btnPrev.Size = New System.Drawing.Size(45, 25)
            Me.btnPrev.Text = "Prev"
            Me.btnPrev.ToolTipText = "Prev Ballot"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
            '
            'btnNext
            '
            Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnNext.Enabled = False
            Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
            Me.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnNext.Name = "btnNext"
            Me.btnNext.Size = New System.Drawing.Size(46, 25)
            Me.btnNext.Text = "Next"
            Me.btnNext.ToolTipText = "Next Ballot"
            '
            'ToolStripSeparator8
            '
            Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
            Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 28)
            '
            'btnFit
            '
            Me.btnFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnFit.Enabled = False
            Me.btnFit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFit.Image = CType(resources.GetObject("btnFit.Image"), System.Drawing.Image)
            Me.btnFit.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnFit.Name = "btnFit"
            Me.btnFit.Size = New System.Drawing.Size(31, 25)
            Me.btnFit.Text = "Fit"
            '
            'ToolStripSeparator5
            '
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 28)
            '
            'lblImageCount
            '
            Me.lblImageCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblImageCount.Name = "lblImageCount"
            Me.lblImageCount.Size = New System.Drawing.Size(50, 25)
            Me.lblImageCount.Text = "          "
            '
            'lblFiller1
            '
            Me.lblFiller1.Name = "lblFiller1"
            Me.lblFiller1.Size = New System.Drawing.Size(37, 25)
            Me.lblFiller1.Text = "          "
            '
            'ToolStripSeparator7
            '
            Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
            Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 28)
            Me.ToolStripSeparator7.Visible = False
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
            Me.ToolStripSeparator2.Visible = False
            '
            'btnResume
            '
            Me.btnResume.Enabled = False
            Me.btnResume.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnResume.Image = CType(resources.GetObject("btnResume.Image"), System.Drawing.Image)
            Me.btnResume.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnResume.Name = "btnResume"
            Me.btnResume.Size = New System.Drawing.Size(86, 25)
            Me.btnResume.Text = "Resume"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
            Me.ToolStripSeparator3.Visible = False
            '
            'btnPause
            '
            Me.btnPause.BackColor = System.Drawing.SystemColors.ControlLight
            Me.btnPause.Enabled = False
            Me.btnPause.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPause.Image = CType(resources.GetObject("btnPause.Image"), System.Drawing.Image)
            Me.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnPause.Name = "btnPause"
            Me.btnPause.Size = New System.Drawing.Size(71, 25)
            Me.btnPause.Text = "Pause"
            '
            'ToolStripSeparator6
            '
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
            Me.ToolStripSeparator6.Visible = False
            '
            'btnReplay
            '
            Me.btnReplay.Enabled = False
            Me.btnReplay.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReplay.Image = CType(resources.GetObject("btnReplay.Image"), System.Drawing.Image)
            Me.btnReplay.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnReplay.Name = "btnReplay"
            Me.btnReplay.Size = New System.Drawing.Size(77, 25)
            Me.btnReplay.Text = "Replay"
            '
            'cbSpeed
            '
            Me.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbSpeed.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbSpeed.Items.AddRange(New Object() {"1.0 seconds", "1.5 seconds", "2.0 seconds", "2.5 seconds", "3.0 seconds"})
            Me.cbSpeed.Name = "cbSpeed"
            Me.cbSpeed.Size = New System.Drawing.Size(95, 28)
            '
            'btnMute
            '
            Me.btnMute.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.btnMute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnMute.Image = CType(resources.GetObject("btnMute.Image"), System.Drawing.Image)
            Me.btnMute.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnMute.Name = "btnMute"
            Me.btnMute.Size = New System.Drawing.Size(23, 25)
            Me.btnMute.ToolTipText = "Mute"
            '
            'btnUnmute
            '
            Me.btnUnmute.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.btnUnmute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnUnmute.Image = CType(resources.GetObject("btnUnmute.Image"), System.Drawing.Image)
            Me.btnUnmute.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnUnmute.Name = "btnUnmute"
            Me.btnUnmute.Size = New System.Drawing.Size(23, 25)
            Me.btnUnmute.ToolTipText = "Unmute"
            Me.btnUnmute.Visible = False
            '
            'ToolStripSeparator9
            '
            Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
            Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 28)
            '
            'ToolStripSeparator10
            '
            Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
            Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 28)
            '
            'btnSample
            '
            Me.btnSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnSample.Font = New System.Drawing.Font("Segoe UI", 12.0!)
            Me.btnSample.Image = CType(resources.GetObject("btnSample.Image"), System.Drawing.Image)
            Me.btnSample.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnSample.Name = "btnSample"
            Me.btnSample.Size = New System.Drawing.Size(66, 25)
            Me.btnSample.Text = "Sample"
            '
            'ToolStripSeparator12
            '
            Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
            Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 28)
            '
            'btnManifest
            '
            Me.btnManifest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
            Me.btnManifest.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoadManifest, Me.btnSaveManifest})
            Me.btnManifest.Font = New System.Drawing.Font("Segoe UI", 12.0!)
            Me.btnManifest.Image = CType(resources.GetObject("btnManifest.Image"), System.Drawing.Image)
            Me.btnManifest.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnManifest.Name = "btnManifest"
            Me.btnManifest.Size = New System.Drawing.Size(83, 25)
            Me.btnManifest.Text = "Manifest"
            '
            'btnLoadManifest
            '
            Me.btnLoadManifest.Name = "btnLoadManifest"
            Me.btnLoadManifest.Size = New System.Drawing.Size(178, 26)
            Me.btnLoadManifest.Text = "Load Manifest"
            '
            'btnSaveManifest
            '
            Me.btnSaveManifest.Name = "btnSaveManifest"
            Me.btnSaveManifest.Size = New System.Drawing.Size(178, 26)
            Me.btnSaveManifest.Text = "Save Manifest"
            '
            'scSplitter
            '
            Me.scSplitter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.scSplitter.Location = New System.Drawing.Point(0, 32)
            Me.scSplitter.Name = "scSplitter"
            '
            'scSplitter.Panel1
            '
            Me.scSplitter.Panel1.Controls.Add(Me.imgBallotFront)
            '
            'scSplitter.Panel2
            '
            Me.scSplitter.Panel2.Controls.Add(Me.imgBallotBack)
            Me.scSplitter.Size = New System.Drawing.Size(1124, 589)
            Me.scSplitter.SplitterDistance = 569
            Me.scSplitter.TabIndex = 5
            '
            'imgBallotFront
            '
            Me.imgBallotFront.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imgBallotFront.Image = Nothing
            Me.imgBallotFront.InitialImage = Nothing
            Me.imgBallotFront.Location = New System.Drawing.Point(0, 0)
            Me.imgBallotFront.Name = "imgBallotFront"
            Me.imgBallotFront.Origin = New System.Drawing.Point(0, 0)
            Me.imgBallotFront.PanButton = System.Windows.Forms.MouseButtons.Left
            Me.imgBallotFront.PanMode = False
            Me.imgBallotFront.ScrollbarsVisible = True
            Me.imgBallotFront.Size = New System.Drawing.Size(566, 587)
            Me.imgBallotFront.StretchImageToFit = False
            Me.imgBallotFront.TabIndex = 2
            Me.imgBallotFront.ZoomFactor = 1.0R
            Me.imgBallotFront.ZoomOnMouseWheel = True
            '
            'imgBallotBack
            '
            Me.imgBallotBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imgBallotBack.Image = Nothing
            Me.imgBallotBack.InitialImage = Nothing
            Me.imgBallotBack.Location = New System.Drawing.Point(0, 0)
            Me.imgBallotBack.Name = "imgBallotBack"
            Me.imgBallotBack.Origin = New System.Drawing.Point(0, 0)
            Me.imgBallotBack.PanButton = System.Windows.Forms.MouseButtons.Left
            Me.imgBallotBack.PanMode = False
            Me.imgBallotBack.ScrollbarsVisible = True
            Me.imgBallotBack.Size = New System.Drawing.Size(548, 587)
            Me.imgBallotBack.StretchImageToFit = False
            Me.imgBallotBack.TabIndex = 5
            Me.imgBallotBack.ZoomFactor = 1.0R
            Me.imgBallotBack.ZoomOnMouseWheel = True
            '
            'tmrBatchPlay
            '
            '
            'openManifestFileDialog
            '
            Me.openManifestFileDialog.Filter = "Ballot Manifest | *.xml"
            '
            'saveManifestFileDialog
            '
            Me.saveManifestFileDialog.DefaultExt = "xml"
            Me.saveManifestFileDialog.Filter = "Ballot Manifest | *.xml"
            Me.saveManifestFileDialog.Title = "Save Ballot Manifest"
            '
            'lblUCBerkley
            '
            Me.lblUCBerkley.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblUCBerkley.AutoSize = True
            Me.lblUCBerkley.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUCBerkley.Location = New System.Drawing.Point(13, 624)
            Me.lblUCBerkley.Name = "lblUCBerkley"
            Me.lblUCBerkley.Size = New System.Drawing.Size(465, 20)
            Me.lblUCBerkley.TabIndex = 6
            Me.lblUCBerkley.TabStop = True
            Me.lblUCBerkley.Text = "http://www.stat.berkeley.edu/~stark/Java/Html/ballotPollTools.htm"
            '
            'lblBatch
            '
            Me.lblBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblBatch.AutoSize = True
            Me.lblBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBatch.Location = New System.Drawing.Point(511, 624)
            Me.lblBatch.Name = "lblBatch"
            Me.lblBatch.Size = New System.Drawing.Size(55, 20)
            Me.lblBatch.TabIndex = 7
            Me.lblBatch.Text = "Batch:"
            '
            'ElectionAuditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.ClientSize = New System.Drawing.Size(1124, 652)
            Me.Controls.Add(Me.lblBatch)
            Me.Controls.Add(Me.lblUCBerkley)
            Me.Controls.Add(Me.scSplitter)
            Me.Controls.Add(Me.stripTool)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.KeyPreview = True
            Me.Name = "ElectionAuditForm"
            Me.Text = "Election Audit"
            Me.stripTool.ResumeLayout(False)
            Me.stripTool.PerformLayout()
            Me.scSplitter.Panel1.ResumeLayout(False)
            Me.scSplitter.Panel2.ResumeLayout(False)
            CType(Me.scSplitter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.scSplitter.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents fldBrowserDialog As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents imgBallotFront As ElectionAudit.ImageContainer
        Friend WithEvents stripTool As System.Windows.Forms.ToolStrip
        Friend WithEvents btnOpen As System.Windows.Forms.ToolStripButton
        Friend WithEvents btnResume As System.Windows.Forms.ToolStripButton
        Friend WithEvents btnPause As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btnPrev As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btnNext As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents lblImageCount As System.Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents lblFiller1 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents btnFit As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents scSplitter As System.Windows.Forms.SplitContainer
        Friend WithEvents imgBallotBack As ElectionAudit.ImageContainer
        Friend WithEvents tmrBatchPlay As System.Windows.Forms.Timer
        Friend WithEvents btnReplay As System.Windows.Forms.ToolStripButton
        Friend WithEvents cbSpeed As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents btnMute As System.Windows.Forms.ToolStripButton
        Friend WithEvents btnUnmute As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents openManifestFileDialog As System.Windows.Forms.OpenFileDialog
        Friend WithEvents saveManifestFileDialog As System.Windows.Forms.SaveFileDialog
        Friend WithEvents btnSample As System.Windows.Forms.ToolStripButton
        Friend WithEvents lblUCBerkley As System.Windows.Forms.LinkLabel
        Friend WithEvents lblBatch As System.Windows.Forms.Label
        Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents btnManifest As System.Windows.Forms.ToolStripDropDownButton
        Friend WithEvents btnLoadManifest As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnSaveManifest As System.Windows.Forms.ToolStripMenuItem

    End Class
End Namespace