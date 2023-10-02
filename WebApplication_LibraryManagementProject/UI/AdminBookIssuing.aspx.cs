using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        private UNILibraryDbContext db = new UNILibraryDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*GridViewDataBind();*/
        }
        /*private void GridViewDataBind()
        {
            try
            {
                IssuedBookGridView.DataSource = db.BookIssues.ToList();
                IssuedBookGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }*/
        private bool CheckIfBookExists(string id)
        {
            var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfMemberExists(string username)
        {
            var v = db.Members.Where(b => b.Username == username).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfAccountActive(string username)
        {
            var v = db.Members.Where(b => b.Username == username && b.AccountStatus.Equals("active")).FirstOrDefault();
            return v != null;
        }
        private bool CheckIfIssueEntryExists(string mId, string bId)
        {
            var v = db.BookHistories.Where(b => b.MemberId == mId && b.BookId == bId).FirstOrDefault();
            return v != null;
        }
        private void Clear()
        {
            UsernameTextBox.Text = "";
            BookIdTextBox.Text = "";
            MemberNameTextBox.Text = "";
            BookNameTextBox.Text = "";
            StartDateTextBox.Text = "";
            EndDateTextBox.Text = "";
            ErrorLabel.Text = "";
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {

            try
            {
                var member = db.Members.Where(m => m.Username == UsernameTextBox.Text.Trim()).FirstOrDefault();
                var book = db.Books.Where(b => b.Id == BookIdTextBox.Text.Trim()).FirstOrDefault();
                if(member != null && book != null)
                {
                    MemberNameTextBox.Text = member.FullName;
                    BookNameTextBox.Text = book.Title;
                    ErrorLabel.Text = "Go Bouton clicked";
                }
                else
                {
                    ErrorLabel.Text = "Member and Book with given id doesn't exist!";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex+"')</script>");
            }
        }

        protected void IssueButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                BookHistory bookIssue = new BookHistory();
                bookIssue.MemberId = UsernameTextBox.Text.Trim();
                bookIssue.BookId = BookIdTextBox.Text.Trim();
                bookIssue.IssueDate = StartDateTextBox.Text.Trim();
                ErrorLabel.Text = StartDateTextBox.Text.Trim();


                if (CheckIfBookExists(bookIssue.BookId) && CheckIfMemberExists(bookIssue.MemberId))
                {
                    if(CheckIfIssueEntryExists(bookIssue.MemberId, bookIssue.BookId))
                    {
                        ErrorLabel.Text = "Member already have this book";
                    }
                    else
                    {
                        if (CheckIfAccountActive(bookIssue.MemberId))
                        {
                            var book = db.Books.Where(b => b.Id == bookIssue.BookId).FirstOrDefault();
                            if (book.CurrentStock > 0)
                            {
                                book.CurrentStock--;
                                db.BookHistories.Add(bookIssue);
                                db.SaveChanges();
                                /*GridViewDataBind();*/
                                Clear(); 
                            }
                            else
                            {
                                ErrorLabel.Text = "Sorry! No more book in stock.";
                            }
                        }
                        else
                        {
                            ErrorLabel.Text = "Account is not active!";
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book or Member doesn't exist!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                string mId = UsernameTextBox.Text.Trim();
                string bId = BookIdTextBox.Text.Trim();

                if (CheckIfBookExists(bId) && CheckIfMemberExists(mId))
                {
                    var v = db.BookHistories.Where(b => b.MemberId == mId && b.BookId == bId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Book.CurrentStock++;
                        db.BookHistories.Remove(v);
                        db.SaveChanges();
                        /*GridViewDataBind();*/
                        Clear();
                    }
                    else
                    {
                        ErrorLabel.Text = "Entry doesn't exist!";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Book or Mebmber doesn't exist!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        //For coloring defaulters list on gridview row
        protected void IssuedBookGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}