<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true"
    CodeFile="rptItemReceive.aspx.cs" Inherits="rptItemReceive" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="3" align="center" class="gridBox">
        <tr>
            <td>
                From Date :
            </td>
            <td>
                <asp:Calendar ID="cal1" runat="server"></asp:Calendar>
            </td>
            <td>
                To Date :
            </td>
            <td>
                <asp:Calendar ID="cal2" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Button ID="btnreceive" runat="server" Text="Show Report" 
                    onclick="btnreceive_Click" CssClass="ActionButtons" />
            </td>
        </tr>
         
    </table>
    <table id="tblcrystalreport1" runat="server" visible="false">
    <tr>
    <td>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" visible="true" toolpanelview="None" hastogglegrouptreebutton="false" hastoggleparameterpanelbutton="false"
                    displaytoolbar="True" printmode="Pdf" haspagenavigationbuttons="True" />
    </td>
    </tr>
    </table>
</asp:Content>
