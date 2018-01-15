using System;
using System.Configuration;
using System.IO;

namespace AutoFTP
{
    public class FtpEnvironment
    {
        public string GetRemoteDir()
        {
            return ConfigurationManager.AppSettings["remoteDir"];
        }

        public string GetLocalDir()
        {
            string local = ConfigurationManager.AppSettings["localDir"];
            return Path.Combine(local, ApppendTodaysSubfolderNameToPath());
        }

        public void SetupLocalDir(string local)
        {
            Directory.CreateDirectory(local);
        }

        public int GetNumberOfExpectFiles()
        {
            string number = ConfigurationManager.AppSettings["numberOfExpectedFiles"];
            return int.Parse(number);
        }

        private string ApppendTodaysSubfolderNameToPath()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("yy-MM-dd-dddd") + @"\";
        }
    }
}
