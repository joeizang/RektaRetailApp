﻿using System.Linq;
using System;
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
            InventorySuppliers = new List<SuppliersInventories>();
            InventoryItems = new List<Product>();
        }
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(450)]
        public string? Description { get; set; }

        public UnitMeasure UnitAmount { get; set; }

        public decimal TotalCostValue { get; private set; }

        public float Quantity => InventoryItems.Sum(q => q.Quantity);

        public bool Verified { get; set; }

        public string? BatchNumber { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public List<Product> InventoryItems { get; set; }

        [Required]
        public DateTimeOffset SupplyDate { get; set; }

        public List<SuppliersInventories> InventorySuppliers { get; set; }


        public void CalculateTotalValuesOfInventory()
        {
            if (InventoryItems.Any())
            {
                TotalCostValue = InventoryItems.Sum(x => x.CostPrice);
                TotalRetailValue = InventoryItems.Sum(x => x.RetailPrice);

            }
        }

        public decimal TotalRetailValue { get; private set; }
    }
}
