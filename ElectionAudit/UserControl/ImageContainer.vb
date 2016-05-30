<Runtime.InteropServices.ComVisible(False)> _
Public Class ImageContainer

    Public Event SelectionZoomed()
    Public Event ImageZoomed(ByVal isZoomIn As Boolean)
    Public Event OriginChanged(ByVal value As Point)

    Private _scrollVisible As Boolean = True

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Public Properties"

    Public Property PanMode() As Boolean
        Get
            Return ImagePane1.PanMode
        End Get
        Set(ByVal value As Boolean)
            ImagePane1.PanMode = value
        End Set
    End Property

    Public Property PanButton() As MouseButtons
        Get
            Return ImagePane1.PanButton
        End Get
        Set(ByVal value As MouseButtons)
            ImagePane1.PanButton = value
        End Set
    End Property

    Public Property ZoomOnMouseWheel() As Boolean
        Get
            Return ImagePane1.ZoomOnMouseWheel
        End Get
        Set(ByVal value As Boolean)
            ImagePane1.ZoomOnMouseWheel = value
        End Set
    End Property

    Public Property ZoomFactor() As Double
        Get
            Return ImagePane1.ZoomFactor
        End Get
        Set(ByVal value As Double)
            ImagePane1.ZoomFactor = value
        End Set
    End Property

    Public Property Origin() As Point
        Get
            Return ImagePane1.Origin
        End Get
        Set(ByVal value As Point)
            ImagePane1.Origin = value
        End Set
    End Property

    Public Property StretchImageToFit() As Boolean
        Get
            Return ImagePane1.StretchImageToFit
        End Get
        Set(ByVal value As Boolean)
            ImagePane1.StretchImageToFit = value
        End Set
    End Property

    Public ReadOnly Property ApparentImageSize() As Size
        Get
            Return ImagePane1.ApparentImageSize
        End Get
    End Property

    Public Sub FitToScreen()
        ImagePane1.FitToScreen()
    End Sub

    Public Sub ZoomIn()
        ImagePane1.ZoomIn()
    End Sub

    Public Sub ZoomOut()
        ImagePane1.ZoomOut()
    End Sub

    Public Sub ZoomSelection(imageContainer As ImageContainer)
        ImagePane1.SelectedRectangle = imageContainer.ImagePane1.SelectedRectangle
        ImagePane1.ZoomSelection()
    End Sub

    Public Property ScrollbarsVisible() As Boolean
        Get
            Return _scrollVisible
        End Get
        Set(ByVal value As Boolean)
            _scrollVisible = value
            HScrollBar1.Visible = value
            VScrollBar1.Visible = value
            If value = False Then
                ImagePane1.Dock = DockStyle.Fill
            Else
                ImagePane1.Dock = DockStyle.None
                ImagePane1.Location = New Point(0, 0)
                ImagePane1.Width = ClientSize.Width - VScrollBar1.Width
                ImagePane1.Height = ClientSize.Height - HScrollBar1.Height

            End If
        End Set
    End Property

#End Region

#Region "Public/Private Shadows"

    Public Shadows Property Image() As Image
        Get
            Return ImagePane1.Image
        End Get
        Set(ByVal value As Image)
            ImagePane1.Image = value
            If value Is Nothing Then
                HScrollBar1.Enabled = False
                VScrollBar1.Enabled = False
                Exit Property
            End If
        End Set
    End Property

    Public Sub ReplaceImage(ByVal value As Image)
        ImagePane1.ReplaceImage(value)
        If value Is Nothing Then
            HScrollBar1.Enabled = False
            VScrollBar1.Enabled = False
            Exit Sub
        End If
    End Sub

    Public Shadows Property InitialImage() As Image
        Get
            Return ImagePane1.InitialImage
        End Get
        Set(ByVal value As Image)
            ImagePane1.InitialImage = value
            If value Is Nothing Then
                HScrollBar1.Enabled = False
                VScrollBar1.Enabled = False
                Exit Property
            End If
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub ImagePane1_ImageZoomed(isZoomIn As Boolean) Handles ImagePane1.ImageZoomed
        RaiseEvent ImageZoomed(isZoomIn)
    End Sub

    Private Sub ImagePane1_SelectionZoomed() Handles ImagePane1.SelectionZoomed
        RaiseEvent SelectionZoomed()
    End Sub

    Private Sub ImagePane1_SetScrollPositions() Handles ImagePane1.SetScrollPositions
        SetScrollBars(ImagePane1)
    End Sub


    Private Sub ScrollBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles HScrollBar1.ValueChanged, VScrollBar1.ValueChanged
        ImagePane1.Origin = New Point(HScrollBar1.Value, VScrollBar1.Value)
        RaiseEvent OriginChanged(ImagePane1.Origin)
    End Sub

#End Region

    Private Sub SetScrollBars(imagePane As ImagePane)

        Dim originX As Integer = imagePane.Origin.X
        Dim originY As Integer = imagePane.Origin.Y
        Dim factoredCtrlWidth As Integer = imagePane.Width / imagePane.ZoomFactor
        Dim factoredCtrlHeight As Integer = imagePane.Height / imagePane.ZoomFactor
        HScrollBar1.Maximum = imagePane.Image.Width
        VScrollBar1.Maximum = imagePane.Image.Height

        If factoredCtrlWidth >= imagePane.Image.Width Or StretchImageToFit Then
            HScrollBar1.Enabled = False
            HScrollBar1.Value = 0
        Else
            HScrollBar1.LargeChange = factoredCtrlWidth
            HScrollBar1.Enabled = True
            HScrollBar1.Value = originX
        End If

        If factoredCtrlHeight >= imagePane.Image.Height Or StretchImageToFit Then
            VScrollBar1.Enabled = False
            VScrollBar1.Value = 0
        Else
            VScrollBar1.Enabled = True
            VScrollBar1.LargeChange = factoredCtrlHeight
            VScrollBar1.Value = originY
        End If

    End Sub

End Class   'ImageControl class
