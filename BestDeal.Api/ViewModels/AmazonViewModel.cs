using System.Xml.Serialization;

namespace BestDeal.Api.ViewModels;

[XmlType(TypeName = "Query")]
public class AmazonViewModel
{
    public string ProductTitle { get; set; }
    public int MaxPrice { get; set; }
}
