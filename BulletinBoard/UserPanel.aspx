<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPanel.aspx.cs" Inherits="BulletinBoard.UserPanel" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title>Beyond Board - User Settings</title>
      <!-- Latest compiled and minified CSS (Bootstrap) -->
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
      <!-- End of Bootstrap -->
      <link href="css/stylisationCSS.css" rel="stylesheet" />
   </head>
   <body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/pexels-photo-289326.jpeg')">
      <form id="form1" runat="server">
         <div>
            <asp:Label style="left: 1715px; top: 0px; font-size:medium; position: absolute;" class="label label-info" ID="welcomeUsernameLabel" text="Welcome" runat="server"/>  <!--Greeting label, displaying Real Name of a user. -->
            <asp:Button style="left: 1630px; top: 0px; position:absolute;" CssClass="btn btn-danger" ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" /> <!--Add logout button -->
            <asp:Button style="left: 1650px; top: 370px; position:absolute;" CssClass="btn btn-danger" ID="goBackButton" runat="server" Text="Go Back" OnClick="goBackButton_Click" />
            <div style="left:400px; top:90px; position:absolute;" class="container">
               <h2 class="h2Style">Beyond Board</h2>
               <div style="top:150px; position:absolute;" class="container">
                  <p style="width: 1172px; text-align:center;" class="textStyle">Your info... </p>
               </div>
               <div style="top:30px; position:absolute;" class="container">
                  <asp:Label ID="htmlLabel" runat="server" Text="Label"></asp:Label>
                   <asp:Label ID="Label1" style="left: 160px; top:265px; background-color:lawngreen; color: black;  position:absolute; font-size:larger;" runat="server" Visible="true" Text="Change your password here! ==>>"></asp:Label>
          <asp:Label ID="changePasswordLabel" style="left: 440px; top:295px; background-color:lawngreen; color: black;  position:absolute;" runat="server" Visible="false" Text="Password changed!"></asp:Label>
          <asp:TextBox ID="changePasswordTextbox" inputType="password" style="left: 440px; top:265px; position:absolute;" placeholder="Your new password" runat="server" TextMode="Password"></asp:TextBox>
          <asp:Button ID="changePasswordButton" style="left:640px;top:265px;  position:absolute;" class="btn btn-success" runat="server" OnClick="changePasswordButton_Click" Text="Change password!" />
               </div>
               <div style="top:350px; position:absolute;" class="container">
                  <p style="width: 1172px; text-align:center; background-color: blanchedalmond; color:black;"class="textStyle">Posts made by you... </p>
               </div>
               <div style="top:215px; position:absolute;" class="container" >
                  <asp:Label ID="htmlLabel2" runat="server" Text="Label"></asp:Label>
               </div>
            </div>
         </div>
      </form>
   </body>
</html>