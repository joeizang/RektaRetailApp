﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RektaRetailApp.Domain.DomainModels;
using RektaRetailApp.Web.ApiModel.Category;
using RektaRetailApp.Web.ApiModel.Product;
using RektaRetailApp.Web.Commands.Product;

namespace RektaRetailApp.Web.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductApiModel>();
            CreateMap<ProductApiModel, Product>();
            CreateMap<Product, ProductSummaryApiModel>();
            CreateMap<CreateProductCommand, Product>()
                .ForMember(d => d.ProductCategories, conf => conf.Ignore());
            
        }
    }
}
