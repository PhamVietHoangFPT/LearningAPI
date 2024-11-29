using LearningAPI.Data;
using LearningAPI.Models.Entities;
using LearningAPI.Models.Entities.Account.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;
        public AccountsController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
           var AccountList = dBContext.Accounts.ToList();

           return Ok(AccountList);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAccountById(Guid id)
        {
            var Account = dBContext.Accounts.Find(id);
            if (Account == null)
            {
                return NotFound();
            }
            return Ok(Account);
        }

        [HttpPost]
        public IActionResult CreateAccount(AddAccountDto addAccountDto)
        {
            var Account = new Models.Entities.Account.Account()
            {
                AccountName = addAccountDto.AccountName,
                AccountPassword = addAccountDto.AccountPassword,
                AccountAddress = addAccountDto.AccountAddress,
                IsDeleted = false
            };
            dBContext.Accounts.Add(Account);
            dBContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAccount(Guid id, UpdateAccountDTO updateAccountDTO)
        {
            var Account = dBContext.Accounts.Find(id);
            if (Account is null)
            {
                return NotFound();
            }
            Account.AccountName = updateAccountDTO.AccountName;
            Account.AccountPassword = updateAccountDTO.AccountPassword;
            Account.AccountAddress = updateAccountDTO.AccountAddress;
            dBContext.SaveChanges();
            return Ok(Account);
        }

        [HttpPut]
        [Route("{id:guid}/{status}")]
        public IActionResult UpdateStatusAccount(Guid id, bool status)
        {
            var Account = dBContext.Accounts.Find(id);
            if (Account is null)
            {
                return NotFound();
            }

            Account.IsDeleted = status;
            dBContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteAccount(Guid id)
        {
            var Account = dBContext.Accounts.Find(id);
            if (Account is null)
            {
                return NotFound();
            }
            dBContext.Accounts.Remove(Account);
            dBContext.SaveChanges();
            return Ok();
        }
    }
}
