﻿using System;
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
 *  Page Description: This page pull data from the db or shows an empty text field depending on if you are performing an edit or a first time add.
 *  File Name: TodoDetails.aspx.cs
*/

namespace COMP2007_S2016_MidTerm_200289381
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.getTodoDetails();
            }
        }

        protected void getTodoDetails()
        {

            // populate the form with existing data from the data base
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            //connect to db
            using (TodoConnection db = new TodoConnection())
            {
                Todo updatedDetails = (from Todo in db.Todos where Todo.TodoID == TodoID select Todo).FirstOrDefault();

                //map the todo properties to the form

                if (updatedDetails != null)
                {
                    TodoNameTextBox.Text = updatedDetails.TodoName;
                    TodoNotesTextBox.Text = updatedDetails.TodoNotes;

                    //if (Check_Completed.Checked == true)
                    //{
                    //    updatedDetails.Completed = true;
                    //}
                    //if (Check_Completed.Checked == false)
                    //{
                    //    updatedDetails.Completed = false;
                    //}
                }
            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (TodoConnection db = new TodoConnection())
            {
                //creating new todo object based on the model
                Todo TodoDetails = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0)// our url has a TodoID in it
                {
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    //get the current game from EF DB
                    TodoDetails = (from Todo in db.Todos where Todo.TodoID == TodoID select Todo).FirstOrDefault();

                }

                //add form data to the new todo record
                TodoDetails.TodoName = TodoNameTextBox.Text;
                TodoDetails.TodoNotes = TodoNotesTextBox.Text;

                //if (TodoDetails.Completed == true)
                //{
                //    Check_Completed.Checked = true;
                //}
                //if (TodoDetails.Completed == false)
                //{
                //    Check_Completed.Checked = false;
                //}

                //use LINQ to ADO.NET to insert record to DB
                if (TodoID == 0)
                {
                    db.Todos.Add(TodoDetails);
                }

                //save all changes in the DB
                db.SaveChanges();

                //redirect to TodoList page
                Response.Redirect("TodoList.aspx");
            }
        }
    }
}
