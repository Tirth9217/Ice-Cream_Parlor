<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true" CodeFile="Category_Master.aspx.cs" Inherits="Category_Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" border="3" id="tblgrid" runat="server" class="gridBox">
        <tr>
            <td>
                Search:
            </td>
            <td>
                <asp:TextBox ID="txtsearch" runat="server" ></asp:TextBox>
                <asp:Button ID="btnsearch" runat="server" Text="Search"  CssClass="ActionButtons"
                    onclick="btnsearch_Click" />
                <asp:Button ID="btnadd" runat="server" Text="Add" onclick="btnadd_Click" CssClass="ActionButtons"/>
                <asp:Button ID="btnviewall" runat="server" Text="View all" CssClass="ActionButtons"
                    onclick="btnviewall_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvcategory" runat="server" 
                    OnRowCommand="gvcategory_RowCommand" AllowPaging="True" 
                    OnPageIndexChanging="gvcategory_PageIndexChanging" 
                    OnSorting="gvcategory_Sorting" 
                    onselectedindexchanged="gvcategory_SelectedIndexChanged">
                <Columns>
               <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="E" CommandArgument='<%#Eval("CatId") %>' CssClass="ActionButtons" />
                </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="D" CommandArgument='<%#Eval("CatId") %>' CssClass="ActionButtons" />
                </ItemTemplate>
                    
                </asp:TemplateField>

                </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table border="3" align="center" id="tblcategory" runat="server" class="formBox">
        <tr>
            <th colspan="2">
                Category Master
            </th>
        </tr>
        <tr>
            <td class="tdCaption">
                Category Id:
            </td>
            <td>
                <asp:TextBox ID="txtcategoryid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Category Name:
            </td>
            <td>
                <asp:TextBox ID="txtcategoryname" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtcategoryname" ErrorMessage="Enter Category Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Category Description:
            </td>
            <td>
                <asp:TextBox ID="txtcategorydescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtcategorydescription" 
                    ErrorMessage="Enetr category Description"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Status:
            </td>
            <td>
                <asp:RadioButton ID="rdoactive" runat="server" Text="Active" GroupName="active" Checked="true" />
                <asp:RadioButton ID="rdoinactive" runat="server" Text="Inactive" GroupName="active" />
            </td>
        </tr>
        
        
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" CssClass="ActionButtons" />
                <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="ActionButtons"
                    onclick="btnupdate_Click"  />
                <asp:Button ID="btncancel" runat="server" Text="cancel" CssClass="ActionButtons"
                    onclick="btncancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

