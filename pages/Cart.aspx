<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="onlineShop.pages.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/font-awesome.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
          <br />
    
          <!-- navBar-->
       
         <div>
            <div class="bg-dark  fixed-top na">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark float-left">
                    <a class="navbar-brand" href="#">FCIS <span>store</span></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav">
                            <li class="nav-item ">
                                <a class="nav-link" href="Home.aspx">Home <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item ">
                                <a class="nav-link" href="laptops.aspx">Laptops</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="mobile.aspx">Mobile</a>
                            </li>
                            <li class="nav-item dropdown" id="rege" runat="server">
                                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Registration </a>
                                <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                    <a class="dropdown-item" href="regesterationuser.aspx">User</a>
                                    <a class="dropdown-item" href="companyregesteration.aspx">Company</a>

                                </div>
                            </li>

                           
                            <li class="nav-item active " id="cart" runat="server">
                                <a class="nav-link " href="Cart.aspx">Cart</a>
                            </li>
                             


                        </ul>

                    </div>

                </nav>
                <!--Account Data -->
               
                 <div class="btn-group float-right b" id="account" runat="server">
                
                    <button type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span id="accountName" runat="server"></span>
                    </button>
                       <div id="Div1" class="dropdown-menu dropdown-menu-right f1" runat="server">
                       <a runat="server" onserverclick="Unnamed_ServerClick1">my page</a>
                           <br />
                            <a runat="server" onserverclick="Unnamed_ServerClick">LogOut</a>
                       
                       
                       
                    </div>
                    
                </div>

                <!--Login Area-->
                <div class="btn-group float-right b" id="login" runat="server">
                
                    <button type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span id="userNameStored" runat="server">Login</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-right f1">
                        <form class="px-4 py-3 ">
                            <div class="form-group">
                                <label for="exampleDropdownFormEmail">Email address</label>
                                <input type="email" class="form-control" style="font-size:15px" id="enterEmail" runat="server" placeholder="email@example.com"/>
                            </div>
                            <div class="form-group">
                                <label for="exampleDropdownFormPassword">Password</label>
                                <input type="password" class="form-control" id="enterPassword" runat="server" placeholder="Password"/>
                            </div>
                            <div class="form-check">
                                <label class="form-check-label">
                                    <input type="checkbox" class="form-check-input"/>
                                         Remember me
                                </label>
                            </div>
                            <button type="submit" class="btn btn-primary" id="signinButton" runat="server"  >Sign in</button>
                        </form>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">New around here? Sign up</a>
                        <a class="dropdown-item" href="#">Forgot password?</a>
                    </div>
                </div>
            </div>
        </div>
           <div class="container">  
        <h3 id="success" runat="server" class="d-none">will come after 3 days</h3></div>
              <div class="container f_slide" id="hide" runat="server">

                  <!--hear the dynamic-->
           
                    
            <button id="buybtn" class="btn btn-info float-lg-right" runat="server" onserverclick="Unnamed_ServerClick3"  >Buy Now</button>
                          
                  <div id="creditcart" class="d-none">
       <div >
         <i class="fa fa-cc-visa fa-2x"></i>
         <i class="fa fa-cc-paypal fa-2x"></i>
         <i class="fa fa-cc-mastercard fa-2x"></i>
        </div>
       

        <input id="creditcard" class="form-control w-25 float-left mr-2"/>
            
        <button id="checkvalid" class="btn btn-primary float-left" > ok</button>
    
    </div>
             </div>  
        <div id="buy" runat="server" class="container d-none w-25" style="position:absolute; z-index:100000; top:45%; left:36%; ">

            <label runat="server"  id="prices" class="form-control">

            </label>

<button class="btn btn-outline-primary float-right" runat="server" onserverclick="Unnamed_ServerClick4">sure</button>

        </div>
      
<div class="d-block  container  m-b5  ">
                <h3 >Products</h3>
                <div id="productsShow">
                    <div class="flex-row" id="adds" runat="server">
                       

                    </div>



                </div>



            </div>



            <!--Footer Area-->
                    <footer class="bg-dark ">
          <p>Copyright ©2017 </p> <h6> FCIS.Com</h6>



        </footer>   


    </div>
    </form>
    <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>
</body>
</html>
