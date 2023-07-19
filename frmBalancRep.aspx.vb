Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Drawing

Class Default2

    Inherits System.Web.UI.Page
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Teradat As New Int32
        Teradat = 0
        Dim sqlString As String = ""
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Server.MapPath("app_data\Man.accdb")
        Dim sqlConnection As New OleDbConnection(connectionString)
        sqlString = " SELECT masrofat.operation, sum(masrofat.kima) as [Tmasrof],  (SELECT sum(eradata.kima)  FROM eradata   WHERE   operation= masrofat.operation )  AS Teradat, IIF(Teradat is null,0,Teradat) -  IIF(Tmasrof is null,0,Tmasrof)  as Bal FROM masrofat GROUP BY operation ORDER  BY operation"
        'sqlString = " SELECT masrofat.operation, sum(masrofat.kima) as [Tmasrof],  (SELECT sum(eradata.kima)  FROM eradata   WHERE   operation= masrofat.operation )  AS [Teradat] FROM masrofat GROUP BY operation ORDER  BY operation"
        Dim sqlCommand As New OleDbCommand(sqlString, sqlConnection)
        sqlConnection.Open()
        Dim dataReader As OleDbDataReader = sqlCommand.ExecuteReader(Data.CommandBehavior.CloseConnection)
        GridView1.DataSource = dataReader
        GridView1.DataBind()

        lblRCount.Text = GridView1.Rows.Count() & " عمــلية  "

        If GridView1.Rows.Count > 0 Then
            Dim totM As New Decimal
            Dim totE As New Decimal
            Dim totB As New Decimal
            Dim i As Integer
            For i = 0 To GridView1.Rows.Count - 1
                totE = totE + Val(GridView1.Rows(i).Cells(1).Text)
                totM = totM + Convert.ToDecimal(GridView1.Rows(i).Cells(2).Text)
                totB = totB + Convert.ToDecimal(GridView1.Rows(i).Cells(3).Text)
            Next
            GridView1.FooterRow.Cells(0).Text = " Totals "
            GridView1.FooterRow.Cells(1).Text = totE.ToString()
            GridView1.FooterRow.Cells(2).Text = totM.ToString()
            GridView1.FooterRow.Cells(3).Text = totB.ToString()
        End If
    End Sub

    Protected Sub PrintCurrentPage(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintCurrent.Click, btnPrintCurrent.Click
        '        lblRCount.Text = "عدد الصفوف =" & GridView1.Rows.Count
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
        ' sb.Append("تفرير"");")

        ' sb.Append(txt)
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
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex

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

    Private Function Parse(ByVal p1 As Object) As String
        Throw New NotImplementedException
    End Function

    Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub
End Class
