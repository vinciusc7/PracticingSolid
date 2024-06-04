using Microsoft.EntityFrameworkCore;
using Simplecrud.Models;

namespace Simplecrud.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ItemModel> Items { get; set; }
    }
}
