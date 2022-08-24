<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true" CodeFile="Item_Master.aspx.cs" Inherits="Item_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tblitemgrid" runat="server" border="3" align="center" class="gridBox">
        <tr>
            <td>
                Search:
            </td>
            <td>
                <asp:TextBox ID="txtitemsearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnsearch" runat="server" Text="Search" 
                    onclick="btnsearch_Click"  CssClass="ActionButtons"/>
                <asp:Button ID="btnadd" runat="server" Text="Add" onclick="btnadd_Click" CssClass="ActionButtons" />
                <asp:Button ID="btnviewall" runat="server" Text="View All" 
                    onclick="btnviewall_Click" CssClass="ActionButtons"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvitem" runat="server" OnRowCommand="gvitem_RowCommand" AllowPaging="True" 
                    OnPageIndexChanging="gvitem_PageIndexChanging" 
                    OnSorting="gvitem_Sorting">
                <Columns>
                <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="E" CommandArgument='<%#Eval("ItemId") %>' CssClass="ActionButtons" />
                </ItemTemplate>
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="D" CommandArgument='<%#Eval("ItemId") %>' CssClass="ActionButtons" />
                </ItemTemplate>
                
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table id="tblitemmaster" runat="server" border="3" align="center" class="formBox">
        <tr>
        <th colspan="2" >
        Item Master
        </th>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Id:
            </td>
            <td>
                <asp:TextBox ID="txtitemid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Name:
            </td>
            <td>
                <asp:TextBox ID="txtitemname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtitemname" ErrorMessage="Enetr Item Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Category Id:
            </td>
            <td>
                <asp:DropDownList ID="ddlcategoryid" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Item Desc:
            </td>
            <td>
                <asp:TextBox ID="txtitemdescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtitemdescription" ErrorMessage="Enetr Item Description"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Status:
            </td>
            <td>
                <asp:RadioButton ID="rdoactive" runat="server" GroupName="active" Text="A" Checked="true" />
                <asp:RadioButton ID="rdoinactive" runat="server" GroupName="active" Text="I" />
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Rate:
            </td>
            <td>
                <asp:TextBox ID="txtrate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtrate" ErrorMessage="Enetr Item Rate"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Stock:
            </td>
            <td>
                <asp:TextBox ID="txtstock" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtstock" ErrorMessage="Enter Valid Stock"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Minimum Quantity:
            </td>
            <td>
                <asp:TextBox ID="txtminimumquantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtminimumquantity" 
                    ErrorMessage="Enter At least Minimum Quantity "></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" CssClass="ActionButtons"  />
                <asp:Button ID="btnupdate" runat="server" Text="Update" 
                    onclick="btnupdate_Click"  CssClass="ActionButtons"/>
                <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                    onclick="btncancel_Click"  CssClass="ActionButtons"/>
            </td>
        </tr>
    </table>
</asp:Content>
