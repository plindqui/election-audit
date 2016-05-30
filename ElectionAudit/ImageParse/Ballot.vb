Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Security

Public Class BallotList
    Private _ballots As New List(Of Ballot)

    Public Sub New()
        'Nothing to see here.... move along :)
    End Sub

    Public Sub New(ByVal FileName As String)
        Dim reader As XmlTextReader = Nothing
        Dim frontCount As Integer = 0
        Dim backCount As Integer = 0

        Try
            reader = New XmlTextReader(FileName)
            Dim oBallot As Ballot = Nothing
            Dim parentPath As String = String.Empty
            Dim isCompressed As String = String.Empty

            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element And reader.Name = "ballot"
                        If Not oBallot Is Nothing Then
                            oBallot.Id = _ballots.Count + 1
                            _ballots.Add(oBallot)
                        End If
                        oBallot = New Ballot
                        If reader.HasAttributes Then
                            While reader.MoveToNextAttribute()
                                If reader.Name = "Path" Then
                                    parentPath = reader.Value
                                ElseIf reader.Name = "Zip" Then
                                    isCompressed = reader.Value
                                End If
                            End While
                        End If
                    Case XmlNodeType.Element And reader.Name = "front"
                        If reader.HasAttributes Then
                            While reader.MoveToNextAttribute()
                                If reader.Name = "File" Then
                                    oBallot.FrontImage = New ImageFile(reader.Value, parentPath, isCompressed)
                                    frontCount += 1
                                End If
                            End While
                        End If
                    Case XmlNodeType.Element And reader.Name = "back"
                        If reader.HasAttributes Then
                            While reader.MoveToNextAttribute()
                                If reader.Name = "File" Then
                                    oBallot.BackImage = New ImageFile(reader.Value, parentPath, isCompressed)
                                    backCount += 1
                                End If
                            End While
                        End If
                End Select
            Loop

            If Not oBallot Is Nothing Then
                oBallot.Id = _ballots.Count + 1
                _ballots.Add(oBallot)
            End If

        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try

    End Sub

    Public Sub New(ByVal fileEntries As List(Of FileEntry))
        Dim fileIndex As Integer = 0

        While fileIndex < fileEntries.Count
            Dim oBallot As New Ballot
            Dim fEntry As FileEntry = fileEntries(fileIndex)
            Dim fName As String = Path.GetFileNameWithoutExtension(fEntry.FilePath)
            If fName.EndsWith("F") Then
                oBallot.FrontImage = New ImageFile(fEntry)
                If fileIndex + 1 < fileEntries.Count _
                AndAlso oBallot.FrontImage.ParentPath = fileEntries(fileIndex + 1).ParentPath _
                AndAlso Path.GetFileNameWithoutExtension(fileEntries(fileIndex + 1).FilePath).EndsWith("R") Then
                    oBallot.BackImage = New ImageFile(fileEntries(fileIndex + 1))
                    fileIndex += 2
                Else
                    fileIndex += 1
                End If
            Else
                oBallot.BackImage = New ImageFile(fEntry)
                If fileIndex + 1 < fileEntries.Count _
                AndAlso oBallot.BackImage.ParentPath = fileEntries(fileIndex + 1).ParentPath _
                AndAlso Path.GetFileNameWithoutExtension(fileEntries(fileIndex + 1).FilePath).EndsWith("F") Then
                    oBallot.FrontImage = New ImageFile(fileEntries(fileIndex + 1))
                    fileIndex += 2
                Else
                    fileIndex += 1
                End If
            End If
            oBallot.Id = _ballots.Count + 1
            _ballots.Add(oBallot)
        End While
    End Sub

    Public Property Ballots() As List(Of Ballot)
        Get
            Return _ballots
        End Get
        Set(ByVal value As List(Of Ballot))
            _ballots = value
        End Set
    End Property

    Public Function AsXml() As String
        Dim sb As New StringBuilder

        sb.Append("<?xml version='1.0' encoding='UTF-8'?>" & vbCrLf)
        sb.Append("<ballots>" & vbCrLf)
        For Each oBallot As Ballot In _ballots
            If Not oBallot.FrontImage Is Nothing Then
                sb.Append("<ballot Path='" & SecurityElement.Escape(oBallot.FrontImage.ParentPath.ToString) & "' Zip='" & oBallot.FrontImage.IsCompressed.ToString & "' >")
                sb.Append("<front File='" & SecurityElement.Escape(oBallot.FrontImage.FileName) & "' />")
            Else
                sb.Append("<ballot Path='" & SecurityElement.Escape(oBallot.BackImage.ParentPath.ToString) & "' Zip='" & oBallot.BackImage.IsCompressed.ToString & "' >")
            End If
            If Not oBallot.BackImage Is Nothing Then
                sb.Append("<back File='" & SecurityElement.Escape(oBallot.BackImage.FileName) & "' />")
            End If
            sb.Append("</ballot>" & vbCrLf)
        Next
        sb.Append("</ballots>" & vbCrLf)

        Return sb.ToString
    End Function

End Class   'BallotList class

Public Class Ballot
    Private _Id As String
    Private _frontImage As ImageFile
    Private _backImage As ImageFile

    Public Property Id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property

    Public Property FrontImage As ImageFile
        Get
            Return _frontImage
        End Get
        Set(value As ImageFile)
            _frontImage = value
        End Set
    End Property

    Public Property BackImage As ImageFile
        Get
            Return _backImage
        End Get
        Set(value As ImageFile)
            _backImage = value
        End Set
    End Property

End Class   'Ballot class

Public Class ImageFile

    Private _FileName As String
    Private _ParentPath As String
    Private _IsCompressed As Boolean

    Public Sub New(ByVal file As FileEntry)
        _FileName = file.FilePath
        _ParentPath = file.ParentPath
        _IsCompressed = file.FileType = FileEntry.FileTypeEnum.CompressedFile
    End Sub

    Public Sub New(ByVal filePath As String, parentPath As String, isCompressed As String)
        _FileName = filePath
        _ParentPath = parentPath
        If isCompressed = "True" Then
            _IsCompressed = True
        Else
            _IsCompressed = False
        End If
    End Sub

    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property

    Public Property ParentPath() As String
        Get
            Return _ParentPath
        End Get
        Set(ByVal value As String)
            _ParentPath = value
        End Set
    End Property

    Public Property IsCompressed() As Boolean
        Get
            Return _IsCompressed
        End Get
        Set(ByVal value As Boolean)
            _IsCompressed = value
        End Set
    End Property

    Public Function ArchivePath() As String
        If _IsCompressed Then
            Return _ParentPath & "\" & _FileName & ".zip"
        Else
            Return _ParentPath & "\" & _FileName
        End If
    End Function

End Class   'ImageFile class
