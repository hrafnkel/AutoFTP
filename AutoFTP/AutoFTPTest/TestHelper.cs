using System;

namespace AutoFTPTest
{
    public class TestHelper
    {
        public string ApppendTodaysSubfolderNameToPath()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("yy-MM-dd-dddd") + @"\";
        }
    }
}
