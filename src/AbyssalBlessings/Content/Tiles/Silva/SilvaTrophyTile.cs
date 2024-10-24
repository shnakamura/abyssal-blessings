using Terraria.Localization;
using Terraria.ObjectData;

namespace AbyssalBlessings.Content.Tiles.Silva;

public class SilvaTrophyTile : ModTile
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();

        Main.tileFrameImportant[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileSpelunker[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
        TileObjectData.addTile(Type);

        TileID.Sets.DisableSmartCursor[Type] = true;
        TileID.Sets.FramesOnKillWall[Type] = true;

        AddMapEntry(new Color(120, 85, 60), Language.GetText("MapObject.Trophy"));

        DustType = DustID.WoodFurniture;
    }

    public override void NumDust(int i, int j, bool fail, ref int num) {
        base.NumDust(i, j, fail, ref num);

        num = fail ? 1 : 3;
    }
}
