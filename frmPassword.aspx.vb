
Partial Class password
    Inherits System.Web.UI.Page

    Private Property FormView As Object

    Protected Sub ButtonLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLogIn.Click
        If TextBoxUserName.Text = "Farid" Then
            If TextBoxPassword.Text = "1965" Then
                Response.Redirect("frmMain.aspx")
            Else
                lblPassword.Text = "كلمة السر غير صحيحة"
                TextBoxPassword.Text = ""
                TextBoxPassword.Focus()
            End If
        Else
            lblPassword.Text = "كلمة المرور غير صحيحة"
            TextBoxUserName.Text = ""
            TextBoxUserName.Focus()
        End If
    End Sub

    Protected Sub ImageButtonExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExit.Click

    End Sub

End Class
