using Profile.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileRoleEntityTypeConfiguration : IEntityTypeConfiguration<ProfileRole>
    {
        public void Configure(EntityTypeBuilder<ProfileRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
