using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DotNetLive.ForumsWeb.Events
{
    public class RabbitMQConnectionManager
    {
        private IConnection _connection;
        private static object _connectionLocker = new object();

        private IModel _currentModel;
        private static object _channelLocker = new object();


        public string ConnectionString { get; private set; }

        public RabbitMQConnectionManager(IOptions<RabbitMQSettings> settings)
        {
            ConnectionString = settings.Value.ConnectionString;
        }

        public RabbitMQConnectionManager(string configurationName)
        {
            this.ConnectionString = configurationName;
        }

        private IConnection Connection
        {
            get
            {
                if (_connection == null || !_connection.IsOpen)
                {
                    lock (_connectionLocker)
                    {
                        if (_connection == null || !_connection.IsOpen)
                        {
                            var connString = RabbitMQConnectionStringBuilder.BuildConnectionString(ConnectionString);
                            var factory = new ConnectionFactory()
                            {
                                HostName = connString.HostName,
                                UserName = connString.UserName,
                                Password = connString.Password,
                                VirtualHost = connString.VirtualHost
                            };
                            _connection = factory.CreateConnection();
                        }
                    }
                }
                return _connection;
            }
        }

        public IModel GetCurrentModel()
        {
            if (_currentModel == null || _currentModel.IsClosed)
            {
                lock (_channelLocker)
                {
                    if (_currentModel == null || _currentModel.IsClosed)
                    {
                        _currentModel = Connection.CreateModel();
                    }
                }
            }
            return _currentModel;
        }

    }
}
