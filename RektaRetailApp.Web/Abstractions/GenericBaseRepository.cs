using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RektaRetailApp.Domain.Abstractions;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.Data;

namespace RektaRetailApp.Web.Abstractions
{
  public class GenericBaseRepository : IRepository
  {
    private readonly IHttpContextAccessor _accessor;
    private readonly RektaContext _db;

    public GenericBaseRepository(IHttpContextAccessor accessor, RektaContext db)
    {
      _accessor = accessor;
      _db = db;
    }
    public async Task Commit<T>() where T : BaseDomainModel
    {
      var user = _accessor.HttpContext.User.Identity.Name ?? "Anonymous User";
      foreach (var entity in _db.ChangeTracker.Entries<T>())
      {
        if (entity.State == EntityState.Added)
        {
          entity.Entity.CreatedAt = DateTimeOffset.Now.LocalDateTime;
          entity.Entity.UpdatedAt = DateTimeOffset.Now.LocalDateTime;
          if (string.IsNullOrEmpty(entity.Entity.CreatedBy))
          {
            entity.Entity.CreatedBy = user;
            entity.Entity.UpdatedBy = user;
          }
        }
<<<<<<< HEAD
        public async Task Commit<T>(CancellationToken token) where T : BaseDomainModel
        {
            var user = _accessor.HttpContext.User.Identity.Name ?? "Anonymous User";
            foreach (var entity in _db.ChangeTracker.Entries<T>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTimeOffset.Now.LocalDateTime;
                    entity.Entity.UpdatedAt = DateTimeOffset.Now.LocalDateTime;
                    if (string.IsNullOrEmpty(entity.Entity.CreatedBy))
                    {
                        entity.Entity.CreatedBy = user;
                        entity.Entity.UpdatedBy = user;
                    }
                }
=======
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)

        if (entity.State == EntityState.Modified)
        {
          entity.Entity.UpdatedAt = DateTimeOffset.Now.LocalDateTime;
          if (string.IsNullOrEmpty(entity.Entity.UpdatedBy))
          {
            entity.Entity.UpdatedBy = user.ToUpperInvariant();
          }
        }

      }

<<<<<<< HEAD
            await _db.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public async Task<T> GetOneBy<T>(CancellationToken token, Expression<Func<T, object>>[]? includes = null,
            params Expression<Func<T, bool>>[] searchTerms) where T : BaseDomainModel
        {
            var query = _db.Set<T>().AsNoTracking();

<<<<<<< HEAD
            if (!(includes is null) || includes?.Length != 0)
=======
            if (includes is null || includes.Length == 0)
>>>>>>> 89b8f47 (moved persistence to containers. Modified the models some to achieve clients desire)
            {
                query = searchTerms.Aggregate(query, (current, term) => current.Where(term));
                var result = query.SingleOrDefaultAsync();
                return result;
            }

            query = includes.Aggregate(query, (current, include) => current.Include(include));
            query = searchTerms.Aggregate(query, (current, term) => current.Where(term));
<<<<<<< HEAD

            var result = await query.SingleOrDefaultAsync(token).ConfigureAwait(false);
            return result;
=======
            var altResult = query.SingleOrDefaultAsync();
            return altResult;
>>>>>>> 89b8f47 (moved persistence to containers. Modified the models some to achieve clients desire)
        }
=======
      await _db.SaveChangesAsync().ConfigureAwait(false);
    }

    public Task<T> GetOneBy<T>(Expression<Func<T, object>>[]? includes = null,
        params Expression<Func<T, bool>>[] searchTerms) where T : BaseDomainModel
    {
      var query = _db.Set<T>().AsNoTracking();

      if (includes is null || includes.Length == 0)
      {
        query = searchTerms.Aggregate(query, (current, term) => current.Where(term));
        var result = query.SingleOrDefaultAsync();
        return result;
      }

      query = includes.Aggregate(query, (current, include) => current.Include(include));
      query = searchTerms.Aggregate(query, (current, term) => current.Where(term));
      var altResult = query.SingleOrDefaultAsync();
      return altResult;
>>>>>>> 5ffa05a (implement soft delete on all DomainEntities.)
    }
  }
}
