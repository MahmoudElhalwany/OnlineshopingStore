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
using System.IO;

namespace onlineShop
{
    public class loginClass
    {
        public static int count = 0, cnt = 0;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7Q14GL7\SQLEXPRESS;Initial Catalog=OnlineShopStore;Integrated Security=True");
  
       
       public void login(string email, string password)
        {
            try
            {
               
                Check(email, password);
                if (email.Contains('@') && email.Length != 0 && password.Length != 0)
                {
                    if (count == 1 || cnt == 1)
                    {//application ["comoruser"]=com or user
                        string Name;
                        if (count == 1)
                            Name = getUserName(email, true);
                        else
                            Name = getUserName(email, false);
                   //     HttpContext.Current.Response.Write("<script>alert('login successful');</script>");
                       
                        HttpContext.Current.Application["Name"] = Name;
                        if(cnt==1)
                        HttpContext.Current.Application["cat"] = "com";
                        else if(count==1)
                            HttpContext.Current.Application["cat"] = "use";
                        
                         HttpContext.Current.Response.Redirect("Home.aspx");

                    }
                    else
                    {
                        HttpContext.Current.Response.Write("<script>alert('login unsuccessful');</script>");

                    }

                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('login unsuccessful');</script>");

                }
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Error');</script>");

            }





        }
 
        protected void Check(string email, string password)
        {

            con.Open();
            string query = "loginCheck" + "'" + email + "' ,'" + password + "'";
            string query2 = "loginCheckInCompanyData" + "'" + email + "' ,'" + password + "'";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = con;
            count = (int)cmd.ExecuteScalar();
            SqlCommand com = new SqlCommand(query2);
            com.Connection = con;
            cnt = (int)com.ExecuteScalar();
            con.Close();
        }
        protected string getUserName(string email, bool valueForName)
        {
            string Name = "";
            con.Open();
            string query = "getNameOfUser" + "'" + email + "'";
            string query2 = "getNameOfCompany" + "'" + email + "'";
            SqlCommand cmd, com;
            if (valueForName == true)
            {
                cmd = new SqlCommand(query);
                cmd.Connection = con;
                Name = (string)cmd.ExecuteScalar();
            }
            else
            {
                com = new SqlCommand(query2);
                com.Connection = con;
                Name = (string)com.ExecuteScalar();
            }


            con.Close();
            return Name;
        }
        public int getCount()
        {
            return count;

       }



    }
}