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
    public partial class Cart : System.Web.UI.Page
    {
        loginClass obj = new loginClass();
        products products_obj = new products();
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            cart.Style.Add("display", "none");
            account.Style.Add("display", "none");
            string cat="";
            if (Application["cat"] != null)
            {
                 cat = Application["cat"].ToString();
            }
            if (Application["name"] != null && cat == "use")
            {//check com or user to remove home and open mange page of company :)
                string name = Application["name"].ToString();
                if (name != null)
                {
                    rege.Style.Add("display", "none");
                    login.Style.Add("display", "none");
                    cart.Style.Remove("display");
                    account.Style.Remove("display");
                    accountName.InnerHtml = name;
                    products_obj.load_l(Application["name"].ToString());
                    load_p();
          
                }

            }
            else
            {
                Application["please"] = "please login first";
                Response.Redirect("home.aspx");

            }

            if (Session["success"] != null)
            {
                if (Session["success"].ToString() == "1")
                {
                    success.Attributes["class"] = "d-block";
                    success.Style.Add("margin", "40px 0 20px 0");
                    Session["success"] = null;
                }
            }
            else
            {
               

                SqlCommand cmd = new SqlCommand("getcount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param_s = new SqlParameter()
                {

                    ParameterName = "@name",
                    Value = Application["Name"].ToString()
                };
                cmd.Parameters.Add(param_s);
                con.Open();

                //int count = (int)cmd.ExecuteScalar();
                int count = 0;

                con.Close();

                if (count == 0)
                {
                    buybtn.Style.Add("display", "none");
                    buybtn.Style.Add("color", "red");
                    success.Attributes["class"] = "";
                    success.Style.Add("margin", "40px 0 20px 0");
                    success.InnerHtml = "No products in Your cart";

                }
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            

        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            Response.Redirect("user.aspx");

        }

        protected void Unnamed_ServerClick2(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerClick3(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("buy",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param_N = new SqlParameter() {

                ParameterName = "@name",
                Value=Application["Name"].ToString()
            };
            cmd.Parameters.Add(param_N);
           
            cmd.Parameters.Add("@price", SqlDbType.Float).Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteNonQuery();
            string price =cmd.Parameters["@price"].Value.ToString();
            con.Close();
            prices.InnerHtml = "<h4>" + price + " </h4>";
            buy.Style.Add("display", "block !important");
            adds.Style.Add("display", "none");


        }
        public void load_p()
        {
            List<data> finall =(List<data>)Application["carts"];


            string add = "";
            int i = 0;
            for (int j = 0; j < finall.Count; j++)
            {
                if (finall[i].productPieces == 0)
                    continue;
                if (finall[i].productCategory == "2")
                {
                    add += @" <div id='divv" + i + "' class='d-inline-block bg-white bo-2 'data-toggle='tooltip'  data-placement='top'  title='price:" + finall[i].productPrice + @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(finall[i].productPicture) +
                                    @"'  class='d-block ' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + finall[i].productName + @"</h6>
                       </div><a class='btn btn-danger' href='deletefromcart.aspx?id=" + i + "&key=" + finall[i].productName + "&page=cart' value='" + finall[i].productName + "'>Delete</a ></div>";

                }
                else
                {
                    add += @"<div id='divv" + i + "' class='d-inline-block bg-white bo-1' data-toggle='tooltip'  data-placement='top' title='price:" + finall[i].productPrice;
                    add += @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(finall[i].productPicture) +
                             @"'  class='d-block lapt' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + finall[i].productName + @"</h6>
                       </div><a  class='btn btn-danger' href='deletefromcart.aspx?id=" + i + "&key=" + finall[i].productName + "&page=cart' value='" + finall[i].productName + "'>Delete</a ></div>";
                }
                i++;

            }
            adds.InnerHtml = add;

        }


        protected void Unnamed_ServerClick4(object sender, EventArgs e)
        {
            buybtn.Style.Add("class", "d-none");
            SqlCommand cmd = new SqlCommand("bought",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param_N = new SqlParameter()
            {

                ParameterName = "@name",
                Value = Application["Name"].ToString()
            };
            cmd.Parameters.Add(param_N);
            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();
            Session["success"] = 1;
            Response.Redirect("cart.aspx");
        }
    }
}