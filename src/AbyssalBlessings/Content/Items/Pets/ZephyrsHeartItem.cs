using AbyssalBlessings.Content.Buffs;

namespace AbyssalBlessings.Content.Items.Pets;

public class ZephyrsHeartItem : ModItem
{
    public override void SetDefaults() {
        Item.noUseGraphic = true;
        Item.useTurn = true;

        Item.width = 30;
        Item.height = 32;

        Item.useTime = 15;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;

        Item.buffType = ModContent.BuffType<ZephyrSquidBuff>();
        Item.shoot = ModContent.ProjectileType<Projectiles.Pets.ZephyrSquidProjectile>();
    }

    public override bool? UseItem(Player player) {
        if (player.whoAmI == Main.myPlayer) {
            player.AddBuff(Item.buffType, 3600);
        }

        return true;
    }
}
