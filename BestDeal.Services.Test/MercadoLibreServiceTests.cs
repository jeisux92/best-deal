using System;
using System.Collections.Generic;
using System.Linq;
using BestDeal.Models.Deals;
using BestDeal.Repository.Models;
using BestDeal.Repository.Repositories;
using BestDeal.Services;
using BestDeal.Services.Implementation;
using Moq;
using NUnit.Framework;

namespace BestDeal.Repository.Test;

public class MercadoLibreServiceTests
{
    [Test]
    public void GetDealMercadoLibre()
    {
        string name = "on";
        double price = 250.9;
        DealRequest dealRequest = new DealRequest
        {
            Name = name,
            Price = price,
        };

        var phone = GetMercadoLibreProducts()
            .Where(x =>
                x.Product.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Value <= price)
            .MinBy(x => x.Value);

        Mock<IMercadoLibreRepository> mockRepo = new Mock<IMercadoLibreRepository>();

        mockRepo.Setup(repo => repo.GetProductsByNameAndPrice(name, price))
            .Returns(GetMercadoLibreProducts().Where(x =>
                x.Product.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Value <= price));

        IMercadoLibreService amazonService = new MercadoLibreService(mockRepo.Object);
        var product = amazonService.GetDeal(dealRequest);

        Assert.AreEqual(phone.Product, product.Name);
    }


    private List<MercadoLibreProduct> GetMercadoLibreProducts()
    {
        return new List<MercadoLibreProduct>()
        {
            new MercadoLibreProduct() { Product = "Car", Description = "BMW sport", Value = 20000.0 },
            new MercadoLibreProduct() { Product = "Bike", Description = "Generic Bike", Value = 199.9 },
            new MercadoLibreProduct() { Product = "USB driver", Description = "1TB driver", Value = 100.5, },
            new MercadoLibreProduct() { Product = "Jacket", Description = "Black Jacket Zara", Value = 101.5 },
            new MercadoLibreProduct() { Product = "Monitor 2K", Description = "2K monitor", Value = 200.5 },
            new MercadoLibreProduct() { Product = "Monitor 4K", Description = "4K monitor", Value = 400.5 },
        };
    }
}