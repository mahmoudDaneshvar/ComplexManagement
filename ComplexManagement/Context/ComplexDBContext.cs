using ComplexManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComplexManagement.Context
{
    public class ComplexDBContext : DbContext
    {
        public ComplexDBContext(DbContextOptions<ComplexDBContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Complex> Complexes { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Unit> Units { get; set; }

    }
}
