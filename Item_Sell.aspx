<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true" CodeFile="Item_Sell.aspx.cs" Inherits="Item_Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="3" align="center" class="formBox" >
        <tr>
        <th colspan="2">
        Item Sell
        </th>
        </tr>
        <tr>
            <td class="tdCaption">
                Customer Name:
            </td>
            <td>
                <asp:DropDownList ID="ddlcustomername" runat="server" 
                   >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Category:
            </td>
            <td>
                <asp:DropDownList ID="ddlitemcategory" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlitemcategory_SelectedIndexChanged" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Name:
            </td>
            <td>
                <asp:DropDownList ID="ddlitemname" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlitemname_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Rate:
            </td>
            <td>
                <asp:TextBox ID="txtitemrate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtitemrate" ErrorMessage="Enetr Item Rate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Qty:
            </td>
            <td>
                <asp:TextBox ID="txtitemqty" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtitemqty" ErrorMessage="Enter Quantity"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnsell" runat="server" Text="Sell" onclick="btnsell_Click" CssClass="ActionButtons"  />
            </td>
        </tr>
    </table>
</asp:Content>

