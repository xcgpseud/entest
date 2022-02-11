using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class SqliteContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"DataSource=ensek.db");
        }
    }
}
