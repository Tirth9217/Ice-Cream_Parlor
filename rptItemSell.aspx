<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true"
    CodeFile="rptItemSell.aspx.cs" Inherits="rptItemSell" %>

    <%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" align="center" class="gridBox">
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
                <asp:Button ID="btnShow" runat="server" Text="Show Report" 
                    onclick="btnShow_Click" CssClass="ActionButtons"  />
            </td>
        </tr>
    </table>
    <table id="tblReport" runat="server" visible="false">
        <tr>
            <td>
                crystal report display
                <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                    visible="true" toolpanelview="None" hastogglegrouptreebutton="false" hastoggleparameterpanelbutton="false"
                    displaytoolbar="True" printmode="Pdf" haspagenavigationbuttons="True" />
            </td>
        </tr>
    </table>
</asp:Content>
