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

public class EbayServiceTests
{
    [Test(Description = "No Products")]
    public void GetDealEbayLibre()
    {
        string name = "Air M";
        double price = 250.9;
        DealRequest dealRequest = new DealRequest
        {
            Name = name,
            Price = price,
        };

        var laptop = GetEbayProducts()
            .FirstOrDefault(x => x.Content.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        Mock<IEbayRepository> mockRepo = new Mock<IEbayRepository>();
        mockRepo.Setup(repo => repo.GetProductsByNameAndPrice(name, price))
            .Returns(GetEbayProducts().Where(x =>
                x.Title.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Price <= price));

        IEbayService ebayService = new EbayService(mockRepo.Object);
        var product = ebayService.GetDeal(dealRequest);

        Assert.AreNotEqual(laptop.Title, product?.Name);
    }


    private List<EbayProduct> GetEbayProducts()
    {
        return new List<EbayProduct>
        {
            new EbayProduct() { Title = "Mouse", Content = "Wireless Mouse", Price = 12.0, Stock = 5 },
            new EbayProduct() { Title = "MacBook Air M1", Content = "MacBook Air M1", Price = 900.0, Stock = 11 },
            new EbayProduct() { Title = "Tablet", Content = "Samsung T8", Price = 800.9, Stock = 7 },
            new EbayProduct() { Title = "Watch", Content = "Digital Watch", Price = 101.5, Stock = 32 },
            new EbayProduct() { Title = "Monitor", Content = "4K monitor", Price = 250.5, Stock = 100 },
        };
    }
}