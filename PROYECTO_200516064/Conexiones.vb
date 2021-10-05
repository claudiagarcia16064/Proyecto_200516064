Imports System.Data.SqlClient
Module Conexiones
    'Create ADO.NET objects.
    Public ConnectionString = "Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True"
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Public ds As DataSet = New DataSet()
    Private cmd As SqlCommandBuilder
    Public da As SqlDataAdapter

    Sub verificarconexion()
        'con.ConnectionString = ConnectionString
        Try
            Dim con As New SqlConnection("Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True")
            con.Open()
            MsgBox("La conexion se ha realizado exitosamente!! ")
        Catch ex As Exception
            MsgBox("No se estableció conexión por: " & ex.Message)
        End Try
    End Sub

    Public Function usuarioRegistrado(ByVal usuario As String) As String

        Dim con As New SqlConnection("Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True")
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select * from usuario where usuario ='" & usuario & "'", con)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = True
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox("Datos no encontrados")
        End Try
        Return resultado
    End Function

    Function contrasena(ByVal usuario As String) As String
        Dim resultado As String = ""
        Try
            enunciado = New SqlCommand("Select password from usuarios where usuario ='" & usuario & "'", ConnectionString)
            respuesta = enunciado.ExecuteReader

            If respuesta.Read Then
                resultado = respuesta.Item("contraseña")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox("error contrasena")
        End Try
        Return resultado
    End Function

    Function obtenertabla(usuario As String)
        Dim con As New SqlConnection("Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True")
        con.ConnectionString = ConnectionString
        con.Open()
        Dim dadapter As New SqlDataAdapter("SELECT * FROM " + usuario + "", con)
        Dim dataset As New DataSet()
        dadapter.Fill(dataset, usuario)
        con.Close()
        Return dataset.Tables(usuario)
    End Function

    Function obtenertablacond(tabla As String, query As String)
        Dim con As New SqlConnection("Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True")
        con.ConnectionString = ConnectionString
        con.Open()
        Dim dadapter As New SqlDataAdapter(query, con)
        Dim dataset As New DataSet()
        dadapter.Fill(dataset, tabla)
        con.Close()

        Return dataset.Tables(tabla)
    End Function

    Sub ejecutarQuery(query As String)
        Dim con As New SqlConnection("Data Source=DESKTOP-GFQ1SVB;Initial Catalog=BD_200516064;Integrated Security=True")
        con.ConnectionString = ConnectionString
        con.Open()
        Dim Command As New SqlCommand(query, con)
        Dim res = Command.ExecuteNonQuery()
        MsgBox("La operación se realizó exitosamente ")
        con.Close()
    End Sub

End Module
