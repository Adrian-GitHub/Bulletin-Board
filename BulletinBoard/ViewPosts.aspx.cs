using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class ViewPosts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userName"] == null)
            {
                Response.Redirect("/Error404");
            }
            SQLDatabase.DatabaseRow row = (SQLDatabase.DatabaseRow)Session["Boards"]; // Extract the row that we stored earlier on the Session.
            SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");

            string name = Request.Cookies["userName"].Value;
            welcomeUsernameLabel.Text += " " + name;

            if (!IsPostBack)
            {
                string html = ""; //string for html output


                html += "<table class=\"table table-hover\" style=\"top: 170px; position: absolute; \">"; //table start

                html += "<tr style=\"background-color:#d3d3d3;\"> <th>PostID</th><th>Message</th><th>CreatorID</th><th>BoardID</th><th>DateCreated</th><th>TimeCreated</th></tr>>"; //headers

                for (int g = 0; g < posts_table.RowCount; g++)
                {
                    string IDfromBoards = row["ID"].ToString(); //converting ID row from Session into a string.

                    string PostsID = posts_table.GetRow(g)["BoardID"].ToString(); //converting BoardID from Posts table into a string

                    if (IDfromBoards == PostsID) // if id's are same, proceed ( that means, that this board contains messages specific to that board.)
                    {
                        html += "<tr>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["ID"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["Text"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["CreatorID"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["BoardID"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["DateCreated"];
                        html += "</td>";

                        html += "<td style=\"color: white; background-color:#000000;   opacity: 0.7;\">";
                        html += posts_table.GetRow(g)["TimeCreated"];
                        html += "</td>";

                        html += "</tr>";
                    }
                }
                html += "</table>"; //table end
                htmlLabel.Text = html; //throw html string into label.
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1d); //setting cookie expiry date , killing it. removing cookie named userName
            Session.Clear(); //clearing session
            Response.Redirect("/Default"); //redirecting user to the default page.
        }

        protected void addNewPostButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddPost");
        }

        protected void goBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }

        protected void PanelOpenButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AuthPage");
        }
    }
}