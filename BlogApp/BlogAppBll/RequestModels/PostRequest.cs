using System;

namespace BlogApp.BlogAppBll.RequestModels
{
    public class PostRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
    }
}
