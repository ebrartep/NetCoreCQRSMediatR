using CQRSMediaTRNetCore.Queries;
using MediatR;

namespace CQRSMediaTRNetCore.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        => await _fakeDataStore.GetProductById(request.Id);
    }
}
