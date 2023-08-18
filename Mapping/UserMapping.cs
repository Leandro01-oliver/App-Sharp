using app_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_web.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tb_user");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
              .HasColumnName("id");

            builder.Property(p => p.Email)
                   .IsRequired().HasColumnName("email");

            builder.Property(p => p.Password)
               .IsRequired().HasColumnName("password");

            builder.Property(p => p.Password)
                 .IsRequired();


        }
    }
}
