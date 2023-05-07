using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Profile.Domain.Models.DataContexts;
using Profile.Domain.Models.Entities.Membership;
using Profile.Domain.Models.Extensions;
using Profile.Domain.Models.ViewModels;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ProfileDbContext db;
        private readonly UserManager<ProfileUser> userManager;
        private readonly IHostEnvironment env;

        public ProfileController(ProfileDbContext db, UserManager<ProfileUser> userManager, IHostEnvironment env)
        {
            this.db = db;
            this.userManager = userManager;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var userInfo = db.ProfileUsers
                .Include(pu => pu.PhotoAlbums)
                .Where(pu => pu.UserId == user.Id)
                .FirstOrDefault();

            var photoAlbums = db.PhotoAlbums.Where(pa => pa.UserId == user.Id)
                .ToList();


            var profileInfo = new ProfileViewModel
            {
                User = user,
                UserInfo = userInfo,
                PhotoAlbums = photoAlbums
            };


            return View(profileInfo);
        }



        public async Task<IActionResult> EditProfile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var userInfo = db.ProfileUsers
              .Where(pu => pu.UserId == user.Id)
              .FirstOrDefault();

            var model = new EditProfileViewModel
            {
                User = user,
                UserInfo = userInfo,
                ProfilePictureUrl = userInfo.ProfilePictureUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var userInfo = db.ProfileUsers
              .Where(pu => pu.UserId == user.Id)
              .FirstOrDefault();

            user.Name = model.User.Name;
            user.Surname = model.User.Surname;
            user.Email = model.User.Email;
            user.UserName = model.User.UserName;
            userInfo.Location = model.UserInfo.Location;
            userInfo.PhoneNumber = model.UserInfo.PhoneNumber;

            if (model.ProfilePicture == null)
                goto end;


            string extexsion = Path.GetExtension(model.ProfilePicture.FileName); //.jpg, png 

            model.ProfilePictureUrl = $"pp-{Guid.NewGuid().ToString().ToLower()}{extexsion}";

            string fullPath = env.GetImagePhysicalPath(model.ProfilePictureUrl);

            using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                model.ProfilePicture.CopyTo(fs);
            }
            userInfo.ProfilePictureUrl = model.ProfilePictureUrl;

        end:

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }
    }


}
