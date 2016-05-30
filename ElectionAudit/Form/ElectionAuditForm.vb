Imports System.IO
Imports System.Linq

Namespace Form

    Public Class ElectionAuditForm
        Private _ballotIndex As Integer = 0
        Private _nextBatchPauseIndex As Integer
        Private _priorBatchPauseIndex As Integer = -1
        Private _batchIndex As Integer
        Private _batchCount As Integer
        Private _ballotsPerBatch As Double = 25
        Private _willBeep As Boolean = True
        Private _fullBallotList As BallotList
        Private _filteredBallotList As BallotList
        Private _IsBallotListFiltered As Boolean = False
        Private _atBallotBatchStart As Boolean = False
        Private _lastDisplayTime As DateTime
        Private _timerInterval As Integer = 2000
        Private _isProcessingEvent As Boolean
        Private _imageOrigin As Point

#Region "Events"

        Private Sub ElectionAuditForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            Text = "Election Audit v" & Application.ProductVersion
            cbSpeed.Text = "1.5 seconds"
        End Sub

        Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
            Dim originalText As String = Text
            Text = "Election Audit v" & Application.ProductVersion

            Dim originalImageCount As String = lblImageCount.Text
            lblImageCount.Text = String.Empty

            tmrBatchPlay.Enabled = False
            btnPause.Enabled = False
            btnResume.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            cbSpeed.Enabled = False

            Dim result As DialogResult = fldBrowserDialog.ShowDialog(Me)
            If result = Windows.Forms.DialogResult.OK Then
                Dim strFolder As String = fldBrowserDialog.SelectedPath
                Text = "Election Audit v" & Application.ProductVersion & "      " & strFolder.Substring(strFolder.LastIndexOfAny("\") + 1)

                Cursor = Cursors.WaitCursor
                Dim fBusy As New WorkingDialog
                fBusy.StartPosition = FormStartPosition.CenterScreen
                fBusy.Show(Me)
                Application.DoEvents()

                'Prepare collection of every image and of every ballot
                _ballotIndex = 0
                Dim fileHandler As New FileHandler
                fileHandler.ForEachFileAndFolder(strFolder, AddressOf fileHandler.DirectoryAction, AddressOf fileHandler.FileAction)
                _fullBallotList = New BallotList(fileHandler.Files)
                _filteredBallotList = _fullBallotList
                _IsBallotListFiltered = False
                fBusy.Close()
                Cursor = Cursors.Default

                Dim dialog As New BallotBatchDialog
                dialog.State = BallotBatchDialog.EnumState.Start
                dialog.StartPosition = FormStartPosition.CenterParent
                result = dialog.ShowDialog(Me)
                If result = Windows.Forms.DialogResult.OK Then
                    _nextBatchPauseIndex = 24
                    If _filteredBallotList.Ballots.Count < _nextBatchPauseIndex Then
                        _nextBatchPauseIndex = _filteredBallotList.Ballots.Count - 1
                    End If
                    _batchCount = CType(Math.Ceiling(_filteredBallotList.Ballots.Count / _ballotsPerBatch), Integer)
                    btnResume.Enabled = True
                    btnNext.Enabled = True
                    btnFit.Enabled = True
                    cbSpeed.Enabled = True
                    btnSample.Enabled = True
                    DisplayFirstImage()
                    imgBallotFront.FitToScreen()
                    imgBallotBack.FitToScreen()
                    _priorBatchPauseIndex = -1
                End If
            Else
                Text = originalText
                lblImageCount.Text = originalImageCount
            End If

        End Sub

        Private Sub btnLoadManifest_Click(sender As Object, e As EventArgs) Handles btnLoadManifest.Click
            Dim originalText As String = Text

            Text = "Election Audit v" & Application.ProductVersion

            Dim originalImageCount As String = lblImageCount.Text
            lblImageCount.Text = String.Empty

            tmrBatchPlay.Enabled = False
            btnPause.Enabled = False
            btnResume.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            cbSpeed.Enabled = False

            Dim result As DialogResult = openManifestFileDialog.ShowDialog(Me)
            If result = Windows.Forms.DialogResult.OK Then
                Dim strFile As String = openManifestFileDialog.FileName
                Text = "Election Audit v" & Application.ProductVersion & "      " & strFile.Substring(strFile.LastIndexOfAny("\") + 1)

                Cursor = Cursors.WaitCursor
                Dim fBusy As New WorkingDialog
                fBusy.StartPosition = FormStartPosition.CenterScreen
                fBusy.Show(Me)
                Application.DoEvents()
                _ballotIndex = 0
                _fullBallotList = New BallotList(strFile)
                _filteredBallotList = _fullBallotList
                _IsBallotListFiltered = False
                fBusy.Close()
                Cursor = Cursors.Default

                Dim dialog As New BallotBatchDialog
                dialog.State = BallotBatchDialog.EnumState.Start
                dialog.StartPosition = FormStartPosition.CenterParent
                result = dialog.ShowDialog(Me)
                If result = Windows.Forms.DialogResult.OK Then
                    _nextBatchPauseIndex = 24
                    If _filteredBallotList.Ballots.Count < _nextBatchPauseIndex Then
                        _nextBatchPauseIndex = _filteredBallotList.Ballots.Count - 1
                    End If
                    _batchCount = CType(Math.Ceiling(_filteredBallotList.Ballots.Count / _ballotsPerBatch), Integer)
                    btnResume.Enabled = True
                    btnNext.Enabled = True
                    btnFit.Enabled = True
                    cbSpeed.Enabled = True
                    btnSample.Enabled = True
                    DisplayFirstImage()
                    imgBallotFront.FitToScreen()
                    imgBallotBack.FitToScreen()
                    _priorBatchPauseIndex = -1
                End If
            Else
                Text = originalText
                lblImageCount.Text = originalImageCount
            End If

        End Sub

        Private Sub btnSaveManifest_Click(sender As Object, e As EventArgs) Handles btnSaveManifest.Click
            saveManifestFileDialog.ShowDialog(Me)
            Dim fileName As String = saveManifestFileDialog.FileName
            If fileName <> "" Then
                Dim oWriter As New StreamWriter(fileName, False)
                oWriter.Write(_filteredBallotList.AsXml)
                oWriter.Close()
            End If
        End Sub

        Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
            Cursor = Cursors.WaitCursor
            DisplayNextImage()
            btnPrev.Enabled = True
            btnFit.Enabled = True
            btnResume.Enabled = True
            cbSpeed.Enabled = True
            Cursor = Cursors.Default
        End Sub

        Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
            Cursor = Cursors.WaitCursor
            If _atBallotBatchStart Then
                DisplayImage()
            Else
                DisplayPrevImage()
            End If
            btnNext.Enabled = True
            btnFit.Enabled = True
            btnResume.Enabled = True
            cbSpeed.Enabled = True
            Cursor = Cursors.Default
        End Sub

        Private Sub btnFit_Click(sender As Object, e As EventArgs) Handles btnFit.Click
            Cursor = Cursors.WaitCursor
            imgBallotFront.FitToScreen()
            imgBallotBack.FitToScreen()
            Cursor = Cursors.Default
        End Sub

        Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
            _imageOrigin = _imgBallotFront.Origin
            tmrBatchPlay.Enabled = False
            btnPause.Enabled = False
            btnResume.Enabled = True
            btnReplay.Enabled = True
            btnPrev.Enabled = True
            btnNext.Enabled = True
            btnFit.Enabled = True
            cbSpeed.Enabled = True
        End Sub

        Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
            If _atBallotBatchStart Then
                _priorBatchPauseIndex = _ballotIndex
            End If
            btnReplay.Enabled = False
            btnPause.Enabled = True
            btnResume.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnFit.Enabled = False
            cbSpeed.Enabled = False
            tmrBatchPlay.Enabled = True
            _lastDisplayTime = Now()
        End Sub

        Private Sub btnReplay_Click(sender As Object, e As EventArgs) Handles btnReplay.Click
            If _atBallotBatchStart Then
                If _nextBatchPauseIndex < _filteredBallotList.Ballots.Count - 1 Then
                    _nextBatchPauseIndex -= 25
                    If _nextBatchPauseIndex < 0 Then
                        _nextBatchPauseIndex = 24
                        If _filteredBallotList.Ballots.Count < _nextBatchPauseIndex Then
                            _nextBatchPauseIndex = _filteredBallotList.Ballots.Count - 1
                        End If
                    End If
                End If
            End If
            _ballotIndex = _priorBatchPauseIndex
            If _ballotIndex < 0 Then
                _ballotIndex = -1
            End If
            btnReplay.Enabled = False
            btnPause.Enabled = True
            btnResume.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnFit.Enabled = False
            cbSpeed.Enabled = False
            tmrBatchPlay.Enabled = True
            _lastDisplayTime = Now()
        End Sub

        Private Sub frmElectionAudit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
            Cursor = Cursors.WaitCursor
            Select Case e.KeyCode
                Case Keys.Enter
                    DisplayNextImage()
                Case Keys.Space
                    DisplayNextImage()
                Case Keys.Add
                    DisplayNextImage()
                Case Keys.Down
                    DisplayNextImage()
                Case Keys.Up
                    DisplayPrevImage()
                Case Keys.PageDown
                    DisplayNextImage()
                Case Keys.PageUp
                    DisplayPrevImage()
                Case Keys.Subtract
                    DisplayPrevImage()
                Case Keys.Home
                    DisplayFirstImage()
                Case Keys.End
                    DisplayLastImage()
            End Select
            Cursor = Cursors.Default
        End Sub

        Private Sub tmrBatchPlay_Tick(sender As Object, e As EventArgs) Handles tmrBatchPlay.Tick
            Dim elapsed As TimeSpan = Now().Subtract(_lastDisplayTime)
            If elapsed.TotalMilliseconds < _timerInterval Then
                Exit Sub
            End If
            If _ballotIndex >= _nextBatchPauseIndex Then
                tmrBatchPlay.Enabled = False
                _atBallotBatchStart = True
                btnPause.Enabled = False

                Dim dialog As New BallotBatchDialog
                dialog.StartPosition = FormStartPosition.CenterParent
                If _ballotIndex < _filteredBallotList.Ballots.Count - 1 Then
                    dialog.State = BallotBatchDialog.EnumState.Midway
                Else
                    dialog.State = BallotBatchDialog.EnumState.Finished
                End If
                dialog.ShowDialog(Me)

                If _ballotIndex < _filteredBallotList.Ballots.Count - 1 Then
                    _nextBatchPauseIndex += 25
                    If _filteredBallotList.Ballots.Count < _nextBatchPauseIndex Then
                        _nextBatchPauseIndex = _filteredBallotList.Ballots.Count - 1
                    End If
                    btnPause.Enabled = False
                    btnResume.Enabled = True
                    btnReplay.Enabled = True
                    btnPrev.Enabled = True
                    btnNext.Enabled = True
                    btnFit.Enabled = True
                    cbSpeed.Enabled = True
                Else
                    btnPause.Enabled = False
                    btnResume.Enabled = False
                    btnReplay.Enabled = True
                    btnPrev.Enabled = True
                    btnNext.Enabled = False
                    btnFit.Enabled = True
                    cbSpeed.Enabled = False
                End If
            Else
                DisplayNextImage()
                _imgBallotFront.Origin = _imageOrigin
            End If
            _lastDisplayTime = Now()
        End Sub

        Private Sub cbSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSpeed.SelectedIndexChanged
            Select Case cbSpeed.Text
                Case "1.0 seconds"
                    _timerInterval = 1000
                Case "1.5 seconds"
                    _timerInterval = 1500
                Case "2.0 seconds"
                    _timerInterval = 2000
                Case "2.5 seconds"
                    _timerInterval = 2500
                Case "3.0 seconds"
                    _timerInterval = 3000
            End Select
        End Sub

        Private Sub imgBallotFront_ImageZoomed(isZoomIn As Boolean) Handles imgBallotFront.ImageZoomed
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                If isZoomIn Then
                    imgBallotBack.ZoomIn()
                Else
                    imgBallotBack.ZoomOut()
                End If
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub imgBallotBack_ImageZoomed(isZoomIn As Boolean) Handles imgBallotBack.ImageZoomed
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                If isZoomIn Then
                    imgBallotFront.ZoomIn()
                Else
                    imgBallotFront.ZoomOut()
                End If
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub imgBallotFront_OriginChanged(value As Point) Handles imgBallotFront.OriginChanged
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                _imageOrigin = value
                imgBallotBack.Origin = value
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub imgBallotFront_SelectionZoomed() Handles imgBallotFront.SelectionZoomed
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                imgBallotBack.ZoomSelection(imgBallotFront)
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub imgBallotBack_OriginChanged(value As Point) Handles imgBallotBack.OriginChanged
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                _imageOrigin = value
                imgBallotFront.Origin = value
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub imgBallotBack_SelectionZoomed() Handles imgBallotBack.SelectionZoomed
            If Not _isProcessingEvent Then
                _isProcessingEvent = True
                imgBallotFront.ZoomSelection(imgBallotBack)
                _isProcessingEvent = False
            End If
        End Sub

        Private Sub btnMute_Click(sender As Object, e As EventArgs) Handles btnMute.Click
            _willBeep = Not _willBeep
            btnMute.Visible = False
            btnUnmute.Visible = True
        End Sub

        Private Sub btnUnmute_Click(sender As Object, e As EventArgs) Handles btnUnmute.Click
            _willBeep = Not _willBeep
            btnMute.Visible = True
            btnUnmute.Visible = False
        End Sub

        Private Sub lblUCBerkley_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblUCBerkley.LinkClicked
            System.Diagnostics.Process.Start(lblUCBerkley.Text)
        End Sub

#End Region

#Region "Image Actions"

        Private Sub DisplayNextImage()
            If _filteredBallotList Is Nothing Then Exit Sub
            If _ballotIndex < _filteredBallotList.Ballots.Count - 1 Then
                _ballotIndex += 1
                DisplayImage()
                If _ballotIndex = _filteredBallotList.Ballots.Count - 1 Then
                    btnNext.Enabled = False
                End If
            End If
        End Sub

        Private Sub DisplayPrevImage()
            If _filteredBallotList Is Nothing Then Exit Sub
            If _ballotIndex > 0 Then
                _ballotIndex -= 1
                DisplayImage()
                If _ballotIndex = 0 Then
                    btnPrev.Enabled = False
                End If
            Else
                btnPrev.Enabled = False
            End If
        End Sub

        Private Sub DisplayFirstImage()
            If _filteredBallotList Is Nothing Then Exit Sub
            _ballotIndex = 0
            DisplayImage()
        End Sub

        Private Sub DisplayLastImage()
            If _filteredBallotList Is Nothing Then Exit Sub
            _ballotIndex = _filteredBallotList.Ballots.Count - 1
            DisplayImage()
        End Sub

        Private Sub DisplayImage()

            _atBallotBatchStart = False
            If _IsBallotListFiltered Then
                lblImageCount.Text = "Ballot: " & _filteredBallotList.Ballots.Item(_ballotIndex).Id & "  [" & _ballotIndex + 1 & " of " & _filteredBallotList.Ballots.Count & "]"
            Else
                lblImageCount.Text = "Ballot: " & _filteredBallotList.Ballots.Item(_ballotIndex).Id & " of " & _filteredBallotList.Ballots.Count
            End If

            Dim oBallotFrontFileEntry As ImageFile
            Dim oBallotBackFileEntry As ImageFile
            Dim oBallotFront As ImagePbm
            Dim sFilePath As String

            oBallotFrontFileEntry = _filteredBallotList.Ballots.Item(_ballotIndex).FrontImage
            If Not oBallotFrontFileEntry Is Nothing Then
                sFilePath = GetNextFilePath(oBallotFrontFileEntry)
                oBallotFront = New ImagePbm(sFilePath)
                If oBallotFrontFileEntry.IsCompressed Then
                    File.Delete(sFilePath)
                End If
                imgBallotFront.ReplaceImage(oBallotFront.BitMap)
            Else
                _isProcessingEvent = True
                Dim bmp As New Bitmap(1, 1)
                imgBallotFront.ReplaceImage(bmp)
                _isProcessingEvent = False
            End If

            oBallotBackFileEntry = _filteredBallotList.Ballots.Item(_ballotIndex).BackImage
            If Not oBallotBackFileEntry Is Nothing Then
                sFilePath = GetNextFilePath(oBallotBackFileEntry)
                Dim oBallotBack As New ImagePbm(sFilePath)
                If oBallotBackFileEntry.IsCompressed Then
                    File.Delete(sFilePath)
                End If
                imgBallotBack.ReplaceImage(oBallotBack.BitMap)
            Else
                _isProcessingEvent = True
                Dim bmp As New Bitmap(1, 1)
                imgBallotBack.ReplaceImage(bmp)
                _isProcessingEvent = False
            End If

            _batchIndex = CType(Math.Ceiling((_ballotIndex + 1) / _ballotsPerBatch), Integer)
            lblBatch.Text = "Batch: " & _batchIndex & " of " & _batchCount

            If _willBeep Then
                Beep()
            End If

        End Sub

        Private Function GetNextFilePath(ByVal fileEntry As ImageFile)
            Dim result As String = String.Empty
            If fileEntry.IsCompressed Then
                Dim oUnCompressedFilePath As String = String.Empty

                Using archive As ZipArchive = ZipFile.OpenRead(fileEntry.ArchivePath)
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If entry.FullName = fileEntry.FileName Then
                            oUnCompressedFilePath = Path.Combine(Path.GetTempPath, entry.FullName)
                            If File.Exists(oUnCompressedFilePath) Then
                                File.Delete(oUnCompressedFilePath)
                            End If
                            entry.ExtractToFile(oUnCompressedFilePath)
                        End If
                    Next
                End Using

                result = oUnCompressedFilePath
            ElseIf fileEntry.IsCompressed = False Then
                result = fileEntry.ArchivePath
            End If
            Return result
        End Function

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
            Cursor = Cursors.WaitCursor
            'detect up arrow key
            If keyData = Keys.Up Then
                DisplayPrevImage()
                Cursor = Cursors.Default
                Return True
            End If
            'detect down arrow key
            If keyData = Keys.Down Then
                DisplayNextImage()
                Cursor = Cursors.Default
                Return True
            End If
            'detect left arrow key
            If keyData = Keys.Left Then
                DisplayPrevImage()
                Cursor = Cursors.Default
                Return True
            End If
            'detect right arrow key
            If keyData = Keys.Right Then
                DisplayNextImage()
                Cursor = Cursors.Default
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

        Private Sub btnSample_Click(sender As Object, e As EventArgs) Handles btnSample.Click
            Dim filterBallotsForm As New SampleForm
            filterBallotsForm.ShowDialog()
            If filterBallotsForm.DialogResult = DialogResult.OK Then
                _IsBallotListFiltered = False
                Dim strId As String = filterBallotsForm.txtSampleBallots.Text.Replace(" ", String.Empty)
                Dim IDs As String() = strId.Split(",")
                If strId.Replace(" ", String.Empty).Replace(",", String.Empty).Length > 0 Then
                    _filteredBallotList = New BallotList
                    _filteredBallotList.Ballots = (From x In _fullBallotList.Ballots Where IDs.Contains(x.Id)
                                                   Select x).ToList
                Else
                    _filteredBallotList = _fullBallotList
                End If
                If _filteredBallotList.Ballots.Count > 0 Then
                    _IsBallotListFiltered = True
                End If
                _nextBatchPauseIndex = 24
                If _filteredBallotList.Ballots.Count < _nextBatchPauseIndex Then
                    _nextBatchPauseIndex = _filteredBallotList.Ballots.Count - 1
                End If
                _batchCount = CType(Math.Ceiling(_filteredBallotList.Ballots.Count / _ballotsPerBatch), Integer)
                btnResume.Enabled = True
                btnNext.Enabled = True
                btnFit.Enabled = True
                cbSpeed.Enabled = True
                btnSample.Enabled = True
                DisplayFirstImage()
                'imgBallotFront.FitToScreen()
                'imgBallotBack.FitToScreen()
                _priorBatchPauseIndex = -1
            End If
        End Sub

        Private Sub lblImageCount_Click(sender As Object, e As EventArgs) Handles lblImageCount.Click
            MsgBox("Front: " & _filteredBallotList.Ballots.Item(_ballotIndex).FrontImage.ParentPath & "\" &
                _filteredBallotList.Ballots.Item(_ballotIndex).FrontImage.FileName & vbCrLf &
                "Back: " & _filteredBallotList.Ballots.Item(_ballotIndex).BackImage.ParentPath & "\" &
                _filteredBallotList.Ballots.Item(_ballotIndex).BackImage.FileName)
        End Sub

#End Region

    End Class   'ElectionAuditForm class
End Namespace