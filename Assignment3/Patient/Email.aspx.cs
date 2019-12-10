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
            FillSentMessageTable();

        }
        HospitalEntities1 dbcon = new HospitalEntities1();
        DateTime currentDate = DateTime.Now;
        //get patient username
        string username = System.Web.HttpContext.Current.User.Identity.Name;
        
        public void FillSentMessageTable()
        {
            string patientEmail = Helpers.PatientHandler.GetPatientEmail(username);

            dbcon.MessageTables.Load();
            var messages = from msg in dbcon.MessageTables.Local
                           where patientEmail.Trim() == msg.MessageFROM.Trim()                         
                           select new
                           {
                               msg.MessageId,
                               msg.MessageTO,
                               msg.MessageFROM,
                               msg.Date,
                               msg.Message

                           };

            if (messages.Count() > 0)
            {
                GridView2.DataSource = messages;
                GridView2.DataBind();
            }
        }

        public void FillMessageTable()
        {
            string patientEmail = Helpers.PatientHandler.GetPatientEmail(username);
            dbcon.MessageTables.Load();
            var messages = from msg in dbcon.MessageTables.Local
                           where patientEmail.Trim() == msg.MessageTO.Trim()
                           select new
                           {
                            msg.MessageId,
                            msg.MessageTO,
                            msg.MessageFROM,
                            msg.Date,
                            msg.Message

                           };

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

            //display the current date
            dateLbl.Text = currentDate.ToShortDateString();
        }

        //Save patient message to message table
        protected void sendMsgBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string patientMsg = msgTxtBox.Text;
                string msgFrom = fromLbl.Text;
                string docLastName = DropDownList1.SelectedValue;
                string docEmail = Helpers.DoctorHandler.GetDocEmail(docLastName);
                string msgTo = docEmail;

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
                RefreshPage();
            }
            catch (Exception error)
            {
                notificationLbl.Visible = true;
                notificationLbl.ForeColor = System.Drawing.Color.Red;
                notificationLbl.Text = "Something went wrong! Please enter in all information.";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        //sent messages table
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteRecord(GridView2);
        }
        public void DeleteRecord(GridView grid)
        {
            try
            {
                GridViewRow row = grid.SelectedRow;
                string msgId = row.Cells[1].Text;
                ListBox1.Items.Add(msgId);

                dbcon.MessageTables.Load();
                var item = from user in dbcon.MessageTables.Local
                           where msgId.Trim() == user.MessageId.ToString().Trim()
                           select user;
                dbcon.MessageTables.Local.Remove(item.First());
                dbcon.SaveChanges();
                RefreshPage();
            }
            catch (Exception error)
            {

            }
        }
        public void RefreshPage()
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        //view messages table
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteRecord(GridView1);
        }
    }
}