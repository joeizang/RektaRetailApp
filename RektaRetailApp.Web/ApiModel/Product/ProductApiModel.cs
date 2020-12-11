﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RektaRetailApp.Web.ApiModel.Category;

namespace RektaRetailApp.Web.ApiModel.Product
{
public class ProductApiModel
    {
<<<<<<< HEAD
        public ProductApiModel(string name, float quantity, decimal suppliedPrice, decimal retailPrice, int id)
        {
            Name = name;
=======
        public ProductApiModel(string name, int supplierId, float quantity, decimal suppliedPrice, decimal unitPrice, decimal retailPrice)
        {
            Name = name;
            SupplierId = supplierId;
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
            Quantity = quantity;
            CostPrice = suppliedPrice;
            RetailPrice = retailPrice;
            ProductCategories = new List<CategoryApiModel>();
            Id = id;
        }
<<<<<<< HEAD
=======
        public string Name { get; }
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f

        public ProductApiModel()
        {
            ProductCategories = new List<CategoryApiModel>();
        }
        public string? Name { get; }

        public int Id { get; set; }

        public decimal RetailPrice { get; }

        public decimal CostPrice { get; }

        public float Quantity { get; }

        public List<CategoryApiModel> ProductCategories { get; }
    }

    public class ProductsForSaleApiModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }
    }

    public class ProductSummaryApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Quantity { get; set; }
    }

    public class ProductSummaryApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Quantity { get; set; }
    }

    public class ProductSummaryApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Quantity { get; set; }
    }

    public class CreateProductApiModel
    {
        public CreateProductApiModel(int supplierId, decimal suppliedPrice, float quantity, decimal unitPrice, decimal retailPrice, DateTimeOffset supplyDate)
        {
            SupplierId = supplierId;
            SuppliedPrice = suppliedPrice;
            Quantity = quantity;
            UnitPrice = unitPrice;
            RetailPrice = retailPrice;
            SupplyDate = supplyDate;
            ProductCategories = new List<CategoryApiModel>();
        }

        public string Name { get; } = null!;

        public decimal RetailPrice { get; }

        public decimal UnitPrice { get; }

        public float Quantity { get; }

        public decimal SuppliedPrice { get; }

        public List<CategoryApiModel> ProductCategories { get; }

        public int SupplierId { get; }

        public DateTimeOffset SupplyDate { get; }
    }

    public class ProductDetailApiModel
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public ProductDetailApiModel(decimal retailPrice, string name, float quantity, decimal suppliedPrice, DateTimeOffset supplyDate, int id)
=======
        public ProductDetailApiModel(decimal retailPrice, decimal unitPrice, string name,
            float quantity, decimal suppliedPrice, string? supplierName, string? mobileNumber, string? imageUrl, DateTimeOffset supplyDate)
>>>>>>> e3390aa (finished with backend features for suppliers. Working on frontend features for suppliers)
=======
        public ProductDetailApiModel(decimal retailPrice, decimal unitPrice, string name,
            float quantity, decimal suppliedPrice, string? supplierName, string? mobileNumber, string? imageUrl, DateTimeOffset supplyDate)
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        {
            Name = name;
            RetailPrice = retailPrice;
            Quantity = quantity;
            CostPrice = suppliedPrice;
            ProductCategories = new List<CategoryApiModel>();
            SupplyDate = supplyDate;
<<<<<<< HEAD
<<<<<<< HEAD
            Id = id;
=======
            ImageUrl = imageUrl;
>>>>>>> e3390aa (finished with backend features for suppliers. Working on frontend features for suppliers)
=======
            ImageUrl = imageUrl;
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        }

        public ProductDetailApiModel()
        {
            ProductCategories = new List<CategoryApiModel>();
        }

        public int Id { get; set; }

        public string Name { get; } = null!;

        public decimal RetailPrice { get; }

        public float Quantity { get; }

        public decimal CostPrice { get; }

        public List<CategoryApiModel> ProductCategories { get; }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> f2bb3482437b8fec14273b933964d84289e28e8f
        public string? SupplierName { get; }

        public string? MobileNumber { get; }
        
        public string? ImageUrl { get; set; }

>>>>>>> e3390aa (finished with backend features for suppliers. Working on frontend features for suppliers)
        public DateTimeOffset SupplyDate { get; }
    }
}
