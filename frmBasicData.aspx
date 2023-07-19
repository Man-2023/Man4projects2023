<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeFile="frmBasicData.aspx.vb" Inherits="Default2" Debug="true"%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>تداول البيانات والتقارير</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {

}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server" dir="rtl" style="background-color: #C0C0C0" 
    title="مان للمشروعات">
    <div style="direction: rtl; background-color: #BFBFFF; position: inherit; list-style-type: circle; " 
        align="center" dir="rtl">
    
        <asp:Label ID="lblSearch" runat="server" Text="Welcom Farid" 
            TabIndex="11" style="text-align: left" BackColor="#EEEEEE"></asp:Label>
            
            <br /><br />
            
                
        <asp:RadioButton ID="RadioButtonDate" runat="server" Visible="False" />
            
                
        <asp:Panel ID="PanelSearchCommand" runat="server"
                style=" POSITION: absolute;  LEFT: 840px;  TOP: 15px;  width: 152px; height: 65px;"  
                BackColor="#3333FF" BorderStyle="Groove" Visible="False">
                <asp:Button ID="btnSubmit" runat="server" Text="أضغط لتثبيت أختيارك" 
                    Width="150px" Font-Bold="True" Font-Italic="False" 
                    style=" POSITION: absolute;  LEFT: -1px;  TOP: 0px;  width: 150px; height: 20px;"  
                    Font-Size="10pt" Height="20px" />
                
                <asp:Button ID="btnSearchAdd" runat="server" Text="اضافة اختيارات أخرى" 
                    style=" POSITION: absolute;  LEFT: -1px;  TOP: 22px;  width: 150px; height: 20px;"  

                    BackColor="#0066FF" Font-Bold="True" ForeColor="White" Width="150px" 
                    Font-Size="10pt" Height="20px" />
                <asp:Button ID="btnSearch" runat="server" BackColor="#006600" 
                    BorderColor="White" Font-Bold="True" ForeColor="White" Text="أبدأ البحث" 
                style=" POSITION: absolute;  LEFT: -1px;  TOP: 42px;  width: 150px; "  
                    
                    Width="150px" Font-Size="10pt" Height="20px" />
       </asp:Panel> 

        <asp:Panel ID="PanelGridView" runat="server"
            style=" POSITION: absolute;  LEFT:1004px;  TOP: 10px;  width: 281px; height: 40px;"  >

            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                Font-Bold="True" Font-Size="Smaller" ForeColor="#000099" 
                style="POSITION: absolute; text-align: right; top: 20px; Height:25px; left: 250px; " 
                TabIndex="2" Width="88px">
                <asp:ListItem>أختيارات البحث</asp:ListItem>
                <asp:ListItem Value="التـــــاريخ">التـــــاريخ</asp:ListItem>
                <asp:ListItem Value="القيمـــــــة">القيمـــــــة</asp:ListItem>
                <asp:ListItem>الوصـــــف</asp:ListItem>
                <asp:ListItem>البنــــــــــد</asp:ListItem>
                <asp:ListItem>البند الفرعى</asp:ListItem>
                <asp:ListItem>العمــــــــلية</asp:ListItem>
                <asp:ListItem>مسئول الصرف</asp:ListItem>
                <asp:ListItem>ملاحظــــــات</asp:ListItem>
            </asp:DropDownList>
                  
            <asp:TextBox ID="txtSearch" runat="server" Font-Bold="True" TabIndex="1" 
                style="POSITION: absolute; left: 130px; width: 80px; top: 20px;" 
                Visible="False"></asp:TextBox>
            
            <asp:TextBox ID="txtSearchD" runat="server" Font-Bold="True" 
                style=" POSITION: absolute; TOP: 20px; width: 80px; left: 5px" 
                TabIndex="1" Visible="False"></asp:TextBox>

            <asp:Button ID="btnCalender1" runat="server" 
                BorderColor="#FFCC00" Font-Bold="True" Font-Names="Times New Roman" 
                Font-Size="11pt" Height="30px" onclick="btnCalender1_Click" 
                style="POSITION: absolute; TOP: 20px; width: 25px; Height:20px; left: 90px; background: " 
                Text="الى" ToolTip="أظهار التقويم" 
                Width="60px" Visible="False" />
            
            <asp:Button ID="btnCalender0" runat="server" 
                BorderColor="#FFCC00" Font-Bold="True" Font-Names="Times New Roman" 
                Font-Size="11pt" Height="30px" onclick="btnCalender_Click" 
                style="POSITION: absolute; TOP: 20px; width: 25px; Height:20px; left: 220px; background: " 
                Text="من" ToolTip="أظهار التقويم" 
                Width="60px" Visible="False" />
            
        </asp:Panel>
        <asp:Panel ID="PanelSupSearch" runat="server"
                        
            style="POSITION: absolute; TOP: 60px; width: 160px; Height:20px; left: 1090px; background: " 
            Visible="False" >
                    <asp:Button ID="ButtonGroup" runat="server" Text="بحث جزئى" 
                                 style="POSITION: absolute; TOP: 0px; left: 90px; height: 20px;" 
                                 Font-Bold="True" ToolTip="البخث عن جزء من الكلمة"/>
        
                    <asp:DropDownList ID="DropDownListGroup" runat="server" AutoPostBack="True"
                                 style="POSITION: absolute; TOP: 0px; left: 10px; height: 20px;" >
                    </asp:DropDownList>
        </asp:Panel>
        <asp:Panel ID="PanelRadio" runat="server" Width="323px">
            
            <asp:RadioButton ID="RadioBtnAdd" runat="server" Font-Bold="True" 
                Font-Size="10pt" BorderColor="Silver" 
                BorderStyle="Solid" Visible="False" />
            <asp:Button ID="btnSearchX" runat="server" BackColor="#D50000" Font-Bold="True" 
                ForeColor="White" Text="تعديل اختيارات البحث" Visible="False" 
                Font-Size="Small" style="width: 142px" />
        </asp:Panel>
        &nbsp;<br />
        &nbsp;<br />
            <asp:Panel ID="PanelCalendar"
            style="    POSITION: absolute; TOP: 80px; left:1100px; width: 147px;  height: 230px;" 
            runat="server" BorderStyle="Groove" Visible="False">

                    <asp:Calendar id="Calendar1" 
                        
                        style="  z-index : 501; LEFT: 16px; POSITION: absolute; TOP: 20px; left:5px; width: 140px;  height: 140px;" runat="server" 
             BorderWidth="1px" DayNameFormat="FirstLetter" 
            Font-Size="10pt" Font-Names="Traditional Arabic" ShowGridLines="True" 
                        Font-Bold="False" Font-Underline="False" dir="ltr" CellPadding="1" 
                        CellSpacing="1">
                        <NextPrevStyle Font-Bold="True" ForeColor="#CC3300" HorizontalAlign="Center" />
                        <OtherMonthDayStyle ForeColor="#0099FF" />
                        <TitleStyle Font-Bold="True" Font-Size="8pt" BackColor="White" />
                        <WeekendDayStyle ForeColor="#3366FF" />
            </asp:Calendar>
          <asp:Button ID="btnClearDate" runat="server" Enabled="False" Font-Bold="True" 
                  style="   LEFT: 7px; POSITION: absolute; TOP: 210px;" 
              Height="20px" Text="مسح" /> 

              <asp:Button ID="btnHide" runat="server" Font-Bold="True" Height="20px" 
                    style="   LEFT: 100px; POSITION: absolute; TOP: 210px;" 
                Text="أخفاء" />  
                    <asp:DropDownList ID="DropDownListYear" runat="server" 
                        
                        style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:10px; width: 60px; height: 20px;" 
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
                        style="  z-index : 501;  POSITION: absolute; TOP: 0px; left:85px; width: 60px; height: 20px;" 
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
        <div style ="height:550px; width:820px;   POSITION: absolute; overflow:  auto ; LEFT: 200px;  " >
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="800px"  
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#999999" BorderStyle="Double" BorderWidth="3px" CellPadding="0" 
            DataKeyNames="ID" dir="rtl" EnableTheming="True" Font-Size="Medium" 
            HorizontalAlign="Center" PageSize="20" ShowFooter="True" 
             TabIndex="5" GridLines="Vertical" CellSpacing="1" >

<RowStyle Width="10%" Font-Size="Medium"></RowStyle>
            <Columns>
                <asp:BoundField DataField="id" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="ID" ApplyFormatInEditMode="True" 
                    ReadOnly="True" >
                    <ControlStyle Width="100%" BackColor="White" ForeColor="White" />
<FooterStyle Wrap="False" Width="7%"></FooterStyle>

<HeaderStyle Wrap="False" Width="7%" BackColor="#0000CC" ForeColor="#0000CC"></HeaderStyle>

<ItemStyle Wrap="False" Width="7%" BackColor="White" ForeColor="White"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="date" DataFormatString="{0:d}" 
                    HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="التاريخ" SortExpression="date" >
                    <ControlStyle Width="160px" />

<FooterStyle Width="7%" Wrap="False"></FooterStyle>

<HeaderStyle Width="7%" Wrap="False"></HeaderStyle>

<ItemStyle Width="12%" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="kima"  HeaderStyle-Width="10%" ItemStyle-Width="10%"
            FooterStyle-Width="10%" HeaderText="القيمة" SortExpression="val(kima)" >
                    <ControlStyle Width="105%" />
<FooterStyle Wrap="False"></FooterStyle>

<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False" Width="5%" HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="wasf" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="الوصف" SortExpression="wasf" >
                    <ControlStyle Width="100%" />

<FooterStyle Width="10%" Wrap="False"></FooterStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False" Width="10%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="item" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="البند" SortExpression="item" >
                    <ControlStyle Width="100%" />
<FooterStyle Wrap="False"></FooterStyle>

<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="subitem" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="البند الفرعى" SortExpression="subitem" >
                    <ControlStyle Width="100%" />
<FooterStyle Wrap="False"></FooterStyle>

<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="operation" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="العملية" SortExpression="operation" >
                    <ControlStyle Width="100%" />
<FooterStyle Wrap="False"></FooterStyle>

<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="sarf" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="مسئول الصرف" SortExpression="sarf" >
                    <ControlStyle Width="100%" />
<FooterStyle Width="2%"></FooterStyle>

<HeaderStyle Width="7%" Wrap="False"></HeaderStyle>

<ItemStyle Width="7%" Wrap="False"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="notes"  HeaderText="ملاحظات" SortExpression="notes" >
                    <ControlStyle Width="100%" />
<FooterStyle Width="20%" Wrap="True"></FooterStyle>

<HeaderStyle Width="20%" Wrap="True"></HeaderStyle>

<ItemStyle Width="20%" Wrap="True"></ItemStyle>
                </asp:BoundField>
                <asp:CommandField CancelText="الغاء" DeleteText="حذف" EditText="تعديل" 
                    HeaderText="الاوامر" InsertText="" NewText="" SelectText="" 
                    ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" 
                    ShowSelectButton="True" UpdateText="تحديث" HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%">
<FooterStyle Width="2%"></FooterStyle>

<HeaderStyle Width="2%"></HeaderStyle>

<ItemStyle Width="2%"></ItemStyle>
                </asp:CommandField>
                <asp:TemplateField>
                    <FooterTemplate>
                        <asp:Button ID="btnTotal" runat="server" Font-Bold="True" 
                            Font-Italic="False" onclick="btnTotal_Click1" Text="تجميع" Width="50px" />
                    </FooterTemplate>
                    <HeaderTemplate>
                        أوامـــر
                    </HeaderTemplate>
                    <HeaderStyle BackColor="#0000CC" ForeColor="#0000CC" />
                    <ItemStyle BackColor="White" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" Font-Size="Medium" ForeColor="Black" 
                 />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
                />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" 
                Wrap="True" Font-Size="Medium" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" 
                 HorizontalAlign="Center" Font-Size="10pt" Height="30px" />
            <EditRowStyle Font-Size="Medium" />
            <AlternatingRowStyle BackColor="#DCDCDC" Font-Size="Medium"  />
        </asp:GridView>
              </div>
  
        <br />
        <asp:Panel ID="PanelCommand" runat="server" 
                style="   LEFT: 10px; POSITION: absolute; TOP: 15px;  width: 185px; bottom: 444px; height: 80px;"  
              BackColor="#9999FF" Enabled="False" >
           
            <asp:Button ID="btnPrintCurrent" runat="server" Font-Bold="True" 
                 style="    POSITION: absolute; TOP: 0px; left:10px; width: 87px; Height:20px;" 
                OnClick="PrintCurrentPage" Text="طباعة " 
                Font-Names="Arabic Transparent" Font-Size="10pt"  />
                
            <asp:Button ID="btnToExcel" runat="server" Text="To Excel File" 
                style="   LEFT: 50px; POSITION: absolute;  TOP: 0px; left:97px; width: 87px;  height: 20px;"  
                Font-Bold="False"  Font-Names="Times New Roman" Font-Size="9pt" 
                Font-Underline="True" />

            <asp:Label ID="lblRCount" runat="server" BackColor="White" 
                BorderColor="#3333FF" ForeColor="Black" 
                style="POSITION: absolute; TOP: 21px; left: 7px; height: 20px;" Width="70px"></asp:Label>

            <asp:Label ID="lblSum" runat="server" 
                style="POSITION: absolute; TOP: 21px; left: 87px; height: 20px; bottom: 404px;" 
                Text="عدد السجلات"></asp:Label>

            <asp:Button ID="btnTotal0" runat="server" Font-Bold="True" Font-Italic="False" 
                style="POSITION: absolute; TOP: 43px; left: 10px; height: 26px;" Width="185px"
                onclick="btnTotal_Click1" Text="تجميع" />

        </asp:Panel>
    
    </div>
    
 <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Default.aspx" 
                style="   LEFT: 200px; POSITION: absolute; TOP: 13px; width: 34px; height: 17px;"  
 
        TabIndex="12" Font-Names="Times New Roman" Font-Size="12pt" 
        Font-Bold="True">عودة</asp:LinkButton>
               
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Man.accdb;Persist Security Info=True" 
        ProviderName="System.Data.OleDb">
    </asp:SqlDataSource>
    </form>
</body>

</html>
