using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<Recipe> recipes;
        List<Recipe> filteredRecipes;
        string keywordSearch;
        private const int Recipe_Per_Page_Number = 12;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                keywordSearch = Request.QueryString["ingredient"];

                recipes = (List<Recipe>)Session["Recipes"];

                filteredRecipes = filterRecipeByKeywordAndIngredient(recipes, keywordSearch);   //filter by catagory 
                filteredRecipes = sortRecipes(filteredRecipes, 0);    //filter by condition - sort by newest recipe is default

                Session["FilteredRecipes"] = filteredRecipes;

                loadFilteredRecipesList(filteredRecipes, 1);
                
            }
        }

        private void loadHtmlCards(List<Recipe> recipes, int pageNum)
        {
            const int itemEachPage = Recipe_Per_Page_Number;     //each page have 9 recipes
            int itemSkip = (pageNum - 1) * itemEachPage;
            List<Recipe> recipePage = recipes.Skip(itemSkip).Take(itemEachPage).ToList();

            foreach(Recipe recipe in recipePage)
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

        private List<Recipe> filterRecipeByKeywordAndIngredient(List<Recipe> recipes, string keyword)
        {
            keywordSearch = Request.QueryString["ingredient"];

            recipes = (List<Recipe>)Session["Recipes"];
            List<Recipe> filteredRecipes;
            //take any recipe if it has keyword as ingredient or has keyword in its name
            filteredRecipes = recipes.Where(r => r.Ingredients.Any(r2 => r2.ToLower().Contains(keywordSearch.ToLower())) 
                                            || r.Name.ToLower().Contains(keywordSearch.ToLower())).ToList();

            return filteredRecipes;

        }

        private List<Recipe> sortRecipes(List<Recipe> recipes, int filterType)
        {
            List<Recipe> sortedRecipes = recipes;

            if (filterType == 0) //newest recipes
            {
                sortedRecipes.OrderBy(r => DateTime.ParseExact(r.PublishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
            }
            else if (filterType == 1) //highest rate recipes
            {
                int maxReviewCount = recipes.Max(r => r.ReviewCount);
                sortedRecipes = recipes.OrderByDescending(r => ((r.ReviewStar / 5) + (r.ReviewCount / maxReviewCount)) / 2).ToList();
            }
            else //most view recipe
            {
                sortedRecipes = recipes.OrderBy(r => r.ViewCount).ToList();
            }

            return sortedRecipes;
        }

        private void loadFilteredRecipesList(List<Recipe> recipes, int pageNum)
        {
            keywordSearch = Request.QueryString["ingredient"];
            catagoryTitle.InnerText = keywordSearch;
            byCatagoryRecipeList.InnerHtml = "";
            

            if (recipes.Count <= 0)
            {
                recipeListNavigation.Attributes.Add("style", "display: none");
                return;
            }

            recipeListNavigation.Attributes.Add("style", "display: flex");
            pageNumber.InnerText = Math.Ceiling(((double)recipes.Count / Recipe_Per_Page_Number)).ToString();    //show number of page - 9 recipe each page

            loadHtmlCards(recipes, pageNum);
        }
        protected void recipeRilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filteredRecipes = (List<Recipe>)Session["FilteredRecipes"];

            filteredRecipes = sortRecipes(filteredRecipes, (int)recipeSorter.SelectedIndex);    //filter by condition - sort by newest recipe is default
            Session["FilteredRecipes"] = filteredRecipes;

            loadFilteredRecipesList(filteredRecipes, 1);
        }

        protected void previousPageAspButton_Click(object sender, EventArgs e)
        {
            filteredRecipes = (List<Recipe>)Session["FilteredRecipes"];

            int curPage = int.Parse(currentPage.InnerText);  //current page
            if (curPage <= 1) return;   //if hit limit page return

            int previousPage = curPage - 1;
            currentPage.InnerText = previousPage.ToString();    //show update page num

            //load new page
            loadFilteredRecipesList(filteredRecipes, previousPage);
        }

        protected void nextPageAspButton_Click(object sender, EventArgs e)
        {
            filteredRecipes = (List<Recipe>)Session["FilteredRecipes"];

            int curPage = int.Parse(currentPage.InnerText);  //current page
            int maxPage = int.Parse(pageNumber.InnerText);  //max page number
            if (curPage >= maxPage) return;   //if hit limit page return

            int nextPage = curPage + 1;
            currentPage.InnerText = nextPage.ToString();//show update page num

            //load new page
            loadFilteredRecipesList(filteredRecipes, nextPage);
        }


    }
}