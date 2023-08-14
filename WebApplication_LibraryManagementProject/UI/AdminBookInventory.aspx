<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.AdminBookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#body_PublishDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1950:2020",
                dateFormat: 'dd-mm-yy'
            });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Book Management</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <img id="imgview" width="100px" src="../Images/Books/writer.png" />
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-4">
                                <label for="body_BookIdTextBox">Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="ID" ID="BookIdTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label for="body_BookNameTextBox">Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Book Name" ID="BookNameTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_LanguageDropDownList">Language</label>
                                    <asp:DropDownList CssClass="form-control" ID="LanguageDropDownList" runat="server">
                                        <asp:ListItem Text="--SELECT--" Selected="True" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="Spanish" Value="French" />

                                    </asp:DropDownList>
                                </div>
                                
                            </div>

                            <div class="col-md-4">
                                <label for="body_AutherNameDropDownList">Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox Class="form-control" placeholder="Author" ID="AuthorName" runat="server">
                                    </asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_GenreListBox">Genre</label>
                                    <asp:ListBox ID="GenreListBox" CssClass="form-control" runat="server" Rows="5" SelectionMode="Multiple">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                        <asp:ListItem Text="Self Help" Value="Self Help" />
                                        <asp:ListItem Text="Motivation" Value="Motivation" />
                                        <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                        <asp:ListItem Text="Wellness" Value="Wellness" />
                                        <asp:ListItem Text="Crime" Value="Crime" />
                                        <asp:ListItem Text="Drama" Value="Drama" />
                                        <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                        <asp:ListItem Text="Horror" Value="Horror" />
                                        <asp:ListItem Text="Poetry" Value="Poetry" />
                                        <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                        <asp:ListItem Text="Romance" Value="Romance" />
                                        <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                        <asp:ListItem Text="Suspense" Value="Suspense" />
                                        <asp:ListItem Text="Thriller" Value="Thriller" />
                                        <asp:ListItem Text="Art" Value="Art" />
                                        <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                        <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                        <asp:ListItem Text="Health" Value="Health" />
                                        <asp:ListItem Text="History" Value="History" />
                                        <asp:ListItem Text="Math" Value="Math" />
                                        <asp:ListItem Text="Textbook" Value="Textbook" />
                                        <asp:ListItem Text="Science" Value="Science" />
                                        <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_ActualStockTextBox">Actual Stock</label>
                                    <asp:TextBox class="form-control" placeholder="Actual Stock" ID="ActualStockTextBox" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_CurrentStockTextBox">Current Stock</label>
                                    <asp:TextBox class="form-control" placeholder="Current Stock" ID="CurrentStockTextBox" ReadOnly="true" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_IssuedBooksTextBox">Issued Books</label>
                                    <asp:TextBox class="form-control" placeholder="Issued Books" ID="IssuedBooksTextBox" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        
                        <div class="row">
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-success" ID="AddBookButton" runat="server" Text="Add" OnClick="AddBookButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-primary" ID="UpdateBookButton" runat="server" Text="Update" OnClick="UpdateBookButton_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button CssClass="btn btn-block btn-danger" ID="DeleteBookButton" runat="server" Text="Delete" OnClick="DeleteBookButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <br />
            </div>

        </div>
    </div>
</asp:Content>
