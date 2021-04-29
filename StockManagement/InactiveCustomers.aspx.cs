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
    public partial class InactiveCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string inactiveCustomers() 
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            string dateForButton = DateTime.Now.AddDays(-31).ToString("d");
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand($"Select * from dbo.Customer where dbo.Customer.CustomerNumber IN (Select cp.CustomerNumber from dbo.Invoice cp where cp.InvoiceDate<'2021-03-3' and not cp.CustomerNumber IN (Select c.CustomerNumber from dbo.Invoice c where c.InvoiceDate>'2021-03-3'))", mySqlConnection);
            mySqlConnection.Open();
            cmd.Connection = mySqlConnection;

            string data = "";

            using (SqlDataReader QueryReader = cmd.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {
                        int membernumber = QueryReader.GetInt32(0);
                        string memberName = QueryReader.GetString(1);
                        string address = QueryReader.GetString(2);
                        string contactnumber = QueryReader.GetString(3);
                        string email = QueryReader.GetString(4);
                        string membertype = QueryReader.GetString(5);





                        data += "<tr><td> " + membernumber + "</td><td> " + memberName + "</td><td> " + address + "</td><td> " + contactnumber + "</td><td> " + email + "</td><td> " + membertype + "</td><tr> ";
                    }
                    mySqlConnection.Close();

                }
                return data;
            }
        }
    }
}