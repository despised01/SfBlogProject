using System;

namespace BlogApp.BlogAppBll.RequestModels
{
    public class CommentRequest
    {
        public Guid Id { get; set; }
        public string BodyText { get; set; }
    }
}
