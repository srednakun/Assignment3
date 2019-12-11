using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Assignment3.Doctor
{
	public partial class DoctorEmail : System.Web.UI.Page
	{
		string docUsername = System.Web.HttpContext.Current.User.Identity.Name;
		HospitalEntities1 dbcon = new HospitalEntities1();
		DateTime currentDate = DateTime.Now;
		protected void Page_Load(object sender, EventArgs e)
		{
			FillLabels();
			FillMessageTable();
			notificationLbl.Visible = false;
		}
		public void FillLabels()
		{
			string docFullName = Helpers.DoctorHandler.GetDoctorFullName(docUsername);
			int docId = Helpers.DoctorHandler.GetDocId(docUsername);
			DocNameLbl.Text = docFullName;
			fromEmail.Text = Helpers.DoctorHandler.GetDocEmail(docId);
			dateLbl.Text = currentDate.ToShortDateString();
		}
		
		public void FillMessageTable()
		{
			int docId = Helpers.DoctorHandler.GetDocId(docUsername);
			string docEmail = Helpers.DoctorHandler.GetDocEmail(docId);

			dbcon.MessageTables.Load();
			var messages = from msg in dbcon.MessageTables.Local
						   where docEmail.Trim() == msg.MessageTO.Trim()
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
				GridView1.DataSource = messages;
				GridView1.DataBind();
			}
		}
		protected void sendMsgBtn_Click(object sender, EventArgs e)
		{
			try
			{
				string docMsg = msgTxtBox.Text;
				ListBox1.Items.Add("docMsg: " + docMsg);
				string msgFrom = fromEmail.Text;
				string patientLastName = patientDrop.SelectedValue;
				string patientEmail = Helpers.PatientHandler.GetEmailByLastName(patientLastName);
				string msgTo = patientEmail;

				
				ListBox1.Items.Add("msg from: " + msgFrom);
				ListBox1.Items.Add("p last name: " + patientLastName);
				ListBox1.Items.Add("msg to: " + msgTo);

				MessageTable message = new MessageTable();
				message.MessageTO = msgTo;
				message.MessageFROM = msgFrom;
				message.Date = currentDate;
				message.Message = docMsg;

				dbcon.MessageTables.Add(message);

				dbcon.SaveChanges();
				RefreshPage();

				notificationLbl.Visible = true;
				notificationLbl.ForeColor = System.Drawing.Color.Green;
				notificationLbl.Text = "Your Message has been sent.";
			}
			catch (Exception error)
			{
				notificationLbl.Visible = true;
				notificationLbl.ForeColor = System.Drawing.Color.Red;
				notificationLbl.Text = "Something went wrong! Please enter in all information.";
				notificationLbl.Text = error.Message;
			}
		}

		public void RefreshPage()
		{
			Page.Response.Redirect(Page.Request.Url.ToString(), true);
		}
	}
}