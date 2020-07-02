using Api.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly FundsLogic _fundsLogic;

        public FundsController()
        {
            _fundsLogic = new FundsLogic();
        }

        [HttpGet("get-funds")]
        public async Task<IActionResult> GetFunds(string id)
        {
            try
            {
                return Ok(string.IsNullOrWhiteSpace(id) ? await _fundsLogic.GetFunds() : await _fundsLogic.GetFunds(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("get-managerfunds")]
        public async Task<IActionResult> GetManagerFunds(string manager)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(manager)) return BadRequest("Input parameter 'manager' is required.");

                return Ok(await _fundsLogic.GetManagerFunds(manager));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}