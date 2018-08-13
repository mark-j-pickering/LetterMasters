using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LetterMastersAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Encode")]
    public class EncodeController : Controller
    {

        // GET: api/Encode/abcde
        [HttpGet("{value}", Name = "Get")]
        public string Get(string value)
        {
            string encodedValue;

            encodedValue = "Encoded";

            return encodedValue;
        }
        
    }
}
