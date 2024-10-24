using System.Collections.Generic;
using System.Linq;
using AbyssalBlessings.Content.Items.Vanity;

namespace AbyssalBlessings.Common.Players;

public sealed class PlayerSpawnInventory : ModPlayer
{
    public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath) {
        var name = Player.name.ToLower();

        if (name != "neoxzenith" && name != "everest") {
            return Enumerable.Empty<Item>();
        }

        return [new Item(ModContent.ItemType<MagicalIceStoneItem>())];
    }
}
