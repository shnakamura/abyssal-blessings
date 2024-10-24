namespace AbyssalBlessings.Content.Buffs;

public class ZephyrSquidBuff : ModBuff
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();

        Main.vanityPet[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        base.Update(player, ref buffIndex);

        var unused = false;

        player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<Projectiles.Pets.ZephyrSquidProjectile>());
    }
}
