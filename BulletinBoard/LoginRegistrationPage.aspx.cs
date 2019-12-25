/* DEVELOPED BY ADRIAN CHUDZIKIEWICZ.
 * ALL RIGHTS RESERVED.
 * IMAGES USED( in HTML sector) ARE COPYRIGHT FREE. 
 * LINKS : FORUM BACKGROUND https://pixabay.com/en/sunrise-scenic-landscape-light-sun-1949939/
 * LINKS : LOGIN BACKGROUND https://pixabay.com/en/landscape-nature-background-2494650/ */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BulletinBoard
{
    public partial class LoginRegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users"); //load users table on load.
            if (Request.Cookies["userName"] != null) //checking if the user got cookie in, if cookie got value inside it then user is logged in
            {
                Response.Redirect("/Boards"); // transfer it to the boards page.
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            loginMessageLBL.Visible = false; //make it invisible if button is clicked then determine if it should show up or not.
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users"); // users table

            for (int r = 0; r < users_table.RowCount; ++r)
            {
                if (usernameTextBox.Text == users_table.GetRow(r)["Username"])
                {
                    if (passwordTextBox.Text == users_table.GetRow(r)["Password"])
                    {
                        /**************************************************/
                        /* ADDING DATE TO THE COLUMN WHEN USER IS LOGGED IN
                         * ************************************************/
                        // If user has logged in, add date login time into his account.
                        // define the values to use for UPDATE
                        string userID = users_table.GetRow(r)["ID"]; // Get current ID of a user.
                        string isAdmin = users_table.GetRow(r)["UserType"]; // Get current ID of a user.

                        Application["userID"] = userID; //storing userID, will be used later on.
                        Application["isAdmin"] = isAdmin; //storing user type, will be used later on.

                        DateTime localTime = DateTime.Now; //store current Date in localTime variable.

                        SQLDatabase.DatabaseRow row = users_table.GetRow(r); //get current ID.
                        row["LastLoginDate"] = localTime.ToString("yyyy-MM-dd"); //format localTime into just date string, without time.
                        row["LastLoginTime"] = localTime.ToString("HH:mm:ss"); //formatting date into time.
                        users_table.Update(row); //update row.

                        /*********************************************************/
                        /* CREATING COOKIES TO REMEMBER THAT THE USER IS LOGGED IN
                         * *******************************************************/
                        //Creating cookie, this will be used to see whether or not the user is logged in and is able to access the boards.
                        //create cookie

                        HttpCookie cookie = new HttpCookie("userName"); //new cookie.

                        string name = row["Name"].ToString(); // getting Name column from row and setting it to name.

                        cookie.Value = name; //assigning string name to cookie
                        cookie.Expires = DateTime.Now.AddHours(2); //cookie lifetime 2 hours.
                        Response.Cookies.Add(cookie); //adding cookie so it's valid.
                        


                        /*********************************************************/
                        /* IF COOKIE IS PRESENT, REDIRECT TO MAIN BOARDS PAGE
                         * *******************************************************/
                        if (cookie != null || string.IsNullOrEmpty(cookie.Value)) //checking if cookie is null or cookieValue is null.
                        {
                            HttpContext.Current.Response.Redirect("/Boards"); //redirecting to main boards page.
                        }

                        return; //quitting for loop, when everything is OK.
                    }
                }
                else
                {
                    loginMessageLBL.Visible = true; // making label visible
                    loginMessageLBL.ForeColor = System.Drawing.Color.Red; // red colour of the text.
                }
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            registerStatusLBL.Visible = false; // make it invisible by default when button is triggered.
            registerStatusPosLBL.Visible = false; // make it invisible by default when button is triggered.
            SQLDatabase.DatabaseTable users_table = new SQLDatabase.DatabaseTable("Users");


            for (int r = 0; r < users_table.RowCount; ++r)
            {
                if (regEmailTextbox.Text == users_table.GetRow(r)["Username"])
                {
                    registerStatusLBL.Visible = true;
                    registerStatusLBL.ForeColor = System.Drawing.Color.Red; //red colour for the label.                    
                    return;

                }
                else
                {
                    registerStatusPosLBL.Visible = true;
                    registerStatusPosLBL.ForeColor = System.Drawing.Color.Green; //green colour for the label
                }
            }


            SQLDatabase.DatabaseRow new_row = users_table.NewRow();    // Create a new based on the format of the rows in this table.

            string new_id = users_table.GetNextID().ToString();    // Use this to create a new ID number for this Users. This new ID follows on from the last row's ID number.

            new_row["ID"] = new_id;                                 // Add some data to the row (using the columns names in the table).
            new_row["Name"] = regRealNameTextbox.Text;            // Users name.
            new_row["Username"] = regEmailTextbox.Text;
            new_row["Password"] = regPasswordTextbox.Text;
            new_row["UserType"] = "User";

            users_table.Insert(new_row);                           // Execute the insert - add this new row into the database.
        } //end
    }
}