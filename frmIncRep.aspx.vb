Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Drawing
'Imports System.Windows.Forms.KeyEventArgs
'Imports System.Windows.Forms.Keys
'Partial Class frmBasicData

Class Default2

    Inherits System.Web.UI.Page
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub

    Dim s1 As String = ""

    Dim txtBand As String = ""
    Dim SortEx As String = ""

    ' Dim s1 As String = CType(Session.Item("s1"), String)

    Function GetManData(ByVal sortBy As String) As System.Data.OleDb.OleDbDataReader
        Dim sqlString As String = ""

        ' Dim s1 As String = ""
        'Dim txtSearch As New TextBox
        'txtSearch.Text = "حاتم"
        '        Dim cn As New OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=" & Server.MapPath("app_data\Man.accdb"))
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\webTest\salary.accdb"
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        'Dim cmdAds As New OleDbCommand("SELECT count(`ad_id`) FROM `tbl_ads` WHERE `ad_isPrivate` = 1", Conn)
        '   tt = "kima"
        Select Case DropDownList1.SelectedIndex
            Case Is = 1
                sqlString = " SELECT * FROM eradata where date >= txtSearch.Text.ToString and date <= txtSearchD.Text.ToString" & " ORDER By " & sortBy
                '  sqlString = " SELECT * FROM eradata where date >= ? and date <= @ ORDER By " & sortBy
                txtBand = " التاريخ من = " & txtSearch.Text.ToString & " إلى " & txtSearchD.Text.ToString
                '       s1 = "date=" & txtSearch.Text.ToString()
            Case Is = 2
                sqlString = " SELECT * FROM eradata where kima = txtSearch.Text.ToString"  '1000'' & txtSearch.Text.ToString & " ORDER By " & sortBy '?   ORDER By " & sortBy
                txtBand = " القيمة = " & txtSearch.Text.ToString
                '       s1 = "kima=" & txtSearch.Text.ToString
            Case Is = 3
                sqlString = " SELECT * FROM eradata where wasf = ?   ORDER By " & sortBy
                txtBand = " الوصف = " & txtSearch.Text.ToString
                '      s1 = "wasf=" & txtSearch.Text.ToString
            Case Is = 4
                sqlString = " SELECT * FROM eradata where eType=?   ORDER By " & sortBy
                txtBand = " نقداً/بشيك = " & txtSearch.Text.ToString
                '      s1 = "item=" & txtSearch.Text.ToString
            Case Is = 5
                sqlString = " SELECT * FROM eradata where operation =?  ORDER By " & sortBy
                txtBand = " العملية = " & txtSearch.Text.ToString
                s1 = "operation=" & "'" & txtSearch.Text.ToString & "'"
            Case Is = 6
                sqlString = " SELECT * FROM eradata where notes=?   ORDER By " & sortBy
                txtBand = " ملاحظات" & txtSearch.Text.ToString
                '     s1 = "notes=" & txtSearch.Text.ToString
        End Select
        ' Dim sqlString As String = " SELECT * FROM eradata ORDER By " & sortBy
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlCommand.Parameters.Clear()
        sqlCommand.Parameters.AddWithValue("?", txtSearch.Text.ToString)
        sqlCommand.Parameters.AddWithValue("@", txtSearchD.Text.ToString)
        sqlConnection.Open()
        'txtSearch1.Text = s1
        ' txtBand.ToString & txtSearch.Text.ToString
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
        lblSearch.Text = txtBand
        '  If MsgBox("هل ترغب فى حذف البند؟", 528387, "رسالة تأكيد") = 6 Then

        '  End If

        If dataReader.HasRows = False Then
            MsgBox("No Record Found !", 65536, "  ")
            ' txtSearch.Text = "no record"
        End If
        Return dataReader
        ' GridView1.DataBind()
    End Function
    Function GetManDataAdd(ByVal searchAdd As String, ByVal sortBy As String) As System.Data.OleDb.OleDbDataReader
        Dim sqlString As String = ""
        'Dim txtBand As String = ""
        'Label1.Text = s1
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT * FROM eradata where " & searchAdd & " ORDER By " & sortBy
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        'GridView1.DataSource = sqlConnection
        GridView1.DataBind()
        sqlConnection.Open()
        'txtSearch1.Text = searchAdd
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
        Return dataReader
        GridView1.DataBind()
        s1 = ""
        txtBand = ""

    End Function
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim control As Control = Nothing
        If (Not (GridView1.FooterRow) Is Nothing) Then
            control = GridView1.FooterRow
        Else
            control = GridView1.Controls(0).Controls(0)
        End If
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")

        Dim sqlConnection As New OleDbConnection(connectionString)
        Dim txtdate As New TextBox
        ' Dim mdate As DateTime
        'mdate.ToString("yyyy/mm/dd")

        '  mdate = CType(control.FindControl("txtdate"), TextBox).Text
        Dim mdate As Date = Date.ParseExact(CType(control.FindControl("txtdate"), TextBox).Text, "yyyy/MM/dd", Nothing)
        'Dim mdate As Date = Date.ParseExact(txtdate.Text, "yyyy/MM/dd", Nothing)
        'Dim mdate As DateTime = DateTime.ParseExact(txtdate.Text, , CultureInfo.InvariantCulture)
        Dim mKima As String = CType(control.FindControl("txtkima"), TextBox).Text
        'Dim mwasf As String = faridtxtbox.Text

        Dim mwasf As String = CType(control.FindControl("txtwasf"), TextBox).Text
        Dim meType As String = CType(control.FindControl("cmbeType0"), DropDownList).Text
        Dim moperation As String = CType(control.FindControl("txtoperation"), TextBox).Text
        Dim mNotes As String = CType(control.FindControl("txtnotes"), TextBox).Text
        'Dim mcolor As String = CType(control.FindControl("txtcolor"), TextBox).Text
        'Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim sqlCommand As New OleDbCommand(connectionString, sqlConnection)
        sqlCommand.Connection = sqlConnection
        sqlCommand.CommandType = CommandType.Text
        'InsertCommand = "INSERT INTO [eradata] ([ID],  [kima], [wasf], [item], [subitem], [operation], [sarf], [notes], [color]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        sqlCommand.CommandText = "INSERT INTO [eradata] (  [date], [kima], [wasf], [eType], [operation], [notes]) VALUES (?, ?, ?, ?, ?, ?)"
        'sqlCommand.Parameters.AddWithValue("?", ID)

        sqlCommand.Parameters.AddWithValue("?", mdate)
        sqlCommand.Parameters.AddWithValue("?", mKima)
        sqlCommand.Parameters.AddWithValue("?", mwasf)
        sqlCommand.Parameters.AddWithValue("?", meType)
        sqlCommand.Parameters.AddWithValue("?", moperation)
        sqlCommand.Parameters.AddWithValue("?", mNotes)
        'sqlCommand.Parameters.AddWithValue("?", mcolor)
        sqlConnection.Open()
        sqlCommand.ExecuteNonQuery()
        sqlConnection.Close()
        'Response.Redirect(Request.Url.AbsoluteUri)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Protected Sub PrintCurrentPage(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintCurrent.Click, btnPrintCurrent.Click
        lblRCount.Text = "عدد الصفوف =" & GridView1.Rows.Count
        GridView1.Columns(GridView1.Columns.Count() - 1).Visible = False
        GridView1.PagerSettings.Visible = True
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView1.RenderControl(hw)
        Dim gridHTML As String = sw.ToString().Replace("""", "'") _
           .Replace(System.Environment.NewLine, "")
        Dim sb As New StringBuilder()
        sb.Append("<body dir='rtl'>")
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload = new function(){")
        sb.Append("var printWin = window.open('', '', 'left=0")
        sb.Append(",top=50,width=1000,height=1200,status=0');")
        sb.Append("printWin.document.write(""")
        sb.Append(lblSearch.Text)
        sb.Append(gridHTML)
        sb.Append(DateTime.Now())
        sb.Append("\n")
        sb.Append(lblSearch.Text)
        sb.Append("تفرير"");")
        sb.Append("printWin.document.close();")
        sb.Append("printWin.focus();")
        sb.Append("printWin.print();")
        sb.Append("printWin.close();};")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.GetType(), "GridPrint", sb.ToString())
        'GridView1.AllowPaging = True

        'GridView1.PagerSettings.Visible = True
        'GridView1.DataBind()
        'End If
        'GridView1.Columns.RemoveAt(3)

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PanelCalendar.Visible = False
        ' Dim RadioBtnAdd As New RadioButton
        If IsPostBack Then
            s1 = (CStr(Session("s1")))
            txtBand = (CStr(Session("txtBand")))

            If RadioBtnAdd.Checked Then
                lblSearch.Text = txtBand
                GridView1.DataSource = GetManDataAdd(s1, "date")
                GridView1.AllowPaging = False
                GridView1.DataBind()
                RadioBtnAdd.Checked = False
            Else
                GridView1.DataSource = GetManData("date")
                GridView1.AllowPaging = False
                GridView1.DataBind()
            End If
            s1 = ""
            txtBand = ""

        End If
        lblRCount.Text = GridView1.Rows.Count
        lblSum.Text = "عدد السجلات"
        'GridView1.Columns(0).HeaderStyle.Width =  "5px"
        'GridView1.Columns(0).ControlStyle.Width = "5px"

        If GridView1.Rows.Count > 0 Then
            PanelCommand.Enabled = True
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex

    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Select Case DropDownList1.SelectedIndex
            Case Is = 1
                txtSearch.Visible = True

                btnCalender0.Visible = True
                btnCalender1.Visible = True
                txtSearchD.Visible = True
                PanelSupSearch.Visible = False
                PanelSearchCommand.Visible = True

            Case Is = 2
                txtSearch.Visible = True

                PanelCalendar.Visible = False
                btnCalender0.Visible = False
                btnCalender1.Visible = False
                txtSearchD.Visible = False
                PanelSupSearch.Visible = False
                PanelSearchCommand.Visible = True

            Case Is = 3
                txtSearch.Visible = True

                PanelCalendar.Visible = False
                btnCalender0.Visible = False
                btnCalender1.Visible = False
                txtSearchD.Visible = False
                PanelSupSearch.Visible = True
                PanelSearchCommand.Visible = True
            Case Is = 4
                txtSearch.Visible = True

                PanelCalendar.Visible = False
                btnCalender0.Visible = False
                btnCalender1.Visible = False
                txtSearchD.Visible = False
                PanelSupSearch.Visible = True
                PanelSearchCommand.Visible = True

            Case Is = 5
                txtSearch.Visible = True

                PanelCalendar.Visible = False
                btnCalender0.Visible = False
                btnCalender1.Visible = False
                txtSearchD.Visible = False
                PanelSupSearch.Visible = True
                PanelSearchCommand.Visible = True

            Case Is = 6
                txtSearch.Visible = True

                PanelCalendar.Visible = False
                btnCalender0.Visible = False
                btnCalender1.Visible = False
                txtSearchD.Visible = False
                PanelSupSearch.Visible = True
                PanelSearchCommand.Visible = True
        End Select
        '  btnSearch.Visible = True
        '   btnSubmit.Visible = True
        txtSearch.Focus()
        txtSearch.Text = ""
        ' btnSearchX.Visible = True
        'btnSearchAdd.Visible = True
    End Sub

    Protected Sub btnSearchAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchAdd.Click
        If IsPostBack Then
            RadioBtnAdd.Checked = True
            s1 = CStr(Session("s1")) & " and "
            txtBand = CStr(Session("txtBand")) & " و "
            Session("s1") = s1
            Session("txtBand") = txtBand
            lblSearch.Text = txtBand.ToString
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        PanelCalendar.Visible = False
        btnCalender0.Visible = False
        btnCalender1.Visible = False
        txtSearchD.Visible = False
        If IsPostBack Then
            s1 = (CStr(Session("s1")))
            txtBand = (CStr(Session("txtBand")))

            Select Case DropDownList1.SelectedIndex
                Case Is = 1
                    txtSearchD.Visible = True
                    s1 = s1 + " Date >= #" & txtSearch.Text.ToString & "#" & " and date <= #" & txtSearchD.Text.ToString & "#"
                    txtBand = txtBand + "التاريخ " & " من " & txtSearch.Text.ToString & " إلى " & txtSearchD.Text.ToString
                Case Is = 2
                    s1 = s1 + "kima=" & "'" & txtSearch.Text.ToString & "'"
                    txtBand = txtBand + "القيمة " & "'" & txtSearch.Text.ToString & "'"
                Case Is = 3
                    s1 = s1 + "wasf=" & "'" & txtSearch.Text.ToString & "'"
                    txtBand = txtBand + "الوصف " & "'" & txtSearch.Text.ToString & "'"
                Case Is = 4
                    s1 = s1 + "eType=" & "'" & txtSearch.Text.ToString & "'"
                    txtBand = txtBand + " نقداً/بشيك " & "'" & txtSearch.Text.ToString & "'"
                Case Is = 5
                    s1 = s1 + "operation=" & "'" & txtSearch.Text.ToString & "'"
                    txtBand = txtBand + "العملية " & "'" & txtSearch.Text.ToString & "'"
                Case Is = 6
                    s1 = s1 + "notes=" & "'" & txtSearch.Text.ToString & "'"
                    txtBand = txtBand + "ملاحظات " & "'" & txtSearch.Text.ToString & "'"
            End Select
            lblSearch.Text = txtBand
            Session("s1") = s1
            Session("txtBand") = txtBand
        End If

    End Sub

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        txtSearch.Focus()
        '        Session("s1") = ""
        '  Dim s1 As String = CType(Session.Item("s1"), String)

    End Sub
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        SortEx = Session(SortEx)
        s1 = (CStr(Session("s1")))

        If RadioBtnAdd.Checked Then
            GridView1.DataSource = GetManDataAdd(s1, SortEx)
            GridView1.DataBind()
        Else
            GridView1.DataSource = GetManData(SortEx)
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        SortEx = Session(SortEx)
        s1 = (CStr(Session("s1")))
        GridView1.EditIndex = e.NewEditIndex

        If RadioBtnAdd.Checked Then
            GridView1.DataSource = GetManDataAdd(s1, SortEx)
            GridView1.DataBind()
        Else
            GridView1.DataSource = GetManData(SortEx)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub GridView1_Update(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb"))
        Dim gvRow As GridViewRow
        gvRow = GridView1.Rows(e.RowIndex)
        Dim cmd As New OleDbCommand("UPDATE [eradata] SET [date] = ?, [kima] = ?, [wasf] = ?, [eType] = ?,  [operation] = ?, [notes] = ? WHERE [IDD] =?", cn)
        ' mId = DirectCast(gvRow.Cells(0).Controls(0), TextBox).Text
        cmd.Parameters.Clear()
        '     lblRCount.Text = DirectCast(gvRow.Cells(3).Controls(0), TextBox).Text
        cmd.Parameters.AddWithValue("date", Convert.ToDateTime(DirectCast(gvRow.Cells(1).Controls(0), TextBox).Text))
        cmd.Parameters.AddWithValue("kima", DirectCast(gvRow.Cells(2).Controls(0), TextBox).Text)
        cmd.Parameters.AddWithValue("wasf", DirectCast(gvRow.Cells(3).Controls(0), TextBox).Text)
        cmd.Parameters.AddWithValue("eType", DirectCast(gvRow.Cells(4).Controls(0), TextBox).Text)
        cmd.Parameters.AddWithValue("operation", DirectCast(gvRow.Cells(6).Controls(0), TextBox).Text)
        cmd.Parameters.AddWithValue("notes", DirectCast(gvRow.Cells(8).Controls(0), TextBox).Text)
        cmd.Parameters.AddWithValue("IDD", GridView1.Rows(e.RowIndex).Cells(0).Text)
        ' cmd.Parameters.AddWithValue("ID", DirectCast(gvRow.Cells(0).Controls(0), TextBox).Text)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        cmd.Dispose()
        cn.Dispose()
        GridView1.EditIndex = -1
        SortEx = Session(SortEx)
        s1 = (CStr(Session("s1")))

        If RadioBtnAdd.Checked Then
            GridView1.DataSource = GetManDataAdd(s1, SortEx)
            GridView1.DataBind()
        Else
            GridView1.DataSource = GetManData(SortEx)
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub btnTotal_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTotal0.Click
        GridView1.EditIndex = -1
        If GridView1.Rows.Count > 0 Then
            Dim tot As New Decimal
            Dim i As Integer
            For i = 0 To GridView1.Rows.Count - 1
                tot = tot + Convert.ToDecimal(GridView1.Rows(i).Cells(2).Text)
            Next
            lblSum.Text = tot.ToString()
            GridView1.FooterRow.Cells(2).Text = tot.ToString()
        End If
    End Sub
    Protected Sub btnToExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            'To Export all pages
            GridView1.AllowPaging = False
            GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next
            For Each row As GridViewRow In GridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    'cell.CssClass = "textmode"
                Next
            Next
            'GridView1.FooterRow.Visible = False
            GridView1.Columns(0).Visible = False
            GridView1.Columns(GridView1.Columns.Count() - 1).Visible = False
            ' GridView1.Columns(GridView1.Columns.Count() - 2).Visible = False
            '  GridView1.Columns(GridView1.Columns.Count() - 11).Visible = False
            GridView1.RenderControl(hw)
            'style to format numbers to string
            Dim style As String = "<style> .textmode { } </style>"
            Response.Write(style)
            Response.Output.Write(lblSearch.Text + "<br/>")
            Response.Output.Write("عدد السطور : ")
            Response.Output.Write(lblRCount.Text)
            Response.Output.Write(sw.ToString())
            Response.Output.Write("التوقيت :")
            Response.Output.Write(DateTime.Now())
            Response.Flush()
            Response.[End]()
        End Using
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        ' Dim rowIndx As New Int32
        Dim gvRow As GridViewRow
        gvRow = GridView1.Rows(e.RowIndex)
        'rowIndx = e.RowIndex 'GridViewAdd.SelectedIndex + 1
        Dim gcount As String

        '  GridView1.DeleteRow(rowIndx)
        '  GridView1.DataBind()
        ' Label1.Text = ""
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        If MsgBox("هل ترغب فى خذف البند؟", 1576963, "رسالة تأكيد") = 6 Then ' 528387  
            Dim sqlConnection As New OleDbConnection(connectionString)
            ' GridView1.Columns(0).Visible = True
            '  GridView1.Rows(e.RowIndex).Cells(0).Visible = True
            gcount = GridView1.Rows(e.RowIndex).Cells(0).Text
            Dim sqlString As String = ""
            sqlString = " DELETE * FROM eradata  WHERE IDD  =" & gcount
            Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
            sqlConnection.Open()
            Dim dataAd As OleDbDataAdapter = New OleDbDataAdapter
            dataAd.DeleteCommand = sqlCommand
            dataAd.DeleteCommand.ExecuteNonQuery()
            sqlConnection.Close()
            gvRow.ForeColor = Color.Red
        End If
    End Sub

    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        txtSearch.AutoPostBack = True
        '        txtSearchD.Text = txtSearch.Text
    End Sub
    Protected Sub ButtonGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGroup.Click
        Dim sqlString As String = ""
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        Select Case DropDownList1.SelectedIndex
            Case Is = 3
                sqlString = " SELECT count(IDD), wasf FROM eradata where wasf like ? GROUP BY " & " wasf" & " order by " & " wasf"
                DropDownListGroup.DataTextField = "wasf"
                DropDownListGroup.DataValueField = "wasf"
            Case Is = 4
                sqlString = " SELECT  count(IDD) ,  eType FROM eradata where eType like? GROUP BY " & "eType" & " order by " & " eType"
                DropDownListGroup.DataTextField = "eType"
                DropDownListGroup.DataValueField = "eType"
            Case Is = 5
                sqlString = " SELECT  count(IDD) ,  operation FROM eradata where operation like? GROUP BY " & " operation" & " order by " & " operation"
                DropDownListGroup.DataTextField = "operation"
                DropDownListGroup.DataValueField = "operation"
            Case Is = 6
                sqlString = " SELECT  count(IDD) ,  notes FROM eradata where notes like? GROUP BY " & "notes" & " order by " & " notes"
                DropDownListGroup.DataTextField = "notes"
                DropDownListGroup.DataValueField = "notes"
        End Select
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlCommand.Parameters.Clear()
        sqlCommand.Parameters.AddWithValue("?", "%" + txtSearch.Text.ToString + "%")

        '  sqlCommand.Parameters.AddWithValue("?", txtSearch.Text.ToString)
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

    Protected Sub btnCalender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalender0.Click
        RadioButtonDate.Checked = True
        PanelCalendar.Visible = True
        'dateTxtBox.Text = Calendar1.SelectedDate
        Calendar1.VisibleDate = Calendar1.SelectedDate
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        If RadioButtonDate.Checked = True Then
            txtSearch.Text = Calendar1.SelectedDate
            'Calendar1.Visible = False
            btnClearDate.Enabled = True
        ElseIf RadioButtonDate.Checked = False Then
            txtSearchD.Text = Calendar1.SelectedDate
            'Calendar1.Visible = False
            btnClearDate.Enabled = True
        End If
        DropDownListYear.SelectedValue = Calendar1.SelectedDate.Year
        DropDownListMonth.SelectedValue = Calendar1.SelectedDate.ToString("MM")
    End Sub

    Protected Sub btnCalender1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalender1.Click
        RadioButtonDate.Checked = False
        txtSearchD.Text = Calendar1.SelectedDate
        'Calendar1.Visible = False
        btnClearDate.Enabled = True
    End Sub

    Protected Sub btnHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHide.Click
        PanelCalendar.Visible = False
        Calendar1.Visible = False
    End Sub

    Protected Sub btnClearDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearDate.Click
        txtSearch.Text = Nothing
        Calendar1.SelectedDate = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim s1 As String = ""
        Dim txtBand As String = ""
        '   If Not Page.IsPostBack Then

        DropDownListYear.SelectedValue = DateTime.Now.ToString("yyyy")
        DropDownListMonth.SelectedValue = DateTime.Now.ToString("MM")
        '    End If
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting

        s1 = (CStr(Session("s1")))
        Session(SortEx) = e.SortExpression
        If RadioBtnAdd.Checked Then
            GridView1.DataSource = GetManDataAdd(s1, e.SortExpression)
            GridView1.DataBind()
        Else
            GridView1.DataSource = GetManData(e.SortExpression)
            GridView1.DataBind()
        End If

    End Sub
End Class
