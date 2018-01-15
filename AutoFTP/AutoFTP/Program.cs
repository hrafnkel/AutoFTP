using System;
using WinSCP;

namespace AutoFTP
{
    static class Program
    {
        static void Main()
        {
            var ftpSession = new FtpSession();
            var ftpEnvironment = new FtpEnvironment();

            string remote = ftpEnvironment.GetRemoteDir();
            string local = ftpEnvironment.GetLocalDir();
            int numberOfExpectedFiles = ftpEnvironment.GetNumberOfExpectFiles();

            ftpEnvironment.SetupLocalDir(local);

            Console.WriteLine("Message: Writing files to {0}\n", local);

            try
            {
                using (Session session = new Session())
                {
                    session.Open(ftpSession.GetSessionOptions());

                    RemoteDirectoryInfo info = session.ListDirectory(remote);

                    if (info.Files.Count == 0)
                        throw new Exception("No files present at remote end");

                    TransferOptions options = new TransferOptions { FileMask = "|*/" };

                    int numberOfFilesRetrieved = 0;
                    foreach (RemoteFileInfo fileInfo in info.Files)
                    {
                        if (IsValidFileType(fileInfo.Name))
                        {
                            Console.WriteLine("Message: Getting file {0}", fileInfo.Name);
                            session.GetFiles(session.EscapeFileMask(remote + fileInfo.Name), local, false, options)
                                .Check();
                            numberOfFilesRetrieved++;
                        }
                    }

                    if (numberOfFilesRetrieved != numberOfExpectedFiles)
                        throw new Exception("Check all files are present at remote end");

                    session.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex);
            }
        }

        private static bool IsValidFileType(string filename)
        {
            return filename.Contains(".csv") || filename.Contains(".xlsx");
        }
    }
}
