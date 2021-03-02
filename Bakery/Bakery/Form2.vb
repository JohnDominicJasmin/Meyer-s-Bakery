Public Class Form2
    Dim totalsales, commisionRate As Double

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click
        Try
            totalsales = TotalSalesTextBox.Text
            commisionRate = Double.Parse(CommisionComboBox.Text)
            CommisionTextBox.Text = Format(CDec((totalsales * commisionRate) / 100), "currency")
        Catch ex As System.FormatException
            MessageBox.Show("INVALID INPUT.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        Form1.Show()
        Me.Hide()

    End Sub
End Class