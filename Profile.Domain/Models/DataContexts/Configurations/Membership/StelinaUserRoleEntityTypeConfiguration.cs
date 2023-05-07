using Profile.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profile.Domain.Models.DataContexts.Configurations
{
    public class ProfileUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<ProfileUserRole>
    {
        public void Configure(EntityTypeBuilder<ProfileUserRole> builder)
        {
            builder.ToTable("UserRole", "Membership");
        }
    }
}
