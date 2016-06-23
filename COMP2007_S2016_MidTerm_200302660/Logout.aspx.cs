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
 * Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file contains the code for our logout page
 */

namespace COMP2007_S2016_MidTerm_200302660
{
    public partial class Logout : System.Web.UI.Page
    {
        /**
         * <summary>
         * This method logs a user out and redirects the user back the home page
         * </summary>
         * 
         * @method Page_Load
         * @returns {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // store session info and authentication methods in the authenticationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            // perform sign out
            authenticationManager.SignOut();

            // Redirect to the Default page
            Response.Redirect("~/Default.aspx");
        }
    }
}