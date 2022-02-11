using Database.Contexts;
using Database.Repositories.Interfaces;
using Domain.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BaseContext _context;

        public AccountRepository(SqliteContext context) => _context = context;

        public async Task<Account?> GetAccountById(int accountId)
        {
            var entity = await _context.Accounts.FirstOrDefaultAsync(entity => entity.AccountId == accountId);

            return entity?.Adapt<Account>();
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var entities = await _context.Accounts.ToListAsync();
            
            return entities.Select(entity => entity.Adapt<Account>());
        }
    }
}
