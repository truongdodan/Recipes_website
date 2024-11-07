using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Recipes_website.App_Code.Models
{
    public class User
    {
        private int id;
        private string email;
        private string password;
        private string name;
        private bool isCreator;
        private bool isAdmin;
        private List<int> savedRecipes;
        private List<int> createdRecipes;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public bool IsCreator { get => isCreator; set => isCreator = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public List<int> SavedRecipes { get => savedRecipes; set => savedRecipes = value; }
        public List<int> CreatedRecipes { get => createdRecipes; set => createdRecipes = value; }

        public User()
        {
        }

        public User(int id, string email, string password, string name, bool isCreator, bool isAdmin, List<int> savedRecipes, List<int> createdRecipes)
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

        public static List<User> getUsers()
        {
            string path = HttpContext.Current.Server.MapPath("./App_Data/Users.json");

            string usersContent = File.ReadAllText(path);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<User> users = jsSerializer.Deserialize<List<User>>(usersContent);

            return users;
        }

        public static void saveUsers(List<User> users)
        {
            string path = HttpContext.Current.Server.MapPath("./App_Data/Users.json");

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string usersContent = javaScriptSerializer.Serialize(users);

            File.WriteAllText(path, usersContent);

        }

        public static User checkAccount(string email, string password)
        {
            List<User> users = getUsers();

            foreach (User user in users)
            {
                if (email.Equals(user.email) && password.Equals(user.password)) return user;
            }

            return null;
        }

        public static User findUserById(int id)
        {
            List<User> users = getUsers();

            foreach (User user in users)
            {
                if (user.id == id) return user;
            }

            return null;
        }
    }
}