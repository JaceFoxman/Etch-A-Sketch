'Jason Permann
'Spring 2025
'RCET2265
'Etch-A-Sketch
'https://github.com/JaceFoxman/Etch-A-Sketch.git

Option Strict On
Option Explicit On
Option Compare Text
Public Class AboutForm
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Me.Hide()
        DrawingForm.Show()
    End Sub
End Class