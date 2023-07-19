<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDelPassword.aspx.vb" Inherits="password" Culture="af-ZA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحة ادخال كلمة المرور</title>
    <style type="text/css">
        .style1
        {
            width: 353px;
        }
        .style2
        {
            height: 32px;
        }
        .style3
        {
            height: 32px;
            width: 208px;
        }
        .style4
        {
            width: 208px;
        }
        .style5
        {
            height: 32px;
            width: 162px;
        }
        .style6
        {
            width: 162px;
        }
        .style7
        {
            height: 32px;
            width: 27px;
        }
        .style8
        {
            width: 27px;
        }
    </style>
</head>
<body bgcolor="#ffccff">
    <form id="form1" runat="server">
    <div align="center" dir="rtl" title="كلمة المرور" 
        style="background-color: #FFCCFF">
    
        <br />

            <asp:ImageButton ID="ImageButtonExit" runat="server" 
                ClientIDMode="Predictable" ImageAlign="Middle" 
                ImageUrl="~/photogallery/close.ico" 
                style="border: 10px; border-radius: 22%; POSITION:   absolute;  z-index:auto; left: 10px; TOP: 10px; width: 60px; height: 60px;" 
                BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" 
            Height="35px" PostBackUrl="Default.aspx" 
            ToolTip="خروج الى الصفحة السابقة" />

        <br />
        <asp:Label ID="Label5" runat="server" Font-Bold="True" 
            Font-Names="Vladimir Script" Font-Size="X-Large" ForeColor="#3399FF" 
            Text="مان للمشروعات الهندسية"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" 
            Font-Names="Edwardian Script ITC" Font-Size="XX-Large" ForeColor="#3399FF" 
            Text="Man for Engineering Projects"></asp:Label>
&nbsp;<br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="14pt" 
            Font-Underline="True" Text="خذف عمليات"></asp:Label>
        <br />
        <br />
        <br />
        <table align="center" bgcolor="#CC0099" cellpadding="5" class="style1" 
            frame="box" rules="groups" title="كلمة المرور" style="color: #FFFFFF">
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td align="left" class="style5">
                    &nbsp;</td>
                <td align="left" class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="TextBoxUserName" runat="server" Width="202px"></asp:TextBox>
                </td>
                <td align="left" class="style6">
                    User Name</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" 
                        Width="202px"></asp:TextBox>
                </td>
                <td align="left" class="style6">
                    Pass Word</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td align="left" class="style6">
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Label ID="lblPassword" runat="server" Text="يجب مراعاة الحروف الكبيرة"></asp:Label>
                </td>
                <td align="left" class="style6">
                    <asp:Button ID="ButtonLogIn" runat="server" Text="Loge In" />
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
        </table>
    
        <br />
    
    </div>
    </form>
</body>
</html>
