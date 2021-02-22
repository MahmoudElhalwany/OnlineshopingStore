using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace onlineShop.pages
{
    public partial class user : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["Name"] != null)
            { 
                
                
                
                accountName.InnerHtml = Application["Name"].ToString(); 
            
            }
            else Response.Redirect("Home.aspx");


        }

        protected void updateData_ServerClick(object sender, EventArgs e)
        {
        }

        protected void gotToCart_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void updateData_ServerClick1(object sender, EventArgs e)
        {

            updateArea.Style["display"] = "none";
            showUpdate.Style["display"] = "block";
        }

        protected void submitDate_ServerClick(object sender, EventArgs e)
        {
            
            string currentName = Application["Name"].ToString();
              SqlCommand com = new SqlCommand("getOldPassword", con);
              com.CommandType = CommandType.StoredProcedure;
              SqlParameter paramName = new SqlParameter() { 
               ParameterName="@value",
               Value=currentName
              };
              com.Parameters.Add(paramName);
              con.Open();
              string oldPassword = (string)com.ExecuteScalar();
              con.Close();
              string newEmail = user_email.Value;
              string newName = String.Format("{0}", Request.Form["user_name"]);
              string userOldPassword = old_password.Value;
              string newPassword = user_password.Value;
              string newCreditNumber = user_credirnumber.Value;
              string newAddress = user_address.Value;
              string Gender = user_gender.Value;

              if (userOldPassword!=oldPassword)
              {
                  Response.Write("<script>alert('Update Unsuccessful');</script>");
              }
              else
              {
                  SqlCommand com1 = new SqlCommand("updateDataUser", con);
                  com1.CommandType = CommandType.StoredProcedure;

                  SqlParameter param_name = new SqlParameter()
                  {
                      ParameterName = "@new_name",
                      Value = newName
                  };
                  com1.Parameters.Add(param_name);
                  //-------------------------------------------------------------

                  SqlParameter param_email = new SqlParameter()
                  {
                      ParameterName = "@new_email",
                      Value = newEmail
                  };
                  com1.Parameters.Add(param_email);
                  //-------------------------------------------------------------

                  SqlParameter param_newPassword = new SqlParameter()
                  {
                      ParameterName = "@new_password",
                      Value = newPassword
                  };
                  com1.Parameters.Add(param_newPassword);
                  //-------------------------------------------------------------
                  SqlParameter param_address = new SqlParameter()
                  {
                      ParameterName = "@new_address",
                      Value = newAddress
                  };
                  com1.Parameters.Add(param_address);
                  //------------------------------------------------------------
                  SqlParameter param_gender = new SqlParameter()
                  {
                      ParameterName = "@new_gender",
                      Value = Gender
                  };
                  com1.Parameters.Add(param_gender);
                  //--------------------------------------------------------------
                  SqlParameter param_credit = new SqlParameter()
                  {
                      ParameterName = "@new_creditCard",
                      Value = newCreditNumber
                  };
                  com1.Parameters.Add(param_credit);
                  //--------------------------------------------------------------

                  con.Open();
                  int effectedRows=(int)com1.ExecuteNonQuery();
                  con.Close();
                  if (effectedRows != 0)
                      Response.Write("<script>alert('Update successful');</script>");
              }
          

        }

        protected void signOut_ServerClick(object sender, EventArgs e)
        {
            Application["logOut"] = "1";
            Response.Redirect("Home.aspx");

        }
    }
}