using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;


namespace Assignment3.Patient
{
    public partial class Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillLabels();
            notificationLbl.Visible = false;


        }
        HospitalEntities1 dbcon = new HospitalEntities1();
        DateTime currentDate = DateTime.Now;
        //Fills in patient name, doctor name, and date labels.
        public void FillLabels()
        {
            //get patient username
            string username = System.Web.HttpContext.Current.User.Identity.Name;
            //get patient's doctorId
            int docId = Helpers.PatientHandler.getPatientDocId(username);

            //display patient's full name
            patientNameLbl.Text = Helpers.PatientHandler.GetPatientFullName(username);
            toPatientNameLbl.Text = Helpers.PatientHandler.GetPatientFullName(username);

            //display patient's full doctor name 
            docLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);
            toDocLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);

            //display the current date
            
            dateLbl.Text = currentDate.ToShortDateString();
        }

        //Save patient message to message table
        protected void sendMsgBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string patientMsg = msgTxtBox.Text;
                string msgTo = toDocLbl.Text;
                string msgFrom = patientNameLbl.Text;

                MessageTable message = new MessageTable();
                message.MessageTO = msgTo;
                message.MessageFROM = msgFrom;
                message.Date = currentDate;
                message.Message = patientMsg;

                dbcon.MessageTables.Add(message);

                dbcon.SaveChanges();
                notificationLbl.Visible = true;
                notificationLbl.ForeColor = System.Drawing.Color.Green;
                notificationLbl.Text = "Your Message has been sent.";

                msgTxtBox.Text = "";
            }
            catch (Exception error)
            {
                notificationLbl.Visible = true;
                notificationLbl.ForeColor = System.Drawing.Color.Red;
                notificationLbl.Text = "Something went wrong! Please enter in all information.";
            }
        }
    }
}