Imports MySql.Data.MySqlClient
'Braian Calvete 3BF
Public Class Form1

    Dim conexion As MySqlConnection = New MySqlConnection
    Dim cmd As New MySqlCommand
    Sub ActualizarSelect()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try

            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "SELECT * FROM perros ORDER BY nombre "
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            GrdVeterinaria.DataSource = ds
            GrdVeterinaria.DataMember = "Tabla"

            conexion.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BRegistrar_Click(sender As Object, e As EventArgs) Handles BRegistrar.Click

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try

            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "INSERT INTO perros(nombre,raza,color) VALUES (@nombre,@raza,@color)"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()

            conexion.Close()

            ActualizarSelect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarSelect()
    End Sub
    Private Sub GrdVeterinaria_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdVeterinaria.CellContentClick

    End Sub

    Private Sub GrdVeterinaria_CellContentClick(sender As Object, e As EventArgs) Handles GrdVeterinaria.SelectionChanged, GrdVeterinaria.CellContentClick
        If (GrdVeterinaria.SelectedRows.Count > 0) Then
            txtNombre.Text = GrdVeterinaria.Item("nombre", GrdVeterinaria.SelectedRows(0).Index).Value
        End If
    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try

            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "UPDATE perros Set nombre=@nombre, raza=@raza, color=@color WHERE id=@id"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.Parameters.AddWithValue("@id", txtId.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()
            txtId.Clear()

            conexion.Close()

            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click
        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try

            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "DELETE FROM perros WHERE id=@id"
            cmd.Prepare()

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtRaza.Text)
            cmd.Parameters.AddWithValue("@color", txtColor.Text)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            txtNombre.Clear()
            txtRaza.Clear()
            txtColor.Clear()
            txtId.Clear()

            conexion.Close()

            ActualizarSelect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
