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
    public partial class companyregesteration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signupCompany_ServerClick(object sender, EventArgs e)
        {
            string nameOfCompany = companyName.Value;
            string emailOfCompany = companyEmail.Value;
            string passwordOfCompany = companyPassword.Value;
            string repPassword = repeatPassword.Value;
            bool isDuplicate = Check(emailOfCompany,true);
            bool isDup = Check(nameOfCompany, false);
            if (isDup&&isDuplicate&&passwordOfCompany==repPassword&&emailOfCompany.Contains('@')&&passwordOfCompany.Length!=0&&repPassword.Length!=0&&nameOfCompany.Length!=0&&emailOfCompany.Length!=0)
            {
                con.Open();
                string query = "addRowinCompanyData" + "'" + nameOfCompany + "' ,'" + emailOfCompany+ "' ,'" +passwordOfCompany + "'";
                SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                Server.Transfer("Home.aspx");

            }
            else
            {
                wrongdata.InnerHtml = "Invalid Data";

            }



        }

        protected bool Check(string email,bool bol)
        {
            con.Open();
            string query = "validData" + "'" + email + "',"+bol+"";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = con;
            int count = (int)cmd.ExecuteScalar();
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