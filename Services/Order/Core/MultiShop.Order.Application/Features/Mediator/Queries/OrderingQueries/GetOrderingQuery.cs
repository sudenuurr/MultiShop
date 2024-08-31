using MediatR;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    //bütün listeyi döner. bu yüzden türü list olarak tanımlandı
    public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
    {
    }
}
