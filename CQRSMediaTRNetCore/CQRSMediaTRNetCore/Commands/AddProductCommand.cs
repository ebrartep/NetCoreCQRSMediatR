using MediatR;

namespace CQRSMediaTRNetCore.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
