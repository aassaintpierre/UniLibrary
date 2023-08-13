<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#body_DoBTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1970:2023",
                dateFormat: 'dd-mm-yy'
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">

        <div class="row">

            <div class="col-md-8 mx-auto">

                <div class="card" style="margin: 10px">

                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <img width="100px" src="../Images/generaluser.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col text-center">
                                <h3>Add Member</h3>
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
                                    <label for="body_EmailTextBox">Email</label>
                                    <asp:TextBox class="form-control" placeholder="example@mail.com" ID="EmailTextBox" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_Status">Status</label>
                                    <asp:DropDownList CssClass="form-control" ID="Status" runat="server">

                                        <asp:ListItem Selected="True">--SELECT--</asp:ListItem>

                                        <asp:ListItem Value="Active">Active</asp:ListItem>

                                        <asp:ListItem Value="Pending">Pending</asp:ListItem>

                                        <asp:ListItem Value="Deactive">Deactive</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_Status">Access level</label>
                                    <asp:DropDownList CssClass="form-control" ID="User_access" runat="server">

                                        <asp:ListItem Selected="True">--SELECT--</asp:ListItem>

                                        <asp:ListItem Value="Admin">Admin</asp:ListItem>

                                        <asp:ListItem Value="User">User</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>

                        

                        <div class="row">
                            <div class="col text-center">
                                <h6><span class="badge badge-pill badge-warning">Login Credentials</span></h6>
                            </div>
                        </div>

                        <div class="row">

                           <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_UsernameTextBox">Username</label>
                                    <asp:TextBox class="form-control" placeholder="User ID" ID="UsernameTextBox" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="body_PasswordTextBox">Password</label>
                                    <asp:TextBox class="form-control" placeholder="******" ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-block btn-success" ID="SignUpButton" runat="server" Text="Register" OnClick="SignUpButton_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
