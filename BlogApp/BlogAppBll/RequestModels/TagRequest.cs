using System;

namespace BlogApp.BlogAppBll.RequestModels
{
    public class TagRequest
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
    }
}
