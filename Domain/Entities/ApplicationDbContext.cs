using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        //}
    }
}

