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
    [Route("api/encode64")]
    public class EncoderController : Controller
    {

        /// <summary>
        /// Returns the Base64 Encoding of an alpha value.
        /// </summary>
        /// <remarks>Returns the Base64 Encoding of the input value.  A non-alpha character in the input is an invalid input</remarks>
        /// <param name="value">The value to encode</param>
        [HttpGet("{value}", Name = "encode64")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public virtual string Encode64(string value)
        {
            string encodedValue;
            if (value != null) value = value.Trim();

            var stripped = GetAlphas(value);

            if (stripped is null || value != stripped)
            {
                throw new EncoderException("Invalid request.  Only alpha characters are valid.");
            }

            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(stripped);

            encodedValue = Convert.ToBase64String(bytes);

            return encodedValue;
        }

        private string GetAlphas(string value)
        {
            if (value is null || value == string.Empty) return null;

            var pattern = @"[^a-zA-Z]";
            var regex = new Regex(pattern);
            var matches = regex.Replace(value, string.Empty);

            string result = matches;

            return result;
        }
        
    }
}
