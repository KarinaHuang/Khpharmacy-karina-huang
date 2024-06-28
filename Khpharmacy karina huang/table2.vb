Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class table2
    Private Sub table2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Conexion As New MySqlConnection("data source = localhost; user id = root; password =; database = farmacia")
        Dim Adaptador As MySqlDataAdapter
        Dim TablaDatos As DataTable
        Dim ConsultaSQL As String
        Try
            ConsultaSQL = "SELECT * FROM productos"
            Adaptador = New MySqlDataAdapter(ConsultaSQL, Conexion)
            TablaDatos = New DataTable
            Adaptador.Fill(TablaDatos)
            DataGridView1.DataSource = TablaDatos
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' boton volver 
        Me.Hide()
        principal.Show()
    End Sub
End Class