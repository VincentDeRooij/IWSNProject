
using IWSN_Backend_Server.Models;
using IWSN_Backend_Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWSN_Backend_Server.Controllers
{
    [Route("bank/users")]
    [ApiController]
    public class BankUserController : ControllerBase
    {
        private readonly BankUserService _userService;

        public BankUserController(BankUserService service)
        {
            // assign the service to the class variable
            this._userService = service;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.GetAll();

        [HttpGet("{referalId:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = this._userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            var userCreated = _userService.CreateUser(user);

            return CreatedAtRoute("GetUser", new { referalId = user.ReferalId.ToString() }, userCreated);
        }

        [HttpPut("{referalId:length(24)}")]
        public IActionResult Update(string id, User user)
        {
            var gatheredUser = this._userService.GetById(id);

            if (gatheredUser == null)
            {
                return NotFound();
            }

            this._userService.Update(id, user);

            return NoContent();
        }

        [HttpDelete("{referalId:length(24)}")]
        public IActionResult Delete(string id, User user)
        {
            var gatheredUser = this._userService.GetById(id);

            if (gatheredUser == null)
            {
                return NotFound();
            }

            this._userService.Remove(user.Id);

            return NoContent();
        }
    }
}
