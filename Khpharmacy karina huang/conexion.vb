Imports MySql.Data
Imports MySql.Data.MySqlClient

Module conexion
    Public conex As MySqlConnection
    Sub conectar()
        Dim conestr = "Server = localhost; Database = farmacia; Port = 3306; user id = root; password = ;" 'variable generica'
        Try
            conex = New MySqlConnection(conestr)
            conex.ConnectionString = conestr
            conex.Open()
            MsgBox("Conexion Exitosa !")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
End Module
