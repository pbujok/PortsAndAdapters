using Microsoft.EntityFrameworkCore;

namespace ItEmperor.PortsAndAdapters.DalLayer
{
    public class BoardDbContext : DbContext
    {
        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoardDbContext).Assembly);
        }

        public DbSet<Comment> Comments { get; set; }
    }
}