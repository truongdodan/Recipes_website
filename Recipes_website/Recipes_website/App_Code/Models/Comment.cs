using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes_website.App_Code.Models
{
    public class Comment
    {
        private string userName;
        private int reviewStar;
        private string imagePath;
        private string commentText;

        public Comment()
        {
        }

        public Comment(string userName, int reviewStar, string imagePath, string commentText)
        {
            this.userName = userName;
            this.reviewStar = reviewStar;
            this.imagePath = imagePath;
            this.commentText = commentText;
        }

        public string UserName { get => userName; set => userName = value; }
        public int ReviewStar { get => reviewStar; set => reviewStar = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public string CommentText { get => commentText; set => commentText = value; }
    }
}