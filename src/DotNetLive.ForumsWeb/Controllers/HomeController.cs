using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using DotNetLive.ForumsWeb.Services;
using AutoMapper;
using DotNetLive.ForumsWeb.Models.TopicViewModels;

namespace DotNetLive.ForumsWeb.Controllers
{
    public class HomeController : Controller
    {
        public TopicQueryService _topicQueryService { get; private set; }
        private IMapper _mapper;

        public HomeController(TopicQueryService topicQueryService,
            IMapper mapper)
        {
            this._topicQueryService = topicQueryService;
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            var list = _topicQueryService.SearchTopic();
            ViewBag.Topics = _mapper.Map<IEnumerable<TopicViewModel>>(list);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MailTest()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Duke Cheng", "duke@feinian.me"));
            message.To.Add(new MailboxAddress("Duke Cheng", "duke.cheng@outlook.com"));
            message.To.Add(new MailboxAddress("FeiNian Cheng", "feinian.cheng@hotmail.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("email host", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("username", @"password");

                client.Send(message);
                client.Disconnect(true);
            }
            return View();
        }
    }
}
