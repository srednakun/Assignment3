using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Assignment3.Patient
{
    public partial class Appointment : System.Web.UI.Page
    {
        HospitalEntities1 dbcon = new HospitalEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintName();
            dbcon.AppointmentsTables.Load();
            NoAppointmentMsg.Visible = false;
           
            int x = patientID();
            var item = from user in dbcon.AppointmentsTables.Local
                       where x == user.PaitentID && user.Date.CompareTo(DateTime.Today)>=0
                       select user;
            GridView1.DataSource = item;
            GridView1.DataBind();
            if (item.Count()==0)
            {
                NoAppointmentMsg.Visible = true;
                NoAppointmentMsg.Text = "You Currently dont have any appointments with us.";
            }
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

            foreach(var item in patient)
            {
                Label1.Text = item.FirstName + " " + item.LastName + "       Doctor Name: " + PrintDoctorName();
            }


           
        }
        protected string PrintDoctorName()
        {
            dbcon.PatientTables.Load();
            dbcon.DoctorsTables.Load();
            string printDoctorname = "";
           
            string username = "";
            int doctorId = 0;
            int patientnumber = patientID();
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = System.Web.HttpContext.Current.User.Identity.Name;
            }

           var doctorNumber  = (from item in dbcon.PatientTables.Local
                          where item.PatientID==patientnumber
                          select item.DoctorID).Single();
            
            var DoctorName = from item in dbcon.DoctorsTables.Local
                             where doctorNumber == item.DoctorsId
                             select item;

            foreach(var x in DoctorName)
            {
                printDoctorname = x.FirstName + " " + x.LastName;
            }

            return printDoctorname;

        }

        public int patientID()
        {
            dbcon.PatientTables.Load();
            dbcon.UsersTables.Load();

            string username = "";
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = System.Web.HttpContext.Current.User.Identity.Name;
            }
            var patID = from user in dbcon.PatientTables.Local
                        where username == user.UserLoginName.Trim()
                        select user.PatientID;
            foreach (var x in patID)
            {
                Label3.Text = x.ToString();
            }
            return Convert.ToInt32(Label3.Text);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dbcon.AppointmentsTables.Load();
                var item = from user in dbcon.AppointmentsTables.Local
                           where Convert.ToInt32(GridView1.SelectedDataKey[0]) == user.AppointmentId
                           select user;
                dbcon.AppointmentsTables.Local.Remove(item.First());
                dbcon.SaveChanges();
            }
            catch(Exception exd)
            {

            }               
        }
    }
}