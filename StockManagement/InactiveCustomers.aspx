<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InactiveCustomers.aspx.cs" Inherits="StockManagement.InactiveCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
     <h1  class="page-header">View Inactive Customers</h1>
     <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> Customer Number </td>                        
            <td> Customer Name </td>            
            <td>Address</td> 
            <td>ContactNumber</td>
             <td>Email</td>
             <td>Customer Type</td>
        </tr>

        <%=inactiveCustomers()%>

    </table>
</asp:Content>
