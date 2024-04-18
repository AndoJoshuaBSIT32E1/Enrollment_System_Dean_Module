Imports System.Data.OleDb
Module DatabaseConnection
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public da As New OleDbDataAdapter
    Public ds As New DataSet
    Public sql As String

    Public Sub connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Joshua\OneDrive\Desktop\My School Works\BSIT32E1_Second Semester\System Integration\Project_System_Integration\Dean-Module\Enrollment_System_Dean-Module\bin\Debug\Enrollment_System.accdb"
        cn.Open()
    End Sub
End Module
