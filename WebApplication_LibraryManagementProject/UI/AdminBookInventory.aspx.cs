using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication_LibraryManagementProject.Models;

namespace WebApplication_LibraryManagementProject.UI
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {
        private UNILibraryDbContext db = new UNILibraryDbContext();
        private static string gImagePath;
        private static int gActualStock, gCurrentStock, gIssuedBooks;
        protected void Page_Load(object sender, EventArgs e)
        {
            BooksGridViewDataBind();
        }
        private void BooksGridViewDataBind()
        {
            try
            {
                IssuedBookGridView.DataSource = db.BookHistories.ToList();
                IssuedBookGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex + "')</script>");
            }
        }

        private Book GetBookInfo(string operation = "add")
        {
            string genres = "";
            foreach (var i in GenreListBox.GetSelectedIndices())
            {
                genres = genres + GenreListBox.Items[i] + ",";
            }
            //genres = Adventure, Crime, Thriller,
            genres = genres.Remove(genres.Length - 1);

            Book book = new Book();
            book.Id = BookIdTextBox.Text.Trim();
            book.Title = BookNameTextBox.Text.Trim();
            book.Language = LanguageDropDownList.SelectedItem.Value;
            book.Author = AuthorName.Text.Trim();
            book.Genre = genres;
            book.ActualStock = Convert.ToInt32(ActualStockTextBox.Text.Trim());
            if (operation.Equals("update"))
            {
                book.CurrentStock = book.ActualStock - gIssuedBooks;
            }
            else
            {
                book.CurrentStock = book.ActualStock;
            }
            return book;
        }
        private bool CheckIfBookExists(string id, string name)
        {
            var v = db.Books.Where(b => b.Id == id && b.Title == name).FirstOrDefault();
            return v != null;
        }
        private void Clear()
        {
            BookIdTextBox.Text = "";
            BookNameTextBox.Text = "";
            AuthorName.Text = "";
            LanguageDropDownList.SelectedIndex = 0;
            ActualStockTextBox.Text = "";
            CurrentStockTextBox.Text = "";
        }
        protected void AddBookButton_Click(object sender, EventArgs e)
        {
            Book book = GetBookInfo();
            try
            {
                if (CheckIfBookExists(book.Id, book.Title))
                {
                    Response.Write("<script>alert('Book Already Exists')</script>");
                }
                else
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void UpdateBookButton_Click(object sender, EventArgs e)
        {
            Book book = GetBookInfo("update");
            try
            {
                var v = db.Books.Where(b => b.Id == book.Id && b.Title == book.Title).FirstOrDefault();
                if (v != null)
                {
                    v.Genre = book.Genre;
                    v.Language = book.Language;
                    v.ActualStock = book.ActualStock;
                    v.CurrentStock = book.CurrentStock;
                    v.Author = book.Author;
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void DeleteBookButton_Click(object sender, EventArgs e)
        {
            string id = BookIdTextBox.Text.Trim();
            try
            {
                var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (v != null)
                {
                    db.Books.Remove(v);
                    db.SaveChanges();
                    BooksGridViewDataBind();
                    Clear();
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }

        protected void AssignBookButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void GoButton_Click(object sender, EventArgs e)
        {
            string id = BookIdTextBox.Text.Trim();
            try
            {
                var v = db.Books.Where(b => b.Id == id).FirstOrDefault();
                if (v != null)
                {
                    BookNameTextBox.Text = v.Title;
                    LanguageDropDownList.SelectedValue = v.Language;
                    AuthorName.Text = v.Author;
                    string[] genres = v.Genre.Split(',');
                    for (int i = 0; i < genres.Length; i++)
                    {
                        for (int j = 0; j < GenreListBox.Items.Count; j++)
                        {
                            if (GenreListBox.Items[j].ToString() == genres[i])
                            {
                                GenreListBox.Items[j].Selected = true;
                            }
                        }
                    }
                    gActualStock = v.ActualStock;
                    gCurrentStock = v.CurrentStock;
                    gIssuedBooks = v.ActualStock - v.CurrentStock;
                    ActualStockTextBox.Text = v.ActualStock.ToString();
                    CurrentStockTextBox.Text = v.CurrentStock.ToString();
                    IssuedBooksTextBox.Text = gIssuedBooks.ToString();
                }
                else
                {
                    Response.Write("<script>alert('Book Doesn't Exist')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Invalid Request')</script>");
            }
        }
    }
}