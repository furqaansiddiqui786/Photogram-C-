using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Photogram.Models
{
    public class PostsModel
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int profileId { get; set; }

        public byte[] Post { get; set; }
    }
}
