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

/**
 * @author: D'Arcey Taylor
 * @date: May 26, 2015
 * @version: 0.0.1 added SetActivePage method
**/

namespace COMP2007_S2016_MidTerm_200302660
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // show the game details area
                    UserPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = true;
                    Login.Visible = false;
                                        
                }
                else
                {
                    // only show login and register
                    UserPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
                SetActivePage();
            }
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Todo List":
                    todo.Attributes.Add("class", "active");
                    break;
                case "Login":
                    Login.Attributes.Add("class", "active");
                    break;
                case "Logout":
                    Logout.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}