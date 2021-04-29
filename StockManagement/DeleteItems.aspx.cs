﻿using System;
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

            string connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string invoiceddate = DateTime.Now.AddDays(-100).ToString("d");
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand($"Select * from dbo.Item Join dbo.CustomerPurchase on dbo.CustomerPurchase.ItemCode=dbo.Item.ItemCode where dbo.Item.ItemCode IN (Select cp.ItemCode from dbo.CustomerPurchase cp where cp.BillingDate<'{invoiceddate}' and not cp.ItemCode IN (Select c.ItemCode from dbo.CustomerPurchase c where c.BillingDate>'{invoiceddate}'))", mySqlConnection);
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
    }
}