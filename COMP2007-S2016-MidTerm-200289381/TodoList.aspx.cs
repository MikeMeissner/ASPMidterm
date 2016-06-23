using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm_200289381.Models;
using System.Web.ModelBinding;


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
    }
}