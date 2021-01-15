using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.ApiModel.Inventory;
using RektaRetailApp.Web.Commands.Inventory;
using RektaRetailApp.Web.Data;
using RektaRetailApp.Web.Helpers;
using RektaRetailApp.Web.Queries.Inventory;

namespace RektaRetailApp.Web.Abstractions.Entities
{
  public interface IInventoryRepository : IRepository
  {
    Task<PagedList<Inventory>> GetAllInventories(GetAllInventoriesQuery request, CancellationToken token);

    Task<InventoryDetailApiModel> GetInventoryById(int id);

    Task<Inventory> GetInventoryById(UpdateInventoryCommand id);

    Task<InventoryApiModel> GetInventoryBy(params Expression<Func<Inventory, bool>>[] searchTerms);

    Task<IEnumerable<InventoryApiModel>> GetInventoriesBy(params Expression<Func<Inventory, bool>>[] searchTerms);

    void CreateInventory(CreateInventoryCommand command);

    Task UpdateInventory(UpdateInventoryCommand command);

    Task DeleteInventory(DeleteInventoryCommand command);

    Task SaveAsync(CancellationToken token);
  }
}
