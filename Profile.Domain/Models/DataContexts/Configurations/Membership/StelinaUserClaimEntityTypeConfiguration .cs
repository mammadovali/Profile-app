using Profile.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileUserClaimEntityTypeConfiguration : IEntityTypeConfiguration<ProfileUserClaim>
    {
        public void Configure(EntityTypeBuilder<ProfileUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
