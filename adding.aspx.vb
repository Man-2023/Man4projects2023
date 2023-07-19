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
        dtData.Columns.Add(New DataColumn("ID"))
        ' dtData.Columns.Add(New DataColumn("date"))
        dtData.Columns.Add(New DataColumn("kima"))
        dtData.Columns.Add(New DataColumn("wasf"))
        dtData.Columns.Add(New DataColumn("item"))
        dtData.Columns.Add(New DataColumn("subitem"))
        dtData.Columns.Add(New DataColumn("operation"))
        dtData.Columns.Add(New DataColumn("sarf"))
        dtData.Columns.Add(New DataColumn("notes"))
        ' dsData.Tables.Add(dtData)
        'dtData = Nothing
        For i = 1 To 15
            dr = dtData.NewRow()
            dr("ID") = i
            '    dr("date") = String.Empty
            dr("kima") = String.Empty
            dr("wasf") = String.Empty
            dr("item") = "خرسانة"
            dr("subitem") = "خامات"
            dr("operation") = String.Empty
            dr("sarf") = "حسام"
            dr("notes") = String.Empty
            dtData.Rows.Add(dr)
            ' Return dsData
        Next i
        ViewState("currentTable") = dtData
        GridViewAdd.DataSource = dtData
        GridViewAdd.DataBind()
        'Dim ddlitem As DropDownList = GridViewAdd.Rows(0).Cells(4).FindControl("cmbitem")
        'Dim ddlsubitem As DropDownList = GridViewAdd.Rows(0).Cells(5).FindControl("cmbsubitem")
        'Dim ddlsarf As DropDownList = GridViewAdd.Rows(0).Cells(7).FindControl("cmbnewsarf")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DropDownListYear.SelectedValue = DateTime.Now.ToString("yyyy")
            DropDownListMonth.SelectedValue = DateTime.Now.ToString("MM")
        End If
        ' If Not Page.IsPostBack Then
        'dateTxtBox.Focus()
        ' GridViewAdd.Rows(0).Cells(1).FindControl("TextBox1").Focus()
        'Calendar1.Visible = True

        ' End If
    End Sub
    Protected Sub AddNewRowToGrid()
        Dim rowIndex As Int32 = 0
        Dim rowNo As Int32 = 1
        CaseOption = (CStr(Session("CaseOption")))
        If (ViewState("currentTable") IsNot Nothing) Then
            Dim dtCurrentTable As DataTable = ViewState("currentTable")
            Dim xx As Int32 = dtCurrentTable.Rows.Count

            Dim drCurrentRow As DataRow '= Nothing
            If (dtCurrentTable.Rows.Count > 0) Then
                Dim c As Int32 = (dtCurrentTable.Rows.Count)
                For i As Int32 = 0 To (GridViewAdd.Rows.Count - 1) Step 1
                    Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                    Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                    Dim ddlitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbitem")

                    Dim ddlsubitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("cmbsubitem")
                    Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox4")
                    Dim ddlsarf As DropDownList = GridViewAdd.Rows(rowIndex).Cells(6).FindControl("cmbnewsarf")
                    Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(7).FindControl("TextBox5")

                    dtCurrentTable.Rows(i)("kima") = txtboxkima.Text
                    dtCurrentTable.Rows(i)("wasf") = txtboxwasf.Text
                    dtCurrentTable.Rows(i)("item") = ddlitem.SelectedItem.Text
                    dtCurrentTable.Rows(i)("subitem") = ddlsubitem.SelectedItem.Text
                    dtCurrentTable.Rows(i)("operation") = txtboxoperation.Text
                    dtCurrentTable.Rows(i)("sarf") = ddlsarf.SelectedValue
                    dtCurrentTable.Rows(i)("notes") = txtboxnotes.Text
                    rowIndex = rowIndex + 1
                    rowNo = rowNo + 1

                Next
                drCurrentRow = dtCurrentTable.NewRow()

                drCurrentRow("ID") = rowNo
                drCurrentRow("kima") = String.Empty
                drCurrentRow("wasf") = String.Empty
                drCurrentRow("item") = "خرسانة"
                drCurrentRow("subitem") = "خامات"
                drCurrentRow("operation") = String.Empty
                drCurrentRow("sarf") = "حسام"
                drCurrentRow("notes") = String.Empty
                dtCurrentTable.Rows.Add(drCurrentRow)

                ' dtCurrentTable.Rows.Add(drCurrentRow)
                ViewState("currentTable") = dtCurrentTable

                GridViewAdd.DataSource = dtCurrentTable
                GridViewAdd.DataBind()
                ' ViewState("GridView") = GridViewAdd.DataSource
                ' Next
            End If
        Else
            Response.Write("ViewState is null")
        End If
        SetPreviousData()
        'Label11.Text = GridViewAdd.Rows(0).Cells(0).ToString()
        'GridViewAdd.Rows(0).Cells(3).Text = "fariiiiid"
    End Sub

    Public Sub SetPreviousData()
        Dim rowIndex As Int32 = 0
        ' If (ViewState("CurrentTable") <> String.Empty) Then
        If (ViewState("currentTable") IsNot Nothing) Then
            Dim dt As DataTable = ViewState("currentTable")
            If (dt.Rows.Count > 0) Then
                Dim i As Int32 = 0
                ' Dim c As Int32 = (dt.Rows.Count)
                Do While i < (dt.Rows.Count)
                    'for (int i = 0; i &lt; dt.Rows.Count; i++)
                    '   Dim txtboxDate As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox1")
                    Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                    Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                    Dim ddlitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbItem")
                    Dim ddlsubitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("cmbSubItem")
                    Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox4")
                    Dim ddlsarf As DropDownList = GridViewAdd.Rows(rowIndex).Cells(6).FindControl("cmbNewSarf")
                    Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(7).FindControl("TextBox5")
                    If (i < dt.Rows.Count - 1) Then
                        '      txtboxDate.Text = dt.Rows(i)("date").ToString()
                        '  dt.Rows(i)("kima") = txtboxkima.Text
                        txtboxkima.Text = dt.Rows(i)("kima").ToString()
                        txtboxwasf.Text = dt.Rows(i)("wasf").ToString()
                        ' dt.Rows(i)("item") = 2 ' ddlitem.SelectedValue
                        'ddlitem.ClearSelection()
                        ' ddlitem.Items.FindByText(dt.Rows(i)("item").ToString()).Value = True ' .Selected = True
                        ddlitem.SelectedValue = dt.Rows(i)("item").ToString()
                        ddlsubitem.SelectedValue = dt.Rows(i)("subitem").ToString()
                        txtboxoperation.Text = dt.Rows(i)("operation").ToString()
                        ddlsarf.SelectedValue = dt.Rows(i)("sarf").ToString()
                        txtboxnotes.Text = dt.Rows(i)("notes").ToString()
                    End If
                    rowIndex = rowIndex + 1
                    i = i + 1
                Loop
            End If
            ' GridViewAdd.DataSource = dt
            '  GridViewAdd.DataBind()
        End If
    End Sub
    Protected Sub ButtonAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AddNewRowToGrid()
        'Calendar1.Visible = True
    End Sub
    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        btnSearch.Visible = True
        dateTxtBox.Visible = True
        Panel2.Visible = False
        GridViewAdd.Visible = False
        dateTxtBox.Text = Calendar1.SelectedDate
        'Calendar1.Visible = False
        btnClearDate.Enabled = True
        DropDownListYear.SelectedValue = Calendar1.SelectedDate.Year
        DropDownListMonth.SelectedValue = Calendar1.SelectedDate.ToString("MM")

    End Sub
    Protected Sub dateTxtBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateTxtBox.TextChanged
        'GridViewAdd.Rows(0).Cells(1)= (Calendar1.SelectedDate))
        '  Label11.Text = " تم ادخال تاريخ اليوم"
        '  GridViewAdd.Rows(0).Cells(1).Focus()

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (GridViewAdd.Rows.Count > 0) Then
            Dim i As Int32 = 0
            Dim rIndex As Int32 = 0

            'Dim TextBox1 As New TextBox
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
            Dim sqlConnection As New OleDbConnection(connectionString)
            sqlConnection.Open()

            CaseOption = (CStr(Session("CaseOption")))
            If CaseOption = "e" Then
                Dim sqlString As String = ""
                sqlString = " DELETE * FROM masrofat where date =? "
                Dim sqlECommand As New OleDbCommand(sqlString, sqlConnection)
                sqlECommand.Parameters.AddWithValue("?", dateTxtBox.Text.ToString)
                '   sqlConnection.Open()
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
                    Dim mitem As String = CType(GridViewAdd.Rows(rIndex).Cells(3).FindControl("cmbItem"), DropDownList).Text
                    Dim msubitem As String = CType(GridViewAdd.Rows(rIndex).Cells(4).FindControl("cmbSubItem"), DropDownList).Text
                    Dim moperation As String = CType(GridViewAdd.Rows(rIndex).Cells(5).FindControl("TextBox4"), TextBox).Text
                    Dim mSarf As String = CType(GridViewAdd.Rows(rIndex).Cells(6).FindControl("cmbNewSarf"), DropDownList).Text
                    Dim mNotes As String = CType(GridViewAdd.Rows(rIndex).Cells(7).FindControl("TextBox5"), TextBox).Text
                    sqlCommand.Parameters.Clear()
                    sqlCommand.CommandText = "INSERT INTO [masrofat] ( [date], [kima], [wasf], [item], [subitem], [operation], [sarf], [notes]) VALUES (?,  ?, ?, ?, ?, ?, ?, ?)"
                    sqlCommand.Parameters.AddWithValue("?", mdate)
                    sqlCommand.Parameters.AddWithValue("?", mKima)
                    sqlCommand.Parameters.AddWithValue("?", mwasf)
                    sqlCommand.Parameters.AddWithValue("?", mitem)
                    sqlCommand.Parameters.AddWithValue("?", msubitem)
                    sqlCommand.Parameters.AddWithValue("?", moperation)
                    sqlCommand.Parameters.AddWithValue("?", mSarf)
                    sqlCommand.Parameters.AddWithValue("?", mNotes)
                    ' sqlConnection.Open()
                    sqlCommand.ExecuteNonQuery()

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
        Label11.Text = ""
        CaseOption = "a"
        Session("CaseOption") = CaseOption
        lblTitle.Text = " بيانات تاريخ جديد "
        lblTitle.BackColor = Drawing.Color.GreenYellow
        dateTxtBox.Text = ""
        btnCalender0.Visible = True
    End Sub

    Protected Sub btnModifyDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModifyDay.Click
        Label11.Text = ""
        CaseOption = "e"
        Session("CaseOption") = CaseOption
        lblTitle.Text = " تعديل يوم سابق "
        lblTitle.BackColor = Drawing.Color.Yellow
        dateTxtBox.Text = ""
        btnCalender0.Visible = True
    End Sub
    Protected Sub btnRemoveDay0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveDay0.Click
        Label11.Text = ""
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
        Panel1.Visible = False
        Calendar1.Visible = False
        Label11.Text = dateTxtBox.Text
        'Label11.BackColor = Drawing.Color.Red
        Dim sqlString As String = ""
        Dim DateText As String
        DateText = dateTxtBox.Text
        Calendar1.SelectedDate = Nothing

        CaseOption = (CStr(Session("CaseOption")))
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT * FROM masrofat where date =? " '& dateTxtBox.Text.ToString
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
                    GridViewAdd.Visible = True
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
                    GridViewAdd.Visible = True

                    btnTotal0.Visible = True
                    lblSum.Visible = True
                    lblSumV.Visible = True
                    lblCount.Visible = True
                    lblCountV.Visible = True

                    GridViewAdd.DataSource = dataReader
                    GridViewAdd.DataBind()
                    GridViewAdd.Rows(0).Cells(1).Focus()

                    Dim xx As Int32 = GridViewAdd.Rows.Count


                    dtData.Columns.Add(New DataColumn("ID"))
                    dtData.Columns.Add(New DataColumn("kima"))
                    dtData.Columns.Add(New DataColumn("wasf"))
                    dtData.Columns.Add(New DataColumn("item"))
                    dtData.Columns.Add(New DataColumn("subitem"))
                    dtData.Columns.Add(New DataColumn("operation"))
                    dtData.Columns.Add(New DataColumn("sarf"))
                    dtData.Columns.Add(New DataColumn("notes"))

                    For i = 1 To xx
                        dr = dtData.NewRow()
                        dr("ID") = i
                        '    dr("date") = String.Empty
                        dr("kima") = String.Empty
                        dr("wasf") = String.Empty
                        dr("item") = "خرسانة"
                        dr("subitem") = "خامات"
                        dr("operation") = String.Empty
                        dr("sarf") = "حسام"
                        dr("notes") = String.Empty
                        dtData.Rows.Add(dr)
                        ' Return dsData
                    Next i

                    For i As Int32 = 0 To (GridViewAdd.Rows.Count - 1) Step 1
                        '          Dim txtboxDate As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox1")
                        Dim txtboxkima As TextBox = GridViewAdd.Rows(rowIndex).Cells(1).FindControl("TextBox2")
                        Dim txtboxwasf As TextBox = GridViewAdd.Rows(rowIndex).Cells(2).FindControl("TextBox3")
                        Dim ddlitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(3).FindControl("cmbitem")
                        Dim ddlsubitem As DropDownList = GridViewAdd.Rows(rowIndex).Cells(4).FindControl("cmbsubitem")
                        Dim txtboxoperation As TextBox = GridViewAdd.Rows(rowIndex).Cells(5).FindControl("TextBox4")
                        Dim ddlsarf As DropDownList = GridViewAdd.Rows(rowIndex).Cells(6).FindControl("cmbnewsarf")
                        Dim txtboxnotes As TextBox = GridViewAdd.Rows(rowIndex).Cells(7).FindControl("TextBox5")

                        dtData.Rows(i)("kima") = txtboxkima.Text
                        dtData.Rows(i)("wasf") = txtboxwasf.Text
                        dtData.Rows(i)("item") = ddlitem.SelectedItem.Text
                        dtData.Rows(i)("subitem") = ddlsubitem.SelectedItem.Text
                        dtData.Rows(i)("operation") = txtboxoperation.Text
                        dtData.Rows(i)("sarf") = ddlsarf.SelectedValue
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
                    GridViewAdd.Visible = True

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
            sqlString = " DELETE * FROM masrofat where date =? "
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
        ' GridViewAdd.DataBind()
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ' lblRCount.Text = "عدد الصفوف =" & GridViewAdd.Rows.Count
        '  GridViewAdd.Columns(GridViewAdd.Columns.Count() - 1).Visible = False
        '  GridViewAdd.Columns(GridViewAdd.Columns.Count() - 2).Visible = False
        '  GridViewAdd.Columns(GridViewAdd.Columns.Count() - 11).Visible = False
        GridViewAdd.PagerSettings.Visible = True
        '   GridViewAdd.Columns(GridViewAdd.Columns.Count() - 11).Visible = False

        '    GridViewAdd.Columns(GridViewAdd.Columns.Count() - 11).Visible = False
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

        '  GridViewAdd.Columns(GridViewAdd.Columns.Count() - 11).Visible = False
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
            Dim totx As String
            Dim tot As New Decimal
            Dim i As Integer
            totx = CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text

            For i = 0 To GridViewAdd.Rows.Count - 1
                ' tot = tot + Convert.ToDecimal(GridViewAdd.Rows(i).Cells(1).Text)
                If CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text <> "" Then
                    tot = tot + CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text
                End If

                'tot = tot + CType(GridViewAdd.Rows(i).Cells(1).FindControl("TextBox2"), TextBox).Text
            Next
            lblSumV.Text = tot.ToString()
            GridViewAdd.FooterRow.Cells(1).Text = tot.ToString()
            lblCountV.Text = GridViewAdd.Rows.Count()
        End If

    End Sub
End Class

