Public Class frmDeanDashboard
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        With frmConfirm
            .TopLevel = False
            Panel4.Controls.Add(frmConfirm)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        With frmSchedule
            .TopLevel = False
            Panel4.Controls.Add(frmSchedule)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnStudents_Click(sender As Object, e As EventArgs) Handles btnStudents.Click
        With frmStudents
            .TopLevel = False
            Panel4.Controls.Add(frmStudents)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnTeacher_Click(sender As Object, e As EventArgs) Handles btnTeacher.Click
        With frmTeacher
            .TopLevel = False
            Panel4.Controls.Add(frmTeacher)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btnSection_Click(sender As Object, e As EventArgs) Handles btnSection.Click
        With frmSections
            .TopLevel = False
            Panel4.Controls.Add(frmSections)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToLongDateString
        lblTime.Text = Now.ToLongTimeString
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()

    End Sub
End Class