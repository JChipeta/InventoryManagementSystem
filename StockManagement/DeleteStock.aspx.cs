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
    public partial class DeleteItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string itemsfordelete()
        {
       
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            string invoiceddate = DateTime.Now.AddDays(-100).ToString("d");
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand($"Select * from dbo.Product Join dbo.Invoice on dbo.Invoice.ProductCode=dbo.Product.ProductCode where dbo.Product.ProductCode IN (Select cp.ProductCode from dbo.Invoice cp where cp.InvoiceDate<'{invoiceddate}' and not cp.ProductCode IN (Select c.ProductCode from dbo.Invoice c where c.InvoiceDate>'{invoiceddate}'))", mySqlConnection);
            mySqlConnection.Open();
            cmd.Connection = mySqlConnection;

            string data = "";

            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        int itemcode = QueryReader.GetInt32(0);
                        string itemname = QueryReader.GetString(1);
                        string description = QueryReader.GetString(2);
                        int price = QueryReader.GetInt32(3);
                        string category = QueryReader.GetString(4);
                        string billingdate = QueryReader.GetDateTime(7).ToString("d");
                     


                      
                            data += "<tr><td> " + itemcode + "</td><td> " + itemname + "</td><td> " + description + "</td><td> " + price + "</td><td> " + category + "</td><td> " + billingdate + "</td><tr> ";
                        
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> itemlist = new List<int>();


            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            string invoiceddate = DateTime.Now.AddDays(-100).ToString("d");
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand($@"Select * from dbo.Product Join dbo.Invoice on dbo.Invoice.ProductCode=dbo.Product.ProductCode where dbo.Product.ProductCode IN (Select cp.ProductCode from dbo.Invoice cp where cp.InvoiceDate<'{invoiceddate}' and not cp.ProductCode IN (Select c.ProductCode from dbo.Invoice c where c.InvoiceDate>'{invoiceddate}')) ", mySqlConnection);
            mySqlConnection.Open();

            cmd.Connection = mySqlConnection;



            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        int itemCode = QueryReader.GetInt32(0);

                        itemlist.Add(itemCode);



                    }

                }

            }
            





            for (int i = 0; i < itemlist.Count; i++)
            {
                SqlCommand commandd = new SqlCommand($"Update dbo.Stock set Quantity=0 where ProductCode='{itemlist[i]}' ", mySqlConnection);
                commandd.ExecuteNonQuery();
                commandd.Dispose();
            }
            mySqlConnection.Close();
            string message = "Stock Cleared Successfully! Check Out of Stock Products";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);




        }


    }
}