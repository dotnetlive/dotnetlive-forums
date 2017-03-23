using DotNetLive.Forums.Entities;
using DotNetLive.Framework.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.Services
{
    public class TopicQueryService
    {
        private IQueryRepository _queryRepository;

        public TopicQueryService(IQueryRepository queryRepository)
        {
            this._queryRepository = queryRepository;
        }

        public Topic GetTopicById(Guid topicId)
        {
            return _queryRepository.Get<Topic>(topicId);
        }

        public IEnumerable<Topic> SearchTopic()
        {
            return _queryRepository.GetAll<Topic>();
        }

    }
}
