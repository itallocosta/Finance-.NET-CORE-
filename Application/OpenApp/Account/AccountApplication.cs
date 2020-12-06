using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Interfaces.Services;
using Entities.Entities;

namespace Application.OpenApp.Account
{
    public class AccountApplication: IAccountApplication
    {
        private readonly IBankAccountService _bankAccountService;

        public AccountApplication(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public Task<BankAccount> Create(BankAccount account)
        {
            return _bankAccountService.CreateAccount(account);
        }

        public Task<IList<BankAccount>> AllAccounts()
        {
            return _bankAccountService.ListAccounts();
        }

        public Task<BankAccount> GetById(int id)
        {
            return _bankAccountService.GetById(id);
        }

        public Task InactiveAccount(int id)
        {
            return _bankAccountService.InactiveAccount(id);
        }
    }
}