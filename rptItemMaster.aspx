<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true"
    CodeFile="rptItemMaster.aspx.cs" Inherits="rptItemMaster" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1" align="center" class="gridBox">
        <tr>
            <td>
                <asp:Button ID="btnshow" runat="server" Text="Show Report" OnClick="btnshow_Click" CssClass="ActionButtons" />
            </td>
        </tr>
    </table>
    <table id="tblReport" runat="server" visible="false">
        <tr>
            <td>
                crystal report display
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    Visible="true" ToolPanelView="None" HasToggleGroupTreeButton="false" HasToggleParameterPanelButton="false"
                    DisplayToolbar="True" PrintMode="Pdf" HasPageNavigationButtons="True" />
            </td>
        </tr>
    </table>
</asp:Content>
