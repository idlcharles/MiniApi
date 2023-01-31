using Microsoft.EntityFrameworkCore;
using MiniApi.Models;

namespace MiniApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Api> Apis { get;  set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
