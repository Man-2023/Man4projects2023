<%@ Page Language="VB" AutoEventWireup="false" CodeFile="adding.aspx.vb" Inherits="adding" EnableEventValidation="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>شاشة الادخال</title>
   <style type="text/css">

    .WebContainer{
    width: 100%;
    height: auto;
}
.articles{
    width:90%; /*Takes 90% width from WebContainer*/
    height: auto;
    margin: auto;
}

body {
  background-color:   Silver;
}

@media only screen and (max-width: 600px) {
  body {
    background-color:  Aqua;
  }
} 

    <style type="text/css">
        .style2
        {
            width: 57px;
            height: 28px;
        }
        .style1
       {
           width: 33px;
       }
       .style2
       {
           width: 207px;
       }
    </style>
</head>
<body>
    <form id="form1"  runat="server" xml:lang="aa">
    <div align="center">
   &nbsp;<asp:Button ID="btnSave" runat="server" Text="حفظ" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:140px; width: 60px; height: 20px; right: 872px;" 
            Font-Size="9pt" Font-Names="Arabic Transparent" dir="rtl" Font-Bold="True" TabIndex="7" 
            Height="17px" Visible="False" />
   <asp:Button ID="btnExit" runat="server" Text="خروج" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:20px; width: 60px; height: 20px; bottom: 574px;" 
            Font-Size="9pt" Font-Names="Arabic Transparent" dir="rtl" Font-Bold="True" TabIndex="9" 
            PostBackUrl="Default.aspx" />  
    
   <asp:Button ID="btnPrint" runat="server" Text="طباعة" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:80px; width: 60px; height: 20px; " 
            Font-Size="9pt" Font-Names="Arabic Transparent" 
            dir="rtl" Font-Bold="True" TabIndex="8" 
            Visible="False" />
     <asp:Button ID="ButtonDel" runat="server" Text=" حذف " left = "10pt" 
            style="  z-index : 501;  POSITION:  absolute; TOP: 0px; left:200px; width: 60px; height: 20px; bottom: 574px;" 
            Font-Bold="True" Visible="False"  />

        <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#CC0000"
        style="  z-index : 501;  POSITION: absolute; TOP: 30px; left:20px;"></asp:Label> 

        <asp:Label ID="lblTitle" runat="server" BackColor="#FFCC66" 
            BorderStyle="Outset" Font-Bold="True" Font-Size="Large" ForeColor="#990033" 
            Text="أدخال البيانات" Width="200px"></asp:Label>
         
         <br />
         
            <asp:Button ID="btnTotal0" runat="server" Font-Bold="True" Font-Italic="False" 
                style="POSITION: absolute; TOP: 53px; left: 10px; height: 26px;" Width="140px"
                onclick="btnTotal_Click1" Text="تجميع" Visible="False" />

         <asp:Button ID="btnSearch" runat="server" Text="بحث" BackColor="#990033" 
            Font-Bold="True" Font-Size="Medium" ForeColor="White" 
            Font-Names="Simplified Arabic" Height="30px" Width="60px" 
            Visible="False" />
         
         <asp:TextBox ID="dateTxtBox" runat="server" Height="20px" dir="rtl"
                            Text='<%# Bind("date") %>' Width="100px" 
                            ontextchanged="dateTxtBox_TextChanged" Wrap="False" 
            Font-Bold="True" Font-Names="Simplified Arabic" Visible="False"></asp:TextBox>
            <asp:Button ID="btnCalender0" runat="server" 
     style="background:" BackColor="#6699FF" Height="30px" onclick="btnCalender_Click" Width="60px" 
            Font-Bold="True" Text=" اجندة" ToolTip="أظهار التقويم" 
            BorderColor="#FFCC00" Font-Size="Medium" Font-Names="Simplified Arabic" 
            Visible="False" ForeColor="White" />

<asp:Button ID="btnAddNewDay" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:90%; width: 6%; height: 20px;" 
            Font-Size="10pt" Font-Names="Arabic Transparent" dir="rtl" Font-Bold="True" runat="server" 
                Text=" يوم جديد"/>

            <asp:Button ID="btnModifyDay" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:84%; width: 6%; height: 20px;" 
            Font-Size="10pt" Font-Names="Arabic Transparent" dir="rtl" Font-Bold="True" runat="server" 
                Text=" تعديل يوم"/>

            <asp:Button ID="btnRemoveDay0" style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:78%; width: 6%; height: 20px; right: 613px;" 
            Font-Size="10pt" Font-Names="Arabic Transparent" dir="rtl" 
            Font-Bold="True" runat="server" 
                Text="الغاء يوم"/>
       
        </div>
 <div style =" height:30px; width: 649px;" dir="rtl" >
 <asp:Panel ID="Panel2" runat="server" Visible="False" 
         
         style="  z-index : 501;  POSITION: absolute; left:170px; top: 80px; width: 849px;">
 
    <table cellspacing="0" cellpadding = "0" rules="all" border="1" id="tblHeader"
        style="font-family:Arial;font-size:10pt; color: #FFFFFF;
        border-collapse:collapse;height:100%; font-weight: bolder;"  >
    <tr style="background-color: #3366FF">
       <td style ="width:41px;text-align:center" class="style1">م</td>
       <td style ="width:100px;text-align:center">القيمة</td>
       <td style ="width:115px;text-align:center">الوصف</td>
       <td style ="width:82px;text-align:center">البند</td>
       <td style ="width:101px;text-align:center">البند الفرعى</td>
       <td style ="width:84px;text-align:center">العملية</td>
       <td style ="width:103px;text-align:center">مسئول الصرف</td>
       <td style ="text-align:center" class="style2">ملاحظات</td>
    </tr>
    </table>
     </asp:Panel>   
</div>       
            <asp:Panel ID="Panel1"
        style="    POSITION: absolute; TOP: 220px; left:2%; width: 145px;  height: 230px; margin-right: 0px;" 
        runat="server" Visible="False" BorderStyle="Ridge">
                    <asp:Calendar id="Calendar1" 
                        style="  z-index : 501;  POSITION: absolute; TOP: 20px; left:5px; width: 139px; bottom: 30px;" runat="server" 
             BorderWidth="1px" DayNameFormat="FirstLetter" 
                ForeColor="Black" Height="50px" 
            Font-Size="10pt" Font-Names="Times New Roman" BorderColor="White" ShowGridLines="True" 
                BorderStyle="Solid" Font-Bold="True">
                        <OtherMonthDayStyle BackColor="#3399FF" ForeColor="White" />
                        <NextPrevStyle BackColor="#CC3300" Font-Bold="True" ForeColor="White" />
                        <DayHeaderStyle BackColor="#CC3300" ForeColor="White" />
                        <TitleStyle BackColor="White" Font-Bold="True" Font-Size="10pt" 
                            ForeColor="Black" />
            </asp:Calendar>
          <asp:Button ID="btnClearDate" runat="server" Enabled="False" Font-Bold="True" 
                  style="   LEFT: 7px; POSITION: absolute; TOP: 200px;" 
              Height="20px" Text="مسح" /> 

              <asp:Button ID="btnHide" runat="server" Font-Bold="True" Height="20px" 
                    style="   LEFT: 100px; POSITION: absolute; TOP: 200px;" 
                Text="أخفاء" />  
                    <asp:DropDownList ID="DropDownListYear" runat="server" 
                        
                        style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:5px; width: 60px; height: 20px;" 
                        AutoPostBack="True"  dir="rtl" Font-Bold="True" >
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem Value="2001"></asp:ListItem>
                        <asp:ListItem>2002</asp:ListItem>
                        <asp:ListItem>2003</asp:ListItem>
                        <asp:ListItem Value="2004"></asp:ListItem>
                        <asp:ListItem>2005</asp:ListItem>
                        <asp:ListItem>2006</asp:ListItem>
                        <asp:ListItem>2007</asp:ListItem>
                        <asp:ListItem>2008</asp:ListItem>
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2020</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                        <asp:ListItem>2027</asp:ListItem>
                        <asp:ListItem>2028</asp:ListItem>
                        <asp:ListItem>2029</asp:ListItem>
                        <asp:ListItem>2030</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownListMonth" runat="server"  dir="rtl"                    
                        style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:80px; width: 60px; height: 20px;" 
                        AutoPostBack="True" Font-Bold="True" >
                        <asp:ListItem Value="01">يناير</asp:ListItem>
                        <asp:ListItem Value="02">فبراير</asp:ListItem>
                        <asp:ListItem Value="03">مارس</asp:ListItem>
                        <asp:ListItem Value="04">أبريل</asp:ListItem>
                        <asp:ListItem Value="05">مايو</asp:ListItem>
                        <asp:ListItem Value="06">يونيو</asp:ListItem>
                        <asp:ListItem Value="07">يوليو</asp:ListItem>
                        <asp:ListItem Value="08">أغسطس</asp:ListItem>
                        <asp:ListItem Value="09">سبتمبر</asp:ListItem>
                        <asp:ListItem Value="10">أكتوبر</asp:ListItem>
                        <asp:ListItem Value="11">نوفمبر</asp:ListItem>
                        <asp:ListItem Value="12">ديسمبر</asp:ListItem>
                    </asp:DropDownList>
             </asp:Panel>              
        <div style ="height:450px; width:850px;   POSITION: absolute; overflow:  auto ; LEFT: 170px;  " >
            <asp:GridView ID="GridViewAdd" runat="server" AutoGenerateColumns="False" 
                BorderStyle="None" CellPadding="1" 
                DataKeyNames="ID" dir="rtl" EnableTheming="True" Font-Size="16pt" 
                GridLines="None" HorizontalAlign="Center" PageSize="20" ShowFooter="True" 
                 TabIndex="5" 
                ShowHeader="False" Font-Bold="True" >
                <RowStyle BackColor="#FFF7E7" Font-Size="X-Small" ForeColor="#8C4510" 
                    Height="18px" VerticalAlign="Middle" Wrap="True" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="No">
                        <ControlStyle Width="30px" />
                        <FooterStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Width="30px" Wrap="False" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="القيمة" SortExpression="kima">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Height="18px" Width="100px" 
                                ontextchanged="TextBox2_TextChanged" Text='<%# Bind("kima") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="الوصـــــف" SortExpression="wasf">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" width="110px" Height="18px" 
                                Text='<%# Bind("wasf") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="110px" />
                        <ItemStyle Width="110px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="البند" SortExpression="item">
                        <ItemTemplate>
                            <asp:DropDownList ID="cmbItem" runat="server" Height="18px" 
                                SelectedValue='<%# Bind("item") %>'>
                                <asp:ListItem>خرسانة</asp:ListItem>
                                <asp:ListItem>بياض</asp:ListItem>
                                <asp:ListItem>نقاشة</asp:ListItem>
                                <asp:ListItem>مهايا</asp:ListItem>
                                <asp:ListItem>سباكة</asp:ListItem>
                                <asp:ListItem>حداد</asp:ListItem>
                                <asp:ListItem>مختلط</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="البند الفرعى" SortExpression="subitem">
                        <ItemTemplate>
                            <asp:DropDownList ID="cmbSubItem" runat="server" Height="18px" 
                                SelectedValue='<%# Bind("subItem") %>'>
                                <asp:ListItem>خامات</asp:ListItem>
                                <asp:ListItem>عمالة</asp:ListItem>
                                <asp:ListItem>عامة</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="العملية" SortExpression="operation">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Height="18px" 
                                Text='<%# Bind("operation") %>' Width="80px"></asp:TextBox>
                        </ItemTemplate>
                        <ControlStyle Width="80px" />
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مسئول الصرف" SortExpression="sarf">
                        <ItemTemplate>
                            <asp:DropDownList ID="cmbNewSarf" runat="server" Height="18px" 
                                SelectedValue='<%# Bind("sarf") %>'>
                                <asp:ListItem>حسام</asp:ListItem>
                                <asp:ListItem>عبد المنعم</asp:ListItem>
                                <asp:ListItem>أشرف</asp:ListItem>
                                <asp:ListItem>أحمد</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ControlStyle Width="100px" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ملاحظات" SortExpression="notes">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox5" runat="server" Height="18px" 
                                Text='<%# Bind("notes") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="200px" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
                                Text="اضافة سطر" Width="207px" />
                        </FooterTemplate>
                        <ControlStyle Width="200px" />
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#99CCFF" Font-Size="Small" ForeColor="#8C4510" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <EditRowStyle Width="10px" />
            </asp:GridView>
         
        
 
        
    </div>
       <asp:Label ID="LabelT" runat="server" Text="مصروفات" 
            style="POSITION: absolute; TOP: 600px; left: 82%; height: 56px; width: 137px;" 
            Font-Bold="True"  Font-Underline="True" Font-Size="30pt"></asp:Label> 
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[id*=GridViewAdd] input[type=text]").on("keypress", function (e) {
        if (e.keyCode == 13) {
            var next = $(this).closest('td').next().find("input[type=text]");           
            if (next.length > 0) {
               next.focus();
 
            } else {
              var next1 = $("#GridView1").find("tr:eq(1)").find("td:eq(2)").Focus();
              $('[id*=Label1]').text(next1);
            }
            return false;
        }
    })
</script>    
            <asp:Label ID="lblSum" runat="server" 
                style="POSITION: absolute; TOP: 88px; left: 100px; height: 20px; bottom: 430px;" 
                Text="أجمالى المبالغ" Visible="False"></asp:Label>

            <asp:Label ID="lblSumV" runat="server" 
                style="POSITION: absolute; TOP: 88px; left: 18px; height: 20px; bottom: 430px;" 
                Text="=====" Visible="False"></asp:Label>

            <asp:Label ID="lblCount" runat="server" 
                style="POSITION: absolute; TOP: 120px; left: 100px; height: 20px; bottom: 430px;" 
                Text="عدد السجلات" Visible="False"></asp:Label>

            <asp:Label ID="lblCountV" runat="server" 
                style="POSITION: absolute; TOP: 120px; left: 18px; height: 20px; bottom: 430px;" 
                Text="=====" Visible="False"></asp:Label>


    </form>
</body>
</html>
