using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }
                string isAdmin = Application["isAdmin"].ToString(); //retrieving previous data stored.

                /* User normally can't proceed here, if he's not Authed by our secure page.
                 Although if he managed to find the way, we will check if he's admin or not.
                 PROGRAM WILL CRASH IF THE USER IS NOT ADMIN, AND TRIES TO ACCESS ADMIN STUFF WHILE BEING NON-ADMIN*/
                if (isAdmin != "Admin") //if user is not admin then redirect.
                {
                    Response.Redirect("/Boards");
                }

                SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");   // Need to load the table we're going to display...

                users_table.Bind(DataList1);

                string name = Request.Cookies["userName"].Value; //fetching value from cookie which is valid only for 2 hours.
                welcomeUsernameLabel.Text += " " + name;
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e) //when logout button is pressed, do this...
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1d);
            Session.Clear(); //clearing session
            Response.Redirect("/Default"); //redirecting user to the default page.
        }

        protected void goBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataListItem i = e.Item;
                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.

                // Find the label controls that are associated with this data item.
                Label ID_LBL = (Label)e.Item.FindControl("ID_Label");           // Find the ID Label.
                Label Name_LBL = (Label)e.Item.FindControl("Name_Label");       // Find the Name Label.
                Label Username_LBL = (Label)e.Item.FindControl("Username_Label"); // Find the Username label...
                Label Password_LBL = (Label)e.Item.FindControl("Password_Label");
                Label UserType_LBL = (Label)e.Item.FindControl("UserType_Label");
                Label LastLoginDate_LBL = (Label)e.Item.FindControl("LastLoginDate_Label");
                Label LastLoginTime_LBL = (Label)e.Item.FindControl("LastLoginTime_Label");

                ID_LBL.Text = r["ID"].ToString();               // Now we have the labels, we can insert the data...   ID number first..then we continue for rest..
                Name_LBL.Text = r["Name"].ToString();           
                Username_LBL.Text = r["Username"].ToString();
                Password_LBL.Text = r["Password"].ToString();
                UserType_LBL.Text = r["UserType"].ToString();
                LastLoginDate_LBL.Text = r["LastLoginDate"].ToString();
                LastLoginTime_LBL.Text = r["LastLoginTime"].ToString();

                Button ViewButton = (Button)e.Item.FindControl("ViewButton");   // Find the button in this row.
                ViewButton.CommandArgument = i.ItemIndex.ToString();    // Allocate the row number to the 'command argument' property of the button, so we can identify which button was pressed later.
                ViewButton.CommandName = "ViewUser";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewUser") //view user button clicked
            {

                int index = int.Parse((string)e.CommandArgument);  // The 'Command Argument' is a string, so turn it into an integer...

                SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");   // Need to load the table again, to extract the row in which the button was clicked.

                SQLDatabase.DatabaseRow row = users_table.GetRow(index);   // Get the row from the table.

                Session["Users"] = row;    // Store this on the Session, so we can access this details in the other page. 

                Response.Redirect("DeleteUser.aspx"); // Now to go the other page to view the module information...
            }
        }

        protected void yourAccButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPanel");
        }
    }
}