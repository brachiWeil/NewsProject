<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>חדשות היום</h1>
        <p class="lead">כאן יוצגו כל נושאי החדשות.</p>
    </div>

    <asp:Repeater ID="rptNews" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%# Eval("Title") %></h2>
                <p><%# Eval("Description") %></p>
                <p><a class="btn btn-default" href='<%# Eval("Link") %>'>קרא עוד &raquo;</a></p>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
