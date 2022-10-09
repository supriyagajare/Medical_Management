


Imports System.Data.SqlClient

Public Class AddTransaction

    Public Sub getmedicinesearch(ByVal sql As String, ByVal dataCollection As AutoCompleteStringCollection)


        Try
            Dim ds As New DataSet()
            dt = New DataTable
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            'da.Fill(dt)
            da.Fill(ds)
            ' DTG.DataSource = dt
            For Each row As DataRow In ds.Tables(0).Rows
                dataCollection.Add(row(0).ToString())
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)




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

    Private Sub AddTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.AutoCompleteMode = AutoCompleteMode.Suggest
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim DataCollection As New AutoCompleteStringCollection()
        getmedicinesearch("select distinct itemname from addmedicine", DataCollection)

        TextBox1.AutoCompleteCustomSource = DataCollection

        Try
            'CALL THE METHOD THAT YOU HAVE CREATED.
            'PUT YOUR QUERY AND THE NAME OF THE DATAGRIDVIEW IN THE PARAMETERS.
            'THIS IS METHOD IS FOR RETREIVING THE DATA IN THE DATABASE TO THE DATAGRIDVIEW
            reload("SELECT itemname,quantity,sellingprice FROM addmedicine", DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Home.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        '  DataGridView1.Sort(DataGridView1.Columns(1), ListSortDirection.Ascending)

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


                MsgBox("Data Found")

            Else
                MsgBox("Data not found")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            ' If () Then
            reload("SELECT * FROM addmedicine where itemname  Like'" + TextBox1.Text + "%'", DataGridView1)

            'End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
