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
public struct data
{
    public string productName;
    public byte[] productPicture;
    public float productPrice;
    public string productCategory;
    public string productDescriptions;
    public int productPieces;
    public string productCompanyName;
};

namespace onlineShop
{
    public class searchClass
    {
        public int x;
        static List<string> searchLine = new List<string>();
        static public List<data> finalReasult = new List<data>();
      


        static public Dictionary<string, List<data>> top = new Dictionary<string, List<data>>();

       
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7Q14GL7\SQLEXPRESS;Initial Catalog=OnlineShopStore;Integrated Security=True");
        public void searchButton(string value)
        {

            top.Clear();
            searchLine.Clear();
            if (value.Length == 0)
            {
                HttpContext.Current.Response.Write("<script>alert('Search Unsuccessful')</script>");
                return;
            }
            string s = "";
            for (int i = 0; i < value.Length; i++)
            {

                if (value[i] != ' ')
                    s += value[i];
                else
                {
                    searchLine.Add(s);
                    s = "";
                }
            }
            con.Open();
            if (s != "") searchLine.Add(s);

            for (int i = 0; i < searchLine.Count; i++)
            {
                List<data> rdrProduct = new List<data>();
                rdrProduct.Clear();
                SqlCommand com = new SqlCommand("searchEngine", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter paramValue = new SqlParameter()
                {
                    ParameterName = "@value",
                    Value = searchLine[i]
                };
                com.Parameters.Add(paramValue);

                SqlDataReader rdr = com.ExecuteReader();
                data readData = new data();
                while (rdr.Read())
                {

                    readData.productName = (string)rdr["Product_Name"];
                    readData.productPicture = (byte[])rdr["Product_Pic"];
                    readData.productPrice = Convert.ToInt32(rdr["Product_Price"]);
                    int cat_id = Convert.ToInt32(rdr["Cat_ID"]);
                    readData.productCategory = cat_id.ToString();
                    /*   SqlCommand comm = new SqlCommand("getCategoryName", con);
                       comm.CommandType = CommandType.StoredProcedure;
                       SqlParameter paramID = new SqlParameter()
                       {
                           ParameterName = "@catID",
                           Value = cat_id
                       };
                       comm.Parameters.Add(paramID);
                       string catName=(string)comm.ExecuteScalar();*/
                    // readData.productCategory = catName;
                    readData.productDescriptions = (string)rdr["Descriptions"];
                    readData.productPieces = (int)rdr["num_of_product"];

                    int comp_id = (int)rdr["Company_ID"];
                    readData.productCompanyName = comp_id.ToString();
                    /*SqlCommand commm=new SqlCommand("getCompanyName",con);
                    comm.CommandType=CommandType.StoredProcedure;
                    SqlParameter paramcompID = new SqlParameter()
                    {
                    ParameterName = "@compID",
                    Value = comp_id
                    };
                    commm.Parameters.Add(paramcompID);
                    string compName = (string)commm.ExecuteScalar();*/
                    //  readData.productCompanyName = compName;
                    rdrProduct.Add(readData);
                }
                rdr.Close();
                s = searchLine[i];
                top[s] = rdrProduct;

            }
            con.Close();

            //get InterSection Rows;
            int q = 0;
            foreach (var key in top.Keys)
            {
                if (q == 0)
                {
                    finalReasult = top[key];
                    q = 1;
                }
                else
                    finalReasult = getIntersect(finalReasult, top[key]);
            }
            HttpContext.Current.Response.Redirect("searchResults.aspx");
        }

        protected List<data> getIntersect(List<data> l1, List<data> l2)
        {
            List<data> ans = new List<data>();
            for (int i = 0; i < l1.Count; i++)
            {
                for (int j = 0; j < l2.Count; j++)
                {
                    if (l1[i].productName == l2[j].productName)
                    {
                        ans.Add(l1[i]);
                        break;

                    }
                }
            }
            return ans;
        }

        public void getli()
        {
            HttpContext.Current.Application["list"] = finalReasult;


        }
    }
}