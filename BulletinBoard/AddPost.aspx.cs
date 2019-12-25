using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class AddPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }
                SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Loading the table, I will be using.
                string name = Request.Cookies["userName"].Value; //fetching value from cookie which is valid only for 2 hours.
                welcomeUsernameLabel.Text = "Welcome " + name;
            }
        }

        protected void addNewPostButton_Click(object sender, EventArgs e)
        {
            /* Setting labels to be invisible by default on button click, then decide.*/
            SuccesspostLABEL.Visible = false;

            string boardID = Application["boardID"].ToString();
            string userID = Application["userID"].ToString();

            DateTime localTime = DateTime.Now; //getting time at the time of button click.

            SQLDatabase.DatabaseTable posts_table = new SQLDatabase.DatabaseTable("Posts");   // Need to load the table we're going to insert into.

            SQLDatabase.DatabaseRow new_row = posts_table.NewRow();    // Create a new based on the format of the rows in this table.

            string new_id = posts_table.GetNextID().ToString();    // Use this to create a new ID number for this module. This new ID follows on from the last row's ID number.


            new_row["ID"] = new_id;                                 // Add some data to the row (using the columns names in the table).
            new_row["Text"] = newPostTextBox.Text;
            new_row["CreatorID"] = userID;
            new_row["BoardID"] = boardID;
            new_row["DateCreated"] = localTime.ToString("yyyy-MM-dd");
            new_row["TimeCreated"] = localTime.ToString("HH:mm:ss");

            posts_table.Insert(new_row);

            SuccesspostLABEL.Visible = true;
            return;
        }

        protected void goBackBUTTON_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards.aspx");
        }

        protected void PanelOpenButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AuthPage");
        }
    }
}