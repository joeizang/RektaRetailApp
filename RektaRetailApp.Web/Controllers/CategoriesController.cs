﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RektaRetailApp.Web.Abstractions.Entities;
using RektaRetailApp.Web.ApiModel.Category;
using RektaRetailApp.Web.Data;
using RektaRetailApp.Web.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RektaRetailApp.Web.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _repo;
        private readonly IMediator _mediator;


        public CategoriesController(ILogger<CategoriesController> logger, 
            ICategoryRepository repo,
            IMediator mediator)
        {
            _logger = logger;
            _repo = repo;
            _mediator = mediator;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        //[HttpGet]
        public async Task<IActionResult> GetCategoryDropDown()
        {
            var dropDown = await _repo.GetForDropDown();

            if (dropDown == null)
            {
                return BadRequest();
            }

            return Ok(dropDown);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _repo.GetCategoryById(id));
        }

        // POST api/<CategoriesController>
        [HttpPost(Name = "create")]
        public async Task<IActionResult> Post([FromBody] CreateCategoryApiModel model)
        {
            try
            {
                _repo.Create(model);
                await _repo.Commit().ConfigureAwait(false);
                var response = await _repo.GetCategoryBy(model.Name, model.Description);
                return CreatedAtRoute("GetCategory", new { id = response.CategoryId }, response);
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message, e.InnerException});
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdateCategoryApiModel model)
        {
            try
            {
                _repo.Update(model);
                await _repo.Commit().ConfigureAwait(false);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return BadRequest(new { e.Message, customMessage = "data submitted is not in a valid state" });
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
