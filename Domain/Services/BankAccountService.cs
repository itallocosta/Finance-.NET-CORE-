using System.Threading.Tasks;
using Domain.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services
{

    class BankAccountService : IBankAccountService
    {

        private readonly IBankAccount _bankAccount;

        public BankAccountService(IBankAccount bankAccount)
        {
            _bankAccount = bankAccount;    
        }

        public async Task<BankAccount> CreateAccount(BankAccount bankAccount)
        {
            bankAccount.ValidateString(bankAccount.BankName, "BankName");
            bankAccount.ValidateDecimal(bankAccount.Overdraft, "Overdraft");
            bankAccount.ValidateDecimal(bankAccount.InterestRate, "InterestRate");
            bankAccount.Active = true;
            if (bankAccount.NotifyList.Count == 0) {
                await _bankAccount.Add(bankAccount);
            } 

            return bankAccount;
        }

        public async Task<BankAccount> GetById(int id)
        {
            return await _bankAccount.GetEntityById(id);
        }

        public async Task InactiveAccount(int id)
        {
            var bankAccount = await _bankAccount.GetEntityById(id);
            if (null != bankAccount)
            {
                bankAccount.Active = false;
                await _bankAccount.Update(bankAccount);
            }
        }

        public async Task<IList<BankAccount>> ListAccounts()
        {
            return await _bankAccount.List();
        }
    }
}
