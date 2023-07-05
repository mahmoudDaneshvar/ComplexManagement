using ComplexManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplexManagement.EntityMaps
{
    internal class BlockEntityMap : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> entity)
        {
            entity.ToTable("Blocks");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            entity.Property(_ => _.UnitCount).IsRequired();


            entity.HasOne(_ => _.Complex)
                .WithMany(_ => _.Blocks)
                .HasForeignKey(_ => _.ComplexId);

        }
    }
}
