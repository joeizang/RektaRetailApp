using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.ApiModel.Supplier;
using RektaRetailApp.Web.Commands.Supplier;
using RektaRetailApp.Web.Helpers;
using RektaRetailApp.Web.Queries.Supplier;

namespace RektaRetailApp.Web.Abstractions.Entities
{
    public interface ISupplierRepository : IRepository
    {
        Task SaveAsync(CancellationToken token);

        Task<PagedList<SupplierApiModel>> GetSuppliersAsync(GetAllSuppliersQuery query, CancellationToken token);

        Task<Supplier> GetSupplierById(int id, CancellationToken token);

        Task<Supplier> GetSupplierBy(CancellationToken token, Expression<Func<Supplier, object>>[]? includes = null,
            params Expression<Func<Supplier, bool>>[] searchTerms);

        void CreateSupplier(CreateSupplierCommand command);

        void UpdateSupplier(UpdateSupplierCommand command);
        
        Task DeleteSupplier(int id, CancellationToken token);
    }
}
