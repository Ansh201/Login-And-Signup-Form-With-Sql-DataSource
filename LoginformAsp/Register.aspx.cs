using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;

namespace LoginformAsp
{
    public partial class Register : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs2"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection(cs);
            string query = "insert into signup values(@fname,@lname,@gender,@email,@address,@username,@password)";
            SqlCommand cmd=new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@fname",FirstNameTextBox.Text);
            cmd.Parameters.AddWithValue("@lname", LastNameTextBox.Text);
            cmd.Parameters.AddWithValue("@gender",DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
            cmd.Parameters.AddWithValue("@address", AddressTextBox.Text);
            cmd.Parameters.AddWithValue("@username", UserNameTextBox.Text);
            cmd.Parameters.AddWithValue("@password", PasswordTextBox.Text);
            con.Open(); 
            int a=cmd.ExecuteNonQuery();
            if (a > 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "script", "alert('Signup Sucessfull..Your User name is  :" + UserNameTextBox.Text + "and Password  is:" + PasswordTextBox.Text + "');",true);
                clearControls();

            }
            else {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>alert('Signup failed!!!')</script>");
            }
           con.Close();
         }
        void clearControls()
        {
            FirstNameTextBox.Text = LastNameTextBox.Text = EmailTextBox.Text = AddressTextBox.Text = UserNameTextBox.Text = PasswordTextBox.Text = ConfirmPasswordTextBox.Text = " ";
            DropDownList1.ClearSelection();

}

    }
}