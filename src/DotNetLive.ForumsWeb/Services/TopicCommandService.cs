using DotNetLive.Forums.Entities;
using DotNetLive.Framework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.Services
{
    public class TopicCommandService
    {
        private ICommandRepository _commandRepository;

        public TopicCommandService(ICommandRepository commandRepository)
        {
            this._commandRepository = commandRepository;
        }

        public Guid CreateTopic(Topic topic)
        {
            _commandRepository.Add(topic);
            return topic.SysId;
        }

        public void UpdateTopic(Topic topic)
        {
            _commandRepository.Update(topic);
        }

        public void DeleteTopic(Guid topicSysId)
        {
            _commandRepository.Delete<Topic>(topicSysId);
        }

    }
}
