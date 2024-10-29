using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;

namespace Recipes_website.App_Codes.Modules
{
    public class Recipe
    {
        private int id;
        private string imageFilePath;
        private string name;
        private float reviewStar;
        private int reviewCount;
        private int viewCount;
        private int authorId;
        private string publishDate;
        private string cookTime;
        private string description;
        private List<string> ingredients;
        private List<string> procedure;
        private List<Comment> comments;

        public Recipe() { }

        public Recipe(int id, string imageFilePath, string name, float reviewStar, int reviewCount, int viewCount, int authorId, string publishDate, string cookTime, string description, List<string> ingredients, List<string> procedure, List<Comment> comments)
        {
            this.id = id;
            this.imageFilePath = imageFilePath;
            this.name = name;
            this.reviewStar = reviewStar;
            this.reviewCount = reviewCount;
            this.viewCount = viewCount;
            this.authorId = authorId;
            this.publishDate = publishDate;
            this.cookTime = cookTime;
            this.description = description;
            this.ingredients = ingredients;
            this.procedure = procedure;
            this.comments = comments;
        }

        public int Id { get => id; set => id = value; }
        public string ImageFilePath { get => imageFilePath; set => imageFilePath = value; }
        public string Name { get => name; set => name = value; }
        public float ReviewStar { get => reviewStar; set => reviewStar = value; }
        public int ReviewCount { get => reviewCount; set => reviewCount = value; }
        public int ViewCount { get => viewCount; set => viewCount = value; }
        public int AuthorId { get => authorId; set => authorId = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string CookTime { get => cookTime; set => cookTime = value; }
        public string Description { get => description; set => description = value; }
        public List<string> Ingredients { get => ingredients; set => ingredients = value; }
        public List<string> Procedure { get => procedure; set => procedure = value; }
        public List<Comment> Comments { get => comments; set => comments = value; }

        public static List<Recipe> getRecipes()
        {
            string path = HttpContext.Current.Server.MapPath("./App_Datas/Recipes.json");

            string recipesContent = File.ReadAllText(path);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Recipe> recipes = jsSerializer.Deserialize<List<Recipe>>(recipesContent);

            return recipes;
        }

        public static void saveRecipes(List<Recipe> recipes)
        {
            string updateJsonContent;

            string path = HttpContext.Current.Server.MapPath("./App_Datas/Recipes.json");


        }

        public static Recipe getRecipeById(int id, List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Id == id) return recipe;
            }

            return null;
        }

        //for if the recipe section is not enough recipe to fill the section
        //for ex the design have 12 but the db only have 5 that match the section criteria
        public static void fillRecipe(int current, int max, List<Recipe> recipes, HtmlGenericControl containElement)
        {
            int count = current;

            foreach (Recipe r in recipes)
            {
                if (count > max) break;
                containElement.InnerHtml += $@"
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
        }

    }
}