Imports MySql.Data.MySqlClient
Module strconcrud
    'SETTING UP THE CONNECTION

    Public Function strstrconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;database=medi;password=root")
    End Function
    Public strcon As MySqlConnection = strstrconnection()
    'DECLARING CLASSES AND VARIABLE
    Public result As String
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
End Module

