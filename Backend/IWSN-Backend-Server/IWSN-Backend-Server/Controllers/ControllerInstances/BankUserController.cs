using IWSN_Backend_Server.Models;
using IWSN_Backend_Server.Models.Settings.Class;
using IWSN_Backend_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Controllers
{
    [Route("api/v1/bank/")]
    [ApiController]
    public class BankUserController : ControllerBase
    {
        private readonly BankAccountService _accountService;

        public BankUserController(BankAccountService service)
        {
            // assign the service to the class variable
            this._accountService = service;
        }

        // get all the available users - async
        [Route(AccountDBRouteSettings.MAIN_ROUTE + "/all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDBModel>>> GetAllUsers()
        {
            var users = await this._accountService.GetAllAsync();
            return users.ToList();
        }

        // get a single user by MongoDB assign Id
        [Route(AccountDBRouteSettings.MAIN_ROUTE + "/{id}")]
        [HttpGet]
        public async Task<ActionResult<AccountDBModel>> GetById(string id)
        {
            var user = await this._accountService.GetByIdAsync(id);
            return user;
        }

        // Create a single user document in MongoDB - works but throws an error? -> System.InvalidOperationException: No route matches the supplied values.
        [Route(AccountDBRouteSettings.MAIN_ROUTE + "/create")]
        [HttpPost]
        public async Task<ActionResult<AccountDBModel>> CreateUser([FromBody]AccountDBModel user)
        {
            var userCreated = await _accountService.CreateUserAsync(user);
            return userCreated;
        }

        // 
        [Route(AccountDBRouteSettings.MAIN_ROUTE + "/update/{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody]AccountDBModel user)
        {
            var gatheredUser = await this._accountService.GetByIdAsync(id);

            if (gatheredUser == null)
            {
                return NotFound();
            }
            await this._accountService.UpdateAsync(id, user);
            return NoContent();
        }

        [Route(AccountDBRouteSettings.MAIN_ROUTE + "/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var accountTaskObject = await this._accountService.GetByIdAsync(id);

            if (accountTaskObject == null)
            {
                return NotFound();
            }
            await this._accountService.RemoveAsync(id);

            return NoContent();
        }
    }
}
