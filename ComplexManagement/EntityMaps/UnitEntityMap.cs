using ComplexManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplexManagement.EntityMaps
{
    public class UnitEntityMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> entity)
        {
            entity.HasKey(_ => _.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.Name).IsRequired().HasMaxLength(50);


            entity.Property(_ => _.BlockId).IsRequired();
        }
    }
}
