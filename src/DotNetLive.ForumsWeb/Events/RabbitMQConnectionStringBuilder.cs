using System;
using System.Text.RegularExpressions;

namespace DotNetLive.ForumsWeb.Events
{
    public class RabbitMQConnectionStringBuilder
    {
        private const string ConnectionStringRegex = @"^(.+)://(.+):(.+)@(.+)/(.+)$";
        public string Portocal { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string VirtualHost { get; set; }

        public RabbitMQConnectionStringBuilder(string connectionString)
        {
            InitConnectionString(connectionString);
        }

        private void InitConnectionString(string connectionString)
        {
            var match = Regex.Match(connectionString, ConnectionStringRegex);
            if (!match.Success)
            {
                throw new InvalidCastException(string.Format("{0} is not a valid RabbitMQ connection string!", connectionString));
            }

            this.Portocal = match.Groups[1].Value;
            this.UserName = match.Groups[2].Value;
            this.Password = match.Groups[3].Value;
            this.HostName = match.Groups[4].Value;
            this.VirtualHost = match.Groups[5].Value;
        }

        public static RabbitMQConnectionStringBuilder BuildConnectionString(string connectionString)
        {
            return new RabbitMQConnectionStringBuilder(connectionString);
        }
    }
}
