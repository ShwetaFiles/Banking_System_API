using BankingSystemAPI.Data;
using BankingSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // POST /api/accounts
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([FromBody] Account account)
        {
            if (string.IsNullOrEmpty(account.Owner))
                return BadRequest("Owner is required.");

            var newAccount = await _accountRepository.CreateAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { accountNumber = newAccount.AccountNumber }, newAccount);
        }

        // GET /api/accounts/{accountNumber}
        [HttpGet("{accountNumber}")]
        public async Task<ActionResult<Account>> GetAccount(int accountNumber)
        {
            var account = await _accountRepository.GetAccountAsync(accountNumber);
            if (account == null)
                return NotFound("Account not found.");

            return Ok(account);
        }

        // GET /api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            var accounts = await _accountRepository.GetAccountsAsync();
            return Ok(accounts);
        }

        // POST /api/accounts/{accountNumber}/deposit
        [HttpPost("{accountNumber}/deposit")]
        public async Task<ActionResult> Deposit(int accountNumber, [FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Amount must be greater than zero.");

            var account = await _accountRepository.GetAccountAsync(accountNumber);
            if (account == null)
                return NotFound("Account not found.");

            account.Balance += amount;
            await _accountRepository.UpdateAccountAsync(account);

            return NoContent();
        }

        // POST /api/accounts/{accountNumber}/withdraw
        [HttpPost("{accountNumber}/withdraw")]
        public async Task<ActionResult> Withdraw(int accountNumber, [FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Amount must be greater than zero.");

            var account = await _accountRepository.GetAccountAsync(accountNumber);
            if (account == null)
                return NotFound("Account not found.");

            if (account.Balance < amount)
                return BadRequest("Insufficient funds.");

            account.Balance -= amount;
            await _accountRepository.UpdateAccountAsync(account);

            return NoContent();
        }
    }
}
