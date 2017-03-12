using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetLive.ForumsWeb.Services;

namespace DotNetLive.ForumsWeb.Controllers
{
    public class ThreadController : Controller
    {
        public ThreadController(ThreadService threadService)
        {
            this.ThreadService = threadService;
        }

        public ThreadService ThreadService { get; private set; }

        public IActionResult Index()
        {
            ThreadService.CreateThread();
            return View();
        }
    }
}