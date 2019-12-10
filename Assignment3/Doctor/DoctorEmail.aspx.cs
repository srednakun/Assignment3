using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3.Doctor
{
	public partial class DoctorEmail : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			FillLabels();
		}
		public void FillLabels()
		{
			string docUsername = System.Web.HttpContext.Current.User.Identity.Name;
			string docFullName = Helpers.DoctorHandler.GetDoctorFullName(docUsername);
			DocNameLbl.Text = docFullName;
			fromDocNameLbl.Text = docFullName;
		}
		protected void sendMsgBtn_Click(object sender, EventArgs e)
		{

		}
	}
}