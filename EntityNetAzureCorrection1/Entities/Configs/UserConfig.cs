using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNetAzureCorrection1.Entities.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Pseudo).IsRequired(false);
            builder.Property(x => x.Created).IsRequired();

            builder.HasData
                (
                    new User()
                    {
                        Id = 1,
                        Email = "User@user.com",
                        Password = "User123=",
                        Pseudo = "UserGuy"
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "Admin@admin.com",
                        Password = "Admin123=",
                        Pseudo = "AdminGuy"
                    }
                );

            
        }
    }
}
