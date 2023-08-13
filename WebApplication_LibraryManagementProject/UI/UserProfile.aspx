<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#body_DoBTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1970:2030",
                dateFormat: 'dd-mm-yy'
            });
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card" style="margin: 10px">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img width="80px" src="../Images/generaluser.png" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Your Account</h3>
                                <span>Account status - </span>
                                <asp:Label CssClass="badge badge-pill badge-info" Text="your status" ID="AccountStatusLabel" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_FullNameTextBox">Full Name</label>
                                    <asp:TextBox class="form-control" placeholder="Full Name" ID="FullNameTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_EmailIdTextBox">Email ID</label>
                                    <asp:TextBox class="form-control" placeholder="example@mail.com" ID="EmailIdTextBox" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                       
                        <div class="row">
                            <div class="col">
                                <h6 class="text-center"><span class="badge badge-pill badge-warning">Enter your password to update data</span></h6>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_UserIdTextBox">Username</label>
                                    <asp:TextBox class="form-control" placeholder="User ID" ID="UserNameTextBox" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_PasswordTextBox">Password</label>
                                    <asp:TextBox class="form-control" placeholder="******" ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="body_NewPasswordTextBox"> New Password</label>
                                    <asp:TextBox class="form-control" placeholder="******" ID="NewPasswordTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-block btn-primary" ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
</asp:Content>
