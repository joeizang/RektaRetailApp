<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RektaRetailApp.Domain.Abstractions;
>>>>>>> 508be61 (finished fetching a paged collection of suppliers)

namespace RektaRetailApp.Web.Helpers
{
    public class PagedList<T> : List<T> where T : class
    {
        public int MaximumPageSize { get; } = 25;
<<<<<<< HEAD
        public int CurrentPage { get; }

        public int TotalPages { get; }
=======
        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }
>>>>>>> 508be61 (finished fetching a paged collection of suppliers)

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            //safety to ensure that no more than a max of 25 entities can be viewed at any time
            private set => _pageSize = (value > MaximumPageSize) ? MaximumPageSize : value;
        }

        public int TotalCount { get; private set; }

        public bool HasPrevious => (CurrentPage > 1);

        public bool HasNext => (CurrentPage < TotalPages);


        public PagedList(int count, int pageSize, int pageNumber, List<T> items)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            AddRange(items);
        }

<<<<<<< HEAD
        public PagedList()
        {
            
        }

        public static async Task<PagedList<T>> CreatePagedList(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken token)
        {
            var count = await source.CountAsync(token).ConfigureAwait(false);
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(token).ConfigureAwait(false);
=======
        public static async Task<PagedList<T>> CreatePagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync().ConfigureAwait(false);
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);
>>>>>>> 508be61 (finished fetching a paged collection of suppliers)
            return new PagedList<T>(count,pageSize,pageNumber,items);
        }
    }
}
