'Option Strict On
'Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataTable
Imports System.Web.UI.WebControls
Imports System.IO

Imports System.Drawing
Imports System.Web.UI.WebControls.DataControlRowType
Imports System.Web.UI.WebControls.DataControlRowState

Class adding
    Inherits System.Web.UI.Page

    Public CaseOption As String = "123"
    Protected Sub setinitialRow()
        Dim dtData As New DataTable()
        Dim dr As DataRow
        Dim dsData As New DataSet()
        dtData.Columns.Add(New DataColumn("IDD"))
        ' dtData.Columns.Add(New DataColumn("date"))
        dtData.Columns.Add(New DataColumn("kima"))
        dtData.Columns.Add(New DataColumn("wasf"))
        dtData.Columns.Add(New DataColumn("etype"))
        dtData.Columns.Add(New DataColumn("operation"))
        dtData.Columns.Add(New DataColumn("notes"))
        ' dsData.Tables.Add(dtData)
        'dtData = Nothing
        For i = 1 To 15
            dr = dtData.NewRow()
            dr("IDD") = i
            '    dr("date") = String.Empty
            dr("kima") = String.Empty
            dr("wasf") = String.Empty
            dr("etype") = "نقداً"
            dr("operation") = String.Empty
            dr("notes") = String.Empty
            dtData.Rows.Add(dr)
            ' Return dsData
        Next i
        ViewState("currentTable") = dtData
        GridViewAdd.DataSource = dtData
        GridViewAdd.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DropDownListYear.SelectedValue = DateTime.Now.ToString("yyyy")
            DropDownListMonth.SelectedValue = DateTime.Now.ToString("MM")
        End If
    End Sub
    Protected Sub AddNewRowToGrid()
        Dim rowIndex As Int32 = 0
        Dim rowNo As Int32 = 1
        CaseOption = (CStr(Session("CaseOption")))
        If (ViewState("currentTable") IsNot Nothing) Then
            Dim dtCurrentTable As DataTable = ViewState("currentTable")

            Dim drCurrentRow As DataRow '= Nothing
            If (dtCurrentTable.Rows.Count > 0) Then
                Dim c As Int32 = (dtCurrentTable.Rows.Count)
                For i As Int32 = 0 To (GridViewAdd.Rows.Count - 1) Step 1
                    Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                    Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                    Dim ddlitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbetype")
                    Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("TextBox4")
                    Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox5")

                    dtCurrentTable.Rows(i)("kima") = txtboxkima.Text
                    dtCurrentTable.Rows(i)("wasf") = txtboxwasf.Text
                    dtCurrentTable.Rows(i)("etype") = ddlitem.SelectedItem.Text
                    dtCurrentTable.Rows(i)("operation") = txtboxoperation.Text
                    dtCurrentTable.Rows(i)("notes") = txtboxnotes.Text
                    rowIndex = rowIndex + 1
                    rowNo = rowNo + 1

                Next
                drCurrentRow = dtCurrentTable.NewRow()

                drCurrentRow("IDD") = rowNo
                drCurrentRow("kima") = String.Empty
                drCurrentRow("wasf") = String.Empty
                drCurrentRow("etype") = "نقداً"
                drCurrentRow("operation") = String.Empty
                drCurrentRow("notes") = String.Empty
                dtCurrentTable.Rows.Add(drCurrentRow)

                ViewState("currentTable") = dtCurrentTable

                GridViewAdd.DataSource = dtCurrentTable
                GridViewAdd.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If
        SetPreviousData()
    End Sub

    Public Sub SetPreviousData()
        Dim rowIndex As Int32 = 0
        If (ViewState("currentTable") IsNot Nothing) Then
            Dim dt As DataTable = ViewState("currentTable")
            If (dt.Rows.Count > 0) Then
                Dim i As Int32 = 0
                Do While i < (dt.Rows.Count)
                    Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                    Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                    Dim ddletype As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbetype")
                    Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("TextBox4")
                    Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox5")
                    If (i < dt.Rows.Count - 1) Then
                        txtboxkima.Text = dt.Rows(i)("kima").ToString()
                        txtboxwasf.Text = dt.Rows(i)("wasf").ToString()
                        ddletype.SelectedValue = dt.Rows(i)("etype").ToString()
                        txtboxoperation.Text = dt.Rows(i)("operation").ToString()
                        txtboxnotes.Text = dt.Rows(i)("notes").ToString()
                    End If
                    rowIndex = rowIndex + 1
                    i = i + 1
                Loop
            End If
        End If
    End Sub
    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AddNewRowToGrid()
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        dateTxtBox.Text = Calendar1.SelectedDate
        btnClearDate.Enabled = True
        DropDownListYear.SelectedValue = Calendar1.SelectedDate.Year
        DropDownListMonth.SelectedValue = Calendar1.SelectedDate.ToString("MM")
    End Sub
    Protected Sub dateTxtBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateTxtBox.TextChanged
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (GridViewAdd.Rows.Count > 0) Then
            Dim i As Int32 = 0
            Dim rIndex As Int32 = 0
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
            Dim sqlConnection As New OleDbConnection(connectionString)
            sqlConnection.Open()
            CaseOption = (CStr(Session("CaseOption")))
            If CaseOption = "e" Then
                Dim sqlString As String = ""
                sqlString = " DELETE * FROM eradata where date =? "
                Dim sqlECommand As New OleDbCommand(sqlString, sqlConnection)
                sqlECommand.Parameters.AddWithValue("?", dateTxtBox.Text.ToString)
                Dim dataAd As OleDbDataAdapter = New OleDbDataAdapter
                dataAd.DeleteCommand = sqlECommand
                dataAd.DeleteCommand.ExecuteNonQuery()
            End If

            Do While i < (GridViewAdd.Rows.Count)
                If CType(GridViewAdd.Rows(rIndex).Cells(1).FindControl("TextBox2"), TextBox).Text <> Nothing Then

                    Dim sqlCommand As New OleDbCommand(connectionString, sqlConnection)
                    Dim mdate As Date = dateTxtBox.Text
                    Dim mKima As String = CType(GridViewAdd.Rows(rIndex).Cells(1).FindControl("TextBox2"), TextBox).Text
                    Dim mwasf As String = CType(GridViewAdd.Rows(rIndex).Cells(2).FindControl("TextBox3"), TextBox).Text
                    Dim metype As String = CType(GridViewAdd.Rows(rIndex).Cells(3).FindControl("cmbetype"), DropDownList).Text
                    Dim moperation As String = CType(GridViewAdd.Rows(rIndex).Cells(4).FindControl("TextBox4"), TextBox).Text
                    Dim mNotes As String = CType(GridViewAdd.Rows(rIndex).Cells(5).FindControl("TextBox5"), TextBox).Text
                    sqlCommand.Parameters.Clear()
                    sqlCommand.CommandText = "INSERT INTO [eradata] ( [date], [kima], [wasf], [etype], [operation], [notes]) VALUES (?,  ?, ?, ?, ?, ?)"
                    sqlCommand.Parameters.AddWithValue("?", mdate)
                    sqlCommand.Parameters.AddWithValue("?", mKima)
                    sqlCommand.Parameters.AddWithValue("?", mwasf)
                    sqlCommand.Parameters.AddWithValue("?", metype)
                    sqlCommand.Parameters.AddWithValue("?", moperation)
                    sqlCommand.Parameters.AddWithValue("?", mNotes)
                    sqlCommand.ExecuteNonQuery()
                    ' sqlConnection.Close()
                End If
                rIndex = rIndex + 1
                i = i + 1
            Loop
            sqlConnection.Close()
        Else
            Label11.Text = "no record to save.."
        End If
    End Sub

    Protected Sub GridViewAdd_Cancel(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridViewAdd.RowCancelingEdit
        Dim inx As Integer = e.RowIndex ' ******System.Web.UI.WebControls.GridViewEditEventArgs
        If (ViewState("currentTable") IsNot Nothing) Then
            Dim dt As DataTable = ViewState("currentTable")
            GridViewAdd.EditIndex = -1
            GridViewAdd.DataSource = dt '("date")
            GridViewAdd.DataBind()
        End If
    End Sub
    Protected Sub GridViewAdd_Edit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridViewAdd.RowEditing
        GridViewAdd.EditIndex = e.NewEditIndex
        GridViewAdd.DataBind()
    End Sub
    Protected Sub btnCalender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalender0.Click
        Panel1.Visible = True
        'dateTxtBox.Text = Calendar1.SelectedDate
        Calendar1.VisibleDate = Calendar1.SelectedDate
        Calendar1.Visible = True
    End Sub
    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
    End Sub
    Protected Sub btnClearDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearDate.Click
        dateTxtBox.Text = Nothing
        Calendar1.SelectedDate = Nothing
    End Sub
    Protected Sub btnHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHide.Click
        Panel1.Visible = False
        Calendar1.Visible = False
    End Sub
    Protected Sub btnAddNewDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNewDay.Click
        CaseOption = "a"
        Session("CaseOption") = CaseOption
        lblTitle.Text = " بيانات تاريخ جديد "
        lblTitle.BackColor = Drawing.Color.GreenYellow
        dateTxtBox.Text = ""
        btnCalender0.Visible = True
    End Sub
    Protected Sub btnModifyDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifyDay.Click
        CaseOption = "e"
        Session("CaseOption") = CaseOption
        lblTitle.Text = " تعديل يوم سابق "
        lblTitle.BackColor = Drawing.Color.Yellow
        dateTxtBox.Text = ""
        btnCalender0.Visible = True
    End Sub
    Protected Sub btnRemoveDay0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveDay0.Click
        CaseOption = "d"
        Session("CaseOption") = CaseOption
        lblTitle.Text = "  ألغاء يوم سابق "
        lblTitle.BackColor = Drawing.Color.MediumVioletRed
        dateTxtBox.Text = ""
        btnCalender0.Visible = True
    End Sub
    Protected Sub TextBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Label11.Text = "date entered"
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Label11.Text = dateTxtBox.Text
        Dim sqlString As String = ""
        Dim DateText As String
        DateText = dateTxtBox.Text
        Calendar1.SelectedDate = Nothing
        CaseOption = (CStr(Session("CaseOption")))
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT * FROM eradata where date =? " '& dateTxtBox.Text.ToString
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlCommand.Parameters.AddWithValue("?", dateTxtBox.Text.ToString)
        sqlConnection.Open()
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)

        Select Case CaseOption
            Case Is = "a"
                If dataReader.HasRows Then
                    Label11.Text = "هذا التاريخ سبق أدخالة ..أعد المحاولة!" & dateTxtBox.Text
                    dateTxtBox.Text = ""
                Else
                    Label11.Text = "تاريخ جديد.." & DateText
                    setinitialRow()
                    GridViewAdd.Rows(0).Cells(1).Focus()
                    Panel2.Visible = True
                    btnSave.Visible = True
                    btnPrint.Visible = True

                    btnTotal0.Visible = True
                    lblSum.Visible = True
                    lblSumV.Visible = True
                    lblCount.Visible = True
                    lblCountV.Visible = True
                End If
            Case Is = "e"
                If dataReader.HasRows Then
                    Label11.Text = dateTxtBox.Text & "هذا التاريخ سبق أدخالة .. "
                    Dim dtData As New DataTable()
                    Dim dr As DataRow
                    Dim rowIndex As Int32 = 0
                    Panel2.Visible = True
                    btnSave.Visible = True
                    btnPrint.Visible = True

                    btnTotal0.Visible = True
                    lblSum.Visible = True
                    lblSumV.Visible = True
                    lblCount.Visible = True
                    lblCountV.Visible = True

                    GridViewAdd.DataSource = dataReader
                    GridViewAdd.DataBind()
                    GridViewAdd.Rows(0).Cells(1).Focus()

                    Dim xx As Int32 = GridViewAdd.Rows.Count

                    dtData.Columns.Add(New DataColumn("IDD"))
                    dtData.Columns.Add(New DataColumn("kima"))
                    dtData.Columns.Add(New DataColumn("wasf"))
                    dtData.Columns.Add(New DataColumn("etype"))
                    dtData.Columns.Add(New DataColumn("operation"))
                    dtData.Columns.Add(New DataColumn("notes"))

                    For i = 1 To xx
                        dr = dtData.NewRow()
                        dr("IDD") = i
                        '    dr("date") = String.Empty
                        dr("kima") = String.Empty
                        dr("wasf") = String.Empty
                        dr("etype") = "نقداً"
                        dr("operation") = String.Empty
                        dr("notes") = String.Empty
                        dtData.Rows.Add(dr)
                    Next i

                    For i As Int32 = 0 To (GridViewAdd.Rows.Count - 1) Step 1
                        Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                        Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                        Dim ddlitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbetype")
                        Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("TextBox4")
                        Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox5")

                        dtData.Rows(i)("kima") = txtboxkima.Text
                        dtData.Rows(i)("wasf") = txtboxwasf.Text
                        dtData.Rows(i)("etype") = ddlitem.SelectedItem.Text
                        dtData.Rows(i)("operation") = txtboxoperation.Text
                        dtData.Rows(i)("notes") = txtboxnotes.Text
                    Next
                    ViewState("currentTable") = dtData
                    xx = dtData.Rows.Count 'GridViewAdd.Rows.Count
                Else
                    Label11.Text = "تاريخ جديد..أعد المحاولة!" & dateTxtBox.Text
                    dateTxtBox.Text = ""
                End If

            Case Is = "d"
                If dataReader.HasRows Then
                    Label11.Text = "هذا التاريخ سبق أدخالة ..أضغط حذف" & dateTxtBox.Text
                    GridViewAdd.DataSource = dataReader
                    GridViewAdd.DataBind()
                    GridViewAdd.Enabled = False
                    Panel2.Visible = True
                    btnPrint.Visible = True
                    ButtonDel.Visible = True
                Else
                    Label11.Text = "تاريخ جديد..أعد المحاولة!" & dateTxtBox.Text
                    dateTxtBox.Text = ""
                End If
                sqlConnection.Close()
        End Select
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonDel.Click
        If MsgBox("هل ترغب فى خذف اليوم؟", 528387, "رسالة تأكيد") = 6 Then
            Label11.Text = ""
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
            Dim sqlConnection As New OleDbConnection(connectionString)
            Dim sqlString As String = ""
            sqlString = " DELETE * FROM eradata where date =? "
            Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
            sqlCommand.Parameters.AddWithValue("?", dateTxtBox.Text.ToString)
            sqlConnection.Open()
            Dim dataAd As OleDbDataAdapter = New OleDbDataAdapter
            dataAd.DeleteCommand = sqlCommand
            dataAd.DeleteCommand.ExecuteNonQuery()
            sqlConnection.Close()
            Label11.Text = "تم الغاء اليوم .."
        End If
    End Sub

    Protected Sub GridViewAdd_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridViewAdd.RowDeleting
        Dim rIndx As New Int32
        rIndx = e.RowIndex 'GridViewAdd.SelectedIndex + 1
        GridViewAdd.DeleteRow(rIndx)
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        GridViewAdd.PagerSettings.Visible = True
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridViewAdd.RenderControl(hw)
        Dim gridHTML As String = sw.ToString().Replace("""", "'") _
           .Replace(System.Environment.NewLine, "")
        Dim sb As New StringBuilder()
        sb.Append("<body dir='rtl'>")
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload = new function(){")
        sb.Append("var printWin = window.open('', '', 'left=0")
        sb.Append(",top=50,width=1000,height=1200,status=0');")
        sb.Append("printWin.document.write(""")
        sb.Append(gridHTML)
        sb.Append(DateTime.Now())
        sb.Append("\n")
        sb.Append("تفرير"");")
        sb.Append("printWin.document.close();")
        sb.Append("printWin.focus();")
        sb.Append("printWin.print();")
        sb.Append("printWin.close();};")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(), "GridPrint", sb.ToString())
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
        ' Do NOT call MyBase.VerifyRenderingInServerForm
    End Sub
    Protected Sub DropDownListYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListYear.SelectedIndexChanged
        Dim year As Int32 = Convert.ToInt32(DropDownListYear.SelectedValue)
        Dim month As Int32 = Convert.ToInt32(DropDownListMonth.SelectedValue)
        Calendar1.VisibleDate = New DateTime(year, month, 1)
        Calendar1.SelectedDate = New DateTime(year, month, 1)
    End Sub
    Protected Sub DropDownListMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListMonth.SelectedIndexChanged
        Dim year As Int32 = Convert.ToInt32(DropDownListYear.SelectedValue)
        Dim month As Int32 = Convert.ToInt32(DropDownListMonth.SelectedValue)
        Calendar1.VisibleDate = New DateTime(year, month, 1)
        Calendar1.SelectedDate = New DateTime(year, month, 1)
    End Sub
    Protected Sub btnTotal_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTotal0.Click
        GridViewAdd.EditIndex = -1
        If GridViewAdd.Rows.Count > 0 Then
            Dim tot As New Decimal
            Dim i As Int32
            For i = 0 To GridViewAdd.Rows.Count - 1
                ' tot = tot + Convert.ToInt32(GridViewAdd.Rows(i).Cells(1).Text)
                If CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text <> "" Then
                    tot = tot + CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text
                End If
            Next
            lblSumV.Text = tot.ToString()
            GridViewAdd.FooterRow.Cells(1).Text = tot.ToString()
            lblCountV.Text = GridViewAdd.Rows.Count()
        End If

    End Sub
End Class

