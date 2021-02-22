<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="hello.aspx.cs" Inherits="onlineShop.pages.hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Css/StyleSheet2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container col-3 mar">
             <div class="color"></div>
       <form class="px-4 py-3 ">
                            <div class="form-group">
                                <label for="exampleDropdownFormEmail">Email address</label>
                                <input type="text" class="form-control" style="font-size:15px" id="enterEmail" runat="server" placeholder="email@example.com"/>
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
                        </form>
    </div>
    </form>

  
    
</body>
</html>
