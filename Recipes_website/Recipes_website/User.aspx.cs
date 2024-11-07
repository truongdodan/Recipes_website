using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private User currentUser;
        private List<Recipe> recipes;
        private const int Recipe_Per_Page_Number = 9;
        private bool isInLoginUserPage = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string userId = Request.QueryString["id"];

                int id = int.Parse(userId);

                //find and update current user
                currentUser = Recipes_website.App_Code.Models.User.findUserById(id);   
                Session["CurrentUser"] = currentUser;
                recipes = (List<Recipe>)Session["Recipes"];

                //if this is current login user, show logout btn
                showLogoutButton();

                //load saved recipe
                loadSavedRecipe(1);

                //load user infor
                loadUserInfor();

            }
        }

        /*private void showAddRecipeButton()
        {
            addRecipeButtonWrapper.Attributes.Add("style", "display: none");

            //get current login user
            User loginUser = (User)Session["User"];

            if (loginUser == null) return;

            if (currentUser.Id == loginUser.Id && loginUser.IsCreator)
            {
                addRecipeButtonWrapper.Attributes.Add("style", "display: flex");
            }
        }*/

        private void showLogoutButton()
        {
            logoutButtonWrapper.Attributes.Add("style", "display: none");

            //get current login user
            User loginUser = (User)Session["User"];

            if (loginUser == null) return;

            if (currentUser.Id == loginUser.Id)
            {
                logoutButtonWrapper.Attributes.Add("style", "display: flex");
            }

        }

        private void loadUserInfor()
        {
            userName.InnerText = currentUser.Name;
            userId.InnerText = "Id: user@000" + currentUser.Id;
        }

        private List<Recipe> findRecipeFromIdList(List<int> idList, List<Recipe> recipeList)
        {
            List<Recipe> recipes = new List<Recipe>();

            foreach(Recipe recipe in recipeList)
            {
                foreach(int id in idList)
                {
                    if(recipe.Id == id) recipes.Add(recipe);
                }
            }

            return recipes;
        }

        private void loadHtmlCards(List<Recipe> recipes ,int pageNum)
        {
            const int itemEachPage = Recipe_Per_Page_Number;
            int itemsSkip = (pageNum - 1) * itemEachPage;      //each page is 9 recipes
            List<Recipe> recipePage = recipes.Skip(itemsSkip).Take(itemEachPage).ToList();
            foreach (Recipe recipe in recipePage)
            {
                recipeList.InnerHtml += $@"
                    <li>
                        <a href=""./RecipesDetail.aspx?id={recipe.Id}"">
                            <img src=""{recipe.ImageFilePath}"" alt=""by catagory recipe"">
                            <div class=""recipe-infor"">
                                <p id=""recipeName"">{recipe.Name}</p>
                                <p id=""recipeAuthor"">Author: {Recipes_website.App_Code.Models.User.findUserById(recipe.AuthorId).Name}</p>
                            </div>
                        </a>
                    </li>
                ";
            }
        }

        private void loadSavedRecipe(int pageNum)
        {
            currentUser = (User)Session["CurrentUser"];    //get user that login
            recipes = (List<Recipe>)Session["Recipes"];     //get recipe list to filter

            List<int> saveRecipesId = currentUser.SavedRecipes; //get id list of recipe that this current user has saved
            List<Recipe> saveRecipes = findRecipeFromIdList(saveRecipesId, recipes);

            recipeList.InnerHtml = "";

            if(saveRecipes.Count <= 0)      //hide navigation if there is no item in the list
            {
                recipeListNavigation.Attributes.Add("style", "display: none");
                return;
            }

            recipeListNavigation.Attributes.Add("style", "display: flex");      //show navigation if there is item in the list
            pageNumber.InnerText = (Math.Round((double)saveRecipes.Count / Recipe_Per_Page_Number)).ToString();     //calculate how many page there is if each page has 9 items


            loadHtmlCards(saveRecipes, pageNum);


        }

        private void loadCreatedRecipe(int pageNum)
        {
            currentUser = (User)Session["CurrentUser"];    //get user that login
            recipes = (List<Recipe>)Session["Recipes"];     //get recipe list to filter

            List<int> createdRecipesId = currentUser.CreatedRecipes; //get id list of recipe that this current user has saved
            List<Recipe> createdRecipes = findRecipeFromIdList(createdRecipesId, recipes);

            recipeList.InnerHtml = "";


            if (createdRecipes.Count <= 0)      //hide navigation if there is no item in the list
            {
                recipeListNavigation.Attributes.Add("style", "display: none");      
                return;
            }

            recipeListNavigation.Attributes.Add("style", "display: flex");      //show navigation if there is item in the list
            pageNumber.InnerText = (Math.Round((double)createdRecipes.Count / 9)).ToString();     //calculate how many page there is if each page has 9 items

            loadHtmlCards(createdRecipes, pageNum);

        }

        protected void saveRecipeTab_Click(object sender, EventArgs e)
        {
            //mark selected tab
            createdRecipeTab.CssClass = "";
            saveRecipeTab.CssClass = "selected";

            loadSavedRecipe(1);
        }

        protected void createdRecipeTab_Click(object sender, EventArgs e)
        {
            //mark selected tab
            createdRecipeTab.CssClass = "selected";
            saveRecipeTab.CssClass = "";

            loadCreatedRecipe(1);
        }

        protected void previousPageAspButton_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(currentPage.InnerText);  //current page
            if (curPage <= 1) return;   //if hit limit page return

            int previousPage = curPage - 1;
            currentPage.InnerText = previousPage.ToString();    //show update page num

            //load new page
            if (saveRecipeTab.CssClass.Equals("selected")) loadSavedRecipe(previousPage);
            else if (createdRecipeTab.CssClass.Equals("selected")) loadCreatedRecipe(previousPage);
        }

        protected void nextPageAspButton_Click(object sender, EventArgs e)
        {
            int curPage = int.Parse(currentPage.InnerText);  //current page
            int maxPage = int.Parse(pageNumber.InnerText);  //max page number
            if (curPage >= maxPage) return;   //if hit limit page return

            int nextPage = curPage + 1;
            currentPage.InnerText = nextPage.ToString();//show update page num

            //load new page
            if (saveRecipeTab.CssClass.Equals("selected")) loadSavedRecipe(nextPage);
            else if(createdRecipeTab.CssClass.Equals("selected")) loadCreatedRecipe(nextPage);
        }

        protected void logoutAspButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("./index.aspx");
        }
    }
}