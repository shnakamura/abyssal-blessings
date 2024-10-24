using AbyssalBlessings.Content.Rarities;
using CalamityMod.Items.Weapons.Ranged;

namespace AbyssalBlessings.Common.Items;

public sealed class HalibutCannonGlobalItem : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
        return entity.type == ModContent.ItemType<HalibutCannon>();
    }

    public override void SetDefaults(Item entity) {
        base.SetDefaults(entity);

        entity.rare = ModContent.RarityType<Abyssal>();
    }
}
