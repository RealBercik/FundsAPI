using Api.Logic;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        public async Task<IActionResult> GetFunds()
        {
            try
            {
                // Note: Installed logging utility Serilog will log which methods are being called. Please see ./Logging/log.json.

                return Ok(await _fundsLogic.GetFunds());
            }
            catch (Exception e)
            {
                Log.Error(e, "General exception");
                throw;
            }
        }

        [HttpGet("get-fund")]
        public async Task<IActionResult> GetFund(string id)
        {
            try
            {
                return Ok(await _fundsLogic.GetFund(id));
            }
            catch (Exception e)
            {
                Log.Error(e, "General exception");
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
                Log.Error(e, "General exception");
                throw;
            }
        }
    }
}