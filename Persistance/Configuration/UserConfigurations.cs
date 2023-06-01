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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i => i.UserName).IsUnicode(false).HasMaxLength(256);
            builder.Property(i => i.Email).IsUnicode(false).HasMaxLength(256);
            builder.HasIndex(i => i.Email).IsUnique(true);
            builder.HasIndex(i => i.UserName).IsUnique(true);
            builder.Property(i => i.Password).HasMaxLength(512);
        }
    }
}
