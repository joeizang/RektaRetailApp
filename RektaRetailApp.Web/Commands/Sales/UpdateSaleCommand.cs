using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RektaRetailApp.Web.ApiModel;
using RektaRetailApp.Web.ApiModel.Sales;

namespace RektaRetailApp.Web.Commands.Sales
{
    public class UpdateSaleCommand : IRequest<Response<SaleDetailApiModel>>
    {
    }



    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Response<SaleDetailApiModel>>
    {
        public Task<Response<SaleDetailApiModel>> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
