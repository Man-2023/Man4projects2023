<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeFile="frmBalancRep.aspx.vb" Inherits="Default2" debug="true"%>


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
    <div style="direction: rtl; background-color: #9999FF; position: inherit; list-style-type: circle; " 
        align="center" dir="rtl">
    
        <asp:Label ID="lblSearch" runat="server" Text="Welcom User" 
            TabIndex="11" style="text-align: left" BackColor="#EEEEEE"></asp:Label>
            
            <br />
        
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblRCount" runat="server" BorderColor="#3333FF" 
            style="POSITION: absolute; TOP: 277px; left: 1022px; height: 26px;" 
            Width="70px" ForeColor="Black"  Font-Bold="True"  Font-Underline="True"></asp:Label>
        
        
        <asp:Label ID="lblSum" runat="server" Text="أجمالى عدد العمليات = " 
            style="POSITION: absolute; TOP: 277px; left: 1074px; height: 26px; width: 138px;" 
            Font-Bold="True"  Font-Underline="True"></asp:Label>
      
        
        <br />
        
        <asp:GridView ID="GridView1" runat="server" Width="650px"  
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="0" dir="rtl" EnableTheming="True" Font-Size="Medium" 
            HorizontalAlign="Center" PageSize="20" ShowFooter="True" 
             TabIndex="5" Font-Bold="False" >

<RowStyle Width="10%" Font-Size="Medium"></RowStyle>
            <Columns>
                <asp:BoundField DataField="operation" HeaderText="العملية" >
                <FooterStyle ForeColor="#3399FF" HorizontalAlign="Center" />
                <HeaderStyle Height="20px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Teradat" HeaderText="أيرادات" 
                    ConvertEmptyStringToNull="False" NullDisplayText="0" >
                <HeaderStyle Height="10px" />
                </asp:BoundField>
                <asp:BoundField DataField="Tmasrof" HeaderText="مصروفات" NullDisplayText="0" />
                <asp:BoundField HeaderStyle-Width="2%" ItemStyle-Width="2%"
            FooterStyle-Width="2%" HeaderText="الصافى" DataField="Bal" NullDisplayText="0" >
<FooterStyle Width="10%" Wrap="False"></FooterStyle>

<HeaderStyle Width="10%" Wrap="False"></HeaderStyle>

<ItemStyle Width="10%" Wrap="False"></ItemStyle>
                <ControlStyle Width="100%" />
                <FooterStyle Width="20%" Wrap="True" />
                <HeaderStyle Width="20%" Wrap="True" />
                <ItemStyle Width="20%" Wrap="True" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" Font-Size="Large" ForeColor="Black" Height="30px" 
                 />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
                />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" 
                Wrap="True" Font-Size="Medium" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" 
                 HorizontalAlign="Center" Font-Size="Large" Height="40px" />
            <EditRowStyle Font-Size="Medium" />
            <AlternatingRowStyle BackColor="#DCDCDC" Font-Size="Medium"  />
        </asp:GridView>
        
        <asp:Label ID="LabelT" runat="server" Text="أجماليات ايرادات ومصروفت وصافى " 
            style="POSITION: absolute; TOP: 110px; left: 1129px; height: 93px; width: 83px;" 
            Font-Bold="True"  Font-Underline="True"></asp:Label>
 
        
        <br />
        <asp:Panel ID="Panel2" runat="server" 
                style="   LEFT: 10px; POSITION: absolute; TOP: 15px;  width: 185px; bottom: 563px; height: 23px;"  
              BackColor="#9999FF" >
           
            <asp:Button ID="btnPrintCurrent" runat="server" Font-Bold="True" 
                 style="    POSITION: absolute; TOP: 0px; left:10px; width: 87px; Height:20px;" 
                OnClick="PrintCurrentPage" Text="طباعة " 
                Font-Names="Arabic Transparent" Font-Size="10pt"  />
                
            <asp:Button ID="btnToExcel" runat="server" Text="To Excel File" 
                style="   LEFT: 50px; POSITION: absolute;  left:97px; width: 87px;  height: 20px;"  
                Font-Bold="False"  Font-Names="Times New Roman" Font-Size="9pt" 
                BackColor="#9999FF" Font-Underline="True" />
        </asp:Panel>
    
    </div>
    
 <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Default.aspx" 
                style="   LEFT: 200px; POSITION: absolute; TOP: 20px;  "  
 
        TabIndex="12" Font-Names="Arabic Transparent" Font-Size="10pt">عودة</asp:LinkButton>
               
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Man.accdb;Persist Security Info=True" 
        ProviderName="System.Data.OleDb">
    </asp:SqlDataSource>
    </form>
</body>

</html>
