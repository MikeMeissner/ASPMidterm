<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200289381.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container" id="todoList">
        <div class="row">
            <div class="jumbotron">
                   <div class="col-md-offset-2 col-md-8">
             

                <h1>Todo List</h1>


                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="todoListGridView" AutoGenerateColumns="False" OnRowDeleting="todoListGridView_RowDeleting" DataKeyNames="todoList" >
                    <Columns>
                        <asp:BoundField DataField="TodoName" HeaderText="Todo" Visible="true" SortExpression="todoName" />
                        <asp:BoundField DataField="team1" HeaderText="Team 1" Visible="true" SortExpression="team1" />
                        <asp:BoundField DataField="team2" HeaderText="Team 2" Visible="true" SortExpression="team2" />
                        <asp:BoundField DataField="roundsWon" HeaderText="Rounds Won" Visible="true" SortExpression="roundsWon" />
                    
                          <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="gameID" DataNavigateUrlFormatString="Admin/CsgoDetails.aspx?gameID={0}" />
                         <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i>'Delete" ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />

                    </Columns>
                  </asp:GridView>


                 <a href="Admin/CsgoDetails.aspx" class="btn btn-success btn-md">Add Game Stats</a>
            </div>
            </div>
         
        </div>
    </div>


</asp:Content>

