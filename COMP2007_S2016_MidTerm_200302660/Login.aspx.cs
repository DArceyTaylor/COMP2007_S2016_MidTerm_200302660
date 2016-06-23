using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/*
    Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file contains the C# code for our login page
*/

namespace COMP2007_S2016_MidTerm_200302660.Todo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /**
         * <summary>
         * This method logs a user in by checking if the user exists, if so allow them in if they supply the right 
         * credentials, if not deny access
         * </summary>
         * 
         * @method LoginButton_Click
         * @returns {void}
         */
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // search for and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);


            // if a match is found for the user
            if (user != null)
            {
                // authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // Sign the user
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                // Redirect to Main Menu
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // throw an error to the AlertFlash div
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }
        }
        /**
         * <summary>
         * This method redirects the user to the home page
         * </summary>
         * 
         * @method BackButton_Click
         * @returns {void}
         */
        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        /**
         * <summary>
         * This method redirects a user to the registration page
         * </summary>
         * 
         * @method RegisterButton_Click
         * @returns {void}
         */
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}