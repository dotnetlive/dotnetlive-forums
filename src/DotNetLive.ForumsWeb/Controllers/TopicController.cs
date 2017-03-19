using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetLive.ForumsWeb.Services;

namespace DotNetLive.ForumsWeb.Controllers
{
    public class TopicController : Controller
    {

        public TopicQueryService _topicQueryService { get; private set; }
        public TopicCommandService _topicCommandService { get; private set; }

        public TopicController(TopicQueryService topicQueryService,
            TopicCommandService topicCommandService)
        {
            this._topicQueryService = topicQueryService;
            this._topicCommandService = topicCommandService;
        }

        [Route("/Topic/{id}")]
        public IActionResult Index(Guid id)
        {
            var topic = _topicQueryService.GetTopicById(id);
            if (topic == null) return Redirect("/");
            topic.ViewCount += 1;
            _topicCommandService.UpdateTopic(topic);
            return View(topic);
        }
    }
}