using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Assignment3.Patient
{
    public partial class PatentHome : System.Web.UI.Page
    {
        HospitalEntities1 dbcon = new HospitalEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillLabels();
            Label1.Visible = false;

        }
        public void FillLabels()
        {
            string username = Helpers.PatientHandler.getPatientUsername();
            patientNameLbl.Text = Helpers.PatientHandler.GetPatientFullName(username);
            int docId = Helpers.PatientHandler.getPatientDocId(username);
            docNameLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            dbcon.TestTables.Load();
            int xd = patientID();
            var med = from user in dbcon.TestTables.Local
                      where xd == user.PatientID
                      select new
                      {
                          user.TestDate,
                          user.TestResults
                      };
            GridView2.DataSource = med;
            GridView2.DataBind();
            
                     


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dbcon.MedicationListTables.Load();
            int x = patientID();
            var med = from user in dbcon.MedicationListTables.Local
                      where x == user.PatientID
                      select user.Description;
            GridView1.DataSource = med;
            GridView1.DataBind();
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
                Label1.Text = x.ToString();
            }
            return Convert.ToInt32(Label1.Text);
        }
    }
}