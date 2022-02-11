using Database.Repositories.Interfaces;
using Domain.DataModels;
using Ensek.Services.Interfaces;

namespace Ensek.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

        public async Task<Account?> GetAccountById(int accountId)
        {
            return await _accountRepository.GetAccountById(accountId);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepository.GetAccounts();
        }
    }
}
