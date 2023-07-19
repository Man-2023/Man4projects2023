Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Drawing

Partial Class delOperation
    Inherits System.Web.UI.Page

    Protected Sub ButtonGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGroup.Click
        Dim sqlString As String = ""
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Manold.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT  count(ID) ,  operation FROM masrofat where operation like? GROUP BY " & " operation" & " order by " & " operation"
        DropDownListGroup.DataTextField = "operation"
        DropDownListGroup.DataValueField = "operation"
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlCommand.Parameters.Clear()
        sqlCommand.Parameters.AddWithValue("?", "%" + txtSearch.Text.ToString + "%")
        sqlConnection.Open()
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
        DropDownListGroup.DataSource = dataReader
        DropDownListGroup.DataBind()
        txtSearch.Text = DropDownListGroup.SelectedValue ' لمعالجة اختيار اول اختيار فى القائمة
        ' ButtonGroup.Enabled = False
        sqlConnection.Close()
    End Sub
    Protected Sub DropDownListGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListGroup.SelectedIndexChanged
        txtSearch.Text = DropDownListGroup.SelectedValue
        txtSearch.Focus()
    End Sub

    Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        '------------------------------- البحث عن العملية 

        Dim sqlString As String = ""
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Manold.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT * FROM masrofat where operation = " & "'" & txtSearch.Text.ToString & "'" ' GROUP BY " & " operation" & " order by " & " operation"
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlConnection.Open()
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)

        If dataReader.HasRows = True Then
            If MsgBox(" هل ترغب فى أرجاع العملية؟ " + txtSearch.Text.ToString, 528387, "رسالة تأكيد") = 6 Then
                sqlString = ""
                sqlString = " SELECT * FROM masrofat where operation = " & "'" & txtSearch.Text.ToString & "'"
                Dim sqlCommand1 As New OleDbCommand(sqlString, sqlConnection)
                '------------------------------- اضافة جميع سجلات العملية للملف الاصلى

                sqlCommand1.CommandText = "INSERT INTO " & Server.MapPath("app_data\Man.accdb") & ".masrofat select * from masrofat where  operation =  " & "'" & txtSearch.Text.ToString & "'"
                sqlCommand1.ExecuteNonQuery()
                '-------------------------------  مسح العملية من الملف الاحتياطى

                sqlString = " DELETE * FROM masrofat where operation = " & "'" & txtSearch.Text.ToString & "'"
                Dim sqlCommand2 As New OleDbCommand(sqlString, sqlConnection)
                Dim dataAd As OleDbDataAdapter = New OleDbDataAdapter
                dataAd.DeleteCommand = sqlCommand2
                dataAd.DeleteCommand.ExecuteNonQuery()
                sqlConnection.Close()
                MsgBox(" تم أستعادة العملية من الملفات! بنجاح" + txtSearch.Text.ToString, 65536, "  ")
                txtSearch.Text = ""
            Else
                txtSearch.Text = ""
            End If
        Else
            MsgBox("  Not  Found ! " + txtSearch.Text.ToString, 65536, "  ")
            sqlConnection.Close()
            txtSearch.Text = ""
        End If

    End Sub
End Class
