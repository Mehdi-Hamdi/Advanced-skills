using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace SerialisationApp
{
    public class XMLSerialiser : ISerialise
    {
        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            // creating a binary formatter object to use to serialise the item to file
            XmlSerializer writer = new XmlSerializer(item.GetType());
            writer.Serialize(fileStream, item);

            fileStream.Close();
        }

        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);
            XmlSerializer reader = new XmlSerializer(typeof(T));

            var deserialisedItem = (T)reader.Deserialize(fileStream);

            fileStream.Close();

            return deserialisedItem;
        }
    }
}
