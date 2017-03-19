using DotNetLive.Framework.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLive.Forums.Entities
{
    /// <summary>
    /// 主题
    /// </summary>
    [Table("forums.topic")]
    public class Topic : BaseEntity
    {
        [Column("nodeid")]
        public Guid NodeId { get; set; }
        [Column("userid")]
        public Guid UserId { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        /// <summary>
        /// 置顶权重
        /// </summary>
        [Column("top")]
        public int Top { get; set; }
        /// <summary>
        /// 精华
        /// </summary>
        [Column("good")]
        public bool Good { get; set; }
        [Column("viewcount")]
        public int ViewCount { get; set; }
        [Column("replycount")]
        public int ReplyCount { get; set; }
        [Column("lastreplyuserid")]
        public Guid? LastReplyUserId { get; set; }
        [Column("lastreplytime")]
        public DateTime? LastReplyTime { get; set; }
        [Column("createdon")]
        public DateTime Createdon { get; set; }
        [Column("deletedon")]
        public DateTime? Deletedon { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
