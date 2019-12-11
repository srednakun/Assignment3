using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Assignment3
{
    public partial class Logon : System.Web.UI.Page
    {
        HospitalEntities1 dbcon = new HospitalEntities1();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Label1.Visible = false;
        }



        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            dbcon.UsersTables.Load();

            string userDoctortype = "doctor";
            string userPatienttype = "patient";
        

            var Doctoruser = from item in dbcon.UsersTables.Local
                             where userDoctortype.Trim().Equals(item.UserLoginType.Trim())
                             select item;
            var PatientUser = from item in dbcon.UsersTables.Local
                              where userPatienttype.Equals(item.UserLoginType.Trim())
                              select item;



            foreach (var item in Doctoruser)
            {
                if (userDoctortype.Equals(item.UserLoginType.Trim()))
                {
                    if (Login1.UserName.Trim().Equals(item.UserLoginName.Trim()) && Login1.Password.Trim().Equals(item.UserLoginPass.Trim()))
                    {
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                    }

                }

            }

            foreach (var item in PatientUser)
            {

                if (userPatienttype.Equals(item.UserLoginType.Trim()))
                {
                    if (Login1.UserName.Trim().Equals(item.UserLoginName.Trim()) && Login1.Password.Trim().Equals(item.UserLoginPass.Trim()))
                    {
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
                    }

                }



            }
        }


            protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {


        }
      




    }
}