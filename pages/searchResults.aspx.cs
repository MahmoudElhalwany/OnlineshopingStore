using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlineShop.pages
{
    public partial class searchResults : System.Web.UI.Page
    {
           loginClass obj = new loginClass();
           searchClass findProducts = new searchClass();
        protected void Page_Load(object sender, EventArgs e)
           {
               findProducts.getli();
               if (Application["list"] != null)
                   load_p();
             
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

        protected void signinButton_ServerClick(object sender, EventArgs e)
        {

            string email = enterEmail.Value;
            string password = enterPassword.Value;
            obj.login(email, password);
            if (Application["name"] != null)
                userNameStored.InnerHtml = Application["name"].ToString();
        }

        public void load_p()
        {  List<data> finall = (List<data>)Application["list"];


            string add = "";
            int i = 0;
            for (int j=0;j< finall.Count;j++)
            {
                if (finall[i].productPieces==0)
                    continue;
                if (finall[i].productCategory == "2")
                {
                    add += @" <div id='divv" + i + "' class='d-inline-block bg-white bo-2 'data-toggle='tooltip'  data-placement='top'  title='price:" + finall[i].productPrice + @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(finall[i].productPicture) +
                                    @"'  class='d-block ' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + finall[i].productName + @"</h6>
                       </div><a class='btn btn-primary' href='getValueOfProduct.aspx?id=" + i + "&key=" + finall[i].productName + "&page=searchresults' value='" + finall[i].productName + "'>Add To Cart</a ></div>";
                 
                }
                else{
                    add += @"<div id='divv" + i + "' class='d-inline-block bg-white bo-1' data-toggle='tooltip'  data-placement='top' title='price:" + finall[i].productPrice;
                add += @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(finall[i].productPicture) +
                         @"'  class='d-block lapt' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + finall[i].productName + @"</h6>
                       </div><a  class='btn btn-primary' href='getValueOfProduct.aspx?id=" + i + "&key=" + finall[i].productName + "&page=searchresults' value='" + finall[i].productName + "'>Add To Cart</a ></div>";
            }
                i++;

            }
            adds.InnerHtml = add;

        }


        protected void searchProduct_ServerClick(object sender, EventArgs e)
        {
            
            string value = searchText.Value;
            findProducts.searchButton(value);
        }
    }
}