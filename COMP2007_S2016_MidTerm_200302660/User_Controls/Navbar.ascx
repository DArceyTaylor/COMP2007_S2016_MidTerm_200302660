﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="COMP2007_S2016_MidTerm_200302660.Navbar" %>
<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-database fa-lg"></i> Todo List App</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <!-- If not logged in -->
                <asp:PlaceHolder ID="PublicPlaceHolder" runat="server">
                    <li id="home" runat="server"><a href="Default.aspx"><i class="fa fa-home fa-lg"></i> Home</a></li>
                    <li id="todo" runat="server"><a href="TodoList.aspx"><i class="fa fa-list-alt fa-lg"></i> Todo List</a></li>
                    <li id="Login" runat="server"><a href="/Login.aspx"><i class="fa fa-sign-in fa-lg"></i> Login</a></li>
                </asp:PlaceHolder>

                <!-- If Logged in as normal user -->
                <asp:PlaceHolder ID="UserPlaceHolder" runat="server">
                   <li id="Logout" runat="server"><a href="/Logout.aspx"><i class="fa fa-sign-out fa-lg"></i> Logout</a></li>
                </asp:PlaceHolder>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
