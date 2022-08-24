<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="tblstockgrid" runat="server" border="3" align="center" class="gridBox">
<tr>
<td colspan="2">
    <asp:GridView ID="gvstock" runat="server" OnRowCommand="gvstock_RowCommand" AllowPaging="True" 
    OnPageIndexChanging="gvstock_PageIndexChanging" OnSorting="gvstock_Sorting" 
        >
    <Columns>
    <asp:TemplateField HeaderText="Done">
    <ItemTemplate>
        <asp:Image ID="imgDelete" runat="server" ImageUrl="~/Image/button_delete.gif" />
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>

</td>
</tr>

</table>
</asp:Content>

