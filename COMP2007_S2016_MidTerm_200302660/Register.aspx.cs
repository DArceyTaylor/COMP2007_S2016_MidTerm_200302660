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
    File Description: This file contains the C# code for our register page
*/

namespace COMP2007_S2016_MidTerm_200302660
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /**
         * <summary>
         * This method redirects the user back the home page
         * </summary>
         * 
         * @method CancelButton_Click
         * @returns {void}
         */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the Default page
            Response.Redirect("~/Default.aspx");
        }
        /**
         * <summary>
         * This method register a new user and then signs them in and redirects them to the gameselection page
         * </summary>
         * 
         * @method RegisterButton_Click
         * @returns {void}
         */
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // create a new user object
            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            // create a new user in the db and store the result 
            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            // check if successfully registered
            if (result.Succeeded)
            {
                // authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in 
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                // Redirect to the Main Menu page
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // display error in the AlertFlash div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }
    }
}