using BestDeal.Repository.Models;

namespace BestDeal.Repository.Repositories.Implementation;

public class AmazonRepository : IAmazonRepository
{
    private static List<AmazonProduct> products = new List<AmazonProduct>()
    {
        new AmazonProduct() { Name = "Socks", Description = "Red Socks", Price = 32.0, Stock = true },
        new AmazonProduct() { Name = "Book", Description = "History Book", Price = 12.0, Stock = true },
        new AmazonProduct() { Name = "T-Shirt", Description = "T-Shirt for summer", Price = 40.0, Stock = true },
        new AmazonProduct() { Name = "Pants", Description = "Long Pants", Price = 15.0, Stock = true },
        new AmazonProduct() { Name = "Glasses", Description = "Sun glass", Price = 10, Stock = false },
        new AmazonProduct() { Name = "Keyboard", Description = "Mechanic keyboard", Price = 40.0, Stock = true },
    };

    public IEnumerable<AmazonProduct> GetProductsByNameAndPrice(string name, double value) =>
        products.Where(x =>
            x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Price <= value && x.Stock);
}