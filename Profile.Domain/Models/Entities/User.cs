using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfilePictureUrl { get; set; } 

        public ICollection<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
