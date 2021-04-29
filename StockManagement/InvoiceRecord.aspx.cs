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
    public partial class InvoiceRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lastPurchased();
        }

        public string lastPurchased()
        {
            string dropdown = DropDownList1.SelectedValue.ToString();
            int quantity = 0;
            string dateForButton = DateTime.Now.AddDays(-31).ToString("d");
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand($"Select * from dbo.Invoice c Join dbo.Product i on c.ProductCode = i.ProductCode where CustomerNumber='{dropdown}' and InvoiceDate>='{dateForButton}'", mySqlConnection);
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
                        string itemname = QueryReader.GetString(6);
                        string membernumber = QueryReader.GetString(1);
                        string quantities = QueryReader.GetString(3);
                        
                        string billingdate = QueryReader.GetDateTime(2).ToString("d");
                     
                        data += "<tr><td> "+ itemcode + "</td><td> "+ itemname + "</td><td> " + membernumber + "</td><td> " + quantities + "</td><td> " + billingdate + "</td><tr> ";
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }
    }
}