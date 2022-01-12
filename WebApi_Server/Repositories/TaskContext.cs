using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WebApi_Server.Repositories
{
    public class TaskContext : DbContext
    {
        public TaskContext()
        {
        }

        public TaskContext([NotNull] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }

    }
}
