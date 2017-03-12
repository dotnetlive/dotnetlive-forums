using DotNetLive.ForumsWeb.Events;

namespace DotNetLive.ForumsWeb.Services
{
    public class EmailMessageHandler : MessageQueueEventHandler<EmailSendRequest>
    {
        public EmailMessageHandler(RabbitMQConnectionManager connectionManager) : base(connectionManager)
        {
        }

        protected override string MessageQueueName => "AppInfrastructureService_EmailSendMessageQueue";

        protected override object BuildMessageQueueData(EmailSendRequest eventData)
        {
            return eventData;
        }
    }
}
