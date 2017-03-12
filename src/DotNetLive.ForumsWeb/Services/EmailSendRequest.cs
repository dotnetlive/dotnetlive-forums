using System.Collections.Generic;
using System.IO;

namespace DotNetLive.ForumsWeb.Services
{
    public class EmailSendRequest
    {
        public string BizCode { get; set; }
        public List<string> Receivers { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Priority { get; set; }
        public List<Stream> Attachments { get; set; }

        public EmailSendRequest()
        {
            Receivers = new List<string>();
            CC = new List<string>();
            BCC = new List<string>();
            Attachments = new List<Stream>();
        }
    }
}
