using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LetterMastersAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Encoder")]
    public class EncodeController : Controller
    {

        // GET: api/Encode/abcde
        [HttpGet("{value}", Name = "Encode64")]
        public string Encode64(string value)
        {
            string encodedValue;
            
            var encoding = new ASCIIEncoding();
            var stripped = GetAlphas(value);
            var bytes = encoding.GetBytes(stripped);

            encodedValue = Convert.ToBase64String(bytes);

            return encodedValue;
        }

        private string GetAlphas(string value)
        {
            var pattern = @"[a-zA-Z]";
            var regex = new Regex(pattern);
            var matches = regex.ToString();

            string result = matches;

            return result;
        }
        
    }
}
