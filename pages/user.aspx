<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="onlineShop.pages.user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/font-awesome.css" rel="stylesheet" />
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <link href="../Css/StyleSheet3.css" rel="stylesheet" />
    <link href="../Css/StyleSheet4.css" rel="stylesheet" />
    <style>
        .goleft {
    margin-right:148px;
}
    </style>

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
                            <li class="nav-item ">
                                <a class="nav-link" href="Home.aspx">Home <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" href="laptops.aspx">Laptops</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="mobile.aspx">Mobile</a>
                            </li>
                            

                           
                            <li class="nav-item " id="cart" runat="server">
                                <a class="nav-link " href="Cart.aspx">Cart</a>
                            </li>
                        </ul>

                    </div>

                </nav>
               

        <div class="btn-group float-right b" id="account" runat="server">
                
                    <button type="button" class="btn btn-dark dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span id="accountName" runat="server"></span>
                    </button>
                       <div id="Div1" class="dropdown-menu dropdown-menu-right f1" runat="server">
                            <a runat="server" id="signOut" onserverclick="signOut_ServerClick">LogOut</a>  
                    </div>
                    
                </div>

                 </div>
            </div>
          <!---------------------------------------------------------------------------------------------->
       
   

      <!--Search Area-->   
     <div class=" navbar navbar-dark bg-dark fixed-top search">
      <div class="container">                           
     <input class="form-control w  float-left" type="search" placeholder="Search" aria-label="Search"/>
    <button class="btn btn-outline-success float-left goleft" type="submit">Search</button>
          </div>
  </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <!--Update User Data-->
    <div class="con container"  id="updateArea" runat="server">
           
        <div class="gotoCenter">
        <button type="button" class="btn btn-outline-success w-100" id="updateData" runat="server" onserverclick="updateData_ServerClick1">Update Data</button>
        <br />
        <br />
        <br />
        <br />
        <br />
        <button type="button" class="btn btn-outline-success w-100" id="gotToCart" runat="server" onserverclick="gotToCart_ServerClick">Go To Cart</button>
        </div>
    </div>
    
    <div id="showUpdate" runat="server" class="makeBox container" style="display:none;">

        <h6>Your Email</h6>
       
         <input id="user_email" runat="server" class="form-control" placeholder="Enter New Email" required="required" />
        <br />

        <h6>New Name</h6>
        
         <input  id="user_name" runat="server" class="form-control" placeholder="Enter New Name" name="userName" required="required" />
        
        <br />
        <h6>Old Password</h6>
        
         <input type="password" id="old_password" runat="server" class="form-control" placeholder="Enter Old Password" name="oldPass" required="required"/>


        <br />
        <h6>New Password</h6>
        
         <input type="password" id="user_password" runat="server" class="form-control" placeholder="Enter New Password" nam="newPass" required="required"/>


        <br />
        <h6>New Credit Number</h6>
        
         <input type="text" id="user_credirnumber" runat="server" class="form-control" placeholder="Enter New Credit Number" name="credit" required="required"/>


        <br />
        <h6>New Adreess</h6>
        
         <input type="text" id="user_address" runat="server" class="form-control" placeholder="Enter New Address" name="address" required="required"/>

        <br />
        <h6> Gender</h6>
     
         <input type="text" id="user_gender" runat="server" class="form-control" placeholder="Male Or Female" name="gender" required="required"/>

        <br />
        <button type="button" class="btn btn-outline-success btn-lg btn-block" id="submitDate" runat="server" onserverclick="submitDate_ServerClick">Submit Data</button>

    </div>

        </form>

    
    <script src="../Js/popper.min.js"></script>
    <script src="../Js/jquery-3.2.1.min.js"></script>
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/JavaScript1.js"></script>


</body>
</html>
