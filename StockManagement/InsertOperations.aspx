<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertOperations.aspx.cs" Inherits="StockManagement.InsertOperations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1  class="page-header">Add Item</h1>

 <table style="width:500px;" class="table" >

    
        <td>

     
    Item Name <asp:TextBox ID="itemnametb"  runat="server" CssClass="glyphicon-envelope"></asp:TextBox>

            </td>
        
     
         <td>
Description <asp:TextBox ID="descriptiontb" runat="server"></asp:TextBox>

             </td>
       

     
 <td>
Price <asp:TextBox ID="pricetb" runat="server"></asp:TextBox>

</td>

     <td>

Category <asp:TextBox ID="categorytb" runat="server"></asp:TextBox>
     </td>
     <td>
   Quantity
        

    <asp:TextBox ID="quantitytb" runat="server"></asp:TextBox>
 </td>


     <td>
         <br />
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Item" Width="83px" />
    </td>
     </table>

    <h1  class="page-header">Add Member</h1>
     <table style="width:500px;" class="table" >

         <td>

             
   Member Name <asp:TextBox ID="membernametb" runat="server"></asp:TextBox>

             </td>
         <td>
Address <asp:TextBox ID="addresstb" runat="server"></asp:TextBox>
             </td>

         <td>
Contact Number <asp:TextBox ID="contactnumbertb" runat="server"></asp:TextBox>
             </td>

<td>
Email <asp:TextBox ID="emailtb" runat="server"></asp:TextBox>
    </td>

<td>
Member Type

<asp:TextBox ID="membertypetb" runat="server"></asp:TextBox>

    </td>

         <td>
             <br />

<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Add Member" />
             </td>

         </table>
    <h1  class="page-header">Add Stock</h1>

    <table style="width:500px;" class="table" >

        <td>
    
<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="ItemName" DataValueField="ItemCode">
</asp:DropDownList>
            </td>

        <td>
Quantity

<asp:TextBox ID="quantitytb0" runat="server"></asp:TextBox>
            </td>

        <td>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagementConnectionString %>" SelectCommand="SELECT * FROM [Item]"></asp:SqlDataSource>
<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Stock" />
            </td>
        </table>
</asp:Content>
