using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public async Task DelayedActionAsync(Action action, int delayMilliseconds)
        {
            await Task.Delay(delayMilliseconds); // Wait for the specified time
            action(); // Execute the action after the delay
        }

        protected async void signUpButton_Click(object sender, EventArgs e)
        {
            string name = Request.Form["UserName"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];


            List<User> users = App_Code.Models.User.getUsers();

            User newUser = new User(users.Count, email, password, name, false, false, new List<int>(), new List<int>());
            users.Add(newUser);

            //save user list back to json file
            App_Code.Models.User.saveUsers(users);

            signUpSuccessFulNofitication.Attributes.Add("class", "signup-success-notification show");

            //show signup successful snackbar
            await DelayedActionAsync(() =>
            {
                signUpSuccessFulNofitication.Attributes.Add("class", "signup-success-notification");
            }, 1500);

        }
    }
}