namespace WorldEditHelper.Items.Search;

internal class PrefixTree
{
    private readonly PrefixTreeNode _head;

    public PrefixTree()
    {
        _head = new PrefixTreeNode(new(), null);
    }

    public void AddWord(string word, IEnumerable<int> indexes)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Word is null or white space", nameof(word));

        if (indexes == null) indexes = Array.Empty<int>();

        var chars = new LinkedList<char>(word.ToLower());
        _head.AddWord(chars, indexes);
    }

    public IEnumerable<int> GetIndexesByPrefix(string prefix)
    {
        PrefixTreeNode targetNode = _head;
        foreach (var ch in prefix)
        {
            if (!targetNode.Children.TryGetValue(ch, out targetNode))
            {
                return Enumerable.Empty<int>();
            }
        }

        return targetNode.GetSubtree()
            .SelectMany(node => node.Indexes)
            .Distinct();
    }
}
