using AbyssalBlessings.Content.Items.Vanity;
using CalamityMod;

namespace AbyssalBlessings.Common.NPCs;

public sealed class ZoologistGlobalNPC : GlobalNPC
{
    public override bool AppliesToEntity(NPC entity, bool lateInstantiation) {
        return entity.type == NPCID.BestiaryGirl;
    }

    public override void ModifyShop(NPCShop shop) {
        base.ModifyShop(shop);

        shop.AddWithCustomValue<MagicalIceStoneItem>(Item.buyPrice(1));
    }
}
