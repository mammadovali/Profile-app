using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string Filename { get; set; }

        public int PhotoAlbumId { get; set; }

        public PhotoAlbum PhotoAlbum { get; set; }
    }
}
