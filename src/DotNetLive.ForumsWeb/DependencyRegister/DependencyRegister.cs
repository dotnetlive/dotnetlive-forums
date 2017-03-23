using DotNetLive.ForumsWeb.Events;
using DotNetLive.ForumsWeb.Services;
using DotNetLive.Framework.Data;
using DotNetLive.Framework.Data.Repositories;
using DotNetLive.Framework.DependencyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.DependencyRegister
{
    public class DependencyRegister : IDependencyRegister
    {
        public ExecuteOrderType ExecuteOrder => ExecuteOrderType.Normal;

        public void Register(IServiceCollection services, IConfigurationRoot configuration, IServiceProvider serviceProvider)
        {
            services.AddScoped<ThreadService>();
            services.AddScoped<EmailService>();
            services.AddScoped<EmailMessageHandler>();

            services.Configure<RabbitMQSettings>(configuration.GetSection("RabbitMQSettings"));
            services.AddSingleton<RabbitMQConnectionManager>();

            #region Data Layer
            services.Configure<DbSettings>(configuration.GetSection("DbSettings"));

            services.AddScoped<CommandDbConnection>();
            services.AddScoped<QueryDbConnection>();

            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            #endregion

            services.AddScoped<TopicCommandService>();
            services.AddScoped<TopicQueryService>();
        }
    }
}
