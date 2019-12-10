using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment3.Doctor
{
	public partial class DoctorHome : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			FillLabels();
		}

		//Show doc username and full name on doc home page
		public void FillLabels()
		{
			string docUsername = System.Web.HttpContext.Current.User.Identity.Name;
			docNameLbl.Text = Helpers.DoctorHandler.GetDoctorFullName(docUsername);
		}
	}
}