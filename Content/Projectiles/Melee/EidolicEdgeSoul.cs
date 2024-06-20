using AbyssalBlessings.Common.Graphics;
using AbyssalBlessings.Common.Projectiles.Components;
using AbyssalBlessings.Content.Projectiles.Typeless;
using CalamityMod;
using CalamityMod.Buffs.DamageOverTime;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Particles;
using CalamityMod.Projectiles.Melee;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AbyssalBlessings.Content.Projectiles.Melee;

public class EidolicEdgeSoul : ModProjectile
{
    /// <summary>
    ///     The projectile's lifespan duration.
    /// </summary>
    /// <remarks>This is what <see cref="Projectile"/>.<see cref="Projectile.timeLeft"/> is initially set to.</remarks>
    public const int Lifespan = 600;

    /// <summary>
    ///     The projectile's charge duration in tick units.
    /// </summary>
    public const int Charge = 20;
    
    /// <summary>
    ///     The projectile's minimum distance in pixel units required for attacking.
    /// </summary>
    public const float Distance = 32f * 16f;

    /// <summary>
    ///     The projectile's speed modifier assigned by the item.
    /// </summary>
    public ref float SpeedModifier => ref Projectile.ai[0];

    /// <summary>
    ///     The projectile's inertia modifier assigned by the item.
    /// </summary>
    public ref float InertiaModifier => ref Projectile.ai[1];

    public override void SetDefaults() {
        Projectile.DamageType = DamageClass.Melee;

        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.friendly = true;
        
        Projectile.width = 20;
        Projectile.height = 20;

        Projectile.alpha = 255;
        Projectile.timeLeft = Lifespan;
        
        Projectile.penetrate = 1;
        Projectile.extraUpdates = 1;
        
        Projectile.TryEnableComponent<ProjectileFadeRenderer>();
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
        target.AddBuff(ModContent.BuffType<CrushDepth>(), 3 * 60);
    }

    public override void OnHitPlayer(Player target, Player.HurtInfo info) {
        target.AddBuff(ModContent.BuffType<CrushDepth>(), 3 * 60);
    }
    
    public override void AI() {
        Projectile.rotation += Projectile.velocity.X * 0.05f;

        if (!Projectile.TryGetOwner(out var player)) {
            UpdateDeath();
            return;
        }
        
        UpdateMovement(player);
    }   

    private void UpdateDeath() {
        if (Projectile.TryGetGlobalProjectile(out ProjectileFadeRenderer component)) {
            component.FadeOut(true);
        }
        else {
            Projectile.Kill();
        }

        Projectile.velocity *= 0.9f;
    }

    private void UpdateMovement(Player player) {
        if (InertiaModifier > 0f) {
            InertiaModifier -= 0.01f;
        }
        
        var speed = 12f * SpeedModifier;
        var inertia = MathHelper.Lerp(20f, 80f, InertiaModifier) * SpeedModifier;
        
        var target = Projectile.FindTargetWithinRange(Distance);

        if (Projectile.timeLeft > Lifespan - Charge || Projectile.DistanceSQ(player.Center) > Distance * Distance) {
            var direction = Projectile.DirectionTo(player.Center);
                
            Projectile.velocity = (Projectile.velocity * (inertia - 1f) + direction * speed) / inertia;
        }
        else if (target != null) {
            CalamityUtils.HomeInOnNPC(Projectile, !Projectile.tileCollide, Distance, speed, inertia);
        }
    }
}