using AGWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AGWalks.API.Data
{
    public class AGWalksDbContext : DbContext
    {
        public AGWalksDbContext(DbContextOptions<AGWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions{ get; set; }
        public DbSet<Walk> Walks{ get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("2f2e8f4f-4c9b-5d9b-ad7f-2d3e4f5a6b7c"),
                    Name = "Northland",
                    Code = "NL",
                    RegionImageUrl = "https://example.com/images/northland.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("21bbf909-108c-4180-bb8d-009f86ce40a8"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/images/auckland.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("4a5ea8be-0308-4d20-b2ba-9144873728cb"),
                    Name = "Waikato",   
                    Code = "WKO",
                    RegionImageUrl = "https://example.com/images/waikato.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
