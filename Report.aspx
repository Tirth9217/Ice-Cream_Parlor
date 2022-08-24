<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1" align="center">
        <tr>
            <td>
                <asp:Button ID="btnshow" runat="server" Text="Show Report" 
                    onclick="btnshow_Click" CssClass="ActionButtons" />
            </td>
        </tr>
    </table>
    <table id="tblReport" runat="server" visible="false">
        <tr>
            <td> crystal report display
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" Visible="true" />
            </td>
            
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
