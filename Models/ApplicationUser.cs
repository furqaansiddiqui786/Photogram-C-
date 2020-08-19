using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Photogram.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PublicName { get; set; }

        public string Bio { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string Link { get; set; }

        [NotMapped]
        [ForeignKey("Link")]
        public virtual PostsModel PostsModel { get; set; }
    }
}
