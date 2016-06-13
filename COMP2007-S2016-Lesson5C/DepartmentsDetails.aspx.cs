using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using statements required for EF DB access
using COMP2007_S2016_Lesson5C.Models;
using System.Linq.Dynamic;

namespace COMP2007_S2016_Lesson5C
{
    public partial class DepartmentsDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            // populate teh form with existing data from the database
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            // connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                // populate a student object instance with the StudentID from the URL Parameter
                Department updatedDepartment = (from department in db.Departments
                                          where department.DepartmentID == DepartmentID
                                          select department).FirstOrDefault();

                // map the student properties to the form controls
                if (updatedDepartment != null)
                {
                    //DepartmentIDTextBox.Text = updatedDepartment.DepartmentID.ToString();
                    DepartmentNameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = updatedDepartment.Budget.ToString("c");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                // use the Student model to create a new student object and
                // save a new record
                Department newDepartment = new Department();

                int DepartmentID = 0;

                if (Request.QueryString.Count > 0) // our URL has a StudentID in it
                {
                    // get the id from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    // get the current student from EF DB
                    newDepartment = (from department in db.Departments
                                  where department.DepartmentID == DepartmentID
                                  select department).FirstOrDefault();
                }

                
                //newDepartment.DepartmentID = int.Parse(DepartmentIDTextBox.Text);
                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Decimal.Parse(BudgetTextBox.Text);

                // use LINQ to ADO.NET to add / insert new student into the database

                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}