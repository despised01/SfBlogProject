using AutoMapper.Internal;
using AutoMapper;
using BlogApp.BlogAppLib.Models;

namespace BlogApp.BlogAppApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
            CreateMap<TagRequest, Tag>();
            CreateMap<Tag, TagRequest>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<Comment, Comment>();
            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostRequest>();
            CreateMap<RoleReqest, Role>();
            CreateMap<Role, RoleReqest>();
        }
    }
}
