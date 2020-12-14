using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.Abstractions;
using RektaRetailApp.Web.Abstractions.Entities;
using RektaRetailApp.Web.ApiModel.Sales;
using RektaRetailApp.Web.Commands.Sales;
using RektaRetailApp.Web.Data;
using RektaRetailApp.Web.Helpers;
using RektaRetailApp.Web.Queries.Sales;

namespace RektaRetailApp.Web.Services
{
    public class SalesRepository : GenericBaseRepository, ISalesRepository
    {
        public SalesRepository([NotNull] IHttpContextAccessor accessor, [NotNull] RektaContext db) : base(accessor, db)
        {
        }

        public Task CancelASale(CancelSaleCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task CreateSale(CreateSaleCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<SaleApiModel>> GetAllSales(GetAllSalesQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetSaleById(GetSaleByIdQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSale(UpdateSaleCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
