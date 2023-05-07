using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Profile.Domain.Models.DataContexts;
using Profile.Domain.Models.Entities;
using Profile.Domain.Models.Entities.Membership;
using Profile.Domain.Models.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Profile.WebUI.Controllers
{
    [Authorize]
    public class PhotoAlbumsController : Controller
    {
        private readonly ProfileDbContext db;
        private readonly UserManager<ProfileUser> userManager;
        private readonly IHostEnvironment env;

        public PhotoAlbumsController(ProfileDbContext db, UserManager<ProfileUser> userManager, IHostEnvironment env)
        {
            this.db = db;
            this.userManager = userManager;
            this.env = env;
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photoAlbum = await db.PhotoAlbums
                .Include(pa => pa.Photos)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photoAlbum == null)
            {
                return NotFound();
            }

            return View(photoAlbum);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhotoAlbum album)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    return NotFound();
                }

                album.UserId = user.Id;

                db.Add(album);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Profile");
            }

            return View(album);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photoAlbum = await db.PhotoAlbums.FindAsync(id);
            if (photoAlbum == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(db.ProfileUsers, "Id", "Id", photoAlbum.UserId);
            return View(photoAlbum);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,UserId")] PhotoAlbum photoAlbum)
        {
            if (id != photoAlbum.Id)
            {
                return NotFound();
            }

            var user = await userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                try
                {
                    photoAlbum.UserId = user.Id;
                    db.Update(photoAlbum);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoAlbumExists(photoAlbum.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Profile");
            }
            ViewData["UserId"] = new SelectList(db.ProfileUsers, "Id", "Id", photoAlbum.UserId);
            return View(photoAlbum);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var album = await db.PhotoAlbums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            var photos = await db.Photos.Where(p => p.PhotoAlbumId == album.Id).ToListAsync();

            foreach (var photo in photos)
            {
                db.Photos.Remove(photo);
            }

            
            db.PhotoAlbums.Remove(album);
            await db.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }

        [HttpGet]
        public IActionResult AddPhotos(int id)
        {
            var album = db.PhotoAlbums.Include(a => a.Photos).FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            ViewBag.AlbumId = id;
            return View(album);
        }


        [HttpPost]
        public async Task<IActionResult> AddPhotos(int id, List<IFormFile> files)
        {
            var album = await db.PhotoAlbums.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = env.GetImagePhysicalPath(fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var photo = new Photo
                    {
                        Filename = fileName,
                        PhotoAlbumId = id
                    };

                    db.Photos.Add(photo);
                }
            }

            await db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = album.Id });
        }

        public async Task<IActionResult> PhotoDetails(int id)
        {
            var photo = await db.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var photo = await db.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            var filePath = env.GetImagePhysicalPath(photo.Filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            db.Photos.Remove(photo);
            await db.SaveChangesAsync();

            return Json(new
            {
                success = true
            });
        }




        private bool PhotoAlbumExists(int id)
        {
            return db.PhotoAlbums.Any(e => e.Id == id);
        }
    }
}
