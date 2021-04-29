<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceandStockInfo.aspx.cs" Inherits="StockManagement.InvoiceandStockInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
     <h1  class="page-header">View Price</h1>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagement_databaseConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3" DataTextField="ProductName" DataValueField="ProductCode">
    </asp:DropDownList>
    Quantity
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button3" class="btn btn-primary" runat="server" OnClick="Button3_Click" Text="Check Status" />
     <br />
    <br />
   
     <table class="table" width="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> Product Name </td>  
            <td>Category</td>
             <td> Quantity </td>      
             <td> Price </td>      
            <td> Total </td>            
        
        </tr>
           <tr>
               <td>&nbsp;</td>
         </tr>
           <%=invoice()%>
 </table>
    <br />
    <br />
    <br />
    <h1  class="page-header">View Stock</h1>
    <table class="table" ="100%" align="center" cellpadding="2" cellspacing="2" border="0" bgcolor="#EAEAEA" >
        <tr align="left" style="background-color:#004080;color:White;" >
            <td> ItemCode </td>                        
            <td> Quantity </td>            
            <td>Date</td> 
            <td>Status</td>
        </tr>

        <%=getStock()%>

    </table>
    <br />
    <br />
     <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="CustomerName" DataValueField="CustomerNumber">
</asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagement_databaseConnectionString %>" SelectCommand="SELECT * FROM [Customer]"></asp:SqlDataSource>
<asp:Button ID="Button2" class="btn btn-primary" runat="server" OnClick="Button2_Click" Text="Sell Item " />
     
</asp:Content>
