using System.IO.Compression;

namespace WorldEditHelper.Items.Test;

class Program
{
    static void Main(string[] args)
    {
        var itemsJson = File.ReadAllText("items.json");
        using var archive = ZipFile.Open("png.zip", ZipArchiveMode.Read);
        var items = ItemsLoader.Load(archive, itemsJson).ToList();
        var search = ItemsSearchEngine.IndexCollection(items);

        foreach (var foundItem in Unfold(ReadLine)
            .TakeWhile(line => line != null)
            .Select(line => line!.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .SelectMany(prefixes => search.Search(prefixes)))
        {
            Console.WriteLine(foundItem.Name);
        }
    }

    static string? ReadLine()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }

    static IEnumerable<T> Unfold<T>(Func<T> seed)
    {
        while (true)
        {
            yield return seed();
        }
    }
}
