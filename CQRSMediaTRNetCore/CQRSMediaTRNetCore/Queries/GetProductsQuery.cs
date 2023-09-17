using MediatR;

namespace CQRSMediaTRNetCore.Queries
{
    public record class GetProductsQuery : IRequest<IEnumerable<Product>>;
   
}
