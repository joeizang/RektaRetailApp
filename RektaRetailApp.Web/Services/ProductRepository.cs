﻿using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.Abstractions;
using RektaRetailApp.Web.Abstractions.Entities;
using RektaRetailApp.Web.ApiModel.Product;
using RektaRetailApp.Web.Commands.Product;
using RektaRetailApp.Web.Data;
using RektaRetailApp.Web.Helpers;
using RektaRetailApp.Web.Queries.Product;

namespace RektaRetailApp.Web.Services
{
    public class ProductRepository : GenericBaseRepository, IProductRepository
    {
        private readonly RektaContext _db;
        private readonly IMapper _mapper;
        private readonly DbSet<Product> _set;
        public ProductRepository(IHttpContextAccessor accessor,
            RektaContext db, IMapper mapper) : base(accessor,db)
        {
            _db = db;
            _mapper = mapper;
            _set = _db.Products;
        }

        public async Task<PagedList<ProductApiModel>> GetAllProducts(GetAllProductsQuery query, CancellationToken token)
        {
            IQueryable<Product> products = _set.AsNoTracking();
            IQueryable<ProductApiModel> tempPaged;
            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                products = products.Where(p => p.Brand!.Contains(query.SearchTerm.Trim().ToUpperInvariant())
                                               && p.Name.Contains(query.SearchTerm.Trim().ToUpperInvariant()));
                tempPaged = products.Select(p => new ProductApiModel(p.Name,p.SupplierId,
                    p.Quantity, p.CostPrice, p.UnitPrice, p.RetailPrice, p.Id));
                var paged = await PagedList<ProductApiModel>
                    .CreatePagedList(tempPaged, query.PageNumber, query.PageSize, token).ConfigureAwait(false);
                return paged;

            }

            tempPaged = products.Select(p => new ProductApiModel(p.Name, p.SupplierId, p.Quantity,
                p.CostPrice, p.UnitPrice,p.RetailPrice, p.Id));
            var pagedProducts = await PagedList<ProductApiModel>
                .CreatePagedList(tempPaged, 1, 10, token).ConfigureAwait(false);
            return pagedProducts;
        }

        public Task<Product> GetProductByIdAsync(int id, CancellationToken token)
        {
            var result = _set.AsNoTracking()
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync(token);
            return result;
        }

        public Task<Product> GetProductByAsync(CancellationToken token, Expression<Func<Product, object>>[]? includes,
            params Expression<Func<Product, bool>>[] searchTerms)
        {
            var product = GetOneBy(token, includes, searchTerms);
            return product;
        }
        public async Task CreateProductAsync(CreateProductCommand command, CancellationToken token)
        {
            var product = _mapper.Map<CreateProductCommand, Product>(command);
            product.Name = product.Name.Trim().ToUpperInvariant();
            if (string.IsNullOrEmpty(product.Brand) || string.IsNullOrEmpty(product.Comments))
            {
                product.Brand = string.Empty;
                product.Comments = string.Empty;
            }
            product.Brand = product.Brand?.Trim().ToUpperInvariant();
            product.Comments = product.Comments?.Trim().ToUpperInvariant();
            var inventory = await _db.Inventories.SingleOrDefaultAsync(x => x.Id == product.InventoryId, token)
                .ConfigureAwait(false);
            // inventory.Quantity += product.Quantity;
            _set.Attach(product);
        }

        public async Task UpdateProductAsync(UpdateProductCommand command, CancellationToken token)
        {
            var target = await _set.Include(x => x.Inventory)
                .SingleOrDefaultAsync(x => x.Id == command.Id, token);
            if (target is null)
                throw new ArgumentException("The Id given doesn't identify any object in persistence!");
            target.Brand = command.Brand?.Trim().ToUpperInvariant();
            target.Name = command.Name.Trim().ToUpperInvariant();
            target.Quantity = command.Quantity;
            target.RetailPrice = command.RetailPrice;
            target.CostPrice = command.CostPrice;
            target.UnitMeasure = command.UnitMeasure;
            target.Verified = command.Verified;
            target.SupplyDate = command.SupplyDate;

            //check that inventory quantity and product quantity are the same if not update inventory
            // if (target.Inventory != null && target.Inventory.Quantity < target.Quantity)
            //     target.Inventory.Quantity = command.Quantity;

            _db.Entry(target).State = EntityState.Modified;
        }

        public void DeleteProductAsync(DeleteProductCommand command)
        {
                var product = _set.Find(command.Id);
                if (product is null)
                    throw new ArgumentException("The id given doesn't belong to a real product!");
                product.IsDeleted = true;
                _db.Entry(product).State = EntityState.Modified;
        }
        public async Task SaveAsync(CancellationToken token)
        {
            await Commit<Product>(token).ConfigureAwait(false);
        }
    }
}
