using Domain.DataModels;

namespace Database.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetAccountById(int accountId);

        Task<IEnumerable<Account>> GetAccounts();
    }
}
