using System;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null)
            {
                LogoutNavLinkButton_Click(sender, e);
            }
            try
            {
                if (Session["role"].Equals(""))
                {
                    AboutLink.Visible = true;
                    ViewBooksLink.Visible = false;
                    UserLoginLink.Visible = true;
                    LogoutLink.Visible = false;
                    HelloUserNavLinkButton.Visible = false;
                    BookIssuingLink.Visible = false;
                    MemberManagementLink.Visible = false;
                    AddMemberLink.Visible = false;
                }
                else if (Session["role"].Equals("User"))
                {
                    AboutLink.Visible = false;
                    ViewBooksLink.Visible = true;
                    UserLoginLink.Visible = false;
                    LogoutLink.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, " + Session["fullname"];
                    BookIssuingLink.Visible = true;
                    MemberManagementLink.Visible = false;
                    AddMemberLink.Visible = false;
                }
                else if (Session["role"].Equals("Admin"))
                {
                    AboutLink.Visible = false;
                    ViewBooksLink.Visible = true;
                    UserLoginLink.Visible = false;
                    LogoutLink.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, Admin";
                    BookIssuingLink.Visible = true;
                    MemberManagementLink.Visible = true;
                    AddMemberLink.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void AboutLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutUs.aspx");
        }

        protected void BookIssuingLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void MemberManagementLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
        }

        protected void AddMemberLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void UserLoginNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void SignUpNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LogoutNavLinkButton_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Session["role"] = "";
            Response.Redirect("HomePage.aspx");
        }

        protected void HelloUserNavLinkButton_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("user"))
            {
                Response.Redirect("UserProfile.aspx");
            }
        }

        protected void ViewBooksNavLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

    }
}