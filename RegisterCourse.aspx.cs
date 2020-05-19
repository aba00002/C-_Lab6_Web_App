using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        List<Lab6.Models.Course> availableCourses = Lab6.Models.Helper.GetAvailableCourses();
        int weeklyHoursSum;
        int numberOfCourses;
        int i;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                for (i = 0; i < availableCourses.Count; i++)
                {
                    CheckBoxList1.Items.Add(new ListItem(availableCourses[i].Title + " - " + availableCourses[i].WeeklyHours + " hours/week", availableCourses[i].WeeklyHours.ToString()));
                }
            }
        }
            protected void Button1_Click(object sender, EventArgs e)
        {
            //If no name is entered
            if (TextBox1.Text == "")
            { Label1.Text = "You must enter a name!";
               GridView1.Visible = false;
            }
            else
            { Label1.Text = ""; }

                //Full time students – cannot exceed 16 hours in a week.
                if (RadioButton1.Checked)
                {
                    if (TextBox1.Text == "")
                    { Label1.Text = "You must enter a name!"; GridView1.Visible = false; }
                   else if (weeklyHoursSum > 16)
                    { Label1.Text = "Your selection exceeds the maximum weekly hours:  16"; GridView1.Visible = false; }
                    else if (numberOfCourses == 0) { }
                    else if (weeklyHoursSum <= 16)
                    {
                    GridView1.Visible = true; ;
                    Label3.Text = "has enrolled in the following courses";
                        CheckBoxList1.Visible = false;
                        Button1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                        TextBox1.Enabled = false;
                        RadioButton1.Enabled = false; RadioButton2.Enabled = false; RadioButton3.Enabled = false;
                    }
                }

                //Part time students – cannot register more than 3 courses;
                if (RadioButton2.Checked)
                {
                if (TextBox1.Text == "")
                { Label1.Text = "You must enter a name!"; GridView1.Visible = false; }

                else if (numberOfCourses > 3)
                { Label1.Text = "Your selection exceeds the maximum number of courses:  3"; GridView1.Visible = false; }
                else if (weeklyHoursSum == 0) { }

                else if (numberOfCourses <= 3)
                {
                    GridView1.Visible = true;
                    Label3.Text = "has enrolled in the following courses";
                    CheckBoxList1.Visible = false;
                    Button1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    TextBox1.Enabled = false;
                    RadioButton1.Enabled = false; RadioButton2.Enabled = false; RadioButton3.Enabled = false;
                }
                }

                //Coop students – cannot register more than 2 courses or exceed 4 hours in a week
                if (RadioButton3.Checked)
                {
                    if (TextBox1.Text == "")
                    { Label1.Text = "You must enter a name!"; GridView1.Visible = false; }

                    //If hours exceed 4
                    else if (weeklyHoursSum > 4)
                    { Label1.Text = "Your selection exceeds the maximum weekly hours:  4"; GridView1.Visible = false; }

                    //if courses exceed 2
                    else if (numberOfCourses > 2)
                    { Label1.Text = "Your selection exceeds the maximum number of courses:  2"; GridView1.Visible = false; }
                    else if (weeklyHoursSum <= 4 && numberOfCourses >= 2)
                    {
                    GridView1.Visible = true;
                    Label3.Text = "has enrolled in the following courses";
                        CheckBoxList1.Visible = false;
                        Button1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                        TextBox1.Enabled = false;
                        RadioButton1.Enabled = false; RadioButton2.Enabled = false; RadioButton3.Enabled = false;
                   }
            }
            }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Table of results
            DataTable dt = new DataTable();
            dt.Columns.Add("Course Code");
            dt.Columns.Add("Course Title");
            dt.Columns.Add("Weekly Hours");

            foreach (ListItem s in CheckBoxList1.Items)
            {
                if (s.Selected == true)
                {
                    switch (s.Text)
                    {
                        case "Introduction to Database Systems - 4 hours/week":
                            i = 0;
                            break;
                        case "Web Programming II - 2 hours/week":
                            i = 1;
                            break;
                        case "Web Programming Language I - 5 hours/week":
                            i = 2;
                            break;
                        case "Web Imaging and Animations - 2 hours/week":
                            i = 3;
                            break;
                        case "Network Operating System - 1 hours/week":
                            i = 4;
                            break;
                        case "Data Warehouse Design - 3 hours/week":
                            i = 5;
                            break;
                        case "Advance Database topics - 1 hours/week":
                            i = 6;
                            break;
                    }
                     weeklyHoursSum += Int32.Parse(s.Value);
                    numberOfCourses += 1;
                    dt.Rows.Add(availableCourses[i].Code, availableCourses[i].Title, s.Value);
                }
                
                }
            dt.Rows.Add("", "Total", weeklyHoursSum);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    }
