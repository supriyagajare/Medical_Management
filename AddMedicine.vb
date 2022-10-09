Public Class AddMedicine
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ' DateTimePicker1 = ""
        TextBox5.Text = ""
        TextBox6.Text = ""


        ' Me.Hide()


    End Sub


    Public Sub addmedicine(ByVal sql As String)
        Try
            strcon.Open()
            'HOLDS THE DATA TO BE EXECUTED
            With cmd
                .Connection = strcon
                .CommandText = sql
                'EXECUTE THE DATA
                result = cmd.ExecuteNonQuery
                'CHECKING IF THE DATA HAS EXECUTED OR NOT AND THEN THE POP UP MESSAGE WILL APPEAR
                If result = 0 Then
                    MsgBox("FAILED TO SAVE THE DATA", MsgBoxStyle.Information)
                Else
                    MsgBox("Item added successfully")
                    'Me.Hide()
                    ' login1.Show()

                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        If TextBox1.Text = "" Then
            MsgBox("Enter itemname")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter company name")

        ElseIf TextBox3.Text = "" Then
            MsgBox("Enter quantity")

        ElseIf DateTimePicker1.Text = "" Then
            MsgBox("Enter Expiry date")

        ElseIf TextBox5.Text = "" Then
            MsgBox("Enter costprice")

        ElseIf TextBox6.Text = "" Then
            MsgBox("Enter selling price")







        End If


        '   If TextBox2.Text = "" Then
        '  MsgBox("Enter password")

        ' End If
        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 Then


            Try
                'CALL THE METHOD THAT YOU HAVE CREATED
                'AND PUT YOUR QUERY IN THE PARAMETER FOR INSERTING THE DATA IN THE DATABASE
                addmedicine("INSERT INTO addmedicine VALUES ('" & TextBox1.Text & "','" _
                 & TextBox2.Text & "','" & TextBox3.Text & "','" & DateTimePicker1.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        Try
            'CALL THE METHOD THAT YOU HAVE CREATED.
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
            reload("SELECT * FROM addmedicine", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Public Sub reload(ByVal sql As String, ByVal DTG As Object)
        Try
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            DTG.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    Private Sub AddMedicine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'CALL THE METHOD THAT YOU HAVE CREATED.
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
            reload("SELECT * FROM addmedicine", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class