using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assignment3.Helpers
{
	//Methods that helps out with getting doctor info
	public class DoctorHandler 
	{

		//get doctor email from last name
		public static string GetDocEmail(string lastName)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
			var doctor = dbcon.DoctorsTables.Local
						 .Where(user => lastName.Trim() == user.LastName.Trim())
						 .Select(user => user.Email).First();

			return doctor.ToString();
		}

		//Get doctor full name from username
		public static string GetDoctorFullName(string username)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
			var doctor = dbcon.DoctorsTables.Local
						.Where(user => username == user.UserLoginName.Trim())
						.Select(user => new { user.FirstName, user.LastName }).First();

			return doctor.FirstName + " " + doctor.LastName;
		}
		//Get doctor full name from an id
		public static string GetDoctorFullName(int docId)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
			var doctor = dbcon.DoctorsTables.Local
						.Where(user => docId == user.DoctorsId)
						.Select(user => new { user.FirstName, user.LastName }).First();

			return doctor.FirstName + " " + doctor.LastName;
		}

		//Get doctor id from a username
		public static int GetDocId(string username)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
				
			int docId = (from user in dbcon.DoctorsTables.Local
						 where username == user.UserLoginName.Trim()
						 select user.DoctorsId).First();

			return docId;
		}

		public static string GetDocEmail(int docId)
		{
			HospitalEntities1 dbcon = new HospitalEntities1();
			dbcon.DoctorsTables.Load();
			string doctorEmail = (from user in dbcon.DoctorsTables.Local
								   where docId == user.DoctorsId
								   select user.Email).First();

			return doctorEmail;
		}

		public static string GetDocUsername()
		{
			return System.Web.HttpContext.Current.User.Identity.Name;
		}
	}
}