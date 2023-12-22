
using Microsoft.EntityFrameworkCore;
using SS.Model;


namespace SS.Infrastructure{

    public class StreamingDbContext_pgsql : DbContext
    {
        public DbSet<StreamingTitle> StreamingTitles{ get; private set; }
        public DbSet<StreamingContent> StreamingContents{ get; private set; }

        public StreamingDbContext_pgsql(DbContextOptions<StreamingDbContext_pgsql> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}