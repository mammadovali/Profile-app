using Profile.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileUserTokenEntityTypeConfiguration : IEntityTypeConfiguration<ProfileUserToken>
    {
        public void Configure(EntityTypeBuilder<ProfileUserToken> builder)
        {
            builder.ToTable("UserTokens", "Membership");
        }
    }
}
