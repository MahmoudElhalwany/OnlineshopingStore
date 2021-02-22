<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="mobile.aspx.cs" Inherits="onlineShop.pages.mobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>mobiles</title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
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
    <form id="form1" runat="server">
    <div >
    
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
                            <li class="nav-item">
                                <a class="nav-link" href="laptops.aspx">Laptops</a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="mobile.aspx">Mobile</a>
                            </li>
                            <li class="nav-item dropdown" id="rege" runat="server">
                                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Registration </a>
                                <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
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
                       <a runat="server" id="goToUser" href="user.aspx">Account Settings</a>
                           <br />
                            <a runat="server" id="signOut" onserverclick="signOut_ServerClick">LogOut</a>
                       
                       
                       
                    </div>



                </div>

                <!--Login Area-->
                <div class="btn-group float-right b" id="login" runat="server">
                
                    <button type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span id="userNameStored" runat="server">Login</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-right f1">
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
                            <button type="submit" class="btn btn-primary" id="signinButton" runat="server" onserverclick="signinButton_ServerClick" >Sign in</button>
                        </div>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item" href="#">New around here? Sign up</a>
                        <a class="dropdown-item" href="#">Forgot password?</a>
                    </div>
                </div>
            </div>
        </div>


        <!--Search Area-->
        <div class=" navbar navbar-dark bg-dark fixed-top search">
      <div class="container">
                                
    <input class="form-control w-75 " type="search" placeholder="Search" aria-label="Search" id="searchText" runat="server"/>
    <button class="btn btn-success bt" type="submit" id="findProd" runat="server" onserverclick="findProd_ServerClick">Search</button>
          </div>
  </div>

        <!--Slider Area-->

            <div class="container-fluid f_slide ">
               
                    <div id="carouselExampleIndicators" class="carousel slide  f_slid" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner ">
                            <div class="carousel-item active ">
                                <img class="d-block w-100" src="../pics/l.png" alt="First slide">
                                <div class="carousel-caption d-none d-md-block">
                                    <h3>Lap</h3>
                                    <p>top</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100" src="../pics/m.jpg" alt="Second slide">
                                <div class="carousel-caption d-none d-md-block">
                                    <h3>Lap</h3>
                                    <p>top</p>
                                </div>
                            </div>
                            <div class="carousel-item">
                                <img class="d-block w-100" src="../pics/in.png" alt="Third slide">
                                <div class="carousel-caption d-none d-md-block">
                                    <h3>Lap</h3>
                                    <p>top</p>
                                </div>
                            </div>
                        </div>
                        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                    
                </div>
            </div>


       
        <div class="d-block mt-3 container">
                <h3 >Products</h3>
                <div id="productsShow">
                    <div class="flex-row" id="adds" runat="server">
                       

                    </div>



                </div>



            </div>
         <div class="blur"></div>
        <div class="newwindow"></div>
         <!--Footer Area-->
                    <footer class="bg-dark ">
          <p>Copyright ©2017 </p> <h6> FCIS.Com</h6>
                        </footer>
                           <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>


    
    </form>
</body>
</html>
