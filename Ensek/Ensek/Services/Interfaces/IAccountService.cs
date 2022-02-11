using Domain.DataModels;

namespace Ensek.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account?> GetAccountById(int accountId);

        Task<IEnumerable<Account>> GetAccounts();
    }
}
