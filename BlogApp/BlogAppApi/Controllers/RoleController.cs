﻿using AutoMapper;
using BlogApp.BlogAppLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BlogApp.BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepository roles;
        private IMapper mapper;

        public RoleController(IRoleRepository roleRepository, IMapper mapper)
        {
            roles = roleRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await roles.Get(id);
            if (role != null)
                return StatusCode(200, role);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var allTags = await roles.GetAll();
            if (allTags != null)
                return StatusCode(200, allTags);
            else
                return NoContent();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(RoleReqest request)
        {
            if (request.Id.ToString() == "" || await roles.Get(request.Id) == null)
            {
                var role = mapper.Map<RoleReqest, Role>(request);
                await roles.Create(role);
                return StatusCode(200);
            }
            else
                return StatusCode(400, "Уже существует");
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(RoleReqest request)
        {
            if (await roles.Get(request.Id) != null)
            {
                var role = mapper.Map<RoleReqest, Role>(request);
                await roles.Update(role);
                return StatusCode(200);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await roles.Get(id);
            if (role != null)
            {
                await roles.Delete(role);
                return StatusCode(200);
            }
            return NotFound();
        }
    }
}
