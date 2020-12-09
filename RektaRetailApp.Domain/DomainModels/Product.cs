﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using RektaRetailApp.Domain.Abstractions;

namespace RektaRetailApp.Domain.DomainModels
{
    public class Product : BaseDomainModel
    {
        public Product()
        {
            ProductCategories = new List<Category>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public decimal RetailPrice { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal SuppliedPrice { get; set; }

        [Required]
        public DateTimeOffset SupplyDate { get; set; }

        [Required]
        public float Quantity { get; set; }

        public float ReorderPoint { get; set; }

        public string? ImageUrl { get; set; }

        public string? Brand { get; set; }

        public string? Comments { get; set; }

        [JsonConverter(typeof(UnitMeasure))]
        public UnitMeasure UnitMeasure { get; set; }

        public bool Verified { get; set; }

        public List<Category> ProductCategories { get; set; }

        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier ProductSupplier { get; set; } = null!;
    }
}