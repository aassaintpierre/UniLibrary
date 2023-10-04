using System;
using System.Linq;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private UNILibraryDbContext db = new UNILibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Only Super admin can remove book from database
                if (Session["role"].Equals("Super Admin"))
                {
                    AdminAccess.Text = "Admin";
                    AdminAccess.Value = "Admin";
                }
                else
                {
                    AdminAccess.Text = "";

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            member.FullName = FullNameTextBox.Text.Trim();
            member.Email = EmailTextBox.Text.Trim();
            member.AccountStatus = Status.SelectedItem.Value;
            member.Access = User_access.SelectedItem.Value;
            member.Username = UsernameTextBox.Text.Trim();
            member.Password = PasswordTextBox.Text.Trim();

            try
            {
                if (CheckIfMemberExists(member.Username))
                {
                    Response.Write("<script>alert('User Already Exists')</script>");

                }
                else
                {
                    db.Members.Add(member);
                    db.SaveChanges();
                    Response.Write("<script>alert('User registered successfully.')</script>");

                    FullNameTextBox.Text = "";
                    EmailTextBox.Text = "";
                    UsernameTextBox.Text = "";
                    PasswordTextBox.Text = "";

                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        private bool CheckIfMemberExists(string username)
        {
            var v = db.Members.Where(m => m.Username == username).FirstOrDefault();
            return v != null;
        }
    }
}