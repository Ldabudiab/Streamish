using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserProfileController>/5
        [Authorize]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserProfileController>
        [Authorize]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserProfileController>/5
        //[Authorize]
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UserProfileController>/5
        //[Authorize]
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        [Authorize]
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

        [Authorize]
        [HttpGet("{firebaseUserId}")]
            public IActionResult GetByFirebaseUserId(string firebaseUserId)
            {
                var userProfile =  _upRepo.GetByFirebaseUserId(firebaseUserId);
                if (userProfile == null)
                {
                    return NotFound();
                }
                return Ok(userProfile);
            }
        [Authorize]
        [HttpGet("DoesUserExist/{firebaseUserId}")]
            public IActionResult DoesUserExist(string firebaseUserId)
            {
                var userProfile = _upRepo.GetByFirebaseUserId(firebaseUserId);
                if (userProfile == null)
                {
                    return NotFound();
                }
                return Ok();
            }
        //[Authorize]
        //[HttpPost]
        //    public IActionResult Register(UserProfile userProfile)
        //    {
        //        // All newly registered users start out as a "user" user type (i.e. they are not admins)
        //        userProfile.UserTypeId = UserType.USER_TYPE_ID;
        //    _upRepo.Add(userProfile);
        //        return CreatedAtAction(
        //            nameof(GetByFirebaseUserId), new { firebaseUserId = userProfile.FirebaseUserId }, userProfile);
        //    }
        }
    }
