using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assignment3.Helpers

	//methods that help with getting patient info
{
	public class PatientHandler 
	{
		public static int getPatientDocId(string patientUsername)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.PatientTables.Load();
			int docId = dbcon.PatientTables.Local
					    .Where(user => patientUsername == user.UserLoginName.Trim())
						.Select(user => user.DoctorID).First();

			return docId;
		}

		public static string GetPatientFullName(string username)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.PatientTables.Load();
			var patient = dbcon.PatientTables.Local
							      .Where (user => username == user.UserLoginName.Trim())
							      .Select (user => new { user.FirstName, user.LastName }).First();

			return patient.FirstName + " " + patient.LastName;
		}

		//Get the patientId using the patient username 
		public static int getPatientId(string username)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.PatientTables.Load();
			int patientId = (from user in dbcon.PatientTables.Local
							 where username == user.UserLoginName.Trim()
							 select user.PatientID).First();

			return patientId;
		}

		public static string getPatientUsername()
		{
			return System.Web.HttpContext.Current.User.Identity.Name;
		}
	}
}