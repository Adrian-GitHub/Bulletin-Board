using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class Boards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }

                SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // Loading the table, I will be using.
                boards_table.Bind(DataList1);

                string name = Request.Cookies["userName"].Value; //fetching value from cookie which is valid only for 2 hours.
                welcomeUsernameLabel.Text += " " + name;                
            }

        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataList1.RepeatLayout = RepeatLayout.Flow; // Let it flow.
                DataListItem i = e.Item;
                System.Data.DataRowView r = ((System.Data.DataRowView)e.Item.DataItem); // 'r' represents the next row in the table that has been passed here via the 'bind' function.

                // Find the label controls that are associated with this data item.
                Label ID_LBL = (Label)e.Item.FindControl("ID_Label");           // Find the ID Label.
                Label Name_LBL = (Label)e.Item.FindControl("Name_Label");       // Find the Name Label.
                Label CreatorID_LBL = (Label)e.Item.FindControl("CreatorID_Label"); // Find the Staff ID Label.
                Label DateCreated_LBL = (Label)e.Item.FindControl("DateCreated_Label"); // Find the DateCreated Label.
                Label TimeCreated_LBL = (Label)e.Item.FindControl("TimeCreated_Label"); // Find the TimeCreated Label.

                ID_LBL.Text = r["ID"].ToString();               // Now we have the labels, we can insert the data...   ID number first,
                Name_LBL.Text = r["Name"].ToString();           // Module name.
                CreatorID_LBL.Text = r["CreatorID"].ToString();     // Staff ID number.
                DateCreated_LBL.Text = r["DateCreated"].ToString();     // Date.
                TimeCreated_LBL.Text = r["TimeCreated"].ToString();     // Time.

                Button ViewButton = (Button)e.Item.FindControl("ViewButton");   // Find the button in this row.
                ViewButton.CommandArgument = i.ItemIndex.ToString();    // Allocate the row number to the 'command argument' property of the button, so we can identify which button was pressed later.
                ViewButton.CommandName = "View";
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "View")    // ViewButton was pressed.
            {

                int index = int.Parse((string)e.CommandArgument);  // CommandArgument from string into an int.                

                SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // Load table again, to identify row.

                SQLDatabase.DatabaseRow row = boards_table.GetRow(index);   // Get the row from the table.

                int boardID = index + 1; //storing index in boardID. Adding 1 to Index, because index starts at 0, meanwhile Board ID stars from 1.
                Application["boardID"] = boardID; //storing boardID "in the cloud". 

                Session["Boards"] = row;    // Store this on the Session, so it will be accessible later, on different page

                Response.Redirect("ViewPosts.aspx"); // Direct to other page to view posts for that board.
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e) //when logout button is pressed, do this...
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1d); //setting cookie expiry date , killing it.
            Session.Clear(); //clearing session
            Response.Redirect("/Default"); //redirecting user to the default page.
        }

        protected void addNewBoardButton_Click(object sender, EventArgs e) //when button Create New Board is pressed...
        {
            Response.Redirect("/AddNewBoard");
        }

        protected void PanelOpenButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AuthPage");
        }
    }
}