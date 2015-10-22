using System.Data.Entity;
using Common.Data.Contracts;
using PhotographyApi.Models;

namespace PhotographyApi.Data
{
    public class PhotographyContext : DbContext, IDbContext
    {
        public PhotographyContext()
            : base(nameOrConnectionString: "photography")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;

        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

    }
}