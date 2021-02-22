using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public struct dataproduct
{
   public byte[] pic;
   public double price;
   public int count;
   public string des;
   public int cat;
}
namespace onlineShop.pages
{ 
    public partial class company : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=OnlineShopStore;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["name"] == null)
                Response.Redirect("Home.aspx");
                accountName.InnerHtml = Application["Name"].ToString();

            if (Session["name"] != null)
                product_load((int)Session["name"]);
            else
                product_load();
        }
        public void product_load(int cat=0)
        {

            Dictionary<string, dataproduct> companypro = new Dictionary<string, dataproduct>();
            string name =accountName.InnerText;
            SqlCommand cmd = new SqlCommand("select companyID from CompanyData where companyName ='" + name + "'",con);
           
            con.Open();
            int id = (int)cmd.ExecuteScalar();
            SqlCommand cmd1 ;
            if (cat == 0)
            {
               cmd1 = new SqlCommand("get_prod '" + id + "'", con);
            }
            else
            {
                 cmd1 = new SqlCommand("get_prod;2 '" + id + "' ,' "+cat+"'", con);

            }
            SqlDataReader red = cmd1.ExecuteReader();
            while (red.Read())
            {
                dataproduct pro = new dataproduct();
                pro.pic =(byte[]) red["Product_Pic"];
                pro.price = Convert.ToDouble(red["Product_Price"]);
                pro.des =(string) red["Descriptions"];
                pro.count =(int) red["num_of_product"];
                if(cat==0)
                pro.cat = (int)red["Cat_ID"];
                companypro[(string)red["Product_Name"]] = pro;
            }

            con.Close();
            string add="";
            foreach (var key in companypro.Keys)
            {
                if (cat == 1)
                {
                    add+=@" <div class='d-inline-block bg-white bo-1' data-toggle='tooltip'  data-placement='top' title='price:" + companypro[key].price;
                }
                if (cat != 1 && companypro[key].cat == 1)
                {
                    add += @" <div class='d-inline-block bg-white bo-1 lapp' data-toggle='tooltip'  data-placement='top' title='price:" + companypro[key].price;
                }
                if (companypro[key].cat == 1||cat==1)
                {
                    add +=  @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(companypro[key].pic) +
                             @"'  class='d-block lapt' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + key + @"</h6>
                       </div> </div>";
                }
                else
                {
                    add += @" <div class='d-inline-block bg-white bo-1 'data-toggle='tooltip'  data-placement='top'  title='price:" + companypro[key].price + @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(companypro[key].pic) +
                                @"'  class='d-block ' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" + key + @"</h6>
                       </div> </div>";

                }
            }
           adds.InnerHtml = add;

        }

        protected void laptops_ServerClick(object sender, EventArgs e)
        {
            Session["name"] = 1;
            productsShow.Style["display"] = "block";
            showAddProductField.Style["display"] = "none";
            productID.Style["display"] = "none";
            Page_Load(sender, e);
        }

        protected void nav_ServerClick(object sender, EventArgs e)
        {
            Session["name"] = 0;
            productsShow.Style["display"] = "block";
            showAddProductField.Style["display"] = "none";
            productID.Style["display"] = "none";
            Page_Load(sender, e);
        }

        protected void mob_ServerClick(object sender, EventArgs e)
        {
            Session["name"] = 2;
            productsShow.Style["display"] = "block";
            showAddProductField.Style["display"] = "none";
            productID.Style["display"] = "none";
            Page_Load(sender, e);

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

        }

        protected void addProduct_ServerClick(object sender, EventArgs e)
        {
            addpro.Style["display"] = "block";
            Application["show"] = "true";
            showAddProductField.Style["display"] = "block";
            productsShow.Style["display"] = "none";
            editpro.Style["display"] = "none";
            hideporComp.Style["display"] = "block";
            hideproCat.Style["display"] = "block";
            pro_ID.Style["display"] = "none";
            productID.Style["display"] = "none";

        }

        protected void deleteProduct_ServerClick(object sender, EventArgs e)
        {
            showAddProductField.Style["display"] = "none";
            productID.Style["display"] = "block";
            productsShow.Style["display"] = "none";
        }

        protected void editProduct_ServerClick(object sender, EventArgs e)
        {
            editpro.Style["display"] = "block";
            // Application["show"] = "true";
            showAddProductField.Style["display"] = "block";
            productsShow.Style["display"] = "none";
            addpro.Style["display"] = "none";
            hideporComp.Style["display"] = "none";
            hideproCat.Style["display"] = "none";
            pro_ID.Style["display"] = "block";
            productID.Style["display"] = "none";


        }

        protected void addpro_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string pro_Name = product_name.Value;
                string pro_price = product_price.Value;
                string pro_cat = product_cat.Value;
                string pro_des = product_des.Value;
                string pro_num = product_num.Value;
                string pro_comp = product_comp.Value;

                HttpPostedFile postedFile = fileupload.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtention = Path.GetExtension(fileName);
                int fileSize = postedFile.ContentLength;
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] b = binaryReader.ReadBytes((int)stream.Length);
                if (pro_Name.Length != 0 && pro_price.Length != 0 && pro_cat.Length != 0 && pro_des.Length != 0 && pro_num.Length != 0 && pro_comp.Length != 0 && b.Length != 0)
                {
                    // get The Id For Category
                    SqlCommand obj = new SqlCommand("getIDofCat", con);
                    obj.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramCatName = new SqlParameter()
                    {
                        ParameterName = "@nameOfCat",
                        Value = pro_cat
                    };
                    obj.Parameters.Add(paramCatName);
                    con.Open();
                    int CatID = (int)obj.ExecuteScalar();
                    con.Close();

                    // get ID for Company 

                    SqlCommand getID = new SqlCommand("getCompanyID", con);
                    getID.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramcompName = new SqlParameter()
                    {
                        ParameterName = "@companyNameIn",
                        Value = pro_comp
                    };
                    getID.Parameters.Add(paramcompName);
                    con.Open();
                    int CompID = (int)getID.ExecuteScalar();
                    con.Close();



                    SqlCommand com = new SqlCommand("addProduct", con);
                    com.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramName = new SqlParameter()
                    {
                        ParameterName = "@nameOfPro",
                        Value = pro_Name
                    };
                    com.Parameters.Add(paramName);
                    SqlParameter paramPrice = new SqlParameter()
                    {
                        ParameterName = "@priceOfPro",
                        Value = pro_price
                    };
                    com.Parameters.Add(paramPrice);
                    SqlParameter paramCat = new SqlParameter()
                    {
                        ParameterName = "@Cat_ID",
                        Value = CatID
                    };
                    com.Parameters.Add(paramCat);
                    SqlParameter paramDes = new SqlParameter()
                    {
                        ParameterName = "@desOfPro",
                        Value = pro_des
                    };
                    com.Parameters.Add(paramDes);

                    SqlParameter paramNum = new SqlParameter()
                    {
                        ParameterName = "@numOfPro",
                        Value = pro_num
                    };
                    com.Parameters.Add(paramNum);
                    SqlParameter paramComp = new SqlParameter()
                    {
                        ParameterName = "@companyID",
                        Value = CompID
                    };
                    com.Parameters.Add(paramComp);
                    SqlParameter paramPicture = new SqlParameter()
                    {
                        ParameterName = "@picOfPro",
                        Value = b
                    };
                    com.Parameters.Add(paramPicture);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Successful')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Unsuccessful')</script>");

                }

            }

            catch
            {
                Response.Write("<script>alert('Please Fill All Data')</script>");

            }


        }

        protected void editpro_ServerClick(object sender, EventArgs e)
        {
            string pro_ID = product_ID.Value;
            string pro_Name = product_name.Value;
            string pro_price = product_price.Value;
            string pro_des = product_des.Value;
            string pro_num = product_num.Value;

            HttpPostedFile postedFile = fileupload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtention = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            byte[] b = binaryReader.ReadBytes((int)stream.Length);




            SqlCommand com = new SqlCommand("editProducts", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter paramName = new SqlParameter()
            {
                ParameterName = "@nameOfProduct",
                Value = pro_Name
            };
            com.Parameters.Add(paramName);
            SqlParameter paramPrice = new SqlParameter()
            {
                ParameterName = "@priceOfProduct",
                Value = pro_price
            };
            com.Parameters.Add(paramPrice);


            SqlParameter paramDes = new SqlParameter()
            {
                ParameterName = "@desOfProduct",
                Value = pro_des
            };
            com.Parameters.Add(paramDes);

            SqlParameter paramNum = new SqlParameter()
            {
                ParameterName = "@numberOfProducts",
                Value = pro_num
            };
            com.Parameters.Add(paramNum);


            SqlParameter paramPicture = new SqlParameter()
            {
                ParameterName = "@pictureOfProduct",
                Value = b
            };
            SqlParameter paramproductID = new SqlParameter()
            {
                ParameterName = "@IdOfProduct",
                Value = pro_ID
            };
            com.Parameters.Add(paramproductID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update Successful')</script>");
        }

        protected void deleteProduct1_ServerClick(object sender, EventArgs e)
        {
            string pid = idever.Value;

            SqlCommand com = new SqlCommand("drop_product", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlParameter paramID = new SqlParameter()
            {
                ParameterName = "@IdOfPro",
                Value = pid

            };
            com.Parameters.Add(paramID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            Response.Write("Delete Successful')</script>");

        }

        protected void signOut_ServerClick(object sender, EventArgs e)
        {
            Application["logOut"] = "1";
            Response.Redirect("Home.aspx");
        }
    }
   
}