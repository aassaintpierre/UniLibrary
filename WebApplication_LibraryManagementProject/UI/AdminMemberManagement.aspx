<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="AdminMemberManagement.aspx.cs" Inherits="WebApplication_LibraryManagementProject.UI.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="container">

            <div class="col-md-8 mx-auto">

                <div class="card" style="margin: 10px">

                    <div class="card-body">


                        <div class="row">
                            <div class="col text-center">
                                <img width="100px" src="../Images/writer.png" />
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col text-center">
                                <h3>Member Management</h3>
                            </div>
                        </div>
                        
                        <br />

                        <div class="row">
                            <div class="col-md-12 text-center">
                                <label for="body_UsernameTextBox">Username</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="Username" ID="UsernameTextBox" runat="server"></asp:TextBox>
                                        <asp:Button CssClass="btn btn-primary" ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label for="body_FullNameTextBox">Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" placeholder="Full Name" ID="FullNameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label for="body_BookIdTextBox">Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" placeholder="Status" ID="AccountStatusTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton CssClass="btn btn-success" ID="ActiveButton" runat="server" OnClick="ActiveButton_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-warning" ID="PendingButton" runat="server" OnClick="PendingButton_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger" ID="DeactiveButton" runat="server" OnClick="DeactiveButton_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label for="body_EmailIDTextBox">Email ID</label>
                                <asp:TextBox class="form-control" placeholder="example@mail.com" ID="EmailIDTextBox" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="body_AccessTextBox">Access</label>
                                <asp:TextBox class="form-control" placeholder="user" ID="AccessTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            
                        </div>

                        <br />

                        <div class="col">
                            <asp:Button CssClass="btn btn-block btn-danger" ID="DeleteUserButton" runat="server" Text="Delete User Permanently" />
                            <asp:LinkButton CssClass="btn btn-block btn-success" ID="AddUserButton" runat="server" OnClick="AddUserButton_Click">Add User</asp:LinkButton>
                        </div>

                    </div>
            </div>

            <!--
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <h3>Member List</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="MemberSqlDataSource" runat="server" ConnectionString="Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;" SelectCommand="SELECT [FullName], [Username], [Email], [AccountStatus], [Access] FROM [Members]"></asp:SqlDataSource>
                                <asp:GridView ID="MemberGridView" CssClass="table table-striped table-bordered table-responsive" runat="server" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="MemberSqlDataSource" OnRowDataBound="MemberGridView_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="FullName" HeaderText="Full name" SortExpression="FullName" />
                                        <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="AccountStatus" HeaderText="Account status" SortExpression="AccountStatus" />
                                        <asp:BoundField DataField="Access" HeaderText="Account access" SortExpression="Access" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            -->
        </div>
    </div>
</asp:Content>
