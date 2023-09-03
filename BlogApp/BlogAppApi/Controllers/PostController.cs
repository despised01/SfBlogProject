﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BlogApp.BlogAppLib.Models;
using AutoMapper;
using BlogApp.BlogAppLib.Repository.Interfaces;
using BlogApp.BlogAppBll.RequestModels;

namespace BlogApp.BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository posts;
        private IMapper mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            posts = postRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allPost = await posts.GetAll();
            if (allPost != null)
            {
                return StatusCode(200, allPost);
            }
            else
                return NoContent();
        }
        [HttpGet]
        [Route("GetAllByAuthor")]
        public async Task<IActionResult> GetAllByAuthorId(Guid authorGuid)
        {
            var allPost = await posts.GetAllByAuthorId(authorGuid);

            if (allPost != null)
            {
                return StatusCode(200, allPost);
            }
            else
                return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var article = await posts.Get(id);
            if (article != null)
                return StatusCode(200, article);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(PostRequest request)
        {
            if (request.Id.ToString() == "" || await posts.Get(request.Id) == null)
            {
                var newPost = mapper.Map<PostRequest, Post>(request);
                await posts.Create(newPost);
                return StatusCode(200);
            }
            else
                return StatusCode(400, "Уже существует");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(PostRequest request)
        {
            if (await posts.Get(request.Id) != null)
            {
                var newPost = mapper.Map<PostRequest, Post>(request);
                await posts.Update(newPost);
                return StatusCode(200);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var newPost = await posts.Get(id);
            if (newPost != null)
            {
                await posts.Delete(newPost);
                return StatusCode(200);
            }
            return NotFound();
        }
    }
}
