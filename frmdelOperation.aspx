<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmdelOperation.aspx.vb" Inherits="delOperation" debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>حذف عملية</title>
</head>
<body bgcolor="#990033">
    <form id="form1" runat="server">
    <div>
    
            <asp:TextBox ID="txtSearch" runat="server" Font-Bold="True" TabIndex="1" 
                style="POSITION: absolute; left: 194px; width: 80px; top: 68px;"></asp:TextBox>
            
        <asp:Label ID="lblDelOperation" runat="server" Text="حذف عملية" 
            Font-Size="XX-Large"              
              style="POSITION: absolute; left: 517px; width: 180px; top: 9px;" 
                ForeColor="White"></asp:Label>
                  
            <asp:ImageButton ID="ImageButtonExit" runat="server" 
                ClientIDMode="Predictable" ImageAlign="Middle" 
                ImageUrl="~/photogallery/close.ico" 
                style="border-style: none; border-color: inherit; border-width: 10px; border-radius: 22%; POSITION:   absolute;  z-index:auto; left: 14px; TOP: 5px; width: 39px; height: 35px;" 
                BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" PostBackUrl="Default.aspx" 
            ToolTip="خروج الى الصفحة السابقة" />

            <br />
        <asp:Panel ID="PanelSupSearch" runat="server"
                        
            
            style="POSITION: absolute; TOP: 60px; width: 160px; Height:20px; left: 1090px; background: " >
                    <asp:Button ID="ButtonGroup" runat="server" Text="بحث جزئى" 
                                 style="POSITION: absolute; TOP: 0px; left: 90px; height: 20px;" 
                                 Font-Bold="True" ToolTip="البخث عن جزء من الكلمة"/>
        
                    <asp:DropDownList ID="DropDownListGroup" runat="server" AutoPostBack="True"
                                 style="POSITION: absolute; TOP: 0px; left: 10px; height: 20px;" >
                    </asp:DropDownList>
        </asp:Panel>
        <br />
        <asp:Button ID="ButtonSearch" runat="server" Text="البحث عن العملية" />
    
    </div>
    </form>
</body>
</html>
