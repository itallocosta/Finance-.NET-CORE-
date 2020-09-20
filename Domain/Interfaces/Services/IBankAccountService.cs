using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBankAccountService
    {
        Task<BankAccount> CreateAccount(BankAccount bankAccount);
        Task InactiveAccount(int id);
        Task<BankAccount> GetById(int id);
        Task<IList<BankAccount>> ListAccounts();
    }
}
