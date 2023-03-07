using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace LoginformAsp
{
    public partial class Login : System.Web.UI.Page
    {
        String cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            String query = "Select * from signup where username= @user COLLATE SQL_Latin1_General_CP1_CS_AS and password=@pass COLLATE SQL_Latin1_General_CP1_CS_AS";
            //Command for execute query
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", UserTextBox.Text);
            cmd.Parameters.AddWithValue("@pass", PassTextBox.Text);
            //Now open Connection

            con.Open();
            // cmd ke pass select query hai use execute krega and kuuch row return krega
            SqlDataReader dr=cmd.ExecuteReader();

            if (dr.HasRows)
            {      //create a session user to display details on other pages
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Login Successful!!')</script");
                Session["user"] = UserTextBox.Text;
               
                Response.Redirect("Dashboard.aspx");

            }
            else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Login Failed!!')</script");

            }
            con.Close();
           }
       
             
        
        }
    
    }
