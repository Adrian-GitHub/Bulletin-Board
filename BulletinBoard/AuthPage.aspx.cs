using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulletinBoard
{
    public partial class AuthPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users"); //table

            string userID = Application["userID"].ToString(); //userID was stored at LoginRegistrationPage, so now let's filter thru it and see if the user is admin
            string isAdmin = Application["isAdmin"].ToString();
                                
           if (isAdmin == "Admin")
                {
                    Response.Redirect("/AdminPanel"); // and if it's, transfer to another page.
                }
            else //if not and the loop has filtered all the rows...
            {

                Response.Redirect("/UserPanel"); // then he's a user.
            }
        }
    }
}