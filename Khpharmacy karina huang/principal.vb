Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Diagnostics.Eventing.Reader


Public Class principal
    Private Sub principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = True
        Panel2.Visible = False
        Size = New Size(400, 370)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        salir.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' boton productos 
        Panel1.Visible = False
        Panel2.Visible = True
        Size = New Size(410, 370)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' boton volver a la pag de seleccion desde productos
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Size = New Size(400, 370)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' boton usuarios 
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = True
        Size = New Size(410, 370)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ' boton volve a pag de seleccion desde usuarios
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
        Size = New Size(400, 370)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'boton agregar usuario
        Me.Hide()
        completar.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'boton enlistar usuario
        Me.Hide()
        tablas.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' boton agregar productos
        Panel2.Visible = False
        Panel4.Visible = True
        Size = New Size(450, 400)

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'boton cancelar de agregar productos
        Panel2.Visible = True
        Panel4.Visible = False
        Size = New Size(400, 370)

    End Sub
    Public Function agregarP(codigo As String, nombre As String, precio As String, cantidad As String)
        If (codigo = "" Or nombre = "" Or precio = "" Or cantidad = "") Then
            MsgBox("Error, falta información", MsgBoxStyle.Critical, "ATENCIÓN")
        Else
            Try
                Dim Comando = New MySqlCommand("SELECT * FROM productos WHERE nombre = '" + nombre + "';", conex)
                Dim Resultado = Comando.ExecuteReader
                Resultado.Read()
                If (Resultado.HasRows) Then
                    MsgBox("Producto ya agregado", MsgBoxStyle.Exclamation, "ATENCIÓN")
                    Resultado.Close()
                Else
                    Resultado.Close()
                    Comando = New MySqlCommand("INSERT INTO productos (codigo_producto,nombre,precio,cantidad) VALUES ('" + codigo + "','" + nombre + "','" + precio + "','" + cantidad + "')", conex)
                    Dim result = Comando.ExecuteNonQuery
                    MsgBox("Producto agregado exitosamente", MsgBoxStyle.Information, "EXITOSO")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    Return True
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            End Try
        End If
        Return False
    End Function
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim agP As String
        agP = agregarP(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ' boton para entrar a editar de producto
        Panel2.Visible = False
        Panel6.Visible = True
        Size = New Size(460, 405)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ' boton para entrar a editar de usuario 
        Panel3.Visible = False
        Panel5.Visible = True
        Size = New Size(460, 405)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        ' cancelar desde la pag actualizacion usuario
        Panel5.Visible = False
        Panel3.Visible = True
        Size = New Size(400, 370)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ' cancelar desde pag actualizacion producto
        Panel6.Visible = False
        Panel2.Visible = True
        Size = New Size(400, 370)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ' buscar el codigo para producto 
        Try
            If (TextBox13.Text = "") Then
                MsgBox("Falta de informacion", MsgBoxStyle.Critical, "ERROR")
            Else
                Dim comando = New MySqlCommand("SELECT * FROM productos WHERE id_producto = " + TextBox13.Text + ";", conex)
                Dim resultado = comando.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    'mostrar las opciones 
                    TextBox8.Text = resultado("codigo_producto")
                    TextBox7.Text = resultado("nombre")
                    TextBox6.Text = resultado("precio")
                    TextBox5.Text = resultado("cantidad")
                    resultado.Close()
                Else
                    MsgBox("El id ingresado no existe", MsgBoxStyle.Information, "ATENCION")
                    resultado.Close()

                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR" + ex.Message)

        End Try



    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ' boton para actualizar productos
        Dim comando = New MySqlCommand("UPDATE productos SET codigo_producto = '" + TextBox8.Text + "', nombre = '" + TextBox7.Text + "', precio = '" + TextBox6.Text + "', cantidad = '" + TextBox5.Text + "' WHERE id_producto = " + TextBox13.Text + ";", conex)
        Dim actualizar = comando.ExecuteNonQuery()
        MsgBox("La modificación ha sido realizado con exito", MsgBoxStyle.Information, "ATENCIÓN")
        TextBox8.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        ' boton para actualizar datos de usuario
        Dim comando = New MySqlCommand("UPDATE usuarios SET username = '" + TextBox12.Text + "', password = '" + TextBox11.Text + "', contrasena = '" + TextBox10.Text + "', fullname = '" + TextBox9.Text + "' WHERE user_id = " + TextBox14.Text + ";", conex)
        Dim actualizar = comando.ExecuteNonQuery()
        MsgBox("La modificación ha sido realizado con exito", MsgBoxStyle.Exclamation, "ATENCIÓN")
        TextBox12.Text = ""
        TextBox11.Text = ""
        TextBox10.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        ' boton buscar usuario
        Try
            If (TextBox14.Text = "") Then
                MsgBox("Falta de informacion", MsgBoxStyle.Critical, "ERROR")
            Else
                Dim comando = New MySqlCommand("SELECT * FROM usuarios WHERE user_id = " + TextBox14.Text + ";", conex)
                Dim resultado = comando.ExecuteReader
                resultado.Read()
                If (resultado.HasRows) Then
                    'mostrar las opciones 
                    TextBox12.Text = resultado("username")
                    TextBox11.Text = resultado("password")
                    TextBox10.Text = resultado("contrasena")
                    TextBox9.Text = resultado("fullname")
                    resultado.Close()
                Else
                    MsgBox("El id ingresado no existe", MsgBoxStyle.Information, "ATENCION")
                    resultado.Close()

                End If

            End If

        Catch ex As Exception
            MsgBox("ERROR" + ex.Message)

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox11.UseSystemPasswordChar = False
        Else
            TextBox11.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox10.UseSystemPasswordChar = False
        Else
            TextBox10.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' boton mostrar lista productos
        Me.Hide()
        table2.Show()
    End Sub
End Class