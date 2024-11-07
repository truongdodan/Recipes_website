<%@ Page Title="Tài khoản" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Recipes_website.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/user.css" />
    <script src="./Script/user.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <main>
        <asp:ScriptManager runat="server"/>
            <div class="user-infor-wrapper">
                <a class="user-image">
                    <img src="./image/user.jfif" alt="user image">
                </a>
                <div class="user-infor">
                    <p id="userName" runat="server">dantRuong do</p>
                    <p id="userId" runat="server">Id: user@666666</p>
                    <div class="logout-button-wrapper" runat="server" id="logoutButtonWrapper">
                        <asp:Button runat="server" ID="logoutAspButton" Text="Đăng xuất" OnClick="logoutAspButton_Click"/>
                    </div>
                </div>
            </div>
            <%--<div runat="server" id="addRecipeButtonWrapper" class="add-recipe-button-wrapper"><asp:Button runat="server" ID="addRecipeButton" class="btn" value="Thêm công thức"></div>--%>
            <div class="recipes-list-wrapper">
            <div class="menu-tab">
                <asp:Button runat="server" ID="saveRecipeTab" Text="Công thức đã lưu" CssClass="selected" UseSubmitBehavior="true" OnClick="saveRecipeTab_Click"/>
                <asp:Button runat="server" ID="createdRecipeTab" Text="Công thức đã tạo" CssClass="" UseSubmitBehavior="true" OnClick="createdRecipeTab_Click"/>
            </div>
            <ul class="recipes-list" id="recipeList" runat="server">
                <li>
                    <a href="#">
                        <img src="./image/dui-ga-chien-gion.png" alt="by catagory recipe">
                        <div class="recipe-infor">
                            <p id="recipeName">This is a super duper spicy chicken fried, dont eat this brah</p>
                            <p id="recipeAuthor">Author: Jacki Chan</p>
                        </div>
                    </a>
                </li>
            </ul>
            <div class="recipe-list-navigation" runat="server" id="recipeListNavigation">
                <asp:Button runat="server" ID="previousPageAspButton" CssClass="btn" Text="Trang sau" OnClick="previousPageAspButton_Click"/>
                <div id="pageNumberIndicator">
                    <span runat="server" id="currentPage">1</span>
                    /
                    <span runat="server" id="pageNumber"></span>
                </div>
                <asp:Button runat="server" ID="nextPageAspButton" CssClass="btn" Text="Trang trước" OnClick="nextPageAspButton_Click"/>
            </div>
            </div>
        </main>
</asp:Content>
