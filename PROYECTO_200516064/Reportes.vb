Public Class Reportes
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        salir()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        CRUD_Libros.Show()
    End Sub
End Class