<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPosts.aspx.cs" Inherits="BulletinBoard.ViewPosts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beyond Board - View Posts</title>
    <!-- Latest compiled and minified CSS (Bootstrap) -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
		<!-- End of Bootstrap -->
		<link href="css/stylisationCSS.css" rel="stylesheet" />
</head>
<body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/pexels-photo-289326.jpeg')">
    <form id="form1" runat="server">
        <div>
				<asp:Label style="left: 1715px; top: 0px;  font-size:medium; position: absolute;" class="label label-info" ID="welcomeUsernameLabel" text="Welcome" runat="server"/><!--Greeting label, displaying Real Name of a user. -->
                <asp:Button style="left: 1715px; top: 25px; position:absolute;" class="btn btn-info" ID="PanelOpenButton" runat="server" OnClick="PanelOpenButton_Click" Text="Your Settings" /> <!-- Settings panel, button -->
                <asp:Button style="left: 1630px; top: 0px; position:absolute;" CssClass="btn btn-danger" ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" /><!--Add logout button -->
                <asp:Button style="left: 1650px; top: 370px; position:absolute;" CssClass="btn btn-danger" ID="goBackButton" runat="server" Text="Go Back" OnClick="goBackButton_Click" />
                <asp:Button style="left: 1650px; top: 320px; position:absolute;" CssClass="btn btn-primary" ID="addNewPostButton" runat="server" Text="Add New Post" OnClick="addNewPostButton_Click" /><!-- Add post button-->
				<div style="left:400px; top:90px; position:absolute;" class="container">
					<h2 class="h2Style">Beyond Board</h2>
					<p style="width: 1172px;" class="textStyle">Recent posts... </p>     
                    <asp:Label ID="htmlLabel" runat="server" Text="Label"></asp:Label> <!-- HTML LABEL, DISPLAYS ALL DATA-->
					</div>
				</div>        
    </form>
</body>
</html>
