Imports MySql.Data.MySqlClient

Module koneksi


    Dim strkon As String = "server=localhost; uid=root; database=ta2020022cs"
    Public kon As New MySqlConnection(strkon)
    Public perintah As New MySqlCommand
    Public mda As New MySqlDataAdapter
    Public ds As New DataSet
    Public cek As mysqldatareader
    Public userLogin As String

End Module
