Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class ImagePbm

    Private _filePath As String
    Private _pbmHeader As PbmHeader
    Private _pbmImageData As Byte()
    Private _bitMap As Bitmap

    Public Sub New(filePath As String)
        _filePath = filePath
        If File.Exists(_filePath) Then
            Dim oStream As New FileStream(_filePath, FileMode.Open)
            ParseStream(oStream)
            oStream.Close()
        End If
    End Sub

    Private Sub ParseStream(ByRef pbmStream As FileStream)
        _pbmHeader = New PbmHeader
        Dim nHeaderState As Integer = 0
        Dim binReader As New BinaryReader(pbmStream)
        While nHeaderState < 3
            Dim nextChar As Char = Chr(binReader.PeekChar())
            If nextChar = "#" Then
                While Not binReader.ReadChar = vbLf
                    'skip comment characters
                End While
            ElseIf Char.IsWhiteSpace(nextChar) Then
                binReader.ReadChar()
            Else
                Select Case nHeaderState
                    Case 0
                        Dim chars As Char() = binReader.ReadChars(2)
                        _pbmHeader.MagicNumber = chars(0).ToString & chars(1).ToString
                        nHeaderState += 1
                    Case 1
                        _pbmHeader.Width = ReadValue(binReader)
                        _pbmHeader.Stride = _pbmHeader.Width / 8
                        nHeaderState += 1
                    Case 2
                        _pbmHeader.Height = ReadValue(binReader)
                        nHeaderState += 1
                End Select
            End If
        End While

        Dim nBytesRemaining As Integer = binReader.BaseStream.Length - binReader.BaseStream.Position
        _pbmImageData = binReader.ReadBytes(nBytesRemaining)
        Dim pImagePointer As IntPtr = Marshal.AllocHGlobal(_pbmImageData.Length)
        Marshal.Copy(_pbmImageData, 0, pImagePointer, _pbmImageData.Length)
        _bitMap = New Bitmap(_pbmHeader.Width, _pbmHeader.Height, _pbmHeader.Stride, PixelFormat.Format1bppIndexed, pImagePointer)
        InvertBitmapColors()
    End Sub

    Private Function ReadValue(ByRef pbmReader As BinaryReader) As Integer
        Dim sValue As New StringBuilder
        While Not Char.IsWhiteSpace(Chr(pbmReader.PeekChar))
            sValue.Append(pbmReader.ReadChar.ToString)
        End While
        pbmReader.ReadByte()
        Return Integer.Parse(sValue.ToString)
    End Function

    Public ReadOnly Property BitMap() As Bitmap
        Get
            Return _bitMap
        End Get
    End Property

    Private Sub InvertBitmapColors()
        Dim pal As ColorPalette = _bitMap.Palette
        pal.Entries(0) = Color.White
        pal.Entries(1) = Color.Black
        _bitMap.Palette = pal
    End Sub

    Public Structure PbmHeader
        Public Property MagicNumber As String
        Public Property Width As Integer
        Public Property Height As Integer
        Public Property Stride As Integer
    End Structure

End Class
