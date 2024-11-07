using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];

            if (currentUser == null) return;

            userImage.Src = "./image/user.jfif";
        }

        protected void checkUser(object sender, EventArgs e)
        {
            User currentUser = (User) Session["User"];

            if(currentUser == null)
            {
                Response.Redirect("./Login.aspx");
            }

            Response.Redirect($"./User.aspx?id={currentUser.Id}");
        }

        protected void searchAspTextBox_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect($"./RecipesBySearch.aspx?search={searchAspTextBox.Text}");
        }
    }
}