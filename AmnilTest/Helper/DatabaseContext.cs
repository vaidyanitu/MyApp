using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmnilTest.Helper;
using AmnilTest.Model;
using AmnilTest.ViewModels;

namespace AmnilTest
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<District> Districts { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<ContestantRating> ContestantRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
            ModelBuilderExtensions.Seed(modelBuilder);
        }
    }
   

}
