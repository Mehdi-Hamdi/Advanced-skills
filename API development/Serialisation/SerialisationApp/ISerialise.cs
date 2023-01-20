namespace SerialisationApp;

public interface ISerialise
{
    public T DeserialiseFromFile<T>(string filePath);

    public void SerialiseToFile<T>(string filePath, T item);
}
