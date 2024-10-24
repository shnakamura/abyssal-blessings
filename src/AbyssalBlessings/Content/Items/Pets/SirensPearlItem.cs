using AbyssalBlessings.Content.Buffs;

namespace AbyssalBlessings.Content.Items.Pets;

public class SirensPearlItem : ModItem
{
    public override void SetDefaults() {
        Item.noUseGraphic = true;
        Item.useTurn = true;

        Item.width = 22;
        Item.height = 24;

        Item.useTime = 15;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.HoldUp;

        Item.buffType = ModContent.BuffType<SirenBuff>();
        Item.shoot = ModContent.ProjectileType<Projectiles.Pets.SirenProjectile>();
    }

    public override bool? UseItem(Player player) {
        if (player.whoAmI == Main.myPlayer) {
            player.AddBuff(Item.buffType, 3600);
        }

        return true;
    }
}
