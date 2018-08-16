using LetterMastersAPI.Controllers;
using LetterMastersAPI.Exceptions;
using NUnit.Framework;

namespace LetterMastersTests
{
    [TestFixture]
    public class EncodeControllerTests
    {
        [Test]
        public void EncodeTestSingleBadChar1()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(Tossa);
        }

        [Test]
        public void EncodeTestSingleBadChar2()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(Tosser2);
        }

        [Test]
        public void EncodeTestSingleBadChar3()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(Tosser3);
        }

        [Test]
        public void EncodeTestSingleBadChar4()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(Tosser4);
        }


        void Tossa()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@"1");
        }

        public void Tosser2()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@"1");
        }

        public void Tosser3()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@"Aa1bbC2");
        }

        public void Tosser4()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@" ");
        }

        [Test]
        public void EncodeTestValidInput()
        {
            EncoderController enc = new EncoderController();
            Assert.AreEqual(@"YQ==", enc.Encode64(@"a"));
            Assert.AreEqual(@"VGhlcXVpY2ticm93bmZveGp1bXBzb3ZlcnRoZWxhenlET0c=", enc.Encode64(@"ThequickbrownfoxjumpsoverthelazyDOG"));
        }

        [Test]
        public void EncodeTestInvalidInput()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(TossTestInvalidInput);
        }

        public void TossTestInvalidInput()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@"The quick brown fox jumps over the lazy DOG!");
        }

        [Test]
        public void EncodeTestInvalidInputSpecial()
        {
            EncoderController enc = new EncoderController();
            Assert.Throws<EncoderException>(TossTestInvalidInputSpecial);
        }

        public void TossTestInvalidInputSpecial()
        {
            EncoderController enc = new EncoderController();
            var result = enc.Encode64(@"`~@#$%^&*()_+-={}|[]\:"";'<>?,./ ");
        }
    }
}
