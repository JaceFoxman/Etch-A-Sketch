<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ReturnButton
        '
        Me.ReturnButton.Location = New System.Drawing.Point(596, 338)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(192, 100)
        Me.ReturnButton.TabIndex = 0
        Me.ReturnButton.Text = "Return"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReturnButton)
        Me.Name = "AboutForm"
        Me.Text = "AboutForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReturnButton As Button
End Class
