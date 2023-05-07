using Profile.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<ProfileUserLogin>
    {
        public void Configure(EntityTypeBuilder<ProfileUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
