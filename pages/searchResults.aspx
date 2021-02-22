<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchResults.aspx.cs" Inherits="onlineShop.pages.searchResults" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <link href="../Css/StyleSheet3.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    
            <div>
            <div class="bg-dark  fixed-top na">
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark float-left">
                    <a class="navbar-brand" href="#">FCIS <span>store</span></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav">
                            <li class="nav-item active">
                                <a class="nav-link" href="Home.aspx">Home <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="laptops.aspx">Laptops</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="mobile.aspx">Mobile</a>
                            </li>
                            <!--Register Option-->
                            <li class="nav-item dropdown" id="rege" runat="server">
                                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">Registration </a>
                                <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink" id="showArea" runat="server">
                                    <a class="dropdown-item" href="regesterationuser.aspx">User</a>
                                    <a class="dropdown-item" href="companyregesteration.aspx">Company</a>

                                </div>
                            </li>

                           
                            <li class="nav-item " id="cart" runat="server">
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
                       <a runat="server">Account Settings</a>
                           <br />
                            <a runat="server">LogOut</a>
                       
                       
                       
                    </div>
                    
                </div>

                <!--Login Area-->
                <div class="btn-group float-right b" id="login" runat="server">
                
                    <button runat="server" id="logs" type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span id="userNameStored" runat="server">Login</span>
                    </button>
                    <div id="log" class="dropdown-menu dropdown-menu-right f1" runat="server">
                       <div id="lo" runat="server"></div>
                        <div class="px-4 py-3 ">
                           
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
                            <button type="submit" class="btn btn-primary" id="signinButton" runat="server" onserverclick="signinButton_ServerClick">Sign in</button>
                        </div>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item"  id="showRegisterMenue" runat="server" >New around here? Sign up</a>
                        <a class="dropdown-item" href="#">Forgot password?</a>
                    </div>
                </div>
            </div>
        </div>
    
        <!--Search Area-->   
  <div class=" navbar navbar-dark bg-dark fixed-top search">
      <div class="container" runat="server">
                                
    <input class="form-control w  float-left"  placeholder="Search..." aria-label="Search" id="searchText" runat="server"/>
    <button class="btn btn-outline-success float-left goleft" type="button" id="searchProduct" runat="server" onserverclick="searchProduct_ServerClick">Search</button>
          </div>
  </div>
     
<div class="d-block  container  m-b5 ">
                <h3 >Products</h3>
                <div id="productsShow">
                    <div class="flex-row" id="adds" runat="server">
                       

                    </div>



                </div>



            </div>

    </form>
      <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>

</body>
</html>
