using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace allmymoney.cashspend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashSpendController : ControllerBase
    {
        // GET: api/CashSpend
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CashSpend/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CashSpend
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CashSpend/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
