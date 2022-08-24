<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <table align="center" border="3" class="gridBox">
        <tr>
            <td colspan="2">
                <asp:Image ID="img" runat="server" ImageUrl="~/Image/header.jpg" />
            </td>
        </tr>
        <tr>
            <th colspan="2" class="style1">
                <span class="style2">Login Page</span>
            </th>
        </tr>
        <tr>
            <td>
                User Id:
            </td>
            <td>
                <asp:TextBox ID="txtuserid" runat="server" MaxLength="20">1</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserid"
                    ErrorMessage="UserName must not be blank"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" MaxLength="8">t</asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"
                    ErrorMessage="Incorrect password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="ActionButtons" />

    </form>
</body>
</html>
