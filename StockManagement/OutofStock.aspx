<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutofStock.aspx.cs" Inherits="StockManagement.OutofStock" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h1  class="page-header">View Out of Stock Products</h1>
    <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
         
             <td> Product Name </td>  
            <td> Quantity </td>            
            <td>StockAddedDate</td> 
        
        </tr>

        <%=outOfStocks()%>

    </table>
</asp:Content>
