<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Recipes_website.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/index.css" />
    <script src="./Script/index.js" defer></script>
</asp:Content>
<asp:Content ID="index" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <main>
        <div class="banner-wrapper">
            <div class="image-wrapper"><img src="" alt="commercial banner"></div>
        </div>
        <div class="top-recipes-wrapper">
            <h3>Top công thức nổi bật trong ngày</h3>
            <div class="top-content-wrapper">
                <img src="./icon/leftArrowTopRes.svg" alt="navigation icon">
                <div class="overflow-wrapper">
                    <ul class="top-cards" id="topCards" runat="server">
                        <%-- for backend generate reference --%>
                        <li>
                            <a href="#" id="number1">
                            <div class="rank-number">1</div>
                            <div class="image-wrapper"><img src="./image/dui-ga-chien-gion.png" alt="dish image"></div>
                            <p>Dish's name</p>
                        </a>
                       </li>
                        
                    </ul>
                </div>
                <img src="./icon/rightArrowTopRes.svg" alt="navigation icon">
            </div>
        </div>
        <div class="recipes-by-popular-keyword-wrapper">
            <h3>Gợi ý theo từ khóa nổi bật</h3>
            <ul class="recipes-by-popular-keyword">
                <li>
                    <h4 class="keyword" runat="server" id="keyWord1">A popular keyword</h4>
                    <div class="overflow-wrapper">
                        <ul class="keyword-list" runat="server" id="keywordList1">
                            <%-- instance for backend generate cards - 6 cards --%>
                            <li>
                                <a href="#">
                                    <img src="#" alt="new recipe">
                                    <p>Recipe's name</p>
                                </a>
                            </li>

                        </ul>
                    </div>
                    <a href="#">Xem them</a>
                </li>
                <li>
                    <h4 class="keyword" runat="server" id="keyWord2">A popular keyword</h4>
                    <div class="overflow-wrapper">
                        <ul class="keyword-list" runat="server" id="keywordList2">
                            <%-- 6 cards here too! --%>

                        </ul>
                    </div>
                    <a href="#">Xem them</a>
                </li>
                <li>
                    <h4 class="keyword"  runat="server" id="keyWord3">A popular keyword</h4>
                    <div class="overflow-wrapper">
                        <ul class="keyword-list"  runat="server" id="keywordList3">
                            <%-- 6 cards here too! --%>

                        </ul>
                    </div>
                    <a href="#">Xem them</a>
                </li>
                <li>
                    <h4 class="keyword"  runat="server" id="keyWord4">A popular keyword</h4>
                    <div class="overflow-wrapper">
                        <ul class="keyword-list"  runat="server" id="keywordList4">
                            <%-- 6 cards here too! --%>    
                            
                        </ul>
                    </div>
                    <a href="#">Xem them</a>
                </li>
            </ul>
        </div>
        <div class="new-recipes-wrapper">
            <h3>Các công thức mới</h3>
            <ul class="new-recipes-list" id="newRecipesList" runat="server">
                 <%-- for backend generate reference --%>
                <li>
                    <a href="#">
                        <img src="" alt="new recipe">
                        <p>This is a recipe</p>
                    </a>
                </li>
                
            </ul>
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
