using System.IO;
using AbyssalBlessings.Common.Players;

namespace AbyssalBlessings;

public sealed class AbyssalBlessings : Mod
{
    public const byte SyncEidolicHeart = 0;

    public override void HandlePacket(BinaryReader reader, int whoAmI) {
        var id = reader.ReadByte();

        switch (id) {
            case SyncEidolicHeart:
                var index = reader.ReadByte();
                var amount = reader.ReadByte();

                var player = Main.player[index];

                if (!player.TryGetModPlayer(out PlayerEidolicHearts modPlayer)) {
                    return;
                }

                modPlayer.EidolicHeartsConsumed = amount;

                if (Main.netMode != NetmodeID.Server) {
                    return;
                }

                modPlayer.SyncPlayer(-1, whoAmI, false);

                break;
        }
    }
}
