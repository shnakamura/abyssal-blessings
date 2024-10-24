namespace AbyssalBlessings.Content.NPCs.Silva;

[AutoloadBossHead]
public sealed class SilvaNPC : ModNPC
{
    public override void SetDefaults() {
        NPC.noTileCollide = true;
        NPC.lavaImmune = true;
        NPC.noGravity = true;
        NPC.boss = true;

        NPC.lifeMax = 50000;
        NPC.defense = 50;

        NPC.width = 30;
        NPC.height = 50;

        NPC.knockBackResist = 0f;

        Music = MusicLoader.GetMusicSlot(Mod, "Assets/Sounds/Music/Silva");
        SceneEffectPriority = SceneEffectPriority.BossHigh;
    }
}
