using AbyssalBlessings.Content.Tiles.Silva;

namespace AbyssalBlessings.Content.Items.Silva;

public class SilvaTrophyItem : ModItem
{
    public override void SetDefaults() {
        Item.DefaultToPlaceableTile(ModContent.TileType<SilvaTrophyTile>());

        Item.width = 32;
        Item.height = 32;

        Item.value = Item.buyPrice(gold: 1);
    }
}
