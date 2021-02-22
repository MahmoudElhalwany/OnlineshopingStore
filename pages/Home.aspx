<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="onlineShop.Home" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fcis Store</title>
   
     <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/font-awesome.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />

    <style>
               .goleft {
    margin-right:148px;
}


    </style>


</head>
<body>
    <form id="form1" runat="server">
      
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
                       <a runat="server" onserverclick="Unnamed_ServerClick">Account Settings</a>
                           <br />
                            <a runat="server" onserverclick="Unnamed_ServerClick1">LogOut</a>
                       
                       
                       
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
                            <button type="submit" class="btn btn-primary" id="signinButton" runat="server" onserverclick="signinButton_ServerClick" >Sign in</button>
                        </div>
                        <div class="dropdown-divider"></div>
                        <a class="dropdown-item"  id="showRegisterMenue" runat="server" onserverclick="showRegisterMenue_ServerClick">New around here? Sign up</a>
                        <a class="dropdown-item" href="#">Forgot password?</a>
                    </div>
                </div>
            </div>
        </div>
    
        <!--Search Area-->   
  <div class=" navbar navbar-dark bg-dark fixed-top search">
      <div class="container">
                                
    <input class="form-control w  float-left"  placeholder="Search..." aria-label="Search" id="searchText" runat="server"/>
    <button class="btn btn-outline-success float-left goleft" type="button" id="searchProduct" runat="server" onserverclick="searchProduct_ServerClick">Search</button>
          </div>
  </div>
     

        <!--Slider Area-->
        <div class="container-fluid f_slide">
            <div class="row bg-white">
                <div id="carouselExampleIndicators" class="carousel slide col-8 f_slid" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                    </ol>
                    <div class="carousel-inner slid">
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
                        <span class="fa fa-angle-double-left fa-lg bg-dark"></span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                      <span class="fa fa-angle-double-right fa-lg bg-dark"></span>
                    </a>
                   
                </div>
                <div class="col-4">
                    <div class="hot container">
                        <div class="a"><a>Whats Hot?</a></div>
                        <div class="lap">
                            <a>Laptops</a>
                            <div>
                                <button class="btn btn-primary py-sm" id="gotoLaptop" runat="server" onserverclick="gotoLaptop_ServerClick">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/item.jpg" /></div>
                        </div>
                        <div class="lap">
                            <a>Mobile</a>
                            <div>
                                <button class="btn btn-primary py-sm" id="gotoMobile" runat="server" onserverclick="gotoMobile_ServerClick">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/SGs8.jpg" /></div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
      

          <!--Second Slider Area-->
          <div class="container-fluid">


            <div id="carouselExampleIndicators1" class="carousel slide " data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                
                <h3 id="populer">Populer</h3>
                <div class="carousel-inner  container-fluid " id="slideradds" runat="server">
                    <div class="carousel-item active">
                        
                          <div class="row  ">
                            <div class=" col-2  q">
                                <div class="s bg-light text-center" style="height:308px;">
                                    <img src="../pics/22.png" style="padding:10px 0 5px 24px;" class="d-block" />
                                    <h6 >name of product</h6>
                                    <p >price:20020</p>
                                    <button class="byn btn-primary" runat="server"  >Add to cart</button>
                                    </div></div>

                    </div>
                        </div>
                    <div class="carousel-item">
       <div class="row  ">
                            <div class=" col-4  q">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <asp:Button ID='Button1' runat='server' Text='Add to cart' OnClientClick='heehhehe()' />
                                            <button  class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>

                                </div>
                            </div>
                            <div class="  col-4  q">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                </div>

                            </div>
                            <div class="  col-4  q ">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                </div>

                            </div>
                        </div>
    </div>
    <div class="carousel-item">
        <div class="row  ">
                            <div class=" col-4  q">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>

                                </div>
                            </div>
                            <div class="  col-4  q">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                </div>

                            </div>
                            <div class="  col-4  q ">
                                <div class="s bg-white">
                                    <div class="a"><a>Whats Hot?</a></div>
                                    <div class="lap">
                                        <a>Laptops</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1iQugdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                    <div class="lap">
                                        <a>Mobile</a>
                                        <div>
                                            <button class="btn btn-primary py-sm">show more details</button><img class="float-right" style="width: 76px; height: 76px;" src="../pics/TB1EAGgdyqAXuNjy1XdXXaYcVXa-88-88.jpg" /></div>
                                    </div>
                                </div>

                            </div>
                        </div>
    </div>
               
               
            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators1" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators1" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
         </div>
      


      



        <footer class="bg-dark ">
          <p>Copyright ©2017 </p> <h6> FCIS.Com</h6>



        </footer>   
          
    </form>
    <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>

</body>
</html>
