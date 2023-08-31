﻿using AutoMapper;
using BlogApp.BlogAppLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentRepository comments;
        private IMapper mapper;

        public CommentController(ICommentRepository commentRepository, IMapper mapper)
        {
            comments = commentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allComments = await comments.GetAll();
            if (allComments != null)
            {
                return StatusCode(200, allComments);
            }
            else
                return NoContent();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var comment = await comments.Get(id);
            if (comment != null)
                return StatusCode(200, comment);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CommentRequest request)
        {
            if (request.Id.ToString() == "" || await comments.Get(request.Id) == null)
            {
                var newComment = mapper.Map<CommentRequest, Comment>(request);
                await comments.Create(newComment);
                return StatusCode(200);
            }
            else
                return StatusCode(400, "Уже существует");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(CommentRequest request)
        {
            if (await comments.Get(request.Id) != null)
            {
                var newComment = mapper.Map<CommentRequest, Comment>(request);
                await comments.Update(newComment);
                return StatusCode(200);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await comments.Get(id);
            if (user != null)
            {
                await comments.Delete(user);
                return StatusCode(200);
            }
            return NotFound();
        }
    }
}
