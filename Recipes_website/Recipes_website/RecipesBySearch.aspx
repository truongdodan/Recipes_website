<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="RecipesBySearch.aspx.cs" Inherits="Recipes_website.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/recipesbycatagory.css" />
    <%--<script src="./Script/recipesbycatagory.js" defer></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <main>
        <div class="anchor-wrapper">
            <div class="line"></div>
            <ul runat="server" id="breadcrumb">
                <li><a href="./index.aspx">Trang chủ</a></li>
            </ul>
            <div class="line"></div>
        </div>
        <div class="by-catagory-recipes-wrapper">
            <h2>Search result for 「<span id="catagory-title">Chicken</span>」</h2>
                <div class="recipe-filter-wrapper">
                    <p>Sắp xếp: </p>
                    <asp:DropDownList ID="recipeSorter" runat="server" OnSelectedIndexChanged="recipeSorter_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Mới nhất" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Đánh giá cao" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Lượt xem" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <ul class="by-catagory-recipes-list" runat="server" id="byCatagoryRecipeList">
                    <li>
                        <a href="#">
                            <img src="./image/dui-ga-chien-gion.png" alt="by catagory recipe">
                            <div class="recipe-infor">
                                <p id="recipeName">This is a super duper spicy chicken fried, dont eat this shit brah</p>
                                <p id="recipeAuthor">Author: Jacki Chan</p>
                            </div>
                        </a>
                    </li>
                </ul>
                <div class="recipe-list-navigation" runat="server" id="recipeListNavigation">
                    <asp:Button runat="server" ID="previousPageAspButton" CssClass="btn" Text="Trang sau" OnClick="previousPageAspButton_Click" />
                    <div id="pageNumberIndicator">
                        <span runat="server" id="currentPage">1</span>
                        /
                        <span runat="server" id="pageNumber"></span>
                    </div>
                    <asp:Button runat="server" ID="nextPageAspButton" CssClass="btn" Text="Trang trước" OnClick="nextPageAspButton_Click" />
                </div>
            </div>
            <aside class="popular-catagory-wraper">
                <h3>Các danh mục nổi bật</h3>
                <ul class="popular-catagory">
                    <li>
                        <h4>Theo nguyên liệu </h4>
                        <ul>
                            <li>
                                <a href="#">Đậu phụ</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Thịt gà</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Nấm hương</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Thịt bò</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Khoai tây</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                        </ul>
                    </li>
                    <li>
                        <h4>Theo món ăn </h4>
                        <ul>
                            <li>
                                <a href="#">Món mì</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Cà ri thịt gà</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Mì spaghetti</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Món xào</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Cơm chiên</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                        </ul>
                    </li>
                    <li>
                        <h4>Khác</h4>
                        <ul>
                            <li>
                                <a href="#">Bổ dưỡng</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Dễ tiêu hóa</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">5 nguyên liệu</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Dễ tiêu hóa</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                            <li>
                                <a href="#">Đơn giản</a>
                                <img src="./icon/rightArrow.svg" alt="right arrow">
                            </li>
                        </ul>
                    </li>
                </ul>
            </aside>
        </main>
</asp:Content>
