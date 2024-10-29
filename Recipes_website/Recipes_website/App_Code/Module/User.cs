using Recipes_website.App_Codes.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes_website.App_Codes
{
    public class User
    {
        private int id {  get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private string name { get; set; }
        private bool isCreator { get; set; }
        private bool isAdmin { get; set; }
        private List<Recipe> savedRecipes { get; set; }
        private List<Recipe> createdRecipes { get; set; }

        public User() {}
        public User(int id, string email, string password, string name, bool isCreator, bool isAdmin, List<Recipe> savedRecipes, List<Recipe> createdRecipes)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.name = name;
            this.isCreator = isCreator;
            this.isAdmin = isAdmin;
            this.savedRecipes = savedRecipes;
            this.createdRecipes = createdRecipes;
        }
    }
}