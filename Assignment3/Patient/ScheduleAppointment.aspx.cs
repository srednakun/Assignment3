using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Assignment3.Patient
{
    public partial class ScheduleAppointment : System.Web.UI.Page
    {
        HospitalEntities1 dbcon = new HospitalEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintName();
            TimeLabel.Visible = false;
            NotificationLabel.Visible = false;
            AppointmentErrMsg.Visible = false;
            getSelectedTime();
            string username = Helpers.PatientHandler.getPatientUsername();
            int docId = Helpers.PatientHandler.getPatientDocId(username);
            docLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);
           

            
           
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar1.Visible = true;

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;


            TextBox1.Text = selectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Gray;
            }
            if (e.Day.IsToday)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
            }

            if (e.Day.Date.CompareTo(DateTime.Today) < 0)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.Gray;
            }
        }

        protected TimeSpan getSelectedTime()
        {
            int hour = Convert.ToInt32(DropDownListHour.SelectedValue);
            int min = Convert.ToInt32(DropDownListMin.SelectedValue);
            string amPM = DropDownListAMPM.SelectedValue;
            string am = "AM";
            string pm = "PM";

            TimeSpan mytime = new TimeSpan();
            if (hour >= 7 && hour <= 11 && amPM==am)
            {
                TimeLabel.Visible = true;
                mytime = new TimeSpan(hour, min, 0);
                TimeLabel.Text = mytime.ToString()+amPM;

            }

            else if (hour == 12 && hour >= 1 && hour <= 5 && amPM==pm)
            {

                mytime = new TimeSpan(hour, min, 0);
                TimeLabel.Visible = true;
                TimeLabel.Text = mytime.ToString()+amPM;


            }
            else
            {
                TimeLabel.Visible = true;
                TimeLabel.Text = mytime.ToString();
                NotificationLabel.Visible = true;
                NotificationLabel.Text = "Doctor is available from 8AM-5PM";

            }

            return mytime;


        }
        protected void PrintName()
        {
            dbcon.PatientTables.Load();
            string username = "";
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = System.Web.HttpContext.Current.User.Identity.Name;
            }

            var patient = from item in dbcon.PatientTables.Local
                          where username == item.UserLoginName.Trim()
                          select item;

            foreach (var item in patient)
            {
                Label1.Text = item.FirstName + " " + item.LastName;
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean createAppointment = true;

                dbcon.AppointmentsTables.Load();




                DateTime date = Convert.ToDateTime(TextBox1.Text);



                dbcon.PatientTables.Load();
                string username = "";
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    username = System.Web.HttpContext.Current.User.Identity.Name;
                }

                var patient = from item in dbcon.PatientTables.Local
                              where username == item.UserLoginName.Trim()
                              select item;

                int first = 0;


                foreach (var item in patient)
                {
                    first = item.PatientID;

                }



                var appt = from user in dbcon.AppointmentsTables.Local
                           where Convert.ToInt32(GridView1.SelectedDataKey[0]) == user.DoctorID
                           select user;
                foreach (var x in appt)
                {
                    if (x.Date == date && x.Time == getSelectedTime())
                    {
                        AppointmentErrMsg.Visible = true;
                        AppointmentErrMsg.Text = "The Doctor Has An Appointment At This Time.";
                        createAppointment = false;
                    }
                }
                //Label1.Text = getSelectedTime().ToString();

                if (createAppointment == true)
                {
                    AppointmentsTable x = new AppointmentsTable();
                    x.PaitentID = first;
                    x.Date = date;
                    x.Time = getSelectedTime();
                    x.Purpose = "Doctor: " +
                    GridView1.SelectedDataKey[1].ToString() + " " +
                    GridView1.SelectedDataKey[2].ToString() + " ";
                     //" Department: ";
                    //GridView1.SelectedDataKey[3].ToString() + " "
                   // + TextBox2.Text;
                    
                    x.DoctorID = Convert.ToInt32(GridView1.SelectedDataKey[0]);
                    x.VisitSummary = "";

                    dbcon.AppointmentsTables.Add(x);

                    dbcon.SaveChanges();
                    AppointmentErrMsg.Visible = true;
                    AppointmentErrMsg.Text = "Appointment Has Been Successfully Added.";

                }
            }
            catch (Exception exd)
            {
                AppointmentErrMsg.Visible = true;
                AppointmentErrMsg.Text = "Please Make Sure All The Boxes Are Filled Out Correctly. ";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}