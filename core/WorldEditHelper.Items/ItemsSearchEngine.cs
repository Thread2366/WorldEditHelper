using WorldEditHelper.Items.Search;

namespace WorldEditHelper.Items;

public class ItemsSearchEngine : IItemsSearchEngine
{
    private readonly PrefixTree _prefixTree;

    public IReadOnlyList<MineItem> AllItems { get; }

    private ItemsSearchEngine(IReadOnlyList<MineItem> items,
        PrefixTree prefixTree)
    {
        AllItems = items;
        _prefixTree = prefixTree;
    }

    public IEnumerable<MineItem> Search(params string[] prefixes)
    {
        if (prefixes.Length == 0) return Enumerable.Empty<MineItem>();

        return prefixes
            .Select(prefix => _prefixTree.GetIndexesByPrefix(prefix))
            .Aggregate((intersection, indexes) => intersection.Intersect(indexes))
            .Select(idx => AllItems[idx]);
    }

    public static ItemsSearchEngine IndexCollection(IReadOnlyList<MineItem> items)
    {
        var prefixTree = new PrefixTree();

        foreach (var (word, indexes) in items
            .SelectMany((item, index) => item.Name
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(word => (word, index)))
            .GroupBy(t => t.word)
            .Select(grp => (grp.Key, grp
                .Select(t => t.index))))
        {
            prefixTree.AddWord(word, indexes);
        }

        return new ItemsSearchEngine(items, prefixTree);
    }
}
