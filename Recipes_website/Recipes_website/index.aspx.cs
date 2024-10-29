using Recipes_website.App_Codes.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Recipe> recipes;
        List<Recipe> topRecipesOfTheDaySection;
        List<Recipe> newRecipesSection;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //filter each section from this recipe list
            recipes = (List<Recipe>)Session["Recipes"];
            

            //Generate recipe for top recipes section - top by rating and comment count
            loadTopRecipesSection();

            //Generate recipe for recommend by keyword section
            loadRecommendByKeyword();

            //Generate recipe for recommend recipes section
            loadNewRecipesSection();
            

        }

        private void loadTopRecipesSection()
        {
            topCards.InnerHtml = "";
            //Generate recipe for top recipes section - top by avarage rating and comment count
            int maxReviewCount = recipes.Max(r => r.ReviewCount);
            //Take top 10 recipes with highest rating and comment count on average
            topRecipesOfTheDaySection = recipes.OrderByDescending(r => ((r.ReviewStar / 5) + (r.ReviewCount / maxReviewCount)) / 2).Take(10).ToList();
            int count = 1;
            foreach(Recipe r in topRecipesOfTheDaySection)
            {
                topCards.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}' id='number{count}'>
                        <div class='rank-number'>{count}</div>
                        <div class='image-wrapper'><img src='{r.ImageFilePath}' alt='dish image'></div>
                    <p>{r.Name}</p>
                    </a>
                  </li> 
                ";

                count++;
            }
            

        }

        private void loadRecommendByKeyword()
        {
            keywordList1.InnerHtml = "";
            keywordList2.InnerHtml = "";
            keywordList3.InnerHtml = "";
            keywordList4.InnerHtml = "";
            string keyword1, keyword2, keyword3, keyword4;
            keyword1 = "Thịt bò";
            keyword2 = "Thịt gà";
            keyword3 = "Rau";
            keyword4 = "Nấm";

            //filter list recipe by key word => check if any ingredient match keyword
            List<Recipe> listKeyword1 = recipes.Where(r => r.Ingredients.Any(r2 => r2.ToLower().Contains(keyword1.ToLower()))).Take(6).ToList();
            keyWord1.InnerText = keyword1;
            //generate card for 1st section
            foreach (Recipe r in listKeyword1)
            {
                keywordList1.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}'>
                        <img src='{r.ImageFilePath}' alt=""new recipe"">
                        <p>{r.Name}</p>
                    </a>
                  </li>    
                ";
            }

            //do the same things for 2nd
            List<Recipe> listKeyword2 = recipes.Where(r => r.Ingredients.Any(r2 => r2.ToLower().Contains(keyword2.ToLower()))).Take(6).ToList();
            keyWord2.InnerText = keyword2;
            foreach (Recipe r in listKeyword2)
            {
                keywordList2.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}'>
                        <img src='{r.ImageFilePath}' alt=""new recipe"">
                        <p>{r.Name}</p>
                    </a>
                  </li>    
                ";
            }

            //the 3rd
            List<Recipe> listKeyword3 = recipes.Where(r => r.Ingredients.Any(r2 => r2.ToLower().Contains(keyword3.ToLower()))).Take(6).ToList();
            keyWord3.InnerText = keyword4;
            foreach (Recipe r in listKeyword3)
            {
                keywordList3.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}'>
                        <img src='{r.ImageFilePath}' alt=""new recipe"">
                        <p>{r.Name}</p>
                    </a>
                  </li>    
                ";
            }

            //the 4th
            List<Recipe> listKeyword4 = recipes.Where(r => r.Ingredients.Any(r2 => r2.ToLower().Contains(keyword4.ToLower()))).Take(6).ToList();
            keyWord4.InnerText = keyword4;
            foreach (Recipe r in listKeyword4)
            {
                keywordList4.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}'>
                        <img src='{r.ImageFilePath}' alt=""new recipe"">
                        <p>{r.Name}</p>
                    </a>
                  </li>    
                ";
            }

        }

        private void loadNewRecipesSection()
        {
            newRecipesList.InnerHtml = "";
            //Generate recipe for new recipe section
            newRecipesSection = (List<Recipe>)Session["Recipes"];
            //12 recipes for this section

            foreach (Recipe r in newRecipesSection.Take(12).ToList()) //Take(12): take the first 12 recipes only
            {
                newRecipesList.InnerHtml += $@"
                  <li>
                    <a href='./RecipesDetail.aspx?id={r.Id}'>
                        <img src='{r.ImageFilePath}' alt='new recipe'>
                        <p>{r.Name}</p>
                    </a>
                  </li>  
                ";
            }
        }
    }
}