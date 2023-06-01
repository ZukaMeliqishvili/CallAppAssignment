using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration
{
    public class UserProfileConfigurations : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.FirstName).HasMaxLength(256);
            builder.Property(i=>i.LastName).HasMaxLength(256);
            builder.Property(i=>i.PersonalNumber).HasMaxLength(11).IsFixedLength(true);
            builder.HasOne(i=>i.User).WithOne(i=>i.UserProfile).HasForeignKey<UserProfile>(i=>i.UserId);
        }
    }
}
