using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AbyssalBlessings.Content.Projectiles.Pets;

public class Siren : ModProjectile
{
    public override void SetStaticDefaults() {
        Main.projPet[Type] = true;

        ProjectileID.Sets.LightPet[Type] = true;
    }

    public override void SetDefaults() {
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.friendly = true;

        Projectile.width = 30;
        Projectile.height = 30;

        Projectile.penetrate = -1;
    }

    public override void AI() {
        Projectile.alpha = (int)MathHelper.Clamp(Projectile.alpha, 0, 255);

        Projectile.rotation = Projectile.velocity.X * 0.1f;
        
        FadeIn();
        
        if (!Projectile.TryGetOwner(out var owner) || !owner.HasBuff<Buffs.Siren>()) {
            FadeOut();
            return;
        }

        Projectile.timeLeft = 2;

        UpdateMovement(owner);
    }

    private void FadeIn() {
        if (Projectile.alpha <= 0) {
            return;
        }

        Projectile.alpha -= 5;
    }

    private void FadeOut() {
        Projectile.alpha += 5;

        if (Projectile.alpha < 255) {
            return;
        }

        Projectile.Kill();
    }

    private void UpdateMovement(Player owner) {
        var center = owner.Center - new Vector2(0f, 8f * 16f);
        var distance = Vector2.DistanceSquared(Projectile.Center, center);

        var addon = Vector2.Zero;
        var boost = 4f * 16f;

        if (owner.controlLeft) {
            addon.X -= boost;
        }

        if (owner.controlRight) {
            addon.X += boost;
        }

        if (owner.controlUp) {
            addon.Y -= boost;
        }

        if (owner.controlDown) {
            addon.Y += boost * 2;
        }
    }
}
