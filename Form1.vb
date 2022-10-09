Imports System.Data.SqlClient
Public Class Form1



    Private Sub login1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        login.Show()




    End Sub
    Public Sub reload(ByVal sql As String, ByVal UserType As String)
        Try
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            '''''''''''''''''
            If dt.Rows.Count >= 1 Then


                MsgBox("Login Successful")
                If UserType = "Admin" Then
                    Home.Show()
                    Me.Hide()


                End If
                If UserType = "user" Then
                    AddTransaction.Show()
                    Me.Hide()

                End If
            Else
                MsgBox("User not found")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        If TextBox1.Text = "" Then
            MsgBox("Enter username")


        End If

        If TextBox2.Text = "" Then
            MsgBox("Enter password")


        End If
        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 Then

            Try

                'CALL THE METHOD THAT YOU HAVE CREATED.
                'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
                'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
                reload("SELECT * FROM login where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'and usertype='" & Trim(ComboBox1.SelectedItem) & "'", Trim(ComboBox1.SelectedItem) + "")

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class