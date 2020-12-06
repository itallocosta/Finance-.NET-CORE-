using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("v2/accounts")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BankAccount>> CreateAccount(
            [FromBody] BankAccount bankAccount,
            [FromServices] IAccountApplication accountApplication
        )
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);
        
            await accountApplication.Create(bankAccount);
            if (bankAccount.NotifyList.Count > 0) return new BadRequestObjectResult(bankAccount.NotifyList);

            return Ok(bankAccount);
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<BankAccount>>> AllAccounts(
            [FromServices] IAccountApplication accountApplication
        )
        {
            return Ok(await accountApplication.AllAccounts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetById(
            int id,
            [FromServices] IAccountApplication accountApplication
        )
        {
            var account = await accountApplication.GetById(id);
            if (account == null)
            {
                return NotFound();
            }
            
            return Ok(await accountApplication.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> InactiveAccount(int id, [FromServices] IAccountApplication accountApplication)
        {
            await accountApplication.InactiveAccount(id);
            return NoContent();
        }
    }
}