Imports System.IO

Public Class FileHandler
    Private _fileList As New List(Of FileEntry)
    Private _parentPath As String

    Public Sub ForEachFileAndFolder(ByVal sourceFolder As String, _
                                    ByVal directoryCallBack As Action(Of DirectoryInfo), _
                                    ByVal fileCallBack As Action(Of FileInfo))

        If Directory.Exists(sourceFolder) Then
            Try
                For Each foldername As String In Directory.GetDirectories(sourceFolder)
                    If directoryCallBack IsNot Nothing Then
                        directoryCallBack.Invoke(New DirectoryInfo(foldername))
                    End If

                    ForEachFileAndFolder(foldername, directoryCallBack, fileCallBack)
                Next
            Catch ex As UnauthorizedAccessException
                Trace.TraceWarning(ex.Message)
            End Try

            If fileCallBack IsNot Nothing Then
                Dim fileList As List(Of String) = Directory.GetFiles(sourceFolder).ToList
                Dim sortedFileList As List(Of String) = fileList.OrderBy(Function(x) New FileInfo(x).Name.Substring(2)).ToList
                For Each filename As String In sortedFileList
                    fileCallBack.Invoke(New FileInfo(filename))
                Next
            End If
        End If
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _fileList.Count
        End Get
    End Property

    Public ReadOnly Property Files() As List(Of FileEntry)
        Get
            Return _fileList
        End Get
    End Property

    Public Sub DirectoryAction(ByVal dirInfo As DirectoryInfo)
        _parentPath = dirInfo.FullName
    End Sub

    Public Sub FileAction(ByVal fileInfo As FileInfo)
        If fileInfo.Extension = ".zip" Then
            Try
                Using archive As ZipArchive = ZipFile.OpenRead(fileInfo.FullName)
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If entry.FullName.EndsWith(".pbm", StringComparison.OrdinalIgnoreCase) Then
                            _fileList.Add(New FileEntry(entry.FullName, fileInfo.FullName, FileEntry.FileTypeEnum.CompressedFile, _parentPath))
                        End If
                    Next
                End Using
            Catch e As Exception
                'Consume the exception
            End Try
        ElseIf fileInfo.Extension = ".pbm" Then
            _fileList.Add(New FileEntry(fileInfo.Name, "", FileEntry.FileTypeEnum.File, _parentPath))
        End If
    End Sub

End Class   'FileHandler class
