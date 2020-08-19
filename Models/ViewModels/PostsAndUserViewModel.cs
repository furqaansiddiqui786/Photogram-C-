using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photogram.Models.ViewModels
{
    public class PostsAndUserViewModel
    {
        public IEnumerable<PostsModel> PostModel { get; set; }

        public UserProfileModel UserProfileModel { get; set; }
    }
}
