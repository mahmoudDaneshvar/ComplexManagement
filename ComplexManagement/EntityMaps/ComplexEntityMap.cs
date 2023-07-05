using ComplexManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplexManagement.EntityMaps
{
    internal class ComplexEntityMap : IEntityTypeConfiguration<Complex>
    {
        public void Configure(EntityTypeBuilder<Complex> entity)
        {
            entity.ToTable("Complexes");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            entity.Property(_ => _.UnitCount).IsRequired();
        }
    }
}
