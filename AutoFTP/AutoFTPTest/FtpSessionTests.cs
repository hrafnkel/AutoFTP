using AutoFTP;
using NUnit.Framework;
using WinSCP;

namespace AutoFTPTest
{
    [TestFixture]
    public class FtpSessionTests
    {
        [SetUp]
        public void SetUp()
        {
            _ftpSession = new FtpSession();
        }

        private FtpSession _ftpSession;

        [Test]
        public void Session_Options_Are_Returned()
        {
            string expected = "username";
            SessionOptions options = _ftpSession.GetSessionOptions();
            string actual = options.UserName;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
