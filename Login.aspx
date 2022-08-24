<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="design.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <table align="center" border="3" class="gridBox">
        <tr>
            <td colspan="2">
                <asp:Image ID="img" runat="server" ImageUrl="~/Image/Headerimg.png" />
            </td>
        </tr>
        <tr>
            <th colspan="2" class="style1">
                <span class="style2">Login Page</span>
            </th>
        </tr>
        <tr>
            <td align="center">
                User Id:
            </td>
            <td>
                <asp:TextBox ID="txtuserid" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserid"
                    ErrorMessage="UserName must not be blank"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center">
                Password:
            </td>
            <td>
                <asp:TextBox ID="txtpassword" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtpassword"
                    ErrorMessage="Incorrect password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="ActionButtons" />
    </form>
</body>
</html>
