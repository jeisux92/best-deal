using BestDeal.Models.Deals;
using BestDeal.Repository.Models;
using BestDeal.Repository.Repositories;

namespace BestDeal.Services.Implementation;

public class MercadoLibreService : IMercadoLibreService
{
    private readonly IMercadoLibreRepository _mercadoLibreRepository;

    public MercadoLibreService(IMercadoLibreRepository mercadoLibreRepository)
    {
        _mercadoLibreRepository = mercadoLibreRepository;
    }

    public DealResponse GetDeal(DealRequest request)
    {
        IEnumerable<MercadoLibreProduct> products =
            _mercadoLibreRepository.GetProductsByNameAndPrice(request.Name, request.Price);
        var product = products.MinBy(x => x.Value);
        if (product is null)
        {
            return null;
        }
        return new DealResponse { Name = product.Product, Description = product.Description, Price = product.Value };
    }
}