<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
using RektaRetailApp.Web.Helpers;

namespace RektaRetailApp.Web.ApiModel
{
    public class PaginatedResponse<T> where T : class
    {
        public PagedList<T> List { get; }

        public int TotalCount { get; }
        public int PageSize { get; }

        public int CurrentPage { get; }

<<<<<<< HEAD
        public string? PreviousPageLink { get; private set; }

        public string? NextPageLink { get; private set; }

        public string CurrentResponseStatus { get; }

        public List<object>? Error { get; set; }

        public void SetNavLinks(string? previousLink, string? nextLink)
        {
            if (string.IsNullOrEmpty(previousLink) || string.IsNullOrEmpty(nextLink))
            {
                PreviousPageLink = string.Empty;
                NextPageLink = string.Empty;
            }
            else
            {
                PreviousPageLink = previousLink;
                NextPageLink = nextLink;
            }
        }


        public PaginatedResponse(PagedList<T> list, int totalCount, int pageSize, int currentPage, string? previousPageLink, 
            string? nextPageLink, string currentResponseStatus, object? errors = null)
=======
        public string? PreviousPageLink { get; }

        public string? NextPageLink { get; }


        public PaginatedResponse(PagedList<T> list, int totalCount, int pageSize, int currentPage, string? previousPageLink, string? nextPageLink)
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        {
            List = list;
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            PreviousPageLink = previousPageLink;
            NextPageLink = nextPageLink;
<<<<<<< HEAD
            CurrentResponseStatus = currentResponseStatus;
            if(errors != null)
                Error?.Add(errors);
        }

        public PaginatedResponse(PagedList<T> list, string currentResponseStatus)
        {
            List = list;
            CurrentResponseStatus = currentResponseStatus;
=======
        }

        public PaginatedResponse(PagedList<T> list)
        {
            List = list;
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        }

        public PaginatedResponse()
        {
            List = new PagedList<T>();
<<<<<<< HEAD
            CurrentResponseStatus = ResponseStatus.NonAction;
=======
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        }
    }
}
