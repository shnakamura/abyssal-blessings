using CalamityMod.Items.LoreItems;

namespace AbyssalBlessings.Content.Items.Abyss;

public class PrimordialWyrmLoreItem : LoreItem, ILocalizedModType
{
    string ILocalizedModType.LocalizationCategory { get; } = "Items";

    public override void SetDefaults() {
        base.SetDefaults();

        Item.width = 26;
        Item.height = 26;
    }
}
