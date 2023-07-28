using MapExample.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MapExample.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<StoreModel> Stores { get; set; }

    }
}
