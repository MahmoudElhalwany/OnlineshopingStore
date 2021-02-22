using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace onlineShop.pages
{
    public partial class getValueOfProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {if(Application["Name"]==null)
        {
            Application["please"]="a";
            Response.Redirect("home.aspx");
        }
            string name = Application["Name"].ToString();
            string pro_name = Request.QueryString["key"];
            string a = Request.QueryString["page"] + ".aspx";
            SqlCommand com = new SqlCommand("getIdOfUser", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter param_N = new SqlParameter()
            {
                ParameterName = "@user_N",
                Value = name
            };
            com.Parameters.Add(param_N);
            con.Open();
            int idOfUser = (int)com.ExecuteScalar();
            con.Close();
            SqlCommand com1 = new SqlCommand("getIdOfProduct", con);
            com1.CommandType = CommandType.StoredProcedure;
            SqlParameter param_P = new SqlParameter()
            {
                ParameterName = "@name_N",
                Value=pro_name
            };
            com1.Parameters.Add(param_P);
            con.Open();
            int idOfProduct = (int)com1.ExecuteScalar();
            con.Close();
            //---------------------------------------------------
            SqlCommand cmd = new SqlCommand("saveInCart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param_IdUser = new SqlParameter()
            {
                ParameterName = "@id_user",
                Value =idOfUser
            };
            cmd.Parameters.Add(param_IdUser);

            SqlParameter param_Idpro = new SqlParameter()
            {
                ParameterName = "@id_prod",
                Value = idOfProduct
            };
            cmd.Parameters.Add(param_Idpro);
            //------------------------------------------------------------------------

            con.Open();
            int x = (int)cmd.ExecuteNonQuery();
            con.Close();
            if (x!=0)
            {
            Response.Redirect(a + "?id=" + Request.QueryString["id"]);  
            }
        }
    }
}