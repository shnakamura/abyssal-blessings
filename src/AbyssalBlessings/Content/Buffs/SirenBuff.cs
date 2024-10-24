namespace AbyssalBlessings.Content.Buffs;

public class SirenBuff : ModBuff
{
    public override void SetStaticDefaults() {
        base.SetStaticDefaults();

        Main.lightPet[Type] = true;
        Main.buffNoTimeDisplay[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex) {
        base.Update(player, ref buffIndex);

        var unused = false;

        player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<Projectiles.Pets.SirenProjectile>());
    }
}