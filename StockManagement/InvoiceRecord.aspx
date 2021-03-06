<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceRecord.aspx.cs" Inherits="StockManagement.InvoiceRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
     <h1  class="page-header">View Invoice Records</h1>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagement_databaseConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="CustomerName" DataValueField="CustomerNumber">
    </asp:DropDownList>
    <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="View Records" />
     <br />
    <br />
     <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
               <td> Product Code </td>        
            <td> Product Name </td>                        
            <td> Customer Number </td>            
            <td>Quantity</td> 
            <td>Date</td>
        </tr>

        <%=lastPurchased()%>

    </table>
</asp:Content>
