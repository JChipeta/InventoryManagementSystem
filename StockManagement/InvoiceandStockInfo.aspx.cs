using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagement
{
    public partial class InvoiceandStockInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        public string invoice()
        {
            string dropdown = DropDownList3.SelectedValue.ToString();



            int quantity = 0;
            if (TextBox1.Text != "")
            {
                quantity = int.Parse(TextBox1.Text);
            }

            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Product where ProductCode='" + dropdown + "'", mySqlConnection);
            mySqlConnection.Open();
            cmd.Connection = mySqlConnection;
            string data = "";

            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        string itemname = QueryReader.GetString(1);
                        int unitprice = QueryReader.GetInt32(3);
                        int price = QueryReader.GetInt32(3) * quantity;
                        string category = QueryReader.GetString(4);
                        string status = "";
                        data += "<tr><td> " + itemname + "</td><td> " + category + "</td><td> " + quantity + "</td><td> " + unitprice + "</td><td> " + price + "</td><tr> ";
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            string member = DropDownList2.SelectedValue.ToString();

            string itemname = DropDownList3.SelectedValue.ToString();

            int quantity = 0;
            int Quantity = 0;
            if (TextBox1.Text != "")
            {
                quantity = int.Parse(TextBox1.Text);
            }
     
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            mySqlConnection.Open();
            SqlCommand cmd = new SqlCommand($"Insert into dbo.Invoice values('{itemname}','{member}','{DateTime.Now.ToString("d")}','{quantity}')", mySqlConnection);

            cmd.ExecuteNonQuery();

            cmd.Dispose();






            SqlCommand selectcommand = new SqlCommand($"Select * from dbo.Stock where ProductCode = '{itemname}' ", mySqlConnection);

         
            selectcommand.Connection = mySqlConnection;

            string data = "";

            using (SqlDataReader QueryReader = selectcommand.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {

                         Quantity = QueryReader.GetInt32(2) - quantity;
                        string StockPurchaseDate = QueryReader.GetString(3);



                    }
    

                }
         
                /*         cmd.Parameters.AddWithValue("@ItemCode", $"{itemname}");
                         cmd.Parameters.AddWithValue("@MemberNumber", $"{member}");
                         cmd.Parameters.AddWithValue("@BillingDate", "2021-05-04");
                         cmd.Parameters.AddWithValue("@Quantity", $"{quantity}");*/

              
            }

            selectcommand.ExecuteNonQuery();

            selectcommand.Dispose();
            SqlCommand commandd = new SqlCommand($"Update dbo.Stock set Quantity={Quantity} where ProductCode='{itemname}' ", mySqlConnection);
            commandd.ExecuteNonQuery();
            commandd.Dispose();
            mySqlConnection.Close();
        }

        public string getStock()
        {
            string dropdown = DropDownList3.SelectedValue.ToString();
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            int Quantity = 0;
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Stock where ProductCode = '" + dropdown + "'", mySqlConnection);
            mySqlConnection.Open();
            cmd.Connection = mySqlConnection;
                        
            string data = "";

            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        int itemCode = QueryReader.GetInt32(1);
                        Quantity = QueryReader.GetInt32(2);
                        string StockPurchaseDate = QueryReader.GetString(3);
                        string status = "";
                        if (Quantity < 10 && Quantity > 0)
                        {

                            status = "Running out of stock";
                        }
                        else if (Quantity == 0)
                        {
                            status = "Out of  Stock";
                        }
                        else
                        {
                            status = "Available in Stock";

                        }


                        data += "<tr><td> " + itemCode + "</td><td> " + Quantity + "</td><td> " + StockPurchaseDate + "</td><td> " + status + "</td><tr> ";
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getStock();
            invoice();
           
        }
    }
}