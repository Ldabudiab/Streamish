﻿using Microsoft.AspNetCore.Mvc;
using Streamish.Models;
using Streamish.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _upRepo;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _upRepo = userProfileRepository;
        }

        // GET: api/<UserProfileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserProfileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("GetByIdWithVideos")]
        public IActionResult GetByIdWithVideos(int id)
        {
            UserProfile up = _upRepo.GetByIdWithVideos(id);
            if (up == null)
            {
                return NotFound();
            }
            return Ok(up);
        }

    }
}
