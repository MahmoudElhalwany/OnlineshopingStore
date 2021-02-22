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
    public partial class Home : System.Web.UI.Page
    {
         loginClass obj = new loginClass();
         products pro = new products();
         string cameFromCompany;
         protected void Page_Load(object sender, EventArgs e)
         {
             pro.product_load();
             load_p();
             if (Application["logOut"] != null)
             {
                 if (Application["logOut"].ToString() == "1")
                 {
                     account.Style["display"] = "none";
                     userNameStored.InnerHtml = "Login";
                     login.Style["display"] = "block";
                     rege.Style["display"] = "block";
                     cart.Style["display"] = "none";
                     Application["name"] = null;
                     Application["logOut"] = null;

                 }
             }

             cart.Style.Add("display", "none");
             account.Style.Add("display", "none");
             if (Application["value"] != null)
                 cameFromCompany = Application["value"].ToString();
             // open Register Drob Down
             if (Session["openRegisterMenue"] != null)
             {
                 if ((int)Session["openRegisterMenue"] == 1)
                 {
                     showArea.Attributes["class"] = showArea.Attributes["class"].ToString() + " show";
                     rege.Attributes["class"] = rege.Attributes["class"].ToString() + " show";
                     navbarDropdownMenuLink.Attributes["aria-expanded"] = "true";
                     Session["openRegisterMenue"] = null;
                 }
             }
             if (Application["name"] != null)
             {//check com or user to remove home and open mange page of company :)
                 string name = Application["name"].ToString();
                 if (name != null)
                 {
                     rege.Style.Add("display", "none");
                     login.Style.Add("display", "none");
                     cart.Style.Remove("display");
                     account.Style.Remove("display");
                     accountName.InnerHtml = name;

                 }
             }
             else if (Application["please"] != null || cameFromCompany == "1")
             {
                 log.Attributes["class"] = log.Attributes["class"].ToString() + " show";

                 login.Attributes["class"] = login.Attributes["class"].ToString() + " show";
                 logs.Attributes["aria-expanded"] = "true";
                 Application["please"] = null;
                 Application["value"] = null;
                 if (cameFromCompany != "1")
                     lo.InnerHtml = " <h6 style='color:red;'>please login first to see your cart</h6> ";
                     cameFromCompany = "0";

             }

         }
        protected void signinButton_ServerClick(object sender, EventArgs e)
        {
           
                string email = enterEmail.Value;
                string password = enterPassword.Value;
                obj.login(email,password);                
                if(Application["name"]!=null)
                        userNameStored.InnerHtml = "Welcome "+Application["name"].ToString();
          }
        struct c
        {
            public dataproduct x;
            public string y;
        }

        public void load_p()
        {

            string add = "";
            int i = 0;


            add += @"<div class='carousel-item active'><div class='row'>";
            foreach (var key in pro.product.Keys)
            {
                if (pro.product[key].count == 0)
                    continue;
                if (i < 18)
                {


                    add += @"<div class=' col-2  q flex-row'><div class='s bg-light text-center d-inline-block ' id='productsShow' style='height:308px;'>";



                    add += @"
                         <img src='data:image/png;base64," + Convert.ToBase64String(pro.product[key].pic) + @"' style='padding:10px 0 5px 24px;' class='d-block' /><h6 >" + key + @"</h6>";

                    add += @"<p >price:" + pro.product[key].price + @"</p>
                                    <asp:Button ID='Button1' runat='server' Text='Add to cart'  />
                                   <a  class='btn btn-primary' href='getValueOfProduct.aspx?id=" + i + "&key=" + key + "&page=Home' value='" + key + @"'>Add To Cart</a >
                                    </div></div>";

                }
                if (i == 5 || i == 11)
                {
                    add += "</div></div>";
                    add += @"<div class='carousel-item '><div class='row'>";
                }
                if (i >= 18)
                    break;


                i++;
            }
            add += "</div></div>";
            slideradds.InnerHtml = add;

        }



        

       
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (obj.getCount() == 0)
                Response.Redirect("company.aspx");
            else
            {
               
                Response.Redirect("user.aspx"); 
            }
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            account.Style["display"] = "none";
            userNameStored.InnerHtml = "Login";
            login.Style["display"] = "block";
            rege.Style["display"] = "block";
            cart.Style["display"] = "none";
            Application["name"] = null;
          //  Response.Redirect("Home.aspx");
        }

        protected void showRegisterMenue_ServerClick(object sender, EventArgs e)
        {
            Session["openRegisterMenue"] = 1;
            Response.Redirect("Home.aspx");   

        }

        protected void gotoMobile_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("mobile.aspx");
        }

        protected void gotoLaptop_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("laptops.aspx");
        }

        protected void searchProduct_ServerClick(object sender, EventArgs e)
        {
            searchClass findProducts = new searchClass();
            string value = searchText.Value;
            findProducts.searchButton(value);
        }
    }
}
