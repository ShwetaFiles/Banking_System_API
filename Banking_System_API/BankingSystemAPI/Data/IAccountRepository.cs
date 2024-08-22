using BankingSystemAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystemAPI.Data
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountAsync(int accountNumber);
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> CreateAccountAsync(Account account);
        Task<Account> UpdateAccountAsync(Account account);
    }
}
