using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace allmymoney.cashspend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashSpendController : ControllerBase
    {
        // POST: api/CashSpend
        [HttpPost]
        [Authorize]
        public void Post([FromBody] string value)
        {
        }
    }
}
