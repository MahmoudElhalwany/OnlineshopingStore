using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;


namespace onlineShop.pages
{
    public partial class registerForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signupButton_Serverclick(object sender, EventArgs e)
        {
            
            string userName=nameOfUser.Value;
            string userEmail=emailOfUser.Value;
            string userPassword=passwordOfUser.Value;
            string repeatOne=repeatPassword.Value;
            bool isDuplicate=Check(userEmail,true);
            bool isDpu = Check(userName, false);
          if (isDpu&&isDuplicate && userEmail.Contains('@') && userPassword == repeatOne && userPassword.Length != 0 && repeatOne.Length != 0)
             {
                    con.Open();
                    string query = "addRow" + "'" + userName+ "' ,'" + userEmail + "' ,'" + userPassword + "'";
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Server.Transfer("Home.aspx");
              }
            else
            {
                wrongRegister.InnerHtml = "wrong Data";

            }


        }
         protected bool Check(string value,bool bol)
        {
            con.Open();
            
            SqlCommand cmd = new SqlCommand("noRepetition",con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlParameter parmaValue = new SqlParameter()
            {
                ParameterName = "@inputEmail",
                Value = value
            };
            cmd.Parameters.Add(parmaValue);

            SqlParameter parmaBool = new SqlParameter()
            {
                ParameterName = "@b",
                Value = bol
            };
            cmd.Parameters.Add(parmaBool);
            int count = Convert.ToInt32 (cmd.ExecuteScalar());
            con.Close();
            if (count == 0) return true;
            else
            {
                return false;
            }
        }

         protected void openLoginAuto_ServerClick(object sender, EventArgs e)
         {
             Application["value"] = "1";
             Response.Redirect("Home.aspx");
         }

    }
}