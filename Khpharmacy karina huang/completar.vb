Imports MySql.Data.MySqlClient

Public Class completar
    Private Sub completar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'boton cancelar
        Me.Hide()
        principal.Show()
    End Sub
    Public Function Vregistrar(usuario As String, contra As String, Ccontra As String, NombComp As String)
        If (usuario = "" Or contra = "" Or Ccontra = "" Or NombComp = "") Then
            MsgBox("Error, falta información", MsgBoxStyle.Critical, "ATENCIÓN")
        Else
            Try
                Dim Comando = New MySqlCommand("SELECT * FROM usuarios WHERE username = '" + usuario + "';", conex)
                Dim Resultado = Comando.ExecuteReader
                Resultado.Read()
                If (Resultado.HasRows) Then
                    MsgBox("Usuario ya existe", MsgBoxStyle.Exclamation, "ATENCIÓN")
                    Resultado.Close()
                Else
                    Resultado.Close()
                    Comando = New MySqlCommand("INSERT INTO usuarios (username,password,contrasena,fullname) VALUES ('" + usuario + "','" + contra + "','" + Ccontra + "','" + NombComp + "')", conex)
                    If (TextBox2.Text = TextBox3.Text) Then
                        Dim result = Comando.ExecuteNonQuery
                        MsgBox("Usuario registrado exitosamente", MsgBoxStyle.Information, "REGISTRO EXITOSO")
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox4.Text = ""
                        Return True
                    Else
                        MsgBox("Error en confirmación de contraseña, intente nuevamente", MsgBoxStyle.Exclamation, "ATENCIÓN")
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
        End If
        Return False
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim registrar As String
        registrar = Vregistrar(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True
        End If
    End Sub
End Class