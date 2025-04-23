'Jason Permann
'Spring 2025
'RCET2265
'Etch-A-Sketch
'https://github.com/JaceFoxman/Etch-A-Sketch.git

Option Strict On
Option Explicit On
Option Compare Text

Imports System.Threading.Thread
Public Class DrawingForm
    'Set Color__________________________________________________________________________
    Function SetColor(Optional newColor As Color = Nothing) As Color
        Static _forecolor As Color = Color.Black
        If newColor <> Nothing Then
            _forecolor = newColor
        End If
        Return _forecolor
    End Function

    Function DialogBox() As Color
        'Make sure to add the tool "Color Dialog Box" added to front pannel to work
        ColorDialog.ShowDialog()
        SetColor(ColorDialog.Color)
        Return SetColor()
    End Function
    'Draw with mouse_____________________________________________________________________________________________
    Private Sub DrawingPictureBox_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseMove
        Static oldx, oldy As Integer

        Select Case e.Button.ToString
            Case "Left"
                DrawWithMouse(oldx, oldy, e.X, e.Y)
            Case "Right"
                'context menu set in drawing picture box properties 
            Case "Middle"
                DialogBox()
        End Select
        oldx = e.X
        oldy = e.Y
    End Sub
    Sub DrawWithMouse(oldx As Integer, oldY As Integer, newX As Integer, newY As Integer)
        Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(SetColor)
        graphics.DrawLine(pen, oldx, oldY, newX, newY)
        graphics.Dispose()
    End Sub
    'Draw WaveForm______________________________________________________________________________________________
    Sub Graticules()
        Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Black)
        Dim y As Integer = 0
        Dim x As Integer = 0

        Do Until y > DrawingPictureBox.Height
            y += (DrawingPictureBox.Height \ 10)
            graphics.DrawLine(pen, 0, y, DrawingPictureBox.Width, y)
        Loop

        Do Until x > DrawingPictureBox.Width
            x += (DrawingPictureBox.Width \ 10)
            graphics.DrawLine(pen, x, 0, x, DrawingPictureBox.Height)
        Loop
    End Sub
    Sub SineWave()
        Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Green)
        Dim ymax As Integer = DrawingPictureBox.Height \ 2
        Dim oldx, newy As Integer
        Dim oldy As Integer = DrawingPictureBox.Height \ 2
        Dim degresPerGraticule As Double = 360 / DrawingPictureBox.Width

        For x = 0 To DrawingPictureBox.Width
            newy = CInt(ymax * Math.Sin((Math.PI / 180) * (x * degresPerGraticule))) + DrawingPictureBox.Height \ 2
            graphics.DrawLine(pen, oldx, oldy, x, newy)
            oldx = x
            oldy = newy
        Next
    End Sub
    Sub CosineWave()
        Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Blue)
        Dim ymax As Integer = DrawingPictureBox.Height \ 2
        Dim oldx, newy As Integer
        Dim oldy As Integer = DrawingPictureBox.Height 'remove the divide 2 here so cosine starts at the right point 
        Dim degresPerGraticule As Double = 360 / DrawingPictureBox.Width

        For x = 0 To DrawingPictureBox.Width
            newy = CInt(ymax * Math.Cos((Math.PI / 180) * (x * degresPerGraticule))) + DrawingPictureBox.Height \ 2
            graphics.DrawLine(pen, oldx, oldy, x, newy)
            oldx = x
            oldy = newy
        Next
    End Sub
    Sub TangentWave()
        Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Red)
        Dim ymax As Integer = DrawingPictureBox.Height \ 2
        Dim oldx, newy As Integer
        Dim oldy As Integer = DrawingPictureBox.Height \ 2
        Dim degresPerGraticule As Double = 360 / DrawingPictureBox.Width

        If DrawingPictureBox.Width < 2400 Then
            For x = 0 To DrawingPictureBox.Width
                newy = CInt(ymax * Math.Tan((Math.PI / 180) * (x * degresPerGraticule))) + DrawingPictureBox.Height \ 2
                graphics.DrawLine(pen, oldx, oldy, x, newy)
                oldx = x
                oldy = newy
            Next
        ElseIf DrawingPictureBox.Width > 2400 Then

        End If
    End Sub
    'Clear Functions___________________________________________________________________________________________________________________________________________________________________
    Sub ShakeAndClear()
        Dim movePosition As Integer = RNG(1, 350) 'RNG not nedded just added for randomness on the shake
        Try
            My.Computer.Audio.Play(My.Resources.KH_Select, AudioPlayMode.Background)
        Catch ex As Exception
            MsgBox("Missing Resources", MsgBoxStyle.Critical, "Error")
        End Try

        For i = 1 To 10
            Me.Top += movePosition
            Me.Left += movePosition
            Sleep(100)
            movePosition *= -1 'need this to bring back to original position
        Next
        DrawingPictureBox.Refresh()
    End Sub

    Function RNG(min As Integer, max As Integer) As Integer
        Dim value As Single
        Randomize()
        value = Rnd()
        value *= max - min
        value += min
        Return CInt(Math.Ceiling(value))
    End Function
    'Event Handelers___________________________________________________________________________________________________________________________________________________________________
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click, ExitToolStripMenuItem.Click, ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click, ClearToolStripMenuItem.Click, ClearToolStripMenuItem1.Click
        ShakeAndClear()
    End Sub
    Private Sub DrawWaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformButton.Click, DrawWaveformsToolStripMenuItem.Click, DrawWaveformToolStripMenuItem.Click
        ShakeAndClear()
        Graticules()
        SineWave()
        CosineWave()
        TangentWave()
    End Sub
    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click, SetColorToolStripMenuItem.Click
        DialogBox()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Hide()
        AboutForm.Show()
    End Sub
End Class