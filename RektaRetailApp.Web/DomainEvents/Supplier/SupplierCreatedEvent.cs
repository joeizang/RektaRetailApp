using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using RektaRetailApp.Web.Abstractions;
using RektaRetailApp.Web.ApiModel;
using RektaRetailApp.Web.ApiModel.Supplier;
using RektaRetailApp.Web.Helpers;

namespace RektaRetailApp.Web.DomainEvents.Supplier
{
    public class SupplierCreatedEvent : DomainEvent
    {

        public SupplierCreatedEvent(SupplierApiModel model)
        {
            HappenedAt = DateTimeOffset.Now;
            ActionPerformed = TaskPerformed.Creation;
            PayLoad = model;
        }
    }
}
