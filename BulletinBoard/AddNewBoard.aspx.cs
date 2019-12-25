using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class AddNewBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userName"] == null)
                {
                    Response.Redirect("/Error404");
                }
            }
            SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // Loading the table, I will be using.
            string name = Request.Cookies["userName"].Value; //fetching value from cookie which is valid only for 2 hours.
            welcomeUsernameLabel.Text = "Welcome " + name;
        }

        protected void addNewBoardButton_Click(object sender, EventArgs e)
        {
            /* Setting labels to be invisible by default on button click, then decide.*/
            boardNAMETAKENlabel.Visible = false;
            SuccessNEWBOARDADDEDLABEL.Visible = false;


            /* ADDING NEW ROW TO THE BOARDS DATABASE */
            string ID = Application["userID"].ToString(); //grabbing data that was stored on the loginregistration page.
            DateTime localTime = DateTime.Now; //getting time at the time of button click.

            SQLDatabase.DatabaseTable boards_table = new SQLDatabase.DatabaseTable("Boards");   // Loading our precious database table.

            SQLDatabase.DatabaseRow new_row = boards_table.NewRow(); //creating new row 


            for (int r = 0; r < boards_table.RowCount; ++r)
            {
                /* CHECK IF BOARD NAME EXISTS IF IT DOES, ABORT OPERATION */
                if (boardNameTEXTBOX.Text == boards_table.GetRow(r)["Name"])
                {
                    boardNAMETAKENlabel.Visible = true;
                    boardNAMETAKENlabel.ForeColor = System.Drawing.Color.Red; // red colour of the text.
                    return;
                }
                else
                {
                    SuccessNEWBOARDADDEDLABEL.Visible = true;
                    SuccessNEWBOARDADDEDLABEL.ForeColor = System.Drawing.Color.Green; // green colour of the text.

                    string new_id = boards_table.GetNextID().ToString(); // getting next ID from the database and storing it in the new_id string.
                    new_row["ID"] = new_id;
                    new_row["Name"] = boardNameTEXTBOX.Text;
                    new_row["CreatorID"] = ID;
                    new_row["DateCreated"] = localTime.ToString("yyyy-MM-dd");//formatting date into just date. 
                    new_row["TimeCreated"] = localTime.ToString("HH:mm:ss"); //formatting date into time.
                    boards_table.Insert(new_row); //insertting new row into boards table.
                    return; //quit after one.
                }
            }          
        }

        protected void goBackBUTTON_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Boards");
        }

        protected void PanelOpenButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AuthPage");
        }
    }
}