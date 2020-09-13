using Newtonsoft.Json;

namespace EnergyAPIClient.Extensions.Serialization
{
    public class JsonDeserializer : IDeserializer
    {
        public T Deserialize<T>(string json) where T : class
        {
            return string.IsNullOrEmpty(json) ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }
    }
}