
'commision
'add information of programmer look at module 5 posted
'design,icons
'display current time in textScreen after calculate

Public Class Form1



    Dim totalItems, total, totalDrinks, totalCakes, salesTax, change, cash As Double

    Const TaxPercentage As Double = 1.0445



    Sub setAllInputsToZeroValueAndGetTotalItems(ByRef setInputToZeroIs As Boolean)
        ' naka store sa 2d array ang mga object mula sa ating inputs
        Dim textBoxes(,) As TextBox = {{freshbread1, freshbread2, freshbread3, freshbread4, freshbread5, freshbread6, freshbread7, freshbread8, freshbread9, freshbread10, freshbread11, freshbread12},
            {hotdrinks1, hotdrinks2, hotdrinks3, hotdrinks4, hotdrinks5, hotdrinks6, hotdrinks7, hotdrinks8, hotdrinks9, hotdrinks10, hotdrinks11, hotdrinks12},
            {pastries1, pastries2, pastries3, pastries4, pastries5, pastries6, pastries7, pastries8, pastries9, pastries10, pastries11, pastries12}
        }

        Try
            For loopA As Integer = 0 To 2
                For loopB As Integer = 0 To 11
                    totalItems += Double.Parse(textBoxes(loopA, loopB).Text) 'i-iterate ang array at kuhanin ang items na input mula kay user

                    If (setInputToZeroIs) Then ' itong value na 'setInputToZeroIs'  ay mula sa parameter(variable sa function na nasa parenthesis) ito ay boolean, kung true ang result then i set lahat ng inputs to "0"
                        textBoxes(loopA, loopB).Text = "0"
                    End If

                Next loopB
            Next loopA
        Catch ex As System.FormatException
            MessageBox.Show("INPUT SHOULD NOT CONTAIN LETTERS OR SPECIAL CHARACTERS, DEVAULT VALUE CANNOT LEAVE A BLANKSPACE", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If (setInputToZeroIs) Then ' itong value na 'setInputToZeroIs'  ay mula sa parameter(variable sa function na nasa parenthesis) ito ay boolean, kung true ang result then i set lahat ng display to "0"
            CostOfDrinkLabel.Text = Format(CDec(0), "currency")
            CostOfCakesLabel.Text = Format(CDec(0), "currency")
            TotalLabel.Text = Format(CDec(0), "currency")
            TotalItemsLabel.Text = "0"
            TaxLabel.Text = Format(CDec(0), "currency")
            CashLabel.Text = Format(CDec(0), "currency")
        End If
    End Sub



    ' ang inputs ay nakastore sa array kasama ang amount kung magkakano sila
    Sub TotalValues()

        Dim textBoxesValue(,) As Double = {{120.0 * Val(freshbread1.Text), 150.0 * Val(freshbread2.Text), 200.0 * Val(freshbread3.Text), 25.0 * Val(freshbread4.Text), 180.0 * Val(freshbread5.Text), 300.0 * Val(freshbread6.Text), 30.0 * Val(freshbread7.Text), 35.0 * Val(freshbread8.Text), 175.0 * Val(freshbread9.Text), 250.0 * Val(freshbread10.Text), 280.0 * Val(freshbread11.Text), 199.99 * Val(freshbread12.Text)},
                                  {150.0 * Val(pastries1.Text), 120.5 * Val(pastries2.Text), 100.0 * Val(pastries3.Text), 45.0 * Val(pastries4.Text), 300.0 * Val(pastries5.Text), 350.0 * Val(pastries6.Text), 250.0 * Val(pastries7.Text), 150.0 * Val(pastries8.Text), 145.0 * Val(pastries9.Text), 200.0 * Val(pastries10.Text), 145.0 * Val(pastries11.Text), 145.0 * Val(pastries12.Text)},
                                     {99.99 * Val(hotdrinks1.Text), 199.99 * Val(hotdrinks2.Text), 250.0 * Val(hotdrinks3.Text), 120.5 * Val(hotdrinks4.Text), 300.5 * Val(hotdrinks5.Text), 300.5 * Val(hotdrinks6.Text), 99.99 * Val(hotdrinks7.Text), 150.0 * Val(hotdrinks8.Text), 250.0 * Val(hotdrinks9.Text), 99.99 * Val(hotdrinks10.Text), 99.99 * Val(hotdrinks11.Text), 200.0 * Val(hotdrinks12.Text)}
        }
        'iterate sa array at kunin ang total amount ng cakes
        For valueOfCakes_A As Integer = 0 To 1
            For valueOfCakes_B As Integer = 0 To 11
                totalCakes += textBoxesValue(valueOfCakes_A, valueOfCakes_B)
            Next valueOfCakes_B
        Next valueOfCakes_A
        'iterate sa array pero sa amount naman ng drinks
        For valueOfDrinks As Integer = 0 To 11
            totalDrinks += textBoxesValue(2, valueOfDrinks)
        Next valueOfDrinks


        Try
            'i set sa label ang mga nakuhang amount mula sa array
            total = totalDrinks + totalCakes

            CostOfDrinkLabel.Text = Format(CDec(totalDrinks), "currency")
            CostOfCakesLabel.Text = Format(CDec(totalCakes), "currency")
            TaxLabel.Text = Format(CDec(total - (total / TaxPercentage)), "currency")
            TotalLabel.Text = Format(CDec(total), "currency")
            TotalItemsLabel.Text = totalItems


        Catch ex As System.Exception
            MessageBox.Show("INVALID INPUT.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    'if ang binayad ay mahigit pa sa total i-print ang resibo else show no balance
    Sub printReceiptScreen()
        Try
            change = CashLabel.Text - total
            cash = CashLabel.Text

            If (cash >= total) Then
                getreceiptSCreen()
            Else
                MessageBox.Show("INSUFFICIENT AMOUNT.", "NO BALANCE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As System.InvalidCastException
            MessageBox.Show("INVALID INPUT.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'print default resibo screen
    Sub clearReceiptScreen()
        ReceiptScreenText.Text = "**********************************************
 * * * * * * * * * *  RECEIPT * * * * * * * * * * 
=============================== "
    End Sub

    Private Sub CommisionButton_Click(sender As Object, e As EventArgs) Handles CommisionButton.Click
        Form2.Show()
        Me.Hide()
        Form2.TotalSalesTextBox.Text = TotalLabel.Text
    End Sub



    'printing resibo 
    Sub getreceiptSCreen()
        Try
            ReceiptScreenText.Text = ("**********************************************
 * * * * * * * * * *  RECEIPT * * * * * * * * * * 
=============================== " & vbCrLf & "COST OF DRINKS: " & CostOfDrinkLabel.Text & vbCrLf &
"COST OF CAKES: " & CostOfCakesLabel.Text & vbCrLf &
"QUANTITY: " & TotalItemsLabel.Text & vbCrLf &
"SUBTOTAL: " & Format(CDec(total / TaxPercentage), "currency") & vbCrLf &
"TOTAL: " & TotalLabel.Text & vbCrLf &
"CASH: " & Format(CDec(CashLabel.Text), "currency") & vbCrLf &
"CHANGE :" & Format(CDec(change), "currency") & vbCrLf &
"VAT(4.45%)" &
vbCrLf & vbCrLf & vbCrLf & vbCrLf & "                 " & Date.Now)
        Catch ex As System.InvalidCastException

        End Try
    End Sub











    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick

        CurrentDate.Text = Date.Now

    End Sub


    'clear button mag function call sa mga nabanggit
    Private Sub ClearLabel_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        setAllInputsToZeroValueAndGetTotalItems(True)
        freshbread1.Focus()
        clearReceiptScreen()
        setAllValuesTo_Zero()

    End Sub
    ' calculate button mag function call sa mga nabanggit
    Private Sub CalculateLabel_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click

        setAllInputsToZeroValueAndGetTotalItems(False)
        TotalValues()
        printReceiptScreen()

        setAllValuesTo_Zero()
    End Sub

    Private Sub ExitLabel_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub
    ' gawing 0 value lahat 
    Sub setAllValuesTo_Zero()
        totalDrinks = 0
        totalCakes = 0
        salesTax = 0
        totalItems = 0
    End Sub



End Class
