<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="companyregesteration.aspx.cs" Inherits="onlineShop.pages.companyregesteration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>registeration</title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lobster" rel="stylesheet"/>
    <link href="../Css/StyleSheet2.css" rel="stylesheet" />


</head>
<body>
   
        

    <form runat="server">
       
     
        <a href="Home.aspx"><img src="../pics/logoPicture.PNG" /></a>
         <div class="container col-3" runat="server">
             <div class="color"></div>
        <h3 class="chSize"> Campany account </h3>
   <label>Campany Name</label>
    <input class="form-control border-dark p h-25" type="text" placeholder="Enter Company Name" name="username" required="required" id="companyName" runat="server"/>

        <label>Company Email</label>
    <input class="form-control border-dark p  h-25" type="text" placeholder="Enter Company Email" name="email" required="required" id="companyEmail" runat="server"/>

    <label>Password</label>
    <input  class="form-control border-dark p  h-25" type="password" placeholder="Enter Password" name="psw" required="required" id="companyPassword" runat="server"/>

    <label>Repeat Password</label>
    <input class="form-control border-dark p  h-25" type="password" placeholder="Repeat Password" name="psw-repeat" required="required" id="repeatPassword" runat="server" />
  
    <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

    <div class="clearfix">
     
      <button type="submit" class="btn btn-outline-primary" id="signupCompany" runat="server" onserverclick="signupCompany_ServerClick" >Sign Up</button>
    </div>
             <div id="wrongdata" runat="server"></div>
             <br />
             <a id="openLoginAuto" runat="server" onserverclick="openLoginAuto_ServerClick">Already have an account</a>


  </div>
        
        </form>
    
      <footer class="bg-dark ">
          <p>Copyright ©2017 </p> <h6> FCIS.Com</h6>
        </footer> 
   
        <script src="../Js/jquery-3.2.1.min.js"></script>
        <script src="../Js/popper.min.js"></script>
        <script src="../Js/bootstrap.min.js"></script>

</body>
</html>

