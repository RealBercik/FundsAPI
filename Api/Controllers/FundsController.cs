using Api.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Serilog;

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
                return Ok(await _fundsLogic.GetFunds());
            }
            catch (Exception e)
            {
                Log.Error(e, "General error");
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
                Log.Error(e, "General error");
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
                Log.Error(e, "General error");
                throw;
            }
        }
    }
}