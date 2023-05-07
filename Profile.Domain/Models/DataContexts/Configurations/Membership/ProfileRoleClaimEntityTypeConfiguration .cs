using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profile.Domain.Models.Entities.Membership;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<ProfileRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ProfileRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
