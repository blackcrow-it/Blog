using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Post
    {
        public Post()
        {
            this.PostId = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.ModifiedAt = DateTime.Now;
            this.Feature = false;
        }
        public string PostId { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public bool Feature { get; set; }
        public string Status { get; set; }
        public bool CommentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ICollection<TermRelationship> TermRelationships { get; set; }
    }
}
