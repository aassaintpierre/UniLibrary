using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private UNILibraryDbContext db = new UNILibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMemberInfo();
            }
        }
        
        private void LoadMemberInfo()
        {
            try
            {
                string userId = Session["username"].ToString();
                string userAccess = Session["role"].ToString();

                if (userAccess == "Super Admin")
                {
                    var v = db.SuperAdmins.Where(m => m.Username == userId).FirstOrDefault();
                    if (v != null)
                    {
                        AccountStatusLabel.Text = "Super Admin";
                        AccountStatusLabel.CssClass = "badge badge-pill badge-success";
                        
                        FullNameTextBox.Text = v.FullName;
                        UserNameTextBox.Text = v.Username;
                        EmailIdTextBox.Text = "";
                        NewPasswordTextBox.Text = "";
                    }
                }
                else if (userAccess == "User" || userAccess == "Admin")
                {
                    var v = db.Members.Where(m => m.Username == userId).FirstOrDefault();
                    if (v != null)
                    {
                        AccountStatusLabel.Text = v.AccountStatus;
                        if (v.AccountStatus.Equals("Active"))
                        {
                            AccountStatusLabel.CssClass = "badge badge-pill badge-success";
                        }
                        else if (v.AccountStatus.Equals("Pending"))
                        {
                            AccountStatusLabel.CssClass = "badge badge-pill badge-warning";
                        }
                        else
                        {
                            AccountStatusLabel.CssClass = "badge badge-pill badge-danger";
                        }
                        FullNameTextBox.Text = v.FullName;
                        EmailIdTextBox.Text = v.Email;
                        UserNameTextBox.Text = v.Username;
                        NewPasswordTextBox.Text = "";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Request! Please login again.')</script>");
                }

            }
            
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }


        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = Session["username"].ToString();
                var v = db.Members.Where(m => m.Username == userId).FirstOrDefault();
                if (PasswordTextBox.Text.Trim().Equals(v.Password))
                {
                    v.FullName = FullNameTextBox.Text.Trim();
                    Session["fullname"] = v.FullName;
                    string newPass = NewPasswordTextBox.Text.Trim();
                    if (!newPass.Equals(""))
                    {
                        v.Password = newPass;
                    }
                    db.SaveChanges();
                    Response.Write("<script>alert('Informations updated successfully!')</script>");
                    NewPasswordTextBox.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        
    }
}