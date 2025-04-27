using CheckMate.Data.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheckMate.API.Configuration
{
    public partial class ActionItemConfiguration : IEntityTypeConfiguration<ActionItem>
    {
        public void Configure(EntityTypeBuilder<ActionItem> builder)
        {
            builder.ToTable("ActionItem", x => x.HasCheckConstraint("CK_Status_Value", "[Status] IN ('open','closed','removed')"));
            builder.HasKey(x => x.ActionItemID)
                   .HasName("ActionItemID");

            builder.Property(x => x.ActionItemID)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.ActionItemName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.ActionItemDescription)
                   .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("Open");

            builder.Property(x => x.ModifiedDate)
                   .HasColumnType("datetimeoffset(7)");

            builder.Property(x => x.CreatedDate)
                   .HasColumnType("datetimeoffset(7)")
                   .HasDefaultValueSql("((sysdatetimeoffset() AT TIME ZONE 'W. Australia Standard Time'))");

            builder.HasIndex(x => new { x.ActionItemName, x.CreatedDate }, "IX_Unique_ActionName_CreatedDate")
                   .IsUnique();

            builder.HasOne(a => a.CreatedBy)
                   .WithMany(u => u.ActionItems)
                   .HasForeignKey(a => a.UserID);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ActionItem> entity);
    }
}
