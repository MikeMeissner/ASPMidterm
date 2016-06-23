using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm_200289381.Models;
using System.Web.ModelBinding;

/*  Author: Michael Meissner
 *  Student#: 200289381
 *  Date: Thursday June 23, 2016
 *  Website Name: Todo List
 *  Page Description: This page pull data from the db and displays it in a gridview it also allows you o delete todos and it can redirect you to a edit page
 *  File Name: TodoList.aspx.cs
*/

namespace COMP2007_S2016_MidTerm_200289381
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is loading for the first time, populate the grid
            if (!IsPostBack)
            {
                //get todo data
                this.GetTodoData();
            }
        }

        protected void GetTodoData()
        {
            //connect to EF
            using (TodoConnection db = new TodoConnection())
            {
                //query the todo table
                var Todo = (from allData in db.Todos
                            select allData);

                //bind results to the gridview
                TodoGridView.DataSource = Todo.ToList();
                TodoGridView.DataBind();
            }
        }

        protected void TodoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex; // store which row was called
            int TodoID = Convert.ToInt32(TodoGridView.DataKeys[selectedRow].Values["TodoID"]);// get game ID

            //connect to db to remove row
            using (TodoConnection db = new TodoConnection())
            {
                Todo removedTodo = (from Todo in db.Todos where Todo.TodoID == TodoID select Todo).FirstOrDefault();

                db.Todos.Remove(removedTodo);

                db.SaveChanges();

                this.GetTodoData();
            }

        }


        // *From here down im lost*
        protected void TodoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow) ((CheckBox)e.Row.FindControl("Check_Completed")).Checked = true;
            
        }

        protected void TodoGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
        }

        protected void TodoGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}