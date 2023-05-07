using Microsoft.AspNetCore.Http;
using Profile.Domain.Models.Entities;
using Profile.Domain.Models.Entities.Membership;

namespace Profile.Domain.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public ProfileUser User { get; set; }

        public User UserInfo { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public string ProfilePictureUrl { get; set; }
    }
}
