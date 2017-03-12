using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.Events
{
    public abstract class MessageQueueEventHandler<TEventData>
    {
        protected abstract string MessageQueueName { get; }
        public RabbitMQConnectionManager ConnectionManager { get; private set; }

        public MessageQueueEventHandler(RabbitMQConnectionManager connectionManager)
        {
            this.ConnectionManager = connectionManager;
        }

        public void HandleEvent(TEventData eventData)
        {
            var resultData = BuildMessageQueueData(eventData);
            PublishToQueue(resultData);
        }

        protected abstract object BuildMessageQueueData(TEventData eventData);

        protected virtual void PublishToQueue(object eventData)
        {
            Task.Run(() =>
            {
                try
                {
                    var channel = ConnectionManager.GetCurrentModel();
                    channel.QueueDeclare(queue: MessageQueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "", routingKey: MessageQueueName, basicProperties: properties, body: MessageHelper.GetMessageBody(eventData));
                }
                catch (Exception ex)
                {
                    //吃掉异常，后续做日志记录
                }
            });
        }
    }
}
