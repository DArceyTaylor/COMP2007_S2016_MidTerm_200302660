<%@ Page Title="TodoList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200302660.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!--
    Author's name: D'Arcey Taylor
    Student	Number: 200302660
    Date Modified: 2016/06/23
    Version: 1.0.0
    File Description: This file contains the todo records
-->

    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo List:</h1>
                   
                <br />
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm" onclick=""><i class="fa fa-plus"></i>Add Todo Item</a>
                <br />
                <div>
                    <label for="PageSizeDropDownList">Records per Page: </label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default btn-sm dropdown-toggle"
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>

                <asp:GridView runat="server" CssClass="table table-bordered table-stripped table-hover"
                    ID="TodoDataGridView" AutoGenerateColumns="false" DataKeyNames="TodoID"
                    OnRowDeleting="TodoDataGridView_RowDeleting" AllowPaging="true" PageSize="3"
                    OnPageIndexChanging="TodoDataGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="TodoDataGridView_Sorting" OnRowDataBound="TodoDataGridView_RowDataBound"
                    PagerStyle-CssClass="pagination-ys">

                    <Columns>
                        <asp:BoundField DataField="TodoName" HeaderText="Todo" Visible="true" SortExpression="TodoName" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" SortExpression="TodoNotes" />
                        <asp:BoundField DataField="Completed" HeaderText="Completed" Visible="true" SortExpression="Completed" />

                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="TodoDetails.aspx" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="~/TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o -fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>

                </asp:GridView>
                <div>
                    <a class="btn btn-primary" href="Default.aspx"><span class="glyphicon glyphicon-arrow-left"> Back</span></a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
