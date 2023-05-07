using Profile.Domain.Models.Entities;
using Profile.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileUser User { get; set; }

        public User UserInfo { get; set; }

        public ICollection<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
