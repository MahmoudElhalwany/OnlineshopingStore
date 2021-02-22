using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineShop.pages
{
    public partial class laptops : System.Web.UI.Page
    {
       
        
        loginClass obj = new loginClass();
    
        products products_obj = new products();
        protected void Page_Load(object sender, EventArgs e)
        {
            products_obj.product_load(0, 1);
            
                load_p();
                //if (Request.QueryString["id"] != null) 
                //Response.Redirect("#divv" + Request.QueryString["id"]);
            cart.Style.Add("display", "none");
            account.Style.Add("display", "none");
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

        }

        protected void login_ServerClick(object sender, EventArgs e)
        {
            string email = enterEmail.Value;
            string password = enterPassword.Value;
            obj.login(email, password);
            if (Application["name"] != null)
                userNameStored.InnerHtml = "Welcome " + Application["name"].ToString();

        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            account.Style["display"] = "none";
            userNameStored.InnerHtml = "Login";
            login.Style["display"] = "block";
            rege.Style["display"] = "block";
            cart.Style["display"] = "none";
            Application["name"] = null;
        }
         public void load_p(){
        
       string add="";
         int i = 0;
            foreach (var key in products_obj.product.Keys)
            {
                if (products_obj.product[key].count == 0)
                    continue;
               
                add += @"<div id='divv"+i+"' class='d-inline-block bg-white bo-1' data-toggle='tooltip'  data-placement='top' title='price:" + products_obj.product[key].price;
                    add +=  @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(products_obj.product[key].pic) +
                             @"'  class='d-block lapt' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + key + @"</h6>
                       </div><a  class='btn btn-primary' href='getValueOfProduct.aspx?id=" + i + "&key=" + key + "&page=laptops' value='" + key + "'>Add To Cart</a ></div>";
                    i++;
               

            }
            //<button id='BtnID" + i + "' class='btn btn-primary' runat='server' onserverclick='saveInCard_ServerClick' value='" + key + "'>Add to my Cart</button>
           adds.InnerHtml = add;
        }

       

        protected void saveInPasket_ServerClick(object sender, EventArgs e)
        {
          
            Response.Write("<script>alert('login unsuccessful');</script>");


        }

        protected void findPro_ServerClick(object sender, EventArgs e)
        {
            searchClass findProducts = new searchClass();
            string value = searchText.Value;
            findProducts.searchButton(value);
        }
    }
}