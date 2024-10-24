using AbyssalBlessings.Content.Tiles.Silva;

namespace AbyssalBlessings.Content.Items.Silva;

public class SilvaRelicItem : ModItem
{
    public override void SetDefaults() {
        base.SetDefaults();

        Item.DefaultToPlaceableTile(ModContent.TileType<SilvaRelicTile>());

        Item.master = true;

        Item.width = 30;
        Item.height = 50;

        Item.rare = ItemRarityID.Master;
        Item.value = Item.buyPrice(gold: 5);
    }
}
