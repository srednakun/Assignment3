using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assignment3.Helpers
{
	//Methods that help out with getting doctor info
	public class DoctorHandler 
	{
		public static string GetDoctorFullName(int docId)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
			var doctor = dbcon.DoctorsTables.Local
						.Where(user => docId == user.DoctorsId)
						.Select(user => new { user.FirstName, user.LastName }).First();

			return doctor.FirstName + " " + doctor.LastName;
		}
	}
}