using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profile.Domain.Models.Entities.Membership;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileUserEntityTypeConfiguration : IEntityTypeConfiguration<ProfileUser>
    {
        public void Configure(EntityTypeBuilder<ProfileUser> builder)
        {
            builder.ToTable("Users", "Membership");
        }
    }
}
