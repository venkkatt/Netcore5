using System.Text.Json.Serialization;

namespace netCore5.Models
{
    //without this api response will be like 0,1,2. To get the enum we need to use the below method.
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage,
        Cleric
    }
}