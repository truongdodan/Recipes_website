<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="RecipesDetail.aspx.cs" Inherits="Recipes_website.WebForm1" MaintainScrollPositionOnPostback="true"%> 
<%--<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="./Style/recipesdetail.css" />
    <script src="./Script/recipesdetail.js" defer ></script>

</asp:Content>
<asp:Content ID="RecipesDetail" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <form runat="server" id="RecipesDetail" enctype="multipart/form-data" method="post">
        <main>
            <asp:ScriptManager runat="server"/>
            <div class="anchor-wrapper">
                <div class="line"></div>
                <ul runat="server" id="breadcrumb">
                    <li><a href="./index.aspx">Trang chủ</a></li>
                </ul>
                <div class="line"></div>
            </div>
            <div class="infor-wrapper" id="inforWrapper" runat="server">
                <div class="dish-image" runat="server" id="dishImage">
                    <img src="./image/ga-ran-muoi-tieu.png" alt="dish image">
                </div>
                <div class="recipe-infor">
                    <h2 class="dish-title" runat="server" id="dishTitle">N/a</h2>
                    <div class="review-infor" runat="server" id="reviewInforInforSection">
                        <ul>
                            <li><img src="./icon/star.svg" alt="rating star"></li>
                            <li><img src="./icon/star.svg" alt="rating star"></li>
                            <li><img src="./icon/star.svg" alt="rating star"></li>
                            <li><img src="./icon/star.svg" alt="rating star"></li>
                            <li><img src="./icon/star.svg" alt="rating star"></li>
                            <li class="star-number"><h4>5</h4></li>
                        </ul>
                        <p class="review-number">(N/a phản hồi)</p>
                    </div>
                    <div class="author" runat="server" id="authorInfor">
                        <img src="./icon/user.svg" alt="author icon">
                        <p>Đăng bởi: </p>
                        <a href="#">N/a</a>
                    </div>
                    <div class="cook-time-infor" runat="server" id="cookTime">
                        <img src="./icon/time.svg" alt="cook time icon">
                        <p class="cook-time-text">Thời gian nấu:  </p>
                        <div class="cook-time">N/a</div>
                        <p class="estimate-text">(ước lượng)</p>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div runat="server" id="lol"></div>
                            <asp:LinkButton runat="server" CssClass="save-recipe btn" ID="saveAspLinkButton" Text="Lưu công thức" OnClick="saveAspLinkButton_Click" >
                                <img />
                                <p></p>
                            </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <%-- this scripts work! if markup inside form with runat="server", script have to be in the same level with markup in the document! --%>
                    <script type="text/javascript">

</script>
                    <aside runat="server" id="descriptionSection">
                        <div class="summary-description">
                            <h4>Mô tả:</h4>
                            <p>
                                N/a
                            </p>
                        </div>
                    </aside>
                </div>
            </div>
            <div class="ingredient-wrapper">
                <h3>Nguyên liệu <%--<span class="server-number">(Xuất ăn 3 người)</span>--%></h3>
                <ul runat="server" id="ingredientSection">
                    <li>N/a</li>
                    <li>N/a</li>
                    <li>N/a</li>
                    <li>N/a</li>
                    <li>N/a</li>
                </ul>
            </div>
            <div class="procedure-wrapper">
                <h3>Quy trình nấu</h3>
                <ol runat="server" id="procedureSection">
                    <%-- instance for backend generate --%>
                    <li>
                        <pre>
        N/a
                        </pre>
                    </li>
                </ol>
            </div>
            <div class="comment-section">
                <div class="review-infor" runat="server" id="reviewInforCommentSection">
                    <h3>Đánh giá</h3>
                    <ul>
                        <li><img src="./icon/star.svg" alt="rating star"></li>
                        <li><img src="./icon/star.svg" alt="rating star"></li>
                        <li><img src="./icon/star.svg" alt="rating star"></li>
                        <li><img src="./icon/star.svg" alt="rating star"></li>
                        <li><img src="./icon/star.svg" alt="rating star"></li>
                        <li class="star-number"><h4>N/a</h4></li>
                    </ul>
                    <p class ID="commentUpdataPanel"="review-number">(N/a phản hồi)</p>
                </div>
                
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <ul class="comments" runat="server" id="commentsListSection">
                            <li>
                                <h4 class="name">N/a</h4>
                                <div>
                                    <div class="comment-infor">
                                        <ul>
                                            <li><img src="./icon/star.svg" alt="rating star"></li>
                                            <li><img src="./icon/star.svg" alt="rating star"></li>
                                            <li><img src="./icon/star.svg" alt="rating star"></li>
                                            <li><img src="./icon/star.svg" alt="rating star"></li>
                                            <li><img src="./icon/star.svg" alt="rating star"></li>
                                        </ul>
                                        <p class="comment-text">N/a</p>
                                    </div>
                                    <div class="comment-image">
                                        <img src="" alt="comment image">
                                    </div>
                                </div>
                            </li>
                        </ul>
                        <div class="comment-btn">
                            <asp:Button Text="Xem thêm" runat="server" ID="loadMoreCommentBtn" CssClass="more-comment btn" OnClick="loadMoreCommentBtn_Click"/>
                            <asp:Button Text="Ẩn bớt" runat="server" ID="hideComment" CssClass="more-comment btn" OnClick="hideComment_Click"/>
                            <div class="add-comment btn save" id="openCommentFormButton" OnClick="turnOnForm()">
                                <img src="./icon/comment.svg" alt="comment icon">
                                <p>Nhận xét</p>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%--<div class="comment-form-wrapper" id="commentForm" runat="server">
                <div class="comment-form">
                    <div class="review-infor">
                        <h3>Đánh giá</h3>
                        <ul>
                            <li><img src="./icon/star_yellow.svg" class="active" alt="rating star"></li>
                            <li><img src="./icon/star_yellow.svg" class="active" alt="rating star"></li>
                            <li><img src="./icon/star_yellow.svg" class="active" alt="rating star"></li>
                            <li><img src="./icon/star_yellow.svg" class="active" alt="rating star"></li>
                            <li><img src="./icon/star_yellow.svg" class="active" alt="rating star"></li>
                        </ul>
                    </div>
                    <div class="add-comment-input">
                        <textarea name="addCommentText" id="addCommentText" placeholder="Nhận xét của bạn"></textarea>
                        <div class="added-comment-image">
                            <label for="addedCommentImage" class="custom-file-upload">
                                <img src="./icon/camera.svg" alt="camera icon">
                            </label>
                            <input type="file" name="AddCommentImage" id="addedCommentImage">
                        </div>
                        <p class="input-error">*Vui lòng điền đầy đủ bình luận và hình ảnh</p>
                    </div>
                    <div class="added-comment-btn">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div runat="server" id="Div1">Hello</div>
                                <asp:Button 
                                    runat="server" 
                                    ID="submitLinkButton" 
                                    Text="Đăng tải" 
                                    OnClick="submitLinkButton_Click"
                                    OnClientClick="return submitForm();">
                                </asp:Button>
                                <input type="button" id="cancelCommentBtn" value="Hủy" onclick="turnOffForm()"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>--%>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="comment-form-wrapper" id="commentForm" runat="server">
                        <div class="comment-form">
                            <div class="review-infor">
                                <h3>Đánh giá</h3>
                                <ul>
                                    <li><img src="./icon/star_yellow.svg" class="active" alt="rating star" ></li>
                                    <li><img src="./icon/star_yellow.svg" class="active" alt="rating star" onclick="changeStarColor(event)"></li>
                                    <li><img src="./icon/star_yellow.svg" class="active" alt="rating star" onclick="changeStarColor(event)"></li>
                                    <li><img src="./icon/star_yellow.svg" class="active" alt="rating star" onclick="changeStarColor(event)"></li>
                                    <li><img src="./icon/star_yellow.svg" class="active" alt="rating star" onclick="changeStarColor(event)"></li>
                                    <input type="hidden" name="reviewStarCounter" value ="5"/> <%-- this for counting user rating star in comment form--%>
                                </ul>
                            </div>
                            <div class="add-comment-input">
                                <textarea name="addCommentText" id="addCommentText" placeholder="Nhận xét của bạn"></textarea>
                                <div class="added-comment-image">
                                    <label for="addedCommentImage" class="custom-file-upload" >
                                        <img src="./icon/camera.svg" alt="camera icon">
                                    </label>
                                    <input type="file" name="AddCommentImage" id="addedCommentImage" onchange="showChosenImage(event)" accept="image/png, image/jpeg, image/jfif"/>
                                </div>
                                <p class="input-error">*Vùng nhận xét không thể để trống!</p>
                            </div>
                            <div class="added-comment-btn">
                                        <%--<div runat="server" id="Div1">Hello</div>--%>
                                <asp:Button 
                                    runat="server" 
                                    ID="submitCommentAspButton" 
                                    Text="Đăng tải" 
                                    OnClick="submitCommentAspButton_Click"
                                    OnClientClick="return submitForm();">
                                </asp:Button>
                                <input type="button" id="cancelCommentBtn" value="Hủy" onclick="turnOffForm()"/>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="submitCommentAspButton" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="similar-recipe-wrapper">
                <h3>Các công thức tương tự</h3>
                <ul class="similar-recipe-list" runat="server" id="similarRecipeList">
                    <%-- instance for backend generate --%>
                    <li>
                        <a href="#">
                            <img src="./image/dui-ga-chien-gion.png" alt="recipe picture">
                            <div class="recipe-title">
                                <p>Đùi gà chiên giòn </p>
                                <div class="background"></div>
                            </div>
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
    </form>
</asp:Content>
