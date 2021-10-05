Public Class Imagen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        insertar_usuario(1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        insertar_usuario(2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        insertar_usuario(3)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        insertar_usuario(4)

    End Sub

    Public Sub insertar_usuario(img As Integer)

        Try
            ejecutarQuery("INSERT INTO usuario(nombre,apellido,usuario,tipo_usuario,nacimiento,contraseña,imagen) 
                        VALUES('" + Registro.TextBox1.Text + "','" +
                                    Registro.TextBox2.Text + "','" +
                                    Registro.TextBox3.Text + "','" +
                                    Registro.ComboBox1.Text.ToString+ "','" +
                                    Registro.DateTimePicker1.Text.ToString + "','" +
                                    Registro.TextBox5.Text + "'," +
                                    img.ToString + ");")


        Catch ex As Exception

            MsgBox("Se produjo un error, sus datos no fueron salvados") : Registro.TextBox1.Focus() : Exit Sub
        End Try
        Form1.Show()

    End Sub

End Class