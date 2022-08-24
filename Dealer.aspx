<%@ Page Title="" Language="C#" MasterPageFile="~/IceDairy.master" AutoEventWireup="true"
    CodeFile="Dealer.aspx.cs" Inherits="Dealer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tblDealergrid" runat="server" border="3" align="center">
        <tr>
            <td>
                Search:
            </td>
            <td>
                <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnsearch" runat="server" Text="Search" 
                    CssClass="ActionButtons" onclick="btnsearch_Click" />
                <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="ActionButtons" 
                    onclick="btnadd_Click" />
                <asp:Button ID="btnviewall" runat="server" Text="View All" 
                    CssClass="ActionButtons" onclick="btnviewall_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvdealer" runat="server" OnRowCommand="gvdealer_RowCommand" AllowPaging="True"
                    OnPageIndexChanging="gvdealer_PageIndexChanging" OnSorting="gvdealer_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="E" CommandArgument='<%#Eval("DealerId") %>'
                                    CssClass="ActionButtons" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="D" CommandArgument='<%#Eval("DealerId") %>'
                                    CssClass="ActionButtons" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table id="tbldealer" runat="server" border="3" align="center" class="formBox">
       <tr>
       <th colspan="2">
       Dealer Master
       </th>
       </tr>
        <tr>
            <td class="tdCaption">
                Dealer Id:
            </td>
            <td>
                <asp:TextBox ID="txtdealerid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Dealer Name:
            </td>
            <td>
                <asp:TextBox ID="txtdealername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtdealername" ErrorMessage="Enter Customer Name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Adress:
            </td>
            <td>
                <asp:TextBox ID="txtadress" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtadress" ErrorMessage="Enter valid Address"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Email:
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtemail" ErrorMessage="enetr valid E-Mail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Mobile No:
            </td>
            <td>
                <asp:TextBox ID="txtmobileno" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtmobileno" ErrorMessage="Enetr Mobile No"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtmobileno" ErrorMessage="Enter Correct Mobile No" 
                    ValidationExpression="^([6-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Description:
            </td>
            <td>
                <asp:TextBox ID="txtdescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtdescription" ErrorMessage="Enter Description"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdCaption">
                Status:
            </td>
            <td>
                <asp:RadioButton ID="rdoactive" runat="server" Text="A" GroupName="customer" Checked="true" />
                <asp:RadioButton ID="rdoinactive" runat="server" Text="I" GroupName="customer" />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnsave" runat="server" Text="save" onclick="btnsave_Click" CssClass="ActionButtons"  />
            <asp:Button ID="btnupdate" runat="server" Text="Update" 
                onclick="btnupdate_Click" CssClass="ActionButtons"/>
            <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                onclick="btncancel_Click" CssClass="ActionButtons" />
        </td>
        </tr>
        </table>
</asp:Content>
