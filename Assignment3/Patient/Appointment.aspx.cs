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
            FillLabels();
            FillApptTable();
        }
        string username = Helpers.PatientHandler.getPatientUsername();
        public void FillLabels()
        {
            patientNameLbl.Text = Helpers.PatientHandler.GetPatientFullName(username);
            int docId = Helpers.PatientHandler.getPatientDocId(username);
            docLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);
        }
        public void FillApptTable()
        {
            try
            {
                dbcon.AppointmentsTables.Load();
                NoAppointmentMsg.Visible = false;

                int x = Helpers.PatientHandler.getPatientId(username);
                var item = from user in dbcon.AppointmentsTables.Local
                           where x == user.PaitentID && user.Date.CompareTo(DateTime.Today) >= 0
                           select user;
                GridView1.DataSource = item;
                GridView1.DataBind();
                if (item.Count() == 0)
                {
                    NoAppointmentMsg.Visible = true;
                    NoAppointmentMsg.Text = "You Currently dont have any appointments with us.";
                }
            }
            catch (Exception error)
            {

            }
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