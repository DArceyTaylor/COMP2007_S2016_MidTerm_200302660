using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are required to connect to EF DB
using COMP2007_S2016_MidTerm_200302660.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/*
 * Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file contains the code for our todolist
 */

namespace COMP2007_S2016_MidTerm_200302660
{
    public partial class TodoList : System.Web.UI.Page
    {
        /**
         * <summary>
         * This method loads the todo data in ascending order by todoid, and depending on how a person is or is not logged
         * in
         * </summary>
         * 
         * @method Page_Load
         * @returns {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the tododata grid
            if (!IsPostBack)
            {
                Session["SortColumn"] = "GameID"; //default sort column
                Session["SortDirection"] = "ASC";
                // Get the todo data
                this.GetTodoData();
            }

            // if the user logged in show the edit and hide the delete columns
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                TodoDataGridView.Columns[7].Visible = true;
                TodoDataGridView.Columns[8].Visible = true;
                
            }
            // if the user is not logged in hide the edit and the delete columns
            else
            {
                TodoDataGridView.Columns[7].Visible = false;
                TodoDataGridView.Columns[8].Visible = false;
            }


        }

        /**
         * <summary>
         * This method gets the todo data depending on the dropdown a person has selected, so that it is sorted
         * by date
         * </summary>
         * 
         * @method GettodoData
         * @returns {void}
         */
        protected void GetTodoData()
        {
            // connect to EF
            using (TodoConnection db = new TodoConnection())
            {

                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the todos Table using EF and LINQ
                var Todos = (from allTodos in db.Todos
                             select allTodos);

                // bind the result to the GridView
                TodoDataGridView.DataSource = Todos.AsQueryable().OrderBy(SortString).ToList();
                TodoDataGridView.DataBind();
            }

        }

        /**
         * <summary>
         * Changes the amount of objects are on each grid view
         * </summary>
         * @method PageSizeDropDownList_SelectedIndexChanged
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         **/
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set the new page size
            TodoDataGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetTodoData();
        }

        /**
         * <summary>
         * this event handler deletes a game from the db using EF
         * </summary>
         * 
         * @method GameDataGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         **/
        protected void TodoDataGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get selected gameID using the Grid's DataKey Collection
            int TodoID = Convert.ToInt32(TodoDataGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF to find the selected game in the DB and remove it
            using (TodoConnection db = new TodoConnection())
            {
                //create object of the game class and store the query string inside of it
                Todo deletedGame = (from TodoRecords in db.Todos
                                    where TodoRecords.TodoID == TodoID
                                    select TodoRecords).FirstOrDefault();

                // remove the selected game from the db
                db.Todos.Remove(deletedGame);

                // save the changes
                db.SaveChanges();

                // refresh the grid
                this.GetTodoData();
            }
        }

        /**
         * <summary>
         * This event handler allows pagination to occur for the game tracker page
         * </summary>
         * @method GameDataGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         **/
        protected void TodoDataGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // set the new page number
            TodoDataGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetTodoData();
        }

        /**
         * <summary>
         * Sorts the objects are on each grid view
         * </summary>
         * @method GameDataGridView_Sorting
         * @param {object} sender
         * @param {GridViewSortEventArgs} e
         * @returns {void}
         **/
        protected void TodoDataGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // refresh the grid
            this.GetTodoData();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodoDataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)//if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < TodoDataGridView.Columns.Count - 1; index++)
                    {
                        if (TodoDataGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
    }
}