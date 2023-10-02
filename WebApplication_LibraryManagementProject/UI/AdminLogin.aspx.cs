using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private UNILibraryDbContext db = new UNILibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = AdminIdTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            var v = db.Members.Where(m => m.Username == username && m.Password == password && m.Access == "Admin").FirstOrDefault();
            var super = db.SuperAdmins.Where(m => m.Username == username && m.Password == password).FirstOrDefault();
            if (super != null)
            {
                //Super admin
                Session["username"] = super.Username;
                Session["fullname"] = super.FullName;
                Session["status"] = "";
                Session["role"] = "Super Admin";
                Response.Redirect("UserProfile.aspx");

            }
            else if (v != null)
            {
                //Allow access
                Session["username"] = v.Username;
                Session["fullname"] = v.FullName;
                Session["status"] = "";
                Session["role"] = v.Access;
                Response.Redirect("UserProfile.aspx");
            }
            else
            {
                //Deny Access
                Response.Write("<script>alert('Incorrect Username or Password')</script>");
            }
        }

    }
}