using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MidTerm_200302660.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/*
 * Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file checks to see if we are updating a current todo or adding a new todo to the DB
 */

namespace COMP2007_S2016_MidTerm_200302660
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        /**
         * <summary>
         * This method gets the user data when the page loads depending if you are editing or adding a todo
         * </summary>
         * 
         * @method Page_Load
         * @returns {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if a user is logged in
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if ((!IsPostBack) && (Request.QueryString.Count > 0))
                {
                    this.GetTodoData();
                }
            }
            else
            {
                Response.Redirect("/Login.aspx");
            }
        }

        /**
         * <summary>
         * This method gets the user data from the database using Todo id
         * </summary>
         * 
         * @method GetTodoData
         * @returns {void}
         */
        protected void GetTodoData()
        {
            // populate the form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["GameID"]);

            //connect to the EF framework
            using (TodoConnection db = new TodoConnection())
            {
                //populate a game object instance with the GameID from the URL paramerter
                Todo updatedTodo = (from Todo in db.Todos
                                    where Todo.TodoID == TodoID
                                    select Todo).FirstOrDefault();

                //map the game properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    CompletedCheckBox.Text = updatedTodo.Completed;

                }
            }
        }
        /**
         * <summary>
         * This method returns you to the default.aspx
         * </summary>
         * 
         * @method CancelButton_Click
         * @returns {void}
         */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // redirect back to users page
            Response.Redirect("~/Default.aspx");
        }
        /**
         * <summary>
         * This method saves the new todo information, depending if the todo has no ID or already has one to save a new todo
         * or save the changes 
         * </summary>
         * 
         * @method SaveButton_Click
         * @returns {void}
         */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int TodoID = 0;

            // if updating user
            if (Request.QueryString.Count > 0)
            {
                using (TodoConnection db = new TodoConnection())
                {
                    Todo newTodo = new Todo();

                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    newTodo = (from Todos in db.Todos
                               where Todos.TodoID == TodoID
                               select Todos).FirstOrDefault();

                    newTodo.TodoName = TodoNameTextBox.Text;
                    newTodo.TodoNotes = TodoNotesTextBox.Text;
                    newTodo.Completed = CompletedCheckBox.Checked;

                    db.SaveChanges();

                    // redirect to the users list
                    Response.Redirect("~/TodoList.aspx");

                }
            }

            
            
        }
    }
}