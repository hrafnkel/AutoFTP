using System.IO;
using AutoFTP;
using NUnit.Framework;

namespace AutoFTPTest
{
    [TestFixture]
    public class FtpEnvironmentTests
    {
        [SetUp]
        public void SetUp()
        {
            _ftpEnvironment = new FtpEnvironment();
            _helper = new TestHelper();

            if (Directory.Exists(_localDir)) Directory.Delete(_localDir);
        }

        private FtpEnvironment _ftpEnvironment;
        private TestHelper _helper;
        private readonly string _localDir = @"C:\ftptest";

        [Test]
        public void Local_Directory_Is_Created()
        {
            bool exists1 = Directory.Exists(_localDir);
            _ftpEnvironment.SetupLocalDir(_localDir);
            bool exists2 = Directory.Exists(_localDir);

            Assert.False(exists1);
            Assert.True(exists2);
        }

        [Test]
        public void Local_Directory_Name_Is_Retrieved_From_Settings()
        {
            var expected = @"C:\Temp\" + _helper.ApppendTodaysSubfolderNameToPath();
            var remote = _ftpEnvironment.GetLocalDir();
            Assert.That(remote, Is.EqualTo(expected));
        }

        [Test]
        public void Number_of_Expect_Files_Is_Retrieved()
        {
            int count = _ftpEnvironment.GetNumberOfExpectFiles();
            Assert.That(count, Is.GreaterThan(0));
        }

        [Test]
        public void Remote_Directory_Name_Is_Retrieved_From_Settings()
        {
            var expected = @"/";
            var remote = _ftpEnvironment.GetRemoteDir();
            Assert.That(remote, Is.EqualTo(expected));
        }
    }
}
