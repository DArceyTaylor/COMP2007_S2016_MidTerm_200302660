<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200302660.Todo.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--
    Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file contains our Login form, with a link to our Register page incase the user doesn't have a login
-->
    <div class="container">

        <div class="row">

            <div class="col-md-offset-4 col-md-4">

                <div class="alert alert-danger" id="AlertFlash" runat="server" visible="false">

                    <asp:Label runat="server" ID="StatusLabel" />

                </div>

                <h1>Login Page</h1>

                <div class="panel panel-primary">

                    <div class="panel-heading">

                        <h1 class="panel-title"><i class="fa fa-sign-in fa-lg"></i>Login</h1>

                    </div>

                    <br />

                    <div class="panel-body">

                        <div class="form-group">

                            <label class="control-label" for="UserNameTextBox">Username:</label>

                            <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>

                        </div>

                        <div class="form-group">

                            <label class="control-label" for="PasswordTextBox">Password:</label>

                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>

                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button Text="Back" ID="BackButton" runat="server" CssClass="btn btn-danger" OnClick="BackButton_Click" TabIndex="0" formnovalidate="True" />
                            </div>

                            <div class="col-md-6 text-right">
                                <asp:Button Text="Login" ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" TabIndex="0" />
                            </div>
                        </div>
                        <br />
                        <div class="text-right">
                            <asp:Button Text="Register" ID="RegisterButton" runat="server" CssClass="btn btn-warning" OnClick="RegisterButton_Click" TabIndex="0" formnovalidate="True" />
                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>
</asp:Content>
