<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="BulletinBoard.DeleteUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beyond Board - Delete User</title>
    <!-- Latest compiled and minified CSS (Bootstrap) -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
		<!-- End of Bootstrap -->
		<link href="css/stylisationCSS.css" rel="stylesheet" />
</head>
<body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/pexels-photo-289326.jpeg')">
    <form id="form1" runat="server">
        <div>
            <asp:Label style="left: 1715px; top: 0px; font-size:medium; position: absolute;" class="label label-info" ID="welcomeUsernameLabel" text="Welcome" runat="server"/><!--Greeting label, displaying Real Name of a user. -->
           <asp:Button style="left: 1630px; top: 0px; position:absolute;" CssClass="btn btn-danger" ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" /><!--Add logout button -->
            <asp:Button style="left: 1650px; top: 370px; position:absolute;" CssClass="btn btn-danger" ID="goBackButton" runat="server" Text="Go Back" OnClick="goBackButton_Click" />
            <div style="left:400px; top:90px; position:absolute;" class="container">
					<h2 class="h2Style">Beyond Board</h2>
                    <p style="width: 1172px; text-align:center;" class="textStyle">User Management Area </p> 
                <div style="background-color:wheat;"><asp:Label style="top:10px;" ID="userIDlabel" runat="server" Text=""></asp:Label>
                <asp:Label style="top:20px;" ID="Namelabel" runat="server" Text=""></asp:Label>
                <asp:Label style="top:30px;" ID="usernameLabel" runat="server" Text=""></asp:Label>
                <asp:Label style="top:40px;" ID="usertypeLabel" runat="server" Text=""></asp:Label>
        <asp:Label style="top:50px;" ID="userPasswordLabel" runat="server" Text=""></asp:Label>
        <asp:Label style="top:60px;" ID="userLastLoginDatelabel" runat="server" Text=""></asp:Label>
        <asp:Label style="top:70px;" ID="userLastLoginTimelabel" runat="server" Text=""></asp:Label></div> 
                <p style="width: 1172px; top:130px; text-align:center; background-color:darkturquoise" class="textStyle">Are you sure you want to delete the user? </p>                 
                <asp:Button style="left:300px; top:150px;" ID="deleteButton" CssClass="btn btn-danger" runat="server" Text="Yes" OnClick="deleteButton_Click" />
        <asp:Button style="left:300px; top:150px;" ID="dontDeleteButton" runat="server" CssClass="btn btn-success" Text="No" OnClick="dontDeleteButton_Click" />
                <asp:Label style="left:350px; top: 150px; background-color:black; color:red; font-weight:700; font-size-adjust:initial;" ID="statusINFOlbl" runat="server" Visible="false" Text="USER DELETED"></asp:Label>
                </div>
        </div>
    </form>
</body>
</html>
