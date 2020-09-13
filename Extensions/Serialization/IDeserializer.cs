namespace EnergyAPIClient.Extensions.Serialization
{
    public interface IDeserializer
    {
        T Deserialize<T>(string json) where T : class;
    }
}