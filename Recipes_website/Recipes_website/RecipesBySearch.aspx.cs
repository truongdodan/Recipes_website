using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        List<Recipe> recipes;
        List<Recipe> filteredRecipes;
        string keywordSearch;
        private const int Recipe_Per_Page_Number = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        private void loadHtmlCards(List<Recipe> recipes, int pageNum)
        {
            const int itemEachPage = Recipe_Per_Page_Number;     //each page have 9 recipes
            int itemSkip = (pageNum - 1) * itemEachPage;
            List<Recipe> recipePage = recipes.Skip(itemSkip).Take(itemEachPage).ToList();

            foreach (Recipe recipe in recipePage)
            {
                byCatagoryRecipeList.InnerHtml += $@"
                    <li>
                        <a href=""./RecipesDetail.aspx?id={recipe.Id}"">
                            <img src=""{recipe.ImageFilePath}"" alt=""{recipe.Name}"">
                            <div class=""recipe-infor"">
                                <p id=""recipeName"">{recipe.Name}</p>
                                <p id=""recipeAuthor"">Author: {App_Code.Models.User.findUserById(recipe.AuthorId).Name}</p>
                            </div>
                        </a>
                    </li>
                ";
            }
        }

        private List<Recipe> filterRecipeByName(List<Recipe> recipes, string keyword)
        {
            keywordSearch = Request.QueryString["ingredient"];

            recipes = (List<Recipe>)Session["Recipes"];
            List<Recipe> filteredRecipes;
            //take any recipe if it has keyword as ingredient or has keyword in its name
            filteredRecipes = recipes.Where(r => r.Name.ToLower().Contains(keywordSearch.ToLower())).ToList();

            return filteredRecipes;

        }

        protected void recipeSorter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void previousPageAspButton_Click(object sender, EventArgs e)
        {

        }

        protected void nextPageAspButton_Click(object sender, EventArgs e)
        {

        }
    }
}