using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class UserPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }
                changePasswordLabel.Visible = false; //invisible on page load.
                SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");
                SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");

                string name = Request.Cookies["userName"].Value; //fetching value from cookie which is valid only for 2 hours.
                welcomeUsernameLabel.Text += " " + name;

                string userID = Application["userID"].ToString(); //fetching user's id.

                string html = ""; //declaring string which will be used to output information on the screen

                html += "<table class=\"table table-hover\" style=\"top: 170px; position: absolute; \">"; //table start

                html += "<tr style=\"background-color:#d3d3d3;\"> <th>ID</th><th>Name</th><th>Username</th><th>User Type</th><th>Last Login Date</th><th>Last Login Time</th></tr>>"; //headers

                for ( int i = 0; i < users_table.RowCount; ++i)
                {
                    if (userID == users_table.GetRow(i)["ID"]) // if userID is same as ID in column, display result. 
                    {
                        html += "<tr>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["ID"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["Name"];
                        html += "</td>";


                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["Username"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["UserType"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["LastLoginDate"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += users_table.GetRow(i)["LastLoginTime"];
                        html += "</td>";

                        html += "</tr>";
                    }
                }

                html += "</table>"; //table end
                htmlLabel.Text = html; //throw html string into label.

                string htmlString2 = ""; //declaring string which will be used to output information on the screen. THIS ONE IS FOR POSTS.

                htmlString2 += "<table class=\"table table-hover\" style=\"top: 170px; position: absolute; \">"; //table start

                htmlString2 += "<tr style=\"background-color:#d3d3d3;\"> <th>ID</th><th>Message</th><th>Creator ID</th><th>Board ID</th><th>Date Created</th></th><th>Time Created</th></tr>"; //headers

                for (int i = 0; i < posts_table.RowCount; ++i)
                {
                    if (userID == posts_table.GetRow(i)["CreatorID"]) //if ID's are same of creator and user, display results.
                    {
                        htmlString2 += "<tr>";

                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["ID"];
                        htmlString2 += "</td>";

                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["Text"];
                        htmlString2 += "</td>";


                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["CreatorID"];
                        htmlString2 += "</td>";

                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["BoardID"];
                        htmlString2 += "</td>";

                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["DateCreated"];
                        htmlString2 += "</td>";

                        htmlString2 += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        htmlString2 += posts_table.GetRow(i)["TimeCreated"];
                        htmlString2 += "</td>";

                        htmlString2 += "</tr>";
                    }
                }
                htmlString2 += "</table>";
                htmlLabel2.Text = htmlString2; //throw htmlString2 string into label.
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e) //when logout button is pressed, do this...
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1d); //setting cookie expiry date , killing it.
            Session.Clear(); //clearing session
            Response.Redirect("/Default"); //redirecting user to the default page.
        }

        protected void goBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            changePasswordLabel.Visible = false;

            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users"); //loading users table again.. for latest results...

            string userID = Application["userID"].ToString(); //fetching user's id.

            for (int r = 0; r < users_table.RowCount; ++r)
            {                
                SQLDatabase.DatabaseRow row = users_table.GetRow(r); //get current ID.
                if (userID == users_table.GetRow(r)["ID"]) //if userID is the same as it's in the row
                {
                    row["Password"] = changePasswordTextbox.Text; //update password
                    users_table.Update(row); //update row.
                }
                    
            }

            changePasswordLabel.Visible = true; //confirm that success.
        }
    }
}