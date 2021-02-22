<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="company.aspx.cs" Inherits="onlineShop.pages.company" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company</title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/font-awesome.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <link href="../Css/StyleSheet3.css" rel="stylesheet" />
    <style>
        #productsShow img{
    width:100px;
    height:170px;
    margin:auto;

}

        #productsShow div {
    min-width:100px;
}


    </style>


</head>
<body>
   

        <!-- navBar-->

        <div>
            <div class="bg-dark  fixed-top na">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark float-left">
                    <a class="navbar-brand" id="nav" runat="server" onserverclick="nav_ServerClick">FCIS <span>store</span></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav">
                           
                            <li class="nav-item  ">
                                <a class="nav-link" id="laptops" runat="server" onserverclick="laptops_ServerClick">My Laptops</a>
                            </li>
                            <li class="nav-item ">
                                <a class="nav-link" id="mob" runat="server" onserverclick="mob_ServerClick">My Mobiles</a>
                            </li>
                        </ul>
                    </div>
                </nav>
                <!--Account Data -->

                <div class="btn-group float-right b" id="account" runat="server">

                   
                    <button runat="server" id="logs" type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                       <span id="accountName" runat="server"></span>
                    </button>
                      <div id="log" class="dropdown-menu dropdown-menu-right f1" runat="server">
                       <div id="lo" runat="server"></div>
                        <a runat="server" onserverclick="Unnamed_ServerClick">My Message</a>
                          <br />
                          <a runat="server" id="signOut" onserverclick="signOut_ServerClick">LogOut</a>
                       
                    </div>

                </div>

              
                
            </div>
        </div>
    <!--------------------------------------------------------------------------------------------------------->

     <form id="form1" runat="server">
         <!--Add or Delete or Edit Button -->
        <div class="container ">
            <div class=" ma-l">
            <button id="addProduct" runat="server" onserverclick="addProduct_ServerClick" class="btn btn-primary com_btn"> <i class="fa fa-product-hunt"></i> add prdouct</button>
            <button id="deleteProduct" runat="server" onserverclick="deleteProduct_ServerClick" class="btn btn-danger com_btn"> <i class="fa fa-eraser"></i> Delete prdouct</button>
             <button id="editProduct" runat="server" onserverclick="editProduct_ServerClick" class="btn btn-success com_btn"> <i class="fa fa-edit"></i> Edit prdouct</button>
                 </div>

            <!--Product Area Of Company-->
            <div class="d-block mt-3">
                <div id="productsShow" runat="server">
                <h3 >My Products</h3>
                    <div class="flex-row" id="adds" runat="server">
                    </div>
                </div>
            </div>
            <!---------------------------------------------------------------->

            <!--Add And Edit Product-->
            <div id="showAddProductField" runat="server" class="container" style="display: none">
            
            <div id="pro_ID" runat="server" style="display:none">
            <h6>Product ID</h6>
            <input type="text" id="product_ID" runat="server" class="form-control" placeholder="Product Name" aria-label="Product ID" aria-describedby="basic-addon1" />
                       <br />
                 </div>
            <h6>Product Name</h6>
            <input type="text" id="product_name" runat="server" class="form-control" placeholder="Product Name" aria-label="Username" aria-describedby="basic-addon1" />

            <br />
            <h6>Product Price</h6>
            <input type="text" id="product_price" runat="server" class="form-control" placeholder="Product Price" aria-label="Username" aria-describedby="basic-addon1" />

            <br />
            <div id="hideproCat" runat="server">
            <h6>Category Name</h6>
            <input type="text" id="product_cat" runat="server" class="form-control" placeholder="Category Name" aria-label="Username" aria-describedby="basic-addon1" />
            <br />
            </div>
           
            <h6>Product Description</h6>
            <input type="text" id="product_des" runat="server" class="form-control" placeholder="Product Description" aria-label="Username" aria-describedby="basic-addon1" />

            <br />
            <h6>Number Of Porducts</h6>
            <input type="text" id="product_num" runat="server" class="form-control" placeholder="Number Of Porducts" aria-label="Username" aria-describedby="basic-addon1" />

            <br />
             <div id="hideporComp" runat="server">
            <h6>Name Of Company</h6>
            <input type="text" id="product_comp" runat="server" class="form-control" placeholder="Name Of Company" aria-label="Username" aria-describedby="basic-addon1" />
            <br />
            </div>
            <h6>Product Picture</h6>
            <asp:FileUpload ID="fileupload" runat="server" />

            <br />
            <button type="button" class="btn btn-primary btn-lg btn-block" id="addpro" runat="server" onserverclick="addpro_ServerClick" style="display:none">Add Product</button>
            <button type="button" class="btn btn-primary btn-lg btn-block" id="editpro" runat="server"  onserverclick="editpro_ServerClick" style="display:none">Update Product</button>
        </div>
     <!------------------------------------------------------------------------------------->

        <!--Delete Area-->
        <div id="productID" runat="server" style="display:none" class="container">
             <h6>Product ID</h6>
             <input type="text" id="idever" runat="server" class="form-control" placeholder="Product Name" aria-label="Product ID" aria-describedby="basic-addon1" />
             <button type="button" class="btn btn-primary btn-lg btn-block" id="deleteProduct1" runat="server" onserverclick="deleteProduct1_ServerClick">Delete Product</button>
            </div>



        </div>

    </form>
      <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>
</body>
</html>
