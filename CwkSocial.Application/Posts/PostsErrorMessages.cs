using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Application.Posts
{
    public class PostsErrorMessages
    {
        public const string PostNotFound = "No post found with ID {0}";
        public const string PostDeleteNotPossible = "Onle the owner of a post can delete it";
        public const string PostUpdateNotPossible = "Post update not possible because it's not the post owner that initiates the update";
    }
}
