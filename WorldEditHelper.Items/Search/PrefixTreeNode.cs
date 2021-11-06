using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldEditHelper.Items.Search
{
    internal readonly struct PrefixTreeNode
    {
        public Dictionary<char, PrefixTreeNode> Children { get; }

        public HashSet<int> Indexes { get; }

        public PrefixTreeNode(
            Dictionary<char, PrefixTreeNode> children, 
            IEnumerable<int> indexes)
        {
            Children = children;
            Indexes = indexes?.ToHashSet() ?? new HashSet<int>();
        }

        public void AddWord(LinkedList<char> chars, IEnumerable<int> indexes)
        {
            if (chars.Count == 0)
                throw new ArgumentException("Word is empty", nameof(chars));

            if (indexes == null) indexes = Array.Empty<int>();

            var first = chars.First.Value;
            chars.RemoveFirst();

            PrefixTreeNode childNode;

            if (Children.ContainsKey(first))
                childNode = Children[first];
            else
            {
                childNode = new PrefixTreeNode(new(), null);
                Children[first] = childNode;
            }

            if (chars.Count == 0)
            {
                childNode.Indexes.UnionWith(indexes);
            }
            else
            {
                childNode.AddWord(chars, indexes);
            }
        }

        public IEnumerable<PrefixTreeNode> GetSubtree()
        {
            return GetSubtreeRecursive();
        }

        private IEnumerable<PrefixTreeNode> GetSubtreeRecursive()
        {
            return Children
                .Select(kv => kv.Value)
                .SelectMany(child => child.GetSubtreeRecursive())
                .Prepend(this);
        }
    }
}
