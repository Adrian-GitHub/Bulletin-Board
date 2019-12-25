using SQLDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }
                statusINFOlbl.Visible = false;
                /* User normally can't proceed here, if he's not Authed by our secure page.
                 Although if he managed to find the way, we will check if he's admin or not.
                 PROGRAM WILL CRASH IF THE USER IS NOT ADMIN, AND TRIES TO ACCESS ADMIN STUFF WHILE BEING NON-ADMIN*/
                string isAdmin = Application["isAdmin"].ToString();
                if (isAdmin != "Admin") //if user is not admin then redirect.
                {
                    Response.Redirect("/Boards");
                }
                SQLDatabase.DatabaseRow r = (SQLDatabase.DatabaseRow)Session["Users"]; // Extract the row that we stored earlier on the Session.

                // Now display the data...
                userIDlabel.Text = r["ID"].ToString() + "(User ID)" + "<br>";
                Namelabel.Text = r["Name"].ToString() + "(User's Name)" + "<br>";
                usernameLabel.Text = r["Username"].ToString() + "(User's Username)" + "<br>";
                userPasswordLabel.Text = r["Password"].ToString() + "(User's Password)" + "<br>";
                usertypeLabel.Text = r["UserType"].ToString() + "(User Type)" + "<br>";
                userLastLoginDatelabel.Text = r["LastLoginDate"].ToString() + "(LLD)" + "<br>";
                userLastLoginTimelabel.Text = r["LastLoginTime"].ToString() + "(LLT)" + "<br>";
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e) //when logout button is pressed, do this...
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1d); //setting cookie expiry date , killing it.
            Session.Clear(); //clearing session
            Response.Redirect("/Default"); //redirecting user to the default page.
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            statusINFOlbl.Visible = false;

            SQLDatabase.DatabaseRow r = (SQLDatabase.DatabaseRow)Session["Users"]; // Extract the row that we stored earlier on the Session.
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users"); //loading users table again.. for latest results...

            string userID = r["ID"]; //fetching user's id.

            for (int i = 0; i < users_table.RowCount; ++i)
            {
                SQLDatabase.DatabaseRow row = users_table.GetRow(i); //get current ID.
                if (userID == users_table.GetRow(i)["ID"]) //if userID is the same as it's in the row
                {
                    row["ID"] = userID.ToString();

                    users_table.Delete(row);
                }


            }

            statusINFOlbl.Visible = true;
        }

        protected void dontDeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }

        protected void goBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }
    }
}