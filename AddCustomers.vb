Public Class AddCustomers



    Public Sub addcustomer(ByVal sql As String)
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


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Then
            MsgBox("Enter Name")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Phone Number")

        ElseIf TextBox3.Text = "" Then
            MsgBox("Enter Date")


        End If

        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 Then


                Try
                    'CALL THE METHOD THAT YOU HAVE CREATED
                    'AND PUT YOUR QUERY IN THE PARAMETER FOR INSERTING THE DATA IN THE DATABASE
                    addcustomer("INSERT INTO addcustomer VALUES ('" & TextBox1.Text & "','" _
                 & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & TextBox3.Text & "')")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        Try
            'CALL THE METHOD THAT YOU HAVE CREATED.
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
            reload("SELECT * FROM addcustomer", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try








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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub AddCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'CALL THE METHOD THAT YOU HAVE CREATED.
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
            reload("SELECT * FROM addcustomer", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class