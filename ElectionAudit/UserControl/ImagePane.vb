Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

<Runtime.InteropServices.ComVisible(False)> _
Friend Class ImagePane

    'Public Events
    Public Event SetScrollPositions()
    Public Event SelectionZoomed()
    Public Event ImageZoomed(ByVal isZoomIn As Boolean)

    'Member Variables
    Private _mouseButtons As MouseButtons = Windows.Forms.MouseButtons.Left
    Private _originalImage As Bitmap

    Private _startPoint As Point
    Private _origin As New Point(0, 0)

    Private _sourceRectangle As Rectangle
    Private _destinationRectangle As Rectangle

    Private _zoomOnMouseWheel As Boolean = True
    Private _zoomFactor As Double = 1.0

    Private _apparentImageSize As New Size(0, 0)

    Private _drawWidth As Integer
    Private _drawHeight As Integer

    Private _panMode As Boolean = True
    Private _stretchImageToFit As Boolean = False

    Private _selectRectangle As Rectangle
    Private ReadOnly _selectPen As New Pen(Color.Blue, 2) ' Pen used to indicate a selection on the image (zoom window)


#Region "Public/Private Shadows"
    Public Shadows Property Image() As Image
        Get
            Return _originalImage
        End Get
        Set(ByVal value As Image)
            If Not _originalImage Is Nothing Then
                _originalImage.Dispose()
                _selectRectangle = Nothing
                _origin = New Point(0, 0)
                _apparentImageSize = New Size(0, 0)
                _zoomFactor = 1
                GC.Collect()
            End If

            If value Is Nothing Then
                _originalImage = Nothing
                Invalidate()
                Exit Property
            End If

            Dim r As New Rectangle(0, 0, value.Width, value.Height)
            _originalImage = New Bitmap(value)
            _originalImage = _originalImage.Clone(r, PixelFormat.Format32bppPArgb)

            'Force a paint
            Invalidate()
        End Set
    End Property

    Public Sub ReplaceImage(ByVal value As Image)
        If Not _originalImage Is Nothing Then
            _originalImage.Dispose()
            '_selectRectangle = Nothing
            _apparentImageSize = New Size(0, 0)
            GC.Collect()
        End If

        If value Is Nothing Then
            _originalImage = Nothing
            Invalidate()
            Exit Sub
        End If

        Dim r As New Rectangle(0, 0, value.Width, value.Height)
        _originalImage = New Bitmap(value)
        _originalImage = _originalImage.Clone(r, PixelFormat.Format32bppPArgb)

        'Force a paint
        Invalidate()
    End Sub

    Public Shadows Property InitialImage() As Image
        Get
            Return _originalImage
        End Get
        Set(ByVal value As Image)
            Image = value
            ZoomFactor = 1
        End Set
    End Property

#End Region

#Region "Protected Overrides"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.Clear(BackColor)
        DrawImage(e.Graphics)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        _destinationRectangle = New Rectangle(0, 0, ClientSize.Width, ClientSize.Height)
        ComputeDrawingArea()
        MyBase.OnSizeChanged(e)
    End Sub

#End Region

#Region "Public Properties"

    Public Sub ZoomIn()
        ZoomImage(True)
    End Sub

    Public Sub ZoomOut()
        ZoomImage(False)
    End Sub

    Private Sub ZoomImage(ByVal isZoomIn As Boolean)
        ' Get center point
        Dim centerPoint As Point

        centerPoint.X = _origin.X + _sourceRectangle.Width / 2
        centerPoint.Y = _origin.Y + _sourceRectangle.Height / 2

        'set new zoomfactor
        If isZoomIn Then
            ZoomFactor = Math.Round(ZoomFactor * 1.05, 2)
        Else
            If _originalImage.Height - (ClientSize.Height / _zoomFactor) >= 0 OrElse _originalImage.Width - (ClientSize.Width / _zoomFactor) >= 0 Then
                ZoomFactor = Math.Round(ZoomFactor * 0.95, 2)
            End If
        End If

        'Reset the origin to maintain center point
        _origin.X = centerPoint.X - ClientSize.Width / _zoomFactor / 2
        'm_Origin.Y = m_centerpoint.Y - ClientSize.Height / m_ZoomFactor / 2

        CheckBounds()
        RaiseEvent ImageZoomed(isZoomIn)

    End Sub

    Public Property PanButton() As MouseButtons
        Get
            Return _mouseButtons
        End Get
        Set(ByVal value As MouseButtons)
            _mouseButtons = value
        End Set
    End Property

    Public Property ZoomOnMouseWheel() As Boolean
        Get
            Return _zoomOnMouseWheel
        End Get
        Set(ByVal value As Boolean)
            _zoomOnMouseWheel = value
        End Set
    End Property

    Public Property ZoomFactor() As Double
        Get
            Return _zoomFactor
        End Get
        Set(ByVal value As Double)
            _zoomFactor = value
            If _zoomFactor > 15 Then _zoomFactor = 15
            If _zoomFactor < 0.05 Then _zoomFactor = 0.05
            If Not _originalImage Is Nothing Then
                _apparentImageSize.Height = _originalImage.Height * _zoomFactor
                _apparentImageSize.Width = _originalImage.Width * _zoomFactor
                ComputeDrawingArea()
                CheckBounds()
            End If
            Invalidate()
        End Set
    End Property

    Public Property Origin() As Point
        Get
            Return _origin
        End Get
        Set(ByVal value As Point)
            _origin = value
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property ApparentImageSize() As Size
        Get
            Return _apparentImageSize
        End Get
    End Property

    Public Property PanMode() As Boolean
        Get
            Return _panMode
        End Get
        Set(ByVal value As Boolean)
            _panMode = value
        End Set
    End Property

    Public Property StretchImageToFit() As Boolean
        Get
            Return _stretchImageToFit
        End Get
        Set(ByVal value As Boolean)
            _stretchImageToFit = value
            Invalidate()
        End Set
    End Property

    Public Sub FitToScreen()
        StretchImageToFit = False
        Origin = New Point(0, 0)
        If _originalImage Is Nothing Then Exit Sub
        ZoomFactor = Math.Min(ClientSize.Width / _originalImage.Width, ClientSize.Height / _originalImage.Height)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub ImagePane_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If _originalImage Is Nothing Then Exit Sub
        SelectedRectangle = Nothing

        'Set the start point. This is used for panning and zooming so we always set it.
        _startPoint = New Point(e.X, e.Y)
        Focus()
    End Sub

    Private Sub ImagePane_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If _originalImage Is Nothing Then Exit Sub
        If e.Button = _mouseButtons Then

            Dim deltaX As Integer = _startPoint.X - e.X
            Dim deltaY As Integer = _startPoint.Y - e.Y

            If PanMode Then
                'Set the origin of the new image

                _origin.X = _origin.X + (deltaX / _zoomFactor)
                _origin.Y = _origin.Y + (deltaY / _zoomFactor)

                CheckBounds()

                'reset the startpoints
                _startPoint.X = e.X
                _startPoint.Y = e.Y

                'Force a paint
                Invalidate()
            Else
                Draw_Rectangle(e)
            End If
        End If
    End Sub

    Private Sub ImagePane_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If _originalImage Is Nothing Then Exit Sub
        If Not PanMode Then
            If SelectedRectangle = Nothing Then Exit Sub
            ZoomSelection()
        End If
    End Sub

    Private Sub ImagePane_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseWheel
        If Not ZoomOnMouseWheel Then Exit Sub
        'set new zoomfactor
        If e.Delta > 0 Then
            ZoomImage(True)
        ElseIf e.Delta < 0 Then
            ZoomImage(False)
        End If
    End Sub

    Private Sub ImagePane_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        ComputeDrawingArea()
        If StretchImageToFit Then Invalidate()
    End Sub

#End Region

    Public Property SelectedRectangle() As Rectangle
        Get
            Return _selectRectangle
        End Get
        Set(ByVal value As Rectangle)
            _selectRectangle = value
            Invalidate()
        End Set
    End Property

    Private Sub Draw_Rectangle(ByVal e As MouseEventArgs)
        If (New Rectangle(0, 0, Width, Height)).Contains(PointToClient(Windows.Forms.Cursor.Position)) Then
            Dim rectangleWidth As Integer
            rectangleWidth = Math.Abs(_startPoint.X - e.X)
            Dim rectangleHeight As Integer
            rectangleHeight = Math.Abs(_startPoint.Y - e.Y)
            Dim upperLeft As Point
            'need to determine the  upper left corner of the rectangel regardless of whether it's 
            'the start point or the end point, or other.
            upperLeft = New Point(Math.Min(_startPoint.X, e.X), Math.Min(_startPoint.Y, e.Y))
            SelectedRectangle = New Rectangle(upperLeft.X, upperLeft.Y, rectangleWidth, rectangleHeight)
        End If
    End Sub

    Private Sub DrawImage(ByRef g As Graphics)
        If _originalImage Is Nothing Then Exit Sub

        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor

        If _stretchImageToFit Then
            _sourceRectangle = New Rectangle(0, 0, _originalImage.Width, _originalImage.Height)
        Else
            _sourceRectangle = New Rectangle(_origin.X, _origin.Y, _drawWidth, _drawHeight)
        End If

        g.DrawImage(_originalImage, _destinationRectangle, _sourceRectangle, GraphicsUnit.Pixel)

        If Not PanMode Then
            g.DrawRectangle(_selectPen, SelectedRectangle)
        End If

        RaiseEvent SetScrollPositions()

    End Sub

    Private Sub ComputeDrawingArea()
        _drawHeight = Height / _zoomFactor
        _drawWidth = Width / _zoomFactor

    End Sub

    Private Sub CheckBounds()
        If _originalImage Is Nothing Then Exit Sub
        'Make sure we don't go out of bounds
        If _origin.X < 0 Then _origin.X = 0
        If _origin.Y < 0 Then _origin.Y = 0
        If _origin.X > _originalImage.Width - (ClientSize.Width / _zoomFactor) Then
            _origin.X = _originalImage.Width - (ClientSize.Width / _zoomFactor)
        End If
        If _origin.Y > _originalImage.Height - (ClientSize.Height / _zoomFactor) Then
            _origin.Y = _originalImage.Height - (ClientSize.Height / _zoomFactor)
        End If

        If _origin.X < 0 Then _origin.X = 0
        If _origin.Y < 0 Then _origin.Y = 0
    End Sub

    Public Sub ZoomSelection()
        If _originalImage Is Nothing Then Exit Sub

        Dim newOrigin As New Point(CInt(Origin.X + (SelectedRectangle.X / ZoomFactor)), _
                                          Origin.Y + (SelectedRectangle.Y / ZoomFactor))

        Dim newFactor As Double
        If SelectedRectangle.Width > SelectedRectangle.Height Then
            newFactor = (ClientSize.Width / (SelectedRectangle.Width / ZoomFactor))
        Else
            newFactor = (ClientSize.Height / (SelectedRectangle.Height / ZoomFactor))
        End If

        Origin = newOrigin
        ZoomFactor = newFactor
        RaiseEvent SelectionZoomed()

        SelectedRectangle = Nothing
    End Sub

    Public Sub RotateFlip(ByVal rotateFlipType As RotateFlipType)
        If _originalImage Is Nothing Then Exit Sub
        _originalImage.RotateFlip(rotateFlipType)
        Invalidate()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub

End Class   'ImagePane class

