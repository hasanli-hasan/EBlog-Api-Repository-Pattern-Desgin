using EBlogger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBlogger.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Commet> Commets { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Title = "Elon Musk", Body = "I could Elon Musk?" },
                new Blog { Id = 2, Title = "Steve Jobs", Body = "How been like Steve Jobs?" }
            );

            modelBuilder.Entity<Commet>().HasData(
               new Commet { Id = 1, Message = "I know Tesla", BlogId = 1 },
               new Commet { Id = 2, Message = "I know IPhone", BlogId = 2 },
                new Commet { Id = 3, Message = "I know SpaceX", BlogId = 1 }
           );
        }
    }
}
