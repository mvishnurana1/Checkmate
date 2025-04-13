using CheckMate.Data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckMate.API.Configuration
{
    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.UserId)
                   .HasName("UserID");

            builder.Property(x => x.UserId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.ModifiedDate)
                   .HasColumnType("datetimeoffset(7)");

            builder.Property(x => x.CreatedDate)
                   .HasColumnType("datetimeoffset(7)")
                   .HasDefaultValueSql("((sysdatetimeoffset() AT TIME ZONE 'W. Australia Standard Time'))");

            builder.HasMany(u => u.ActionItems)
                   .WithOne(a => a.CreatedBy)
                   .HasForeignKey(a => a.UserID);

           OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<User> entity);
    }
}
