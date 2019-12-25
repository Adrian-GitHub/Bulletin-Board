<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegistrationPage.aspx.cs" Inherits="BulletinBoard.LoginRegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beyond Board - Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/stylisationCSS.css" rel="stylesheet" />
</head>
<body style="background-image:url('Images/abendstimmung-atmospheric-background-531872.jpeg')">
    <form id="form1" runat="server">
        <div class="panel-img imagePosition">            
            <img src="Images/panel.png" />
            &nbsp;&nbsp;</div>
        <div>
            <div> <!--Start of Login board -->
                <div style ="position:absolute; z-index:1;">
                    <div class="modal-body" style="margin: 30px 0px 0px 400px;"></div>
                    <div class="form-group">
                        <label for="username" style="z-index: 1; left: 680px; top: 20px; position: absolute; width: 120px;" class="control-label"><strong>Email address</strong></label><!-- Email, label. Style used for positioning -->
                        <asp:TextBox ID="usernameTextBox" style="left: 680px; top: 50px; position: absolute;" placeholder="Your email" runat="server"></asp:TextBox><!-- Username, textbox. -->
                        <asp:RequiredFieldValidator style="color:red; left: 680px; top: 75px; width: 200px; font-weight:800; position: absolute;" ID="RequiredFieldValidator1" runat="server" validationgroup="valGroup1" ControlToValidate="usernameTextBox" ErrorMessage="should not be blank !"></asp:RequiredFieldValidator> <!-- DON'T ALLOW TEXTBOX TO BE EMPTY -->
                        <span class="help-block"></span>
                    </div>
                    <div class="form-group">
                        <label for="password" style="z-index: 1; left: 680px; top: 110px; position: absolute;" class="control-label"><strong>Password</strong></label><!-- Username, label. Style used for positioning. -->
                        <asp:TextBox ID="passwordTextBox" type="password" style="left: 680px; top: 140px; position: absolute;" placeholder="Your password" runat="server"></asp:TextBox><!-- Password, textbox. -->
                        <asp:RequiredFieldValidator style="color:red; left: 680px; top: 165px; width: 200px; font-weight:800; position: absolute;" ID="RequiredFieldValidator2" runat="server" validationgroup="valGroup1" ControlToValidate="passwordTextBox" Display="Dynamic" ErrorMessage="should not be blank !"></asp:RequiredFieldValidator><!-- DON'T ALLOW TEXTBOX TO BE BLANK -->
                        <span class="help-block"></span>
                    </div>
                </div>
                <asp:Label ID="loginMessageLBL" style="background-color:black; text-shadow: 0px 0px 2px rgb(0, 0, 0); left: 680px; top: 350px; position: absolute;" Visible="False" runat="server">Wrong credentials, try again.</asp:Label>
                <asp:Button ID="loginButton" style="z-index: 1; left: 680px; top: 380px; position: absolute; height: 40px; width: 70px;" class="btn btn-success btn-block" runat="server" CausesValidation="true" ValidationGroup="valGroup1" Text="Login" OnClick="loginButton_Click" /> <!-- Login button, used Bootstrap classes to make it funky. -->
            </div><!--End of Login board -->

            <div> <!--Start of Register board , located on the same page as login board but next to it.-->
                <div style ="position:absolute; z-index:1;">
                    <div class="modal-body" style="margin: 30px 0px 0px 400px;"></div>
                    <div class="form-group">
                        <label for="registerLabel" style="z-index: 1; left: 1010px; top: 30px; position: absolute; height: 30px; width: 140px;" class="control-label"><strong>...or Register here</strong></label><!-- Register here, label. Style used for positioning -->
                        <asp:TextBox ID="regRealNameTextbox" style="left: 1010px; top: 60px; position: absolute;" placeholder="Real Name" runat="server"></asp:TextBox><!-- Real Name, textbox. -->
                        <asp:RequiredFieldValidator style="color:red; left: 1010px; top:85px; width: 200px; font-size:small; font-weight:800; position: absolute;" validationgroup="valGroup2" ID="RequiredFieldValidator3" runat="server" ControlToValidate="regRealNameTextbox" Display="Dynamic" ErrorMessage="should not be blank !"></asp:RequiredFieldValidator> <!-- Something needs to be in the textbox, otherwise throw error -->
                        <span class="help-block"></span>
                    </div>
                     <div class="form-group">
                        <asp:TextBox ID="regEmailTextbox" type="email" style="left: 1010px; top: 100px; position: absolute;" placeholder="Email address" runat="server"></asp:TextBox><!-- Email, textbox. Type changed to email, to verify it's email or not. -->
                        <span class="help-block"></span>
                    </div> 
                    <div class="form-group">
                        <asp:TextBox ID="regPasswordTextbox" type="password" style="left: 1010px; top: 140px; position: absolute;" placeholder="Password" runat="server"></asp:TextBox><!-- Password, textbox. Type changed to password to make it invisible -->
                        <asp:RequiredFieldValidator style="color:red; left: 1010px; top:165px; width: 200px; font-size:small; font-weight:800; position: absolute;" validationgroup="valGroup2" ID="RequiredFieldValidator4" runat="server" ControlToValidate="regPasswordTextbox" Display="Dynamic" ErrorMessage="should not be blank !"></asp:RequiredFieldValidator> <!-- Something needs to be in the textbox, otherwise throw error -->
                        <span class="help-block"></span>
                    </div>
                </div>          
                <asp:Label ID="registerStatusPosLBL" style="background-color:black; text-shadow: 0px 0px 2px rgb(0, 0, 0); left: 1020px; top: 355px; position: absolute;" runat="server" Visible="False"><strong>Welcome aboard !</strong></asp:Label> <!--Label used for displaying successful registration, location set just above the button -->
                <asp:Label ID="registerStatusLBL" style="background-color:black; text-shadow: 0px 0px 2px rgb(0, 0, 0); left: 1020px; top: 355px; position: absolute;" runat="server" Visible="False"><strong>Sorry, email taken.</strong></asp:Label> <!--Label used for displaying errors if record exists, location set just above the button -->
               <asp:Button ID="registerButton" style="z-index: 1; left: 1060px; top: 380px; position: absolute; height: 40px; width: 80px;" class="btn btn-success btn-block" runat="server" OnClick="registerButton_Click" CausesValidation="true" ValidationGroup="valGroup2" Text="Register" /> <!-- Login button, used Bootstrap classes to make it funky. -->
            </div><!--End of Register board -->    
        </div>
    </form>
</body>
</html>
