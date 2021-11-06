using System;
using WorldEditHelper.Items;

namespace WorldEditHelper.Commands
{
    public readonly struct ItemPercentage
    {
        public MineItem Item { get; }
        public int Percentage { get; }

        public ItemPercentage(MineItem item, int percentage)
        {
            if (percentage is < 0 or > 100) 
                throw new ArgumentOutOfRangeException(nameof(Percentage), "Percentage must be between 0 and 100");

            Item = item;
            Percentage = percentage;
        }
    }
}
