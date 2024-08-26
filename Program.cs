using System.Text.Json;
using System.Text.Json.Serialization;
internal partial class Program
{
    private static void Main(string[] args)
    {
        var guys = new List<Guy>() {
           new Guy() { Name = "Bob", Clothes = new Outfit() { Top = "t-shirt", Bottom = "jeans" },
              Hair = new HairStyle() { Color = HairColor.Red, Length = 3.5f }
           },
           new Guy() { Name = "Joe", Clothes = new Outfit() { Top = "polo", Bottom = "slacks" },
              Hair = new HairStyle() { Color = HairColor.Gray, Length = 2.7f }
           },
        };

        var option = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(guys, option);
        Console.WriteLine(jsonString);
        var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
        foreach (var guy in copyOfGuys) {
            Console.WriteLine("I deserialized this guy: {0}", guy);
        }

        var dudes = JsonSerializer.Deserialize<Stack<Dude>>(jsonString);
        while (dudes.Count > 0)
        {
            var dude = dudes.Pop();
            Console.WriteLine($"Next dude: {dude.Name} with {dude.Hair} hair");
        }
        Console.WriteLine(JsonSerializer.Serialize(3));
        Console.WriteLine(JsonSerializer.Serialize((long)-3));
        Console.WriteLine(JsonSerializer.Serialize((byte)0));
        Console.WriteLine(JsonSerializer.Serialize(float.MaxValue));
        Console.WriteLine(JsonSerializer.Serialize(float.MinValue));
        Console.WriteLine(JsonSerializer.Serialize(true));
        Console.WriteLine(JsonSerializer.Serialize("Elephant"));
        Console.WriteLine(JsonSerializer.Serialize("Elephant".ToCharArray()));
        Console.WriteLine(JsonSerializer.Serialize(" "));
    }    
}
