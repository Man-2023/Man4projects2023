<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="frmDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body bgcolor="#0066ff" >
    <form id="form2" runat="server" style="width: 100%">
    <p>
                  
  
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmIncom.aspx">
            <asp:Image ID="Image1" runat="server"  Height="35px"
             style="border-style: none; border-color: inherit; border-width: 10px; border-radius: 50%; POSITION: absolute; TOP: 20px; LEFT: 40px; width: 50px; height: 40px;" 
            ImageUrl="~/photogallery/Incom.jpg" />
            <asp:Label ID="Label7" runat="server"   ForeColor = "White" Font-Size="10pt" Text="<b><u>أدخـــــال أيراد</u></b>" style="   POSITION: absolute; TOP: 60px; LEFT: 30px; width: 100px;" ></asp:Label>
        </asp:HyperLink>
          &nbsp;

        <asp:HyperLink ID="HyperLinkAddMasrof" runat="server" NavigateUrl="~/adding.aspx">
            <asp:Image ID="Image2" runat="server" Height="35px"
             style=" border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 25px; LEFT: 180px; " 
            ImageUrl="~/photogallery/table-edit-icon.png"  Width="50px"/>

            <asp:Label ID="Label8" runat="server" ForeColor = "White" Font-Size="10pt"  Text="<b><u>أضافة مصروف</u></b>"
            style="   POSITION: absolute; TOP: 60px; LEFT: 175px; width: 100px;" ></asp:Label>
        </asp:HyperLink>


    </p>
    <p style="clip: rect(auto, 500px, auto, auto)">
        <asp:HyperLink ID="HyperLinkRepErad" runat="server" NavigateUrl="~/frmIncRep.aspx">
            <asp:Image ID="Image3" runat="server" Height="35px" 
             style="border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 100px; LEFT: 40px; width: 50px; " 
            ImageUrl="~/photogallery/Totals.jpg" Width="60px" />
            <asp:Label ID="Label9" runat="server" ForeColor = "White" Font-Size="10pt"  Text="<b><u>تقرير أيرادات</u></b>"
            style="   POSITION: absolute; TOP:135px; LEFT: 30px; width: 100px;" ></asp:Label>
        </asp:HyperLink>
    &nbsp;
        <asp:HyperLink ID="HyperLinkRepMasrof" runat="server" NavigateUrl="~/frmBasicData.aspx">
            <asp:Image ID="Image4" runat="server" Height="35px" 
             style="border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 100px; LEFT: 185px; width: 50px; " 
            ImageUrl="~/photogallery/rich.png" Width="60px" />
            <asp:Label  ID="Label10" runat="server" ForeColor = "White" Font-Size="10pt"  Text="<b><u>تقرير مصروفات</u></b>"   
            style="   POSITION: absolute; TOP: 135px; LEFT: 170px; width: 100px;" ></asp:Label>
        </asp:HyperLink>

    </p>
    <p>

        <asp:HyperLink ID="HyperLinkDelOperation" runat="server" NavigateUrl="~/frmDelPassword.aspx">
            <asp:Image ID="Image5" runat="server" Height="35px" 
             style="border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 180px; LEFT: 40px; width: 50px; " 
            ImageUrl="~/photogallery/Del.jpg" Width="60px" />
            <asp:Label  ID="Label1" runat="server" ForeColor = "White" Font-Size="10pt"  Text="<b><u>حذف عملية</u></b>"   
            style="   POSITION: absolute; TOP: 215px; LEFT: 40px; width: 100px;" ></asp:Label>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLinkRestorOperation" runat="server" NavigateUrl="~/frmRestorePassword.aspx">
            <asp:Image ID="Image6" runat="server" Height="35px" 
             style="border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 180px; LEFT: 190px; width: 50px; " 
            ImageUrl="~/photogallery/Backup-restore-icon.png" Width="60px" />
            <asp:Label  ID="Label2" runat="server" ForeColor = "White" Font-Size="10pt"  Text="<b><u> ارجاع عملية محذوفة</u></b>"   
            style="   POSITION: absolute; TOP: 215px; LEFT: 170px; width: 150px;" ></asp:Label>
        </asp:HyperLink>

    </p>
                

    <p style="text-align: center">

        <asp:HyperLink ID="HyperLinkEgmaly" runat="server" 
            NavigateUrl="~/frmBalancRep.aspx">
            <asp:Image ID="Image7" runat="server" Height="35px" 
             style="border: 10px ; border-radius: 50%; POSITION: absolute; TOP: 260px; LEFT: 40px; width: 50px; " 
            ImageUrl="~/photogallery/pngkit_hack-png_3547447.png" Width="60px" />
            <asp:Label  ID="Label11" runat="server" ForeColor = "White" Font-Size="10pt" Text="<b><u>أجماليات عمليات</u></b>"   
            style="   POSITION: absolute; TOP: 295px; LEFT: 20px; width: 100px;" ></asp:Label>
        </asp:HyperLink>

        <asp:Button ID="ButtonBackup" runat="server" 
            style="   POSITION: absolute; TOP: 260px; LEFT: 156px; width: 76px; border: 1px double red; border-radius: 50%; height: 57px;" 
            Text="نسح احتياطى" Font-Bold="True" Font-Size="10pt" BackColor="#FFFFCC" />

        <asp:Label ID="Label6" runat="server" Font-Bold="True" 
            Font-Names="Vladimir Script" Font-Size="XX-Large" ForeColor="White" 
            Text="المصروفات والايرادات"
            
        ></asp:Label>

        <asp:Image ID="Image8" runat="server" Height="298px" 
                    style="   POSITION: absolute; TOP: 200px; LEFT: 300px; width: 50%;  border-radius: 50%; height: 400px;" 

            ImageUrl="~/Mockup_02_BG.png" Width="506px" />

    </p>
    </form>
</body>
</html>
