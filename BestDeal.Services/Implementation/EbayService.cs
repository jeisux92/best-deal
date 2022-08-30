using BestDeal.Models.Deals;
using BestDeal.Repository.Models;
using BestDeal.Repository.Repositories;

namespace BestDeal.Services.Implementation;

public class EbayService : IEbayService
{
    private readonly IEbayRepository _ebayRepository;

    public EbayService(IEbayRepository ebayRepository)
    {
        _ebayRepository = ebayRepository;
    }

    public DealResponse GetDeal(DealRequest request)
    {
        IEnumerable<EbayProduct> products = _ebayRepository.GetProductsByNameAndPrice(request.Name, request.Price);
        EbayProduct product = products.MinBy(x => x.Price);
        if (product is null)
        {
            return null;
        }
        return new DealResponse { Name = product.Title, Description = product.Content, Price = product.Price };
    }
}