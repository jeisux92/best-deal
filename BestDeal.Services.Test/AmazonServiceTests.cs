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

public class AmazonServiceTests
{
    [Test(Description = "Get one item from the store amazon")]
    public void GetDealAmazon()
    {
        string name = "Phone";
        double price = 250.9;
        DealRequest dealRequest = new DealRequest
        {
            Name = name,
            Price = price,
        };

        var phone = GetAmazonProducts()
            .FirstOrDefault(x => x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        Mock<IAmazonRepository> mockRepo = new Mock<IAmazonRepository>();
        mockRepo.Setup(repo => repo.GetProductsByNameAndPrice(name, price))
            .Returns(GetAmazonProducts().Where(x =>
                x.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase) && x.Price <= price));

        IAmazonService amazonService = new AmazonService(mockRepo.Object);
        var product = amazonService.GetDeal(dealRequest);

        Assert.AreEqual(phone.Name, product.Name);
    }


    private List<AmazonProduct> GetAmazonProducts()
    {
        return new List<AmazonProduct>()
        {
            new AmazonProduct() { Name = "Socks", Description = "Red Socks", Price = 32.0, Stock = true },
            new AmazonProduct() { Name = "Book", Description = "History Book", Price = 12.0, Stock = true },
            new AmazonProduct() { Name = "T-Shirt", Description = "T-Shirt for summer", Price = 40.0, Stock = true },
            new AmazonProduct() { Name = "Pants", Description = "Long Pants", Price = 15.0, Stock = true },
            new AmazonProduct() { Name = "Phone", Description = "Sun glass", Price = 10, Stock = false },
            new AmazonProduct() { Name = "Keyboard", Description = "Mechanic keyboard", Price = 40.0, Stock = true },
        };
    }
}