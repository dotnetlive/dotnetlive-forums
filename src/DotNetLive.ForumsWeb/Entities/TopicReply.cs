using DotNetLive.Framework.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLive.Forums.Entities
{
    /// <summary>
    /// 回复
    /// </summary>
    [Table("forums.topicReply")]
    public class TopicReply : BaseEntity
    {
        [Column("topicid")]
        public Guid TopicId { get; set; }
        [Column("userid")]
        public Guid UserId { get; set; }
        [Column("replyemail")]
        public string ReplyEmail { get; set; }
        [Column("replycontent")]
        public string ReplyContent { get; set; }
        [Column("createdon")]
        public DateTime Createdon { get; set; }
        [Column("deletedon")]
        public DateTime Deletedon { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
