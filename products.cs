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
    public class products
    {
        public Dictionary<string, dataproduct> product = new Dictionary<string, dataproduct>();
         public List<data> cartPro = new List<data>();

       SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7Q14GL7\SQLEXPRESS;Initial Catalog=OnlineShopStore;Integrated Security=True");
       public void load_l(string name)
       {
         SqlCommand cmd = new SqlCommand("getIdOfUser",con);
           cmd.CommandType=CommandType.StoredProcedure;
           SqlParameter paramN=new SqlParameter()
           {
               ParameterName="@user_N",
               Value=name
       
           };
           cmd.Parameters.Add(paramN);
           con.Open();
           int idOfuser=(int)cmd.ExecuteScalar();
           con.Close();
             SqlCommand cmd1 = new SqlCommand("getCartProducts",con);
           cmd1.CommandType=CommandType.StoredProcedure;
           SqlParameter paramF=new SqlParameter()
           {
               ParameterName="@userIDN",
               Value=idOfuser
       
           };
           cmd1.Parameters.Add(paramF);
           con.Open();
           SqlDataReader red = cmd1.ExecuteReader();    
            data pro = new data();
            while (red.Read())
            {

                pro.productPicture = (byte[])red["Product_Pic"];
                pro.productPrice =Convert.ToInt32(red["Product_Price"]);
                pro.productDescriptions = (string)red["Descriptions"];
                pro.productPieces = (int)red["num_of_product"];
                pro.productCategory = red["Cat_ID"].ToString();
                pro.productName = red["Product_Name"].ToString();
                cartPro.Add(pro);
            }
            red.Close();
            con.Close();
            HttpContext.Current.Application["carts"] = cartPro;
       }
        
        public void product_load(int idofcom=0,int cat=0)
        {
            con.Open();
            SqlCommand cmd;
            if (cat == 0&&idofcom!=0)
            {

                cmd = new SqlCommand("get_prod", con);
                SqlParameter paramID = new SqlParameter()
                {
                    ParameterName="@id",
                    Value=idofcom

                };
                cmd.Parameters.Add(paramID);
            }
            else if (cat != 0 && idofcom!=0)
            {
                cmd = new SqlCommand("get_prod;2 '" + idofcom + "' ,' " + cat + "'", con);

            }
            else if(cat==0&&idofcom==0)
            {
                cmd = new SqlCommand("get_prod;4" , con);
            }
            
            else 
            {
                cmd = new SqlCommand("get_prod;3 '"+ cat + "'", con);

            }

            SqlDataReader red = cmd.ExecuteReader();    

            while (red.Read())
            {
                dataproduct pro = new dataproduct();

                pro.pic = (byte[])red["Product_Pic"];
                pro.price = Convert.ToDouble(red["Product_Price"]);
                pro.des = (string)red["Descriptions"];
                pro.count = (int)red["num_of_product"];
                if (cat == 0)
                    pro.cat = (int)red["Cat_ID"];

                product[(string)red["Product_Name"]] = pro;
            }
            red.Close();
            con.Close();
           
            
           

        }
    }
}