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
    public partial class adminpage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        public static int v= 0;
        
        public struct datacompany
        {
            public int comp_id;
            public string comp_name;
            public string comp_emil;
        }
        public struct datauser
        {
            public int user_id;
            public string user_name;
            public string user_emil;
            public int creditcard;
            public int num_product;
            public string user_address;
            public string user_gender;
        }
        public struct dataproduct_2 //contain all data product ....show by admin
        {
            public int product_id;
            public string product_name;
            public byte[] pic;
            public double price;
            public int cat_id;
            public string des;
            public int num_of_product;
            public int company_id;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["num"] = 1;
            if (Application["admin"] != null)
            {
                string x = Application["admin"].ToString();
                if (x.ToString()!="helloo")
                {
                    Response.Redirect("home.aspx");
                }


            }
            else
            {
                Response.Redirect("home.aspx");

            }
            if (Application["name"] != null)
            {
                Response.Redirect("home.aspx");
            }
            
        }

        protected void showCompData_ServerClick(object sender, EventArgs e)
        {
            List<datacompany> list_company = new List<datacompany>();
            con.Open();
            SqlCommand cmd = new SqlCommand("show_data", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            datacompany x = new datacompany();
            while (rdr.Read())
            {
                x.comp_id = (int)rdr["companyID"];
                x.comp_name = (string)rdr["companyName"];
                x.comp_emil = (string)rdr["companyEmail"];
                list_company.Add(x);
            }
            rdr.Close();
            con.Close();


            string ay;
            ay = "<table class='table'><tr><th>Id</th><th>Email</th><th>Name</th></tr>";
            for (int i = 0; i < list_company.Count; i++)
            {
                ay += "<tr>" + "<td>" + list_company[i].comp_id + "</td><td>" + list_company[i].comp_emil + "</td><td>" + list_company[i].comp_name + "</td><td>";
            }
            ay += "</table>";
            contain.InnerHtml = ay;
            v = 0;
            deleteItem.Style["display"] = "block";
            IDValue.Style["display"] = "block";
        }

        protected void showUserData_ServerClick(object sender, EventArgs e)
        {
            List<datauser> list_user = new List<datauser>();
            con.Open();
            SqlCommand cmd = new SqlCommand("show_user", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            datauser x = new datauser();
            while (rdr.Read())
            {
                x.user_id = (int)rdr["userID"];
                x.user_name = (string)rdr["userName"];
                x.user_emil = (string)rdr["userEmail"];
                if (rdr["creditNumber"] != DBNull.Value)
                {
                    x.creditcard = (int)rdr["creditNumber"];
                }
                if (rdr["numberOfProduct"] != DBNull.Value)
                    x.num_product = Convert.ToInt32(rdr["numberOfProduct"]);
                if (rdr["Gender"] != DBNull.Value)
                    x.user_gender = (string)rdr["Gender"];
                if (rdr["userAddress"] != DBNull.Value)
                    x.user_address = (string)rdr["userAddress"];
                list_user.Add(x);
            }
            rdr.Close();
            con.Close();


            string ay;
            ay = "<table class='table'><tr><th>Id</th><th>Name</th><th>Email</th><th>creditNumber</th><th>Number Of Product</th><th>User Address</th><th>User Gender</th></tr>";
            for (int i = 0; i < list_user.Count; i++)
            {
                ay += "<tr>" + "<td>" + list_user[i].user_id + "</td><td>" + list_user[i].user_name + "</td><td>" + list_user[i].user_emil + "</td><td>" +list_user[i].creditcard+"</td><td>"+list_user[i].num_product+"</td><td>"+list_user[i].user_address+"</td><td>"+list_user[i].user_gender+"</td><td>";
            }
            ay += "</table>";
            contain.InnerHtml = ay;
            v = 1;
            deleteItem.Style["display"] = "block";
            IDValue.Style["display"] = "block";
        }

        protected void showProductData_ServerClick(object sender, EventArgs e)
        {
            List<dataproduct_2> list_product = new List<dataproduct_2>();
            con.Open();
            SqlCommand cmd = new SqlCommand("show_product", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataproduct_2 x = new dataproduct_2();
                x.product_id = (int)rdr["Product_ID"];
                x.des = (string)rdr["Descriptions"];
                x.product_name = (string)rdr["Product_Name"];
                x.pic = (byte[])rdr["Product_Pic"];
                x.price = Convert.ToDouble(rdr["Product_Price"]);
                x.cat_id = (int)rdr["Cat_ID"];
                x.num_of_product = (int)rdr["num_of_product"];
                x.company_id = (int)rdr["Company_ID"];
                list_product.Add(x);
            }
            rdr.Close();
            con.Close();
            v = 2;

            
            string ay; 
            int lnth = list_product.Count / 30;
            int asa=((int)Session["num"]-1)*30;
            ay = "<table class='table'><tr><th>Id</th><th>Name</th><th>Price</th><th>Descriptions</th><th>Number Of Product</th><th>Category ID</th><th>Company ID</th></tr>";
            for (int i =asa ; i < asa+30&&i<list_product.Count; i++)
            {
                ay += "<tr>" + "<td>" + list_product[i].product_id + "</td><td>" + list_product[i].product_name + "</td><td>" + list_product[i].price + "</td><td>" + list_product[i].des + "</td><td>" + list_product[i].num_of_product + "</td><td>" + list_product[i].cat_id + "</td><td>" + list_product[i].company_id + "</td><td>";
                
           }
                ay += "</table>";
                contain.InnerHtml = ay;
            
        }

        protected void deleteItem_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IDValue.Value);
            SqlCommand cmd = new SqlCommand("DeleteData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramID = new SqlParameter()
            {
                ParameterName = "@IDval",
                Value=id
            };
            cmd.Parameters.Add(paramID);
            SqlParameter paramD = new SqlParameter()
            {
                ParameterName = "@x",
                Value = v
            };
            cmd.Parameters.Add(paramD);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Session["num"]=e.CommandArgument;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            
        }
       
    }
}