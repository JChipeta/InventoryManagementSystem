<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="StockManagement.Change_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1  class="page-header">Change Password</h1>
    <div style="display: flex;">
        <table  class="table" >
            <tr>
                <td>Select User</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="userid">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>New Password</td>
                <td>
                    <asp:TextBox ID="repasswordtb"  runat="server" Height="2em" Width="30em"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
               <asp:Button ID="Button2" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Change Password" />
                    </td>
            </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagement_databaseConnectionString %>" SelectCommand="SELECT * FROM [UserLogin]"></asp:SqlDataSource>
</asp:Content>
