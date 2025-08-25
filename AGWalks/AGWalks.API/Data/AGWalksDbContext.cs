using AGWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGWalks.API.Data
{
    public class AGWalksDbContext : DbContext
    {
        public AGWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions{ get; set; }
        public DbSet<Walk> Walks{ get; set; }
    }
}
