Imports System.Data.SqlClient
Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class login

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private results As String

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub





    Public Sub create(ByVal sql As String)
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
                    MsgBox("Register Succesfully")
                    Me.Hide()
                    Form1.Show()

                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub


   

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter username")



        End If

        If TextBox2.Text = "" Then
            MsgBox("Enter password")

        End If
        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 Then


            Try
                'CALL THE METHOD THAT YOU HAVE CREATED
                'AND PUT YOUR QUERY IN THE PARAMETER FOR INSERTING THE DATA IN THE DATABASE
                create("INSERT INTO login (username,password,usertype)VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.SelectedItem & "')")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
