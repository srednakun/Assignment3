using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;

namespace Assignment3.Patient
{
	public partial class PatientLogin : System.Web.UI.Page
	{
		HospitalEntities dbcon = new HospitalEntities();

		protected void Page_Load(object sender, EventArgs e)
		{
			UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
		}

		protected void PatientLoginAuthenticate_Click(object sender, EventArgs e)
		{
			dbcon.UsersTables.Load();
			string username = Login1.UserName;
			string password = Login1.Password;

			

			

		}
	}
}