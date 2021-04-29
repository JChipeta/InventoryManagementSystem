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
    public partial class OutofStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      

        }
        public string outOfStocks()
        {
         
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;

            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("Select * from dbo.Stock Join dbo.Product on dbo.Product.ProductCode=dbo.Stock.ProductCode where Quantity=0", mySqlConnection);
            mySqlConnection.Open();
            cmd.Connection = mySqlConnection;

            string data = "";

            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        string productname = QueryReader.GetString(5);
                    
                        int Quantity = QueryReader.GetInt32(2);
                        string StockPurchaseDate = QueryReader.GetString(3);
                 
                     


                        data += "<tr><td> "+  productname + "</td><td> " + Quantity + "</td><td> " + StockPurchaseDate +"</td><tr> ";
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }
    }
}