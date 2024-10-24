using Terraria.DataStructures;

namespace AbyssalBlessings.Content.Items.Vanity;

public sealed class MagicalIceStonePlayer : ModPlayer
{
    public bool Enabled { get; set; }

    public override void ResetEffects() {
        base.ResetEffects();

        Enabled = false;
    }

    public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo) {
        base.ModifyDrawInfo(ref drawInfo);

        if (!Enabled) {
            return;
        }

        var item = ModContent.GetInstance<MagicalIceStoneItem>();

        Player.head = EquipLoader.GetEquipSlot(Mod, item.Name, EquipType.Head);
        Player.body = EquipLoader.GetEquipSlot(Mod, item.Name, EquipType.Body);
        Player.legs = EquipLoader.GetEquipSlot(Mod, item.Name, EquipType.Legs);
    }
}