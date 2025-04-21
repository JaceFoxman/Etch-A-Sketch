'Jason Permann
'Spring 2025
'RCET2265
'Etch-A-Sketch
'https://github.com/JaceFoxman/Etch-A-Sketch.git

Option Strict On
Option Explicit On
Option Compare Text

Public Class Form1

    'Event Handelers___________________________________________________________________________________________________________________________________________________________________
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click, ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click, ClearToolStripMenuItem1.Click
        DrawingPictureBox.Refresh()
    End Sub

    Private Sub DrawWaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformButton.Click, DrawWaveformsToolStripMenuItem.Click, DrawWaveformToolStripMenuItem.Click

    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click, SetColorToolStripMenuItem.Click

    End Sub

End Class
