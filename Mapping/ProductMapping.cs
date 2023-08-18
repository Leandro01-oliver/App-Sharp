using app_web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_web.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("tb_product");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Name)
                   .IsRequired().HasColumnName("name");

            builder.Property(p => p.Prince)
                .IsRequired().HasColumnName("prince");

            builder.Property(p => p.Active)
              .HasColumnName("active");

            builder.Property(p => p.Active)
            .HasColumnName("active");

            builder.Property(p => p.UserId)
             .HasColumnName("userId");

            builder.HasOne(p => p.User)
                   .WithMany()
                   .HasForeignKey(p => p.UserId);
                   
        }
    }
}
