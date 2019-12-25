<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="BulletinBoard.AddPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beyond Board - New Post</title>
    <!-- Latest compiled and minified CSS (Bootstrap) -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
		<!-- End of Bootstrap -->
		<link href="css/stylisationCSS.css" rel="stylesheet" />
</head>
<body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/pexels-photo-289326.jpeg')">
    <form id="form1" runat="server">
        <div>
            <asp:Label style="left: 1715px; top: 0px; font-size:medium; position: absolute;" class="label label-info" ID="welcomeUsernameLabel" text="Welcome" runat="server"/><!--Greeting label, displaying Real Name of a user. -->
            <asp:Button style="left: 1715px; top: 25px; position:absolute;" class="btn btn-info" ID="PanelOpenButton" runat="server" OnClick="PanelOpenButton_Click" Text="Your Settings" /> <!-- Settings panel, button -->
            <asp:Button style="left: 1630px; top: 0px; position:absolute;" CssClass="btn btn-danger" ID="logoutButton" runat="server" Text="Logout" /><!--Add logout button -->
            <asp:Button style="left: 1050px; top: 450px; position:absolute;" CssClass="btn btn-primary" ID="addNewPostButton" runat="server" Text="Add Post" OnClick="addNewPostButton_Click" /><!--Add post button -->
            <div style="left:400px; top:90px; position:absolute;" class="container">
					<h2 class="h2Style">Beyond Board</h2>
                <p style="width: 1172px;" class="textStyle">Adding new post? Make it interesting ;)... </p>                     
                </div>
            <asp:Label style="background-color:black; left:850px; top: 430px; position:absolute;" ID="SuccesspostLABEL" runat="server" Text="Success! Share it on facebook, inform your friends! Let's get reading!" Visible="False"></asp:Label> <!-- success, post added label-->
            <asp:Button style="left: 1150px; top: 450px; position:absolute;" ID="goBackBUTTON" class="btn btn-danger" runat="server" Text="Go Back" OnClick="goBackBUTTON_Click" /> <!-- go back, to the previous page button -->
            <asp:TextBox style="left:850px; top: 450px; position:absolute;" ID="newPostTextBox" runat="server"></asp:TextBox> <!-- Textbox for new post. -->
        </div>
    </form>
</body>
</html>
