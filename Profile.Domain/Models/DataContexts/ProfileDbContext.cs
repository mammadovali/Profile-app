using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Profile.Domain.Models.Entities;
using Profile.Domain.Models.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.DataContexts
{

    public class ProfileDbContext : IdentityDbContext<ProfileUser, ProfileRole, int, ProfileUserClaim,
        ProfileUserRole, ProfileUserLogin, ProfileRoleClaim, ProfileUserToken>
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> ProfileUsers { get; set; }

        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfileDbContext).Assembly);

            modelBuilder.Entity<User>()
                .HasMany(u => u.PhotoAlbums)
                .WithOne(pa => pa.User)
                .HasForeignKey(pa => pa.UserId);

            modelBuilder.Entity<PhotoAlbum>()
                 .HasMany(pa => pa.Photos)
                 .WithOne(p => p.PhotoAlbum)
                 .HasForeignKey(p => p.PhotoAlbumId);
        }
    }
}
