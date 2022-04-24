using Newtonsoft.Json.Linq;
using System.IO.Compression;

namespace WorldEditHelper.Items;

public static class ItemsLoader
{
    public static IEnumerable<MineItem> Load(ZipArchive archive, string itemsJson)
    {
        var icons = archive.Entries
            .Select(e => e.Open())
            .Select(StreamToArray)
            .ToArray();

        return JArray.Parse(itemsJson)
            .Select(t => t.ToObject<RawItem>())
            .Select(r => new MineItem
            {
                Id = r.Id,
                Name = r.Name,
                Icon = r.Icon > 0 && r.Icon < icons.Length ? icons[r.Icon] : null
            })
            .ToArray();
    }

    private static byte[] StreamToArray(Stream stream)
    {
        using var memStream = new MemoryStream();
        stream.CopyTo(memStream);
        return memStream.ToArray();
    }
}
