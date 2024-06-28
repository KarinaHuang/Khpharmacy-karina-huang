Public Class salir
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Gracias por su uso!", MsgBoxStyle.Information, "ADIOS")
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        principal.Show()
    End Sub
End Class