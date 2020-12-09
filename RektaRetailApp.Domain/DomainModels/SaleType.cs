using System.Text.Json.Serialization;

namespace RektaRetailApp.Domain.DomainModels
{
    [JsonConverter(typeof(SaleType))]
    public enum SaleType
    {
        Paid,
        Credit,
    }

    [JsonConverter(typeof(PaymentType))]
    public enum PaymentType
    {
        Cash,
        Credit,
        Electronic,
        USSD,
        Cheque,
        Other
    }
}