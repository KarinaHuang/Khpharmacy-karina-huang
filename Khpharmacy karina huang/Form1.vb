Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Imports System.Security

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call conectar()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
    Public Function Vingresar(usuario As String, contra As String)
        If (usuario = "" Or contra = "") Then
            MsgBox("Error, Falta información", MsgBoxStyle.Critical, "ATENCIÓN")
            Return False
        Else
            Try
                Dim Comando = New MySqlCommand("SELECT * FROM usuarios WHERE username = '" + usuario + "';", conex)
                Dim Resultado = Comando.ExecuteReader
                Resultado.Read()
                If (Resultado.HasRows) Then
                    If (Resultado("password") = contra) Then
                        MsgBox("HOLA " + Resultado("fullname"), MsgBoxStyle.Information, "BIENVENIDO")
                        Resultado.Close()
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        Me.Hide()
                        principal.Show()
                        Return True
                    Else
                        MsgBox("Contraseña incorrecta, intente de nuevo", MsgBoxStyle.Exclamation, "ATENCIÓN")
                    End If
                Else
                    MsgBox("Usuario no registrado", MsgBoxStyle.Exclamation, "ATENCIÓN")
                End If
                Resultado.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
        End If
        Return False
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ingresar As String
        ingresar = Vingresar(TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        registrar.Show()
    End Sub
End Class
