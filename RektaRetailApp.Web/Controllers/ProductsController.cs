﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RektaRetailApp.Web.ApiModel;
using RektaRetailApp.Web.ApiModel.Product;
using RektaRetailApp.Web.Commands.Product;
using RektaRetailApp.Web.Queries.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RektaRetailApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet(Name = "GetAllProducts")]
        public async Task<ActionResult<PaginatedResponse<ProductApiModel>>> GetAllProducts([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query)
                .ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet(Name = "GetProductsDropDown")]
        public async Task<ActionResult<Response<ProductSummaryApiModel>>> GetProductsForDropdown(
            [FromQuery] GetProductsForSaleQuery query, CancellationToken token)
        {
            var result = await _mediator.Send(query, token).ConfigureAwait(false);
            if (result.CurrentResponseStatus == ResponseStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(Name = "forSale")]
        public async Task<ActionResult<Response<IEnumerable<ProductsForSaleApiModel>>>> GetProductsForSale(GetProductsForSaleQuery query)
        {
            var result = await _mediator.Send(query).ConfigureAwait(false);
            if(!result.CurrentResponseStatus.Equals(ResponseStatus.Success))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Response<ProductDetailApiModel>>> GetProductById(int id)
        {
            var result = await _mediator.Send(new ProductDetailQuery{ Id = id });
            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Response<ProductDetailApiModel>>> CreateProduct(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtRoute("GetProductById", new { id = result.Data.Id}, result);
        }

        //// PUT api/<ProductsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
