using BestDeal.Repository.Models;

namespace BestDeal.Repository.Repositories.Implementation;

public class MercadoLibreRepository : IMercadoLibreRepository
{
    private static List<MercadoLibreProduct> products = new List<MercadoLibreProduct>()
    {
        new MercadoLibreProduct() { Product = "Car", Description = "BMW sport", Value = 20000.0 },
        new MercadoLibreProduct() { Product = "Bike", Description = "Generic Bike", Value = 199.9 },
        new MercadoLibreProduct() { Product = "USB driver", Description = "1TB driver", Value = 100.5, },
        new MercadoLibreProduct() { Product = "Jacket", Description = "Black Jacket Zara", Value = 101.5 },
        new MercadoLibreProduct() { Product = "Monitor 2K", Description = "2K monitor", Value = 200.5 },
        new MercadoLibreProduct() { Product = "Monitor 4K", Description = "4K monitor", Value = 400.5 },
    };

    public IEnumerable<MercadoLibreProduct> GetProductsByNameAndPrice(string name, double value) =>
        products.Where(x => x.Product.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Value <= value);
}