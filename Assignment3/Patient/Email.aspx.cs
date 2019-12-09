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
            FillMessageTable();
            noNewMsgLbl.Visible = false;

        }
        HospitalEntities1 dbcon = new HospitalEntities1();
        DateTime currentDate = DateTime.Now;
        //get patient username
        string username = System.Web.HttpContext.Current.User.Identity.Name;

        public void FillMessageTable()
        {
            int docId = Helpers.PatientHandler.getPatientDocId(username);
            dbcon.DoctorsTables.Load();
            dbcon.PatientTables.Load();

            var docEmail = (from user in dbcon.DoctorsTables.Local
                           where docId == user.DoctorsId
                           select user.Email).First();
            //ListBox1.Items.Add("Doc email: " + docEmail);

            var patientEmail = (from user in dbcon.PatientTables.Local
                               where username == user.UserLoginName.Trim()
                               select user.Email).First();
            //ListBox1.Items.Add("Patient email: " + patientEmail);

            dbcon.MessageTables.Load();
            var messages = from msg in dbcon.MessageTables.Local
                           where docEmail.Trim() == msg.MessageFROM.Trim() &&
                           patientEmail.Trim() == msg.MessageTO.Trim()
                           select new
                           {
                            msg.MessageTO,
                            msg.MessageFROM,
                            msg.Date,
                            msg.Message

                           };

            //ListBox1.Items.Add("count: " + messages.Count());
            if(messages.Count() > 0)
            {
                GridView1.DataSource = messages;
                GridView1.DataBind();
            }
            else
            {
                noNewMsgLbl.Text = "No new messages in your inbox.";
                

            }
        }

        //Fills in patient name, doctor name, and date labels.
        public void FillLabels()
        {
            //get patient's doctorId
            int docId = Helpers.PatientHandler.getPatientDocId(username);

            //display patient's full name
            patientNameLbl.Text = Helpers.PatientHandler.GetPatientFullName(username);
            fromLbl.Text = Helpers.PatientHandler.GetPatientEmail(username);

            //display patient's full doctor name 
            docLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docId);
            toLbl.Text = Helpers.DoctorHandler.GetDocEmail(docId);

            //display the current date
            dateLbl.Text = currentDate.ToShortDateString();
        }


        //Save patient message to message table
        protected void sendMsgBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string patientMsg = msgTxtBox.Text;
                string msgTo = toLbl.Text;
                string msgFrom = fromLbl.Text;

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