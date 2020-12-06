using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IAccountApplication
    {
        Task<BankAccount> Create(BankAccount account);

        Task<IList<BankAccount>> AllAccounts();

        Task<BankAccount> GetById(int id);

        Task InactiveAccount(int id);
    }
}