using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Web;
using LetterMastersAPI.Exceptions;

namespace LetterMastersAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Encode64")]
    public class EncodeController : Controller
    {

        /// <summary>
        /// Returns the Base64 Encoding of an alpha value.
        /// </summary>
        /// <remarks>Returns the Base64 Encoding of the input value.  A non-alpha character in the input is an invalid input</remarks>
        /// <param name="value">The value to encode</param>
        /// <response code="200">OK</response>
        // GET: api/Encode/abcde
        [HttpGet("{value}", Name = "Encode64")]
        [Produces("application/json")]
        public virtual string Encode64(string value)
        {
            string encodedValue;
            
            var encoding = new ASCIIEncoding();
            var stripped = GetAlphas(value);

            if (value != stripped)
            {
                throw new EncoderException("Invalid request.  Only alpha characters are valid.");
            }

            var bytes = encoding.GetBytes(stripped);

            encodedValue = Convert.ToBase64String(bytes);

            return encodedValue;
        }

        private string GetAlphas(string value)
        {
            var pattern = @"[^a-zA-Z]";
            var regex = new Regex(pattern);
            var matches = regex.Replace(value, string.Empty);

            string result = matches;

            return result;
        }
        
    }
}
