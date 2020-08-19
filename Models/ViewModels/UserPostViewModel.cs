using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photogram.Models.ViewModels
{
    public class UserPostViewModel
    {
        public IEnumerable<PostsModel> PostModel { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
