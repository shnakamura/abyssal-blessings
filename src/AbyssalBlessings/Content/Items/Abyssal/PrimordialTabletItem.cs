using AbyssalBlessings.Content.Rarities;

namespace AbyssalBlessings.Content.Items.Abyss;

public class PrimordialTabletItem : ModItem
{
    public override void SetDefaults() {
        base.SetDefaults();

        Item.maxStack = Item.CommonMaxStack;

        Item.width = 66;
        Item.height = 56;

        Item.rare = ModContent.RarityType<Abyssal>();
    }
}
