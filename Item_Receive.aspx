<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true" CodeFile="Item_Receive.aspx.cs" Inherits="Item_Receive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="3" align="center" class="formBox">
       <tr>
       <th colspan="2">
       Item Recieve
       </th>
       </tr>
        <tr>
            <td class="tdCaption">
                ItemItem Category:
            </td>
            <td>
                <asp:DropDownList ID="ddlitemcategory" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlitemcategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Name:
                <td>
                    <asp:DropDownList ID="ddlitemname" runat="server">
                    </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Quantity:
            </td>
            <td>
                <asp:TextBox ID="txtitemquantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtitemquantity" ErrorMessage="Enter Quatity Recieved"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnrecieve" runat="server" Text="Recieve" 
                    CssClass="ActionButtons" onclick="btnrecieve_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

