using System.Text.Json.Serialization;

namespace RektaRetailApp.Domain.DomainModels
{
    [JsonConverter(typeof(UnitMeasure))]
    public enum UnitMeasure
    {
        KG,
        MEASURE,
        PACKS,
        CRATE,
        GALLON,
        TUBER,
        BOTTLE,
        PIECES,
        OTHER
    }
}
