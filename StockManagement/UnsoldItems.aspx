<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnsoldItems.aspx.cs" Inherits="StockManagement.UnsoldItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <b>
        <br />
        </b> 
     <h1  class="page-header">Product Not Bought </h1>
         <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> Product Code </td>                        
            <td> Product Name </td>            
            <td>Description</td> 
            <td>Price</td>
             <td>Category</td>
             <td>LastPurchaseDate</td>
        </tr>

        <%=itemsNotSold()%>

    </table>
</asp:Content>
