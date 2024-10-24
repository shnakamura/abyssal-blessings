namespace AbyssalBlessings.Content.Items.Abyss;

public class XerocsKeyItem : ModItem
{
    public override void SetDefaults() {
        Item.consumable = true;
        Item.maxStack = 1;

        Item.width = 38;
        Item.height = 46;

        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;
    }
}
