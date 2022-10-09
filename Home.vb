Public Class Home
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AddCustomers.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        AddMedicine.Show()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AddTransaction.Show()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        TransactionHistory.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        Me.Close()
        Form1.Show()

    End Sub


End Class