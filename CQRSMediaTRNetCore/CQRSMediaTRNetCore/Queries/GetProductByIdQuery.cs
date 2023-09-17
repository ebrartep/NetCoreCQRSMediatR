using MediatR;

namespace CQRSMediaTRNetCore.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
   
}
