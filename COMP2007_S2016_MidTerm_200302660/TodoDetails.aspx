<%@ Page Title="TodoDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200302660.TodoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--
        Author's name: D'Arcey Taylor
        Student	Number: 200302660
        Date Modified: 2016/06/23
        Version: 1.0.0
        File Description: This file contains the form for updating or adding a new todo
    -->

    <div class="container">
        <div class="row">
            <div class="col-md-offset-4 col-md-4">
                <div class="alert alert-danger" id="AlertFlash" runat="server" visible="false">
                    <asp:Label runat="server" ID="StatusLabel" />
                </div>
                <h1>Todo Details Page</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h1 class="panel-title"><i class="fa fa-user-plus fa-lg"></i>Todo Details</h1>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label" for="TodoNameTextBox">Todo Name:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="Todo Name" required="true" TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="TodoNotesTextBox">Todo Notes:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TodoNotesTextBox" placeholder="Todo Notes" required="true" TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="CompletedCheckBox">Completed:</label>
                            <asp:CheckBox runat="server" CssClass="form-control" ID="CompletedCheckBox" required="false" TabIndex="0"></asp:CheckBox>
                        </div>
                        <div class="text-right">
                            <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />
                            <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" TabIndex="0" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
