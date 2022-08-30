using System.Xml.Serialization;

namespace BestDeal.Models.Deals;

[XmlType(TypeName = "BestDeal")]
public class DealResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}