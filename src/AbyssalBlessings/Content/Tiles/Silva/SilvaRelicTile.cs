using AbyssalBlessings.Content.Items.Silva;
using CalamityMod.Tiles.BaseTiles;

namespace AbyssalBlessings.Content.Tiles.Silva;

public class SilvaRelicTile : BaseBossRelic
{
    public override string RelicTextureName => Texture;

    public override int AssociatedItem => ModContent.ItemType<SilvaRelicItem>();

    public override void NumDust(int i, int j, bool fail, ref int num) {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}
