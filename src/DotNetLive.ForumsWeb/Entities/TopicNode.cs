using DotNetLive.Framework.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLive.Forums.Entities
{
    /// <summary>
    /// 主题节点
    /// </summary>
    [Table("forums.topicNode")]
    public class TopicNode : BaseEntity
    {
        [Column("parentid")]
        public Guid ParentId { get; set; }
        [Column("nodename")]
        public string NodeName { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("order")]
        public int Order { get; set; }
        [Column("createdon")]
        public DateTime Createdon { get; set; }
        [Column("deletedon")]
        public DateTime Deletedon { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
