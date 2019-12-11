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
			FillSentMessageTable();
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

		public void FillSentMessageTable()
		{
			int docId = Helpers.DoctorHandler.GetDocId(docUsername);
			string docEmail = Helpers.DoctorHandler.GetDocEmail(docId);

			dbcon.MessageTables.Load();
			var messages = from msg in dbcon.MessageTables.Local
						   where docEmail.Trim() == msg.MessageFROM.Trim()
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
		protected void sendMsgBtn_Click(object sender, EventArgs e)
		{
			try
			{
				string docMsg = msgTxtBox.Text;
				//ListBox1.Items.Add("docMsg: " + docMsg);
				string msgFrom = fromEmail.Text;
				//ListBox1.Items.Add("msg from: " + msgFrom);
				string patientLastName = patientDrop.SelectedValue;
				//ListBox1.Items.Add("p last name: " + patientLastName);
				string patientEmail = Helpers.PatientHandler.GetEmailByLastName(patientLastName);
				//ListBox1.Items.Add("p email: " + patientEmail);
				string msgTo = patientEmail;
				//ListBox1.Items.Add("msg to: " + msgTo);

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
		public void DeleteRecord(GridView grid)
		{
			try
			{
				GridViewRow row = grid.SelectedRow;
				string msgId = row.Cells[1].Text;

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

		protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			DeleteRecord(GridView1);
		}

		protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
		{
			DeleteRecord(GridView2);
		}
	}
}