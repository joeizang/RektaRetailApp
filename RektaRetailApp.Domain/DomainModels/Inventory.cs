﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RektaRetailApp.Domain.Abstractions;

namespace RektaRetailApp.Domain.DomainModels
{
    public class Inventory : BaseDomainModel
    {
        public Inventory()
        {
            ProductSuppliers = new List<Supplier>();
            InventorySuppliers = new List<SuppliersInventories>();
        }
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(450)]
        public string? Description { get; set; }

        public string? BatchNumber { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        [Required]
        public float Quantity { get; set; }

        [ForeignKey(nameof(InventoryItem))]
        public int ItemId { get; set; }
        public Product InventoryItem { get; set; } = null!;

        [Required]
        public DateTimeOffset SupplyDate { get; set; }

        [Required]
        public List<Supplier> ProductSuppliers { get; set; }

        public List<SuppliersInventories> InventorySuppliers { get; set; }

    }
}
