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

                }
            }

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}