using System;
using NUnit.Framework;
using LetterMastersAPI;

namespace LetterMastersUnitTests
{
    [TestFixture]
    public class Base64EncoderTests
    {
        [Test]
        public void StripNonAlpha()
        {
            LetterMastersAPI.Controllers.EncodeController ec = new LetterMastersAPI.Controllers.EncodeController();
            Assert.Pass();
        }
    }
}
