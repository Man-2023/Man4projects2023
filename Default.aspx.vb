
Partial Class frmDefault
    Inherits System.Web.UI.Page

    Protected Sub ButtonBackup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBackup.Click
        Try
            FileCopy("E:\Man2023\App_Data\Man.accdb", "E:\Backup\Man.accdb")
        Catch rx As Exception
            MsgBox("المجلد الاحتياطى غير موجدود.. !" + rx.Message, 0, "")
            '  Label6.Text = rx.Message
            Console.WriteLine(rx.Message)
        End Try

    End Sub
End Class
