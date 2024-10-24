using AbyssalBlessings.Core.IO;
using ReLogic.Content.Sources;

namespace AbyssalBlessings;

public sealed class AbyssalBlessings : Mod
{
    public override IContentSource CreateDefaultContentSource() {
        var source = new RedirectContentSource(base.CreateDefaultContentSource());

        source.AddRedirect("Content", "Assets/Textures");

        return source;
    }
}
