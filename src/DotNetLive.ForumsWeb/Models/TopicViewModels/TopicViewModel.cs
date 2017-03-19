using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.ForumsWeb.Models.TopicViewModels
{
    public class TopicViewModel
    {
        public Guid SysId { get; set; }
        public Guid NodeId { get; set; }
        public string NodeName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public int Top { get; set; }
        public bool Good { get; set; }
        public int ReplyCount { get; set; }
        public DateTime LastReplyTime { get; set; }
        public DateTime Createdon { get; set; }
    }
}
