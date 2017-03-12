using System;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.Services
{
    public class ThreadService
    {
        public ThreadService(EmailService emailService)
        {
            this.EmailService = emailService;
        }

        public EmailService EmailService { get; private set; }

        public void CreateThread()
        {
            var request = new EmailSendRequest() { Title = "Hello from DukeCheng" };
            request.Receivers.Add("dk@feinian.me");
            EmailService.SendEmail(request);
        }
    }

    public class PostService
    {

    }
}
