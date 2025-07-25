using EngineKnowledgeBase.DataAccess.Configurations;
using EngineKnowledgeBase.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

using Component = EngineKnowledgeBase.DataAccess.Models.Component;

namespace EngineKnowledgeBase.DataAccess
{
    public  class MainDbContext: DbContext
    {      
        public MainDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EngineDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComponentConfigurations());
            modelBuilder.ApplyConfiguration(new IncludedConfigurations());
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<Component>().HasData(
             new Component { ComponentId = 1, Name = "Двигатель 21116", Simple = "true", Product = "true", Description = "Двигатель в сборе ВАЗ-2106" },
             new Component { ComponentId = 2, Name = "Двигатель 1111", Simple = "true", Product = "true", Description = "Двигатель в сборе ВАЗ-1111" },
             new Component { ComponentId = 3, Name = "Двигатель 21126", Simple = "true", Product = "true", Description = "Двигатель в сборе ВАЗ-2106" },
             new Component { ComponentId = 4, Name = "Поршень в сборе", Simple = "true", Product = "true", Description = "Поршень ТДМК 2106, диаметр 79,0 (Моторкомплект) [31912]" },
             new Component { ComponentId = 5, Name = "Поршень", Simple = "false", Product = "false" },
             new Component { ComponentId = 6, Name = "Маслосъёмное кольцо", Simple = "false", Product = "false" },
             new Component { ComponentId = 7, Name = "Компрессионное кольцо", Simple = "false", Product = "false" },
             new Component { ComponentId = 8, Name = "Шатун", Simple = "false", Product = "false" },
             new Component { ComponentId = 9, Name = "Распредвал", Simple = "false", Product = "false" },
             new Component { ComponentId = 10, Name = "Коленвал", Simple = "false", Product = "false" },
             new Component { ComponentId = 11, Name = "Блок цилиндров", Simple = "false", Product = "false" }
            );
            modelBuilder.Entity<Included>().HasData(
                new Included { IncludedId = 1, ParentId = 1, ChildId = 4, Count = 4 },
                new Included { IncludedId = 2, ParentId = 1, ChildId = 9, Count = 1 },
                new Included { IncludedId = 3, ParentId = 1, ChildId = 10, Count = 1 },
                new Included { IncludedId = 4, ParentId = 1, ChildId = 11, Count = 1 },

                new Included { IncludedId = 5, ParentId = 3, ChildId = 4, Count = 4 },
                new Included { IncludedId = 6, ParentId = 3, ChildId = 9, Count = 2 },
                new Included { IncludedId = 7, ParentId = 3, ChildId = 10, Count = 1 },
                new Included { IncludedId = 8, ParentId = 3, ChildId = 11, Count = 1 },

                 new Included { IncludedId = 9, ParentId = 4, ChildId = 5, Count = 1 },
                 new Included { IncludedId = 10, ParentId = 4, ChildId = 6, Count = 1 },
                 new Included { IncludedId = 11, ParentId = 4, ChildId = 7, Count = 2 },
                 new Included { IncludedId = 12, ParentId = 4, ChildId = 8, Count = 1 }
                );
        }
        public DbSet<Models.Component> Components { get; set; }
        public DbSet<Models.Included> Includeds { get; set; }
    }
}
