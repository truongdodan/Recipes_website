using Recipes_website.App_Codes.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Recipes_website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Recipe> recipes;
        Recipe currentRecipe;
        string[] ratingFileType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                recipes = (List<Recipe>)Session["Recipes"];


                //get recipe id
                string recipeId = Request.QueryString["id"];

                int id = int.Parse(recipeId);

                Session["CurrentRecipe"] = Recipe.getRecipeById(id, recipes);

                //Set current recipe to session current recipe - use for load more comment func
                currentRecipe = (Recipe) Session["CurrentRecipe"];

                if(currentRecipe != null)
                {
                    //add breadcrumb
                    breadcrumb.InnerHtml += $@"
                        <li><a href=""./RecipesDetail.aspx?id={currentRecipe.Id}"">{currentRecipe.Name}</a></li>
                    ";

                    //load rating icon type - star? star yellow? half star?
                    ratingFileType = loadRatingIcon(currentRecipe.ReviewStar);

                    //load infor section
                    loadInforSection();

                    //load ingredient and procedure section
                    loadIngredientAndProcedureSection();

                    //load comment section
                    loadCommentSection(4, currentRecipe);
                    Session["VisibledComments"] = 4;
                    hideComment.Visible = false;
                    loadRatingSection(reviewInforCommentSection); //load rating in comment section


                }

                //load similar recipe section
                loadSimilarRecipes();
            }
        }

        private void loadInforSection()
        {
            /*inforWrapper.InnerHtml = "";

            inforWrapper.InnerHtml = $@"
                <div class=""dish-image"">
                    <img src=""{currentRecipe.ImageFilePath}"" alt=""dish image"">
                </div>
                <div class=""recipe-infor"">
                    <h2 class=""dish-title"">{currentRecipe.Name}</h2>
                    <div class=""review-infor"">
                        <ul>
                            <li><img src=""./icon/{ratingFileType[0]}"" alt=""rating star""></li>
                            <li><img src=""./icon/{ratingFileType[1]}"" alt=""rating star""></li>
                            <li><img src=""./icon/{ratingFileType[2]}"" alt=""rating star""></li>
                            <li><img src=""./icon/{ratingFileType[3]}"" alt=""rating star""></li>
                            <li><img src=""./icon/{ratingFileType[4]}"" alt=""rating star""></li>
                            <li class=""star-number""><h4>{currentRecipe.ReviewStar}</h4></li>
                        </ul>
                        <p class=""review-number"">({currentRecipe.ReviewCount} phản hồi)</p>
                    </div>
                    <div class=""author"">
                        <img src=""./icon/user.svg"" alt=""author icon"">
                        <p>Đăng bởi: </p>
                        <a href=""#"">{currentRecipe.AuthorId}</a>
                    </div>
                    <div class=""cook-time-infor"">
                        <img src=""./icon/time.svg"" alt=""cook time icon"">
                        <p class=""cook-time-text"">Thời gian nấu:  </p>
                        <div class=""cook-time"">{currentRecipe.CookTime}</div>
                        <p class=""estimate-text"">(ước lượng)</p>
                    </div>
                    <!-- Add class save -->
                    <div class=""save-recipe btn"">
                        <img src=""./icon/bookmark.svg"" alt=""bookmark icon"">
                        <p>Lưu công thức</p>
                    </div>
                    <asp:Button CssClass=""save-recipe btn"" ID=""saveButton"" runat=""server"" Text=""Lưu công thức"" UseSubmitBehavior=""false"" OnClick=""saveRecipe_Click"" Visible=""false""/>
                    <aside>
                        <div class=""summary-description"">
                            <h4>Mô tả:</h4>
                            <p>{currentRecipe.Description}</p>
                        </div>
                    </aside>
                </div>
            ";*/

            dishImage.InnerHtml = "";
            dishTitle.InnerHtml = "";
            reviewInforInforSection.InnerHtml = "";
            authorInfor.InnerHtml = "";
            cookTime.InnerHtml = "";
            descriptionSection.InnerHtml = "";

            dishImage.InnerHtml = $@"
                <img src=""{currentRecipe.ImageFilePath}"" alt=""dish image"">
            ";

            dishTitle.InnerHtml = $@"
                {currentRecipe.Name}
            ";

            reviewInforInforSection.InnerHtml = $@"
                 <ul>
                    <li><img src=""./icon/{ratingFileType[0]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[1]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[2]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[3]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[4]}"" alt=""rating star""></li>
                    <li class=""star-number""><h4>{currentRecipe.ReviewStar}</h4></li>
                </ul>
                <p class=""review-number"">({currentRecipe.ReviewCount} phản hồi)</p>
            ";

            authorInfor.InnerHtml = $@"
                <img src=""./icon/user.svg"" alt=""author icon"">
                <p>Đăng bởi: </p>
                <a href=""#"">{currentRecipe.AuthorId}</a>
            ";

            cookTime.InnerHtml = $@"
                <img src=""./icon/time.svg"" alt=""cook time icon"">
                <p class=""cook-time-text"">Thời gian nấu:  </p>
                <div class=""cook-time"">{currentRecipe.CookTime}</div>
                <p class=""estimate-text"">(ước lượng)</p>
            ";

            descriptionSection.InnerHtml = $@"
                <div class=""summary-description"">
                    <h4>Mô tả:</h4>
                    <p>{currentRecipe.Description}</p>
                </div>
            ";
        }

        private void loadIngredientAndProcedureSection()
        {
            ingredientSection.InnerHtml = "";
            procedureSection.InnerHtml = "";

            //load ingredients
            foreach(string i in currentRecipe.Ingredients)
            {
                ingredientSection.InnerHtml += $@"
                <li>{i}</li>
                ";
            }

            //load procedure
            foreach (string p in currentRecipe.Procedure)
            {
                procedureSection.InnerHtml += $@"
                <li>
                    <pre>{p}</pre>
                </li>
                ";
            }
        }

        private string[] loadRatingIcon(float rating)
        {
            
            string[] iconTypeList = new string[5];
            float currentRating = rating;

            for (int i = 0; i < iconTypeList.Length; i++)
            {
                if (currentRating >= 1)
                {
                    iconTypeList[i] = "star_yellow.svg";
                    currentRating--;
                }
                else if (currentRating > 0 && currentRating < 1)
                {
                    iconTypeList[i] = "star_half_yellow.svg";
                    currentRating--;
                }
                else
                {
                    iconTypeList[i] = "star.svg";
                    currentRating--;
                }
            }

            return iconTypeList;
        }

        private void loadRatingSection(HtmlGenericControl ratingContainer)
        {
            ratingContainer.InnerHtml = "";

            ratingContainer.InnerHtml = $@"
                <h3>Đánh giá</h3>
                <ul>
                    <li><img src=""./icon/{ratingFileType[0]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[1]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[2]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[3]}"" alt=""rating star""></li>
                    <li><img src=""./icon/{ratingFileType[4]}"" alt=""rating star""></li>
                    <li class=""star-number""><h4>{currentRecipe.ReviewStar}</h4></li>
                </ul>
                <p class=""review-number"">({currentRecipe.ReviewCount} phản hồi)</p>
            ";
        }

        private void loadCommentSection(int commentLoad, Recipe currentRecipe)
        {
            commentsListSection.InnerHtml = "";
            string commentImage;
            

            foreach(Comment c in currentRecipe.Comments.Take(commentLoad))
            {
                string[] userRatingFileType = loadRatingIcon(c.ReviewStar);

                if (c.ImagePath != null)
                {
                    commentImage = $@"
                        <div class=""comment-image"">
                                <img src=""{c.ImagePath}"" alt=""comment image"">
                        </div>
                    ";
                }
                else commentImage = "";

                commentsListSection.InnerHtml += $@"
                    <li>
                        <h4 class=""name"">{c.UserName}</h4>
                        <div>
                            <div class=""comment-infor"">
                                <ul>
                                    <li><img src=""./icon/{userRatingFileType[0]}"" alt=""rating star""></li>
                                    <li><img src=""./icon/{userRatingFileType[1]}"" alt=""rating star""></li>
                                    <li><img src=""./icon/{userRatingFileType[2]}"" alt=""rating star""></li>
                                    <li><img src=""./icon/{userRatingFileType[3]}"" alt=""rating star""></li>
                                    <li><img src=""./icon/{userRatingFileType[4]}"" alt=""rating star""></li>
                                </ul>
                                <p class=""comment-text"">{c.CommentText}</p>
                            </div>
                            " + commentImage + $@"
                        </div>
                    </li>
                ";
            }

        }

        private void loadSimilarRecipes()
        {
            similarRecipeList.InnerHtml = "";
            string currentRecipeName = currentRecipe.Name;
            int count = 1; //count if there is enough 12 recipes for this section if not, add random recipes

            //filter recipes that similar to the current one
            List<Recipe> similarRecipeSection = recipes.Where(r => r.Name.Split(' ').Intersect(currentRecipeName.Split(' ')).Any())
                .Take(8)
                .ToList();

            foreach(Recipe r in similarRecipeSection)
            {
                similarRecipeList.InnerHtml += $@"
                    <li>
                        <a href='./RecipesDetail.aspx?id={r.Id}'>
                            <img src='{r.ImageFilePath}' alt=""recipe picture"">
                            <div class=""recipe-title"">
                                <p>{r.Name}</p>
                                <div class=""background""></div>
                            </div>
                        </a>
                    </li>
                ";
                count++;
            }

            //if not enough recipes, add random
            Recipe.fillRecipe(count, 8, recipes, similarRecipeList);
        }

        protected void hideComment_Click(object sender, EventArgs e)
        {
            loadCommentSection(4, (Recipe)Session["CurrentRecipe"]);
            Session["VisibledComments"] = 4;
            hideComment.Visible = false;
        }

        protected void saveRecipe_Click(object sender, EventArgs e)
        {
        }

        protected void loadMoreCommentBtn_Click(object sender, EventArgs e)
        {
            currentRecipe = (Recipe)Session["CurrentRecipe"];

            int commentSize = currentRecipe.ReviewCount;
            int moreComments = (int)Session["VisibledComments"];
            moreComments += 4;
            Session["VisibledCommented"] = moreComments;

            loadCommentSection(moreComments, currentRecipe);

            if (moreComments >= commentSize) hideComment.Visible = true;
        }

        protected void saveAspLinkButton_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null) //cant comment if user havent sign in
            {
                Response.Redirect("./index.aspx");
                return;
            }

            currentRecipe = (Recipe)Session["CurrentRecipe"];

            if (saveAspLinkButton.CssClass.Contains("active"))
            {
                saveAspLinkButton.CssClass = "save-recipe btn";
                lol.InnerText = "Removed";
                return;
            }

            saveAspLinkButton.CssClass = "save-recipe btn active";
            lol.InnerText = currentRecipe.Id.ToString() + " Saved ";
        }

        protected void submitCommentAspButton_Click(object sender, EventArgs e)
        {
            if (Session["User"] == null) //cant comment if user havent sign in
            {
                Response.Redirect("./index.aspx");
                return;
            }

            currentRecipe = (Recipe)Session["CurrentRecipe"];

            Comment newComment = new Comment();
            string userName;
            int reviewStar = int.Parse(Request.Form["reviewStarCounter"]);
            string commentImagePath;
            string commentText = Request.Form["addCommentText"];

            //save comment image and get COMMENT FILE PATH
            HttpPostedFile uploadedImage = Request.Files["AddCommentImage"];
            if (uploadedImage != null && uploadedImage.ContentLength > 0)
            {
                string fileName = Path.GetFileName(uploadedImage.FileName);
                string fileExtension = Path.GetExtension(fileName);

                string newFileName = $"{currentRecipe.Id}_{currentRecipe.Comments.Count + 1}" + fileExtension;
                string saveFilePath = Path.Combine(Server.MapPath("./image/comment_images/"), newFileName);

                uploadedImage.SaveAs(saveFilePath);
                //Response.Write($"<script> alert('[./image/comment_images/{newFileName}]') </script>");
                commentImagePath = $"./image/comment_images/{newFileName}";
            }

            
            //test
            Response.Write($"<script> alert('{reviewStar}     text: {commentText}') </script>");


        }
    }
}