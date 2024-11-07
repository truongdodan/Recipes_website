using Recipes_website.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recipes_website
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            User user = Recipes_website.App_Code.Models.User.checkAccount(email, password);

            if (user == null) //return if account not find account
            {
                errorMessage.Style.Add("display", "block");
                return;
            }

            errorMessage.Style.Add("display", "none");
            Session["User"] = user;
            Response.Redirect("./index.aspx");

        }
    }
}