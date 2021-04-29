<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteItems.aspx.cs" Inherits="StockManagement.DeleteItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h1  class="page-header">Delete Items</h1>
         <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> ItemCode </td>                        
            <td> ItemName </td>            
            <td>Description</td> 
            <td>Price</td>
             <td>Category</td>
             <td>LastPurchaseDate</td>
            
        </tr>

        <%=itemsfordelete()%>

             

    </table>
    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Delete" />
</asp:Content>
