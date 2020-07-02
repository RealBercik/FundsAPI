using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Api.DataFiles;
using Api.Logic;

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
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return this.Ok(funds.Where(x => x.Name == manager));
        }

    }
}