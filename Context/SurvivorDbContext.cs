using System;
using LastOneStanding.Entities;
using LastOneStanding.Enums;
using Microsoft.EntityFrameworkCore;

namespace LastOneStanding.Context
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryType = Enums.Categories.Celebrities, IsDeleted = false },
                new Category { Id = 2, CategoryType = Enums.Categories.Volunteers, IsDeleted = false }
                 );

            modelBuilder.Entity<Competitors>().HasData(
                new Competitors { Id = 1, FirstName = "Mad", LastName = "Vahid", CategoryId = 1 },
                new Competitors { Id = 2, FirstName = "Cobra", LastName = "Murad", CategoryId = 2 }
                );

            //modelBuilder.Entity<Competitors>()
            //    .Ignore(c => c.Category);
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Competitors> Competitors => Set<Competitors>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
                


    

