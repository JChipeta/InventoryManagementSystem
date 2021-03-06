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
    public partial class InsertOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
    
            
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;

            SqlConnection mySqlConnection = new SqlConnection(connectionstring);

            mySqlConnection.Open();
            SqlCommand cmd = new SqlCommand($"Insert into dbo.Product values('{itemnametb.Text}','{descriptiontb.Text}','{pricetb.Text}','{categorytb.Text}')", mySqlConnection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            int itemNumber = 0;


            SqlCommand selectcommand = new SqlCommand($"Select * from dbo.Product where ProductName='{itemnametb.Text}'", mySqlConnection);

            using (SqlDataReader QueryReader = selectcommand.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {
                  

                    while (QueryReader.Read())
                    {

              
                         itemNumber = QueryReader.GetInt32(0);   



                    }


                }

              
            }
         

            selectcommand.ExecuteNonQuery();

            selectcommand.Dispose();
            SqlCommand insertcommand = new SqlCommand($"Insert into dbo.Stock values({itemNumber},{int.Parse(quantitytb.Text)},'{DateTime.Now.ToString("d")}')", mySqlConnection);
            insertcommand.ExecuteNonQuery();

            insertcommand.Dispose();



           

                //Display success message.
                string message = "Product Added Successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            //empty text after message
                itemnametb.Text = "";
                descriptiontb.Text = "";
                pricetb.Text = "";
                categorytb.Text = "";
                quantitytb.Text = "";
;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;

            SqlConnection mySqlConnection = new SqlConnection(connectionstring);

            mySqlConnection.Open();
            SqlCommand cmd = new SqlCommand($"Insert into dbo.Customer values('{membernametb.Text}','{addresstb.Text}','{contactnumbertb.Text}','{emailtb.Text}','{membertypetb.Text}')", mySqlConnection);

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            //Insert record here.

            //Display success message.
            string message = "Customer Added Successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            //empty text field after message
            membernametb.Text = "";
            addresstb.Text = "";
            contactnumbertb.Text = "";
            emailtb.Text = "";
            membertypetb.Text = "";




        }

        protected void Button3_Click(object sender, EventArgs e) {
            string itemcode = DropDownList1.SelectedValue.ToString();



            int quantity = 0;
            int Quantity = 0;
            if (quantitytb0.Text != "")
            {
                quantity = int.Parse(quantitytb0.Text);
            }
            string connectionstring = ConfigurationManager.ConnectionStrings["StockManagement_databaseConnectionString"].ConnectionString;
            SqlConnection mySqlConnection = new SqlConnection(connectionstring);
            mySqlConnection.Open();
            SqlCommand selectcommand = new SqlCommand($"Select * from dbo.Stock where ProductCode = '{itemcode}' ", mySqlConnection);

            selectcommand.Connection = mySqlConnection;
            string data = "";

            using (SqlDataReader QueryReader = selectcommand.ExecuteReader())
            {
                if (QueryReader.HasRows)
                {

                    while (QueryReader.Read())
                    {

                        Quantity = QueryReader.GetInt32(2) + quantity;
                        string StockPurchaseDate = QueryReader.GetString(3);



                    }


                }

             


            }

            SqlCommand commandd = new SqlCommand($"Update dbo.Stock set Quantity={Quantity}, StockPurchaseDate='{DateTime.Now.ToString("d")}' where ProductCode='{itemcode}'", mySqlConnection);
            commandd.ExecuteNonQuery();
            commandd.Dispose();
            mySqlConnection.Close();

            //Insert record here.

            //Display success message.
            string message = "Stock Added Successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            quantitytb0.Text = "";


        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}