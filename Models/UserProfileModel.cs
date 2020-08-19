using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Photogram.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string PostId { get; set; }

        [NotMapped]
        [ForeignKey("PostId")]
        public virtual PostsModel PostsModel { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string UserName { get; set; }

        public string Bio { get; set; }

    }
}
