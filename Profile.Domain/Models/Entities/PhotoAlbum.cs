using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Entities
{
    public class PhotoAlbum
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
