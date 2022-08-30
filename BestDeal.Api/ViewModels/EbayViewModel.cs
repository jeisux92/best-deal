using System.Xml.Serialization;

namespace BestDeal.Api.ViewModels;

[XmlType(TypeName = "Query")]
public class EbayViewModel
{
    public string Name { get; set; }
    public double Value { get; set; }
}