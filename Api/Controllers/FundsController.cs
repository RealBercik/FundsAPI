using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Api.DataFiles;

namespace Api.Controllers
{
    [ApiController]
    public class FundsController : ControllerBase
    {
        [Route("get-funds")]
        public async Task<IActionResult> GetFunds(string id)
        {
            try
            {
                var file = await System.IO.File.ReadAllTextAsync("./DataFiles/funds.json");

                var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

                if (!string.IsNullOrWhiteSpace(id))
                {
                    return Ok(funds.Single(x => x.MarketCode == id));
                }

                return Ok(funds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Route("get-managerfunds")]
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            return this.Ok(funds.Where(x => x.Name == manager));
        }

    }
}