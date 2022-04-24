namespace WorldEditHelper.Items;

public interface IItemsSearchEngine
{
    IReadOnlyList<MineItem> AllItems { get; }

    IEnumerable<MineItem> Search(params string[] prefixes);
}
