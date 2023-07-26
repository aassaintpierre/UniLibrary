<%@ Page Title="" Language="C#" 
    MasterPageFile="~/UI/Site.Master" 
    AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" 
    Inherits="WebApplication_LibraryManagementProject.UI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <section>
        <div class="card">
            <div class="header">
                <img src="../Images/LMS2.png" alt="Logo" />
                <label class="logo-label">UniLibrary Management System</label>
            </div>


            <div class="content">

                <a href="UserLogin.aspx">
                    <div class="column" onclick="onUserClick()">
                        <img src="../Images/generaluser.png" alt="User Icon" />
                        <label>User</label>
                    </div>
                </a>

                <a href="AdminLogin.aspx">
                    <div class="column" onclick="onAdminClick()">
                        <img src="../Images/adminuser.png"" alt="Admin Icon" />
                        <label>Admin</label>
                    </div>
                </a>

            </div>

        </div>

    </section>
    
</asp:Content>
