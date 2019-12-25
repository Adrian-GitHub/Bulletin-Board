<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error404.aspx.cs" Inherits="BulletinBoard.Error404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beyond Board - 404</title>
    <!-- Latest compiled and minified CSS (Bootstrap) -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
		<!-- End of Bootstrap -->
</head>
<body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/404errorNotLoggedIn.png')">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="TakeMeHomeBUTTON" runat="server" OnClick="TakeMeHomeBUTTON_Click" style="left:740px; top:650px; position:absolute; " CssClass="btn btn-success btn-lg" Text="Take me home! I'm ready to follow the right path!" />
        </div>
    </form>
</body>
</html>
