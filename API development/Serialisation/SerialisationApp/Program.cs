using System.Runtime.CompilerServices;
using Newtonsoft.Json;
namespace SerialisationApp;

public class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        //Trainee joseph = new Trainee() { FirstName = "Joseph", LastName = "McCann", SpartaNo = 7 };

        _serialiser = new BinarySerialiser();

        //serialiser.SerialiseToFile<Trainee>($"{_path}/BinaryJoe.bin", joseph);

        Trainee joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryJoe.bin");

        Course eng134 = new Course()
        {
            Title = "Engineering 134",
            Subject = "C# SDET",
            StartDate = new DateTime(2022, 11, 28)
        };

        eng134.AddTrainee(joseph);
        eng134.AddTrainee(new Trainee() { FirstName = "Ikra", LastName = "Dahir", SpartaNo = 10 });
        eng134.AddTrainee(new Trainee() { FirstName = "Mehdi", LastName = "Hamdi", SpartaNo = 5 });

        _serialiser.SerialiseToFile<Course>($"{_path}/XMLJoe.bin", eng134);

        _serialiser = new JSONSerialiser();
        _serialiser.SerialiseToFile<Course>($"{_path}/JsonJoe.bin", eng134);
    }
}
    [Serializable]
    public class Trainee
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public int? SpartaNo { get; init; }
        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            return $"{SpartaNo} - {FullName}";
        }
    }
[Serializable]
public class Course
{
    public string Subject { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public List<Trainee> Trainees { get; } = new List<Trainee>();
    [field: NonSerialized]
    private readonly DateTime _lastRead;
    public Course()
    {
        _lastRead = DateTime.Now;
    }
    public void AddTrainee(Trainee newTrainee)
    {
        Trainees.Add(newTrainee);
    }
}


