<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertOperations.aspx.cs" Inherits="StockManagement.InsertOperations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1  class="page-header">Add Item</h1>

 <table style="width:500px;" class="table" >

    
        <td>

     
    Item Name <asp:TextBox ID="itemnametb"  runat="server" CssClass="glyphicon-envelope"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup='valGroup1' ControlToValidate="itemnametb" runat="server" ErrorMessage="Insert Name!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        
     
         <td>
Description <asp:TextBox ID="descriptiontb" runat="server"></asp:TextBox>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup='valGroup1' ControlToValidate="descriptiontb" runat="server" ErrorMessage="Insert Description!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

             </td>
       

     
 <td>
Price <asp:TextBox ID="pricetb" runat="server"></asp:TextBox>

     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup='valGroup1' ControlToValidate="pricetb" runat="server" ErrorMessage="Insert Price!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

</td>

     <td>

Category <asp:TextBox ID="categorytb" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup='valGroup1' ControlToValidate="categorytb" runat="server" ErrorMessage="Insert Category!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
     </td>
     <td>
   Quantity
        

    <asp:TextBox ID="quantitytb" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup='valGroup1' ControlToValidate="quantitytb" runat="server" ErrorMessage="Insert Quantity!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
 </td>


     <td>
         <br />
<asp:Button ID="Button1" class="btn btn-primary" runat="server" ValidationGroup='valGroup1' OnClick="Button1_Click" Text="Add Item" Width="83px" />
    </td>
     </table>

    <h1  class="page-header">Add Member</h1>
     <table style="width:500px;" class="table" >

         <td>

             
   Member Name <asp:TextBox ID="membernametb" runat="server"></asp:TextBox>

             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup='valGroup2' ControlToValidate="membernametb" runat="server" ErrorMessage="Insert Name!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

             </td>
         <td>
Address <asp:TextBox ID="addresstb" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup='valGroup2' ControlToValidate="addresstb" ErrorMessage="Insert Address!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
             </td>

         <td>
Contact Number <asp:TextBox ID="contactnumbertb" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup='valGroup2' ControlToValidate="contactnumbertb" ErrorMessage="Insert Contact No.!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
             </td>

<td>
Email <asp:TextBox ID="emailtb" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup='valGroup2' ControlToValidate="emailtb" ErrorMessage="Insert Email!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </td>

<td>
Member Type

<asp:TextBox ID="membertypetb" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup='valGroup2' ControlToValidate="membertypetb" ErrorMessage="Insert Member Type!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

    </td>

         <td>
             <br />

<asp:Button ID="Button2" class="btn btn-primary" runat="server" ValidationGroup='valGroup2' OnClick="Button2_Click" Text="Add Member" />
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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup='valGroup3' ControlToValidate="quantitytb0" ErrorMessage="Insert Quantity!" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>

        <td>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StockManagementConnectionString %>" SelectCommand="SELECT * FROM [Item]"></asp:SqlDataSource>
<asp:Button ID="Button3" class="btn btn-primary" runat="server" ValidationGroup='valGroup3' OnClick="Button3_Click" Text="Add Stock" />
            </td>
        </table>
</asp:Content>
