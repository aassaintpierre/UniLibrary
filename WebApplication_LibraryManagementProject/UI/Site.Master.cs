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
                    ViewBooksLink.Visible = false;
                    LogoutLink.Visible = false;
                    HelloUserNavLinkButton.Visible = false;
                    BookManagLink.Visible = false;
                    MemberManagementLink.Visible = false;
                }
                else if (Session["role"].Equals("User"))
                {;
                    ViewBooksLink.Visible = true;
                    LogoutLink.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, " + Session["fullname"];
                    BookManagLink.Visible = true;
                    MemberManagementLink.Visible = false;
                }
                else if (Session["role"].Equals("Admin"))
                {
                    ViewBooksLink.Visible = true;
                    LogoutLink.Visible = true;
                    HelloUserNavLinkButton.Text = "Hello, Admin";
                    BookManagLink.Visible = true;
                    MemberManagementLink.Visible = true;
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

        protected void BookManagLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void MemberManagementLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagement.aspx");
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
            if (Session["role"].Equals("User") || Session["role"].Equals("Admin"))
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