using CalamityMod.Items.LoreItems;

namespace AbyssalBlessings.Content.Items.Silva;

public class SilvaLoreItem : LoreItem, ILocalizedModType
{
    string ILocalizedModType.LocalizationCategory { get; } = "Items";

    public override void SetDefaults() {
        base.SetDefaults();

        Item.width = 22;
        Item.height = 22;
    }
}
