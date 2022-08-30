using System.Xml.Serialization;

namespace BestDeal.Api.ViewModels;

[XmlType(TypeName = "Query")]
public class MercadoLibreViewModel
{
    public string Title { get; set; }
    public double Price { get; set; }
}