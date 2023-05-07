using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Profile.Domain.Models.Entities.Membership
{
    public class ProfileUser : IdentityUser<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
