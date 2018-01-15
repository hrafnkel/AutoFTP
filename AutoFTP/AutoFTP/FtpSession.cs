using WinSCP;

namespace AutoFTP
{
    public class FtpSession
    {
        private readonly SessionOptions _sessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = "no.home.com",
            UserName = "username",
            Password = "%)u9&kUG10*K",
            SshHostKeyFingerprint = "ssh-rsa 2048 f8:d3:ae:31:48:2a:00:b0:4c:7b:f8:1d:f9:5f:bc:85"
        };

        public SessionOptions GetSessionOptions()
        {
            return _sessionOptions;
        }
    }
}
