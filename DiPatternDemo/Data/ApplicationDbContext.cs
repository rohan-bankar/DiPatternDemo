﻿using Microsoft.EntityFrameworkCore;
using DiPatternDemo.Models;
namespace DiPatternDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {

        }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? products { get; set; }
    }
}
