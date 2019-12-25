<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boards.aspx.cs" Inherits="BulletinBoard.Boards" %>

	<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Beyond Board - Home</title>
		<!-- Latest compiled and minified CSS (Bootstrap) -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
		<!-- End of Bootstrap -->
		<link href="css/stylisationCSS.css" rel="stylesheet" />
	</head>
	<body style="background-attachment:fixed; background-repeat:no-repeat; background-image:url('Images/pexels-photo-289326.jpeg')">
		<form id="form1" runat="server">
			<div>
				<asp:Label style="left: 1715px; top: 0px; font-size:medium; position: absolute;" class="label label-info" ID="welcomeUsernameLabel" text="Welcome" runat="server"/><!--Greeting label, displaying Real Name of a user. -->
                <asp:Button style="left: 1715px; top: 25px; position:absolute;" class="btn btn-info" ID="PanelOpenButton" runat="server" OnClick="PanelOpenButton_Click" Text="Your Settings" />
                <asp:Button style="left: 1630px; top: 0px; position:absolute;" CssClass="btn btn-danger" ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click" /><!--Add logout button -->
                <asp:Button style="left: 1650px; top: 320px; position:absolute;" CssClass="btn btn-primary" ID="addNewBoardButton" runat="server" Text="Create New Board" OnClick="addNewBoardButton_Click" /><!--Add board button -->
				<div style="left:400px; top:90px; position:absolute;" class="container">
					<h2 class="h2Style">Beyond Board</h2>
					<p style="width: 1172px;" class="textStyle">What's happening right now?... </p>            
					<asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand">
						<HeaderTemplate> <!-- Header -->
							<table class="table table-hover" style="top: 170px; position:absolute;">	
									<tr style="color: black;     background-color:#d3d3d3;   opacity: 0.7;">
										<th><asp:Label ID="Label0" runat="server">Board ID</asp:Label></th>
										<th><asp:Label ID="Label1" runat="server">Board Title</asp:Label></th>
										<th><asp:Label ID="Label2" runat="server">Creator ID</asp:Label></th>
										<th><asp:Label ID="Label3" runat="server">Date Created</asp:Label></th>
										<th><asp:Label ID="Label4" runat="server">Time Created</asp:Label></th>
									</tr>
								</HeaderTemplate>
								<ItemTemplate>		 <!-- Middle -->					
									<tr>
										<td style="color: white;     background-color:#000000;   opacity: 0.7;">
											<asp:Label ID="ID_Label" runat="server" Text=""></asp:Label>
										</td>
										<td style="color: white;     background-color:#000000;   opacity: 0.7;">
											<asp:Label ID="Name_Label" runat="server" Text=""></asp:Label>
										</td>
										<td style="color: white;     background-color:#000000;   opacity: 0.7;">
											<asp:Label ID="CreatorID_Label" runat="server" Text=""></asp:Label>
										</td>
										<td style="color: white;     background-color:#000000;   opacity: 0.7;">
											<asp:Label ID="DateCreated_Label" runat="server" Text=""></asp:Label>
										</td>
										<td style="color: white;     background-color:#000000;   opacity: 0.7;">
											<asp:Label ID="TimeCreated_Label" runat="server" Text=""></asp:Label>
										</td>
                                        <td>
                                            <asp:Button class="btn btn-success" ID="ViewButton" runat="server" Text="View" />
                                        </td>
									</tr>
								</ItemTemplate>
								<FooterTemplate> <!-- Footer classified as bottom. -->
								</table>
							</FooterTemplate>
						</asp:DataList>
					</div>
				</div>		
			</form>
		</body>
	</html>
	