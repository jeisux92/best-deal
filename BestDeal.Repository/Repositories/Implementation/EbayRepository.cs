using BestDeal.Repository.Models;

namespace BestDeal.Repository.Repositories.Implementation;

public class EbayRepository : IEbayRepository
{
    private List<EbayProduct> products = new List<EbayProduct>
    {
        new EbayProduct() { Title = "Mouse", Content = "Wireless Mouse", Price = 12.0, Stock = 5 },
        new EbayProduct() { Title = "MacBook Air M1", Content = "MacBook Air M1", Price = 900.0, Stock = 11 },
        new EbayProduct() { Title = "Tablet", Content = "Samsung T8", Price = 800.9, Stock = 7 },
        new EbayProduct() { Title = "Watch", Content = "Digital Watch", Price = 101.5, Stock = 32 },
        new EbayProduct() { Title = "Monitor", Content = "4K monitor", Price = 250.5, Stock = 100 },
    };

    public IEnumerable<EbayProduct> GetProductsByNameAndPrice(string name, double value) =>
        products.Where(x =>
            x.Content.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Price <= value && x.Stock > 0);
}