
Public Class FileEntry

    Public Enum FileTypeEnum
        File
        CompressedFile
    End Enum

    Public Property FilePath As String
    Public Property ArchivePath As String
    Public Property FileType As FileTypeEnum
    Public Property ParentPath As String

    Public Sub New(ByVal filePath As String, ByVal archivePath As String, ByVal fileType As FileTypeEnum, ByVal parentPath As String)
        Me.FilePath = filePath
        Me.ArchivePath = archivePath
        Me.FileType = fileType
        Me.ParentPath = parentPath
    End Sub

End Class   'FileEntry class
