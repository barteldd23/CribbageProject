﻿using Cribbage.BL;
using Cribbage.BL.Models;
using Cribbage.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cribbage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> logger;
        private readonly DbContextOptions<CribbageEntities> options;

        public UserController(ILogger<UserController> logger, DbContextOptions<CribbageEntities> options)
        {
            this.logger = logger;
            this.options = options;
        }

        /// <summary>
        /// Return a list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserManager(options).Load();
        }

        /// <summary>
        /// Get a particular user by id.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return new UserManager(options).LoadById(id);
        }

        /// <summary>
        /// Insert a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="rollback">Should we rollback the insert?</param>
        /// <returns>New Guid</returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] User user, bool rollback = false)
        {

            try
            {
                return new UserManager(options).Insert(user, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update a user.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="user"></param>
        /// <param name="rollback">Should we rollback the update?</param>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Update(user, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="rollback">Should we rollback the delete?</param>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
