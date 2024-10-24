using Terraria.DataStructures;

namespace AbyssalBlessings.Content.Items.Vanity;

public class MagicalIceStoneItem : ModItem
{
    public override void Load() {
        base.Load();

        if (Main.netMode == NetmodeID.Server) {
            return;
        }

        EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Head}", EquipType.Head, this);
        EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Body}", EquipType.Body, this);
        EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
    }

    public override void SetStaticDefaults() {
        base.SetStaticDefaults();

        var equipSlotHead = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Head);
        var equipSlotBody = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Body);
        var equipSlotLegs = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);

        ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
        ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
        ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
        ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLegs] = true;
    }

    public override void SetDefaults() {
        Item.accessory = true;
        Item.vanity = true;

        Item.width = 34;
        Item.height = 42;
    }

    public override void UpdateAccessory(Player player, bool hideVisual) {
        if (!player.TryGetModPlayer(out MagicalIceStonePlayer modPlayer)) {
            return;
        }

        modPlayer.Enabled = true;
    }
}
