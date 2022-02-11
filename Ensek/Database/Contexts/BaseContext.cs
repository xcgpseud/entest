using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class BaseContext : DbContext
    {
        public DbSet<AccountEntity> Accounts => Set<AccountEntity>();

        public DbSet<MeterReadingEntity> MeterReadings => Set<MeterReadingEntity>();
    }
}
