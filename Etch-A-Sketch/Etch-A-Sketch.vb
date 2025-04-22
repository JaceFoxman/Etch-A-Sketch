'Jason Permann
'Spring 2025
'RCET2265
'Etch-A-Sketch
'https://github.com/JaceFoxman/Etch-A-Sketch.git

Option Strict On
Option Explicit On
Option Compare Text

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

        Me.Text = $"({e.X}, {e.Y})"
        Select Case e.Button.ToString
            Case "Left"
                DrawWithMouse(oldx, oldy, e.X, e.Y)
            Case "Right"

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

    'Sub TangentWave()
    '    Dim graphics As Graphics = DrawingPictureBox.CreateGraphics
    '    Dim pen As New Pen(Color.Red)
    '    Dim xTan As Double = 1.0
    '    Dim yTan As Double = 2.0
    '    Dim angle As Double
    '    Dim radians As Double
    '    Dim result As Double

    '    Dim ymax As Double = DrawingPictureBox.Height \ 2
    '    Dim oldx, newy As Double
    '    Dim oldy As Double = DrawingPictureBox.Height \ 2

    '    For x = 0 To 800
    '        radians = angle * (Math.PI / 180)
    '        result = Math.Tan(radians)
    '        angle = CInt(ymax * Math.Tan((Math.PI / 180) * (x * 1))) + DrawingPictureBox.Height \ 2
    '        graphics.DrawLine(pen, oldx, oldy, x, newy)
    '        newy = result
    '        oldx = x
    '        oldy = newy
    '    Next
    'End Sub

    'Clear Functions___________________________________________________________________________________________________________________________________________________________________
    Sub ShakeAndClear()
        Dim defaultYPosition As Integer = 39
        Dim defaultXPosition As Integer = 7
        Dim yPos1 As Integer = 75
        Dim xPos1 As Integer = 30

        xPos1 = DrawingPictureBox.Location.X
        yPos1 = DrawingPictureBox.Location.Y

        defaultXPosition = DrawingPictureBox.Location.X
        defaultYPosition = DrawingPictureBox.Location.Y

        My.Computer.Audio.Play(My.Resources.KH_Select, AudioPlayMode.Background)
        DrawingPictureBox.Refresh()
    End Sub
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
        'TangentWave()
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click, SelectColorToolStripMenuItem.Click, SetColorToolStripMenuItem.Click
        DialogBox()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Me.Hide()
        AboutForm.Show()
    End Sub
End Class