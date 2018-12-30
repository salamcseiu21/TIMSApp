using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TIMSApp.Models.EntityModels;

namespace TIMSApp.DatabaseContexts.DatabaseContext
{
  public partial  class ProjectDbContext:DbContext
    {
        public ProjectDbContext()
        {
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Course> Courses { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseSqlServer("Server=.\\SqlExpress;Database=TIMSDB;Trusted_Connection=True;");
            }
        }

    }
}
