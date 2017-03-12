namespace DotNetLive.ForumsWeb.Services
{
    public class EmailService
    {
        public EmailService(EmailMessageHandler emailMessageHandler)
        {
            this.EmailMessageHandler = emailMessageHandler;
        }

        public EmailMessageHandler EmailMessageHandler { get; private set; }

        public void SendEmail(EmailSendRequest emailSendRequest)
        {
            this.EmailMessageHandler.HandleEvent(emailSendRequest);
        }
    }
}
