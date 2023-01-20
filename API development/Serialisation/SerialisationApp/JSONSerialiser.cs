using Newtonsoft.Json;
namespace SerialisationApp;

public class JSONSerialiser : ISerialise
{
    public T DeserialiseFromFile<T>(string filePath)
    {
        string json = File.ReadAllText(filePath);
        T item = JsonConvert.DeserializeObject<T>(json);

        return item;
    }

    public void SerialiseToFile<T>(string filePath, T item)
    {
        string jsonString = JsonConvert.SerializeObject(item);

        File.WriteAllText(filePath, jsonString);

    }
}
