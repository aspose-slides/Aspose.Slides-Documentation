using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using Aspose.Slides;
using System.IO;
using System.Linq;
using System;

internal static partial class Program
{
    private static void VerifyCase01(Presentation presentation)
    {
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().Any(), "AccessInk: semantic check 1 failed.");
            Context.Require(p.Slides[0].Shapes.OfType<Ink>().First().CustomData.Tags.Count > 0, "AccessInk: semantic check 2 failed.");
        });
        Context.Pass("elements/ink/block-001", "AccessInk", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<Ink>().Any(), "RemoveInk: semantic check 1 failed.");
        });
        Context.Pass("elements/ink/block-002", "RemoveInk", "save-reopen-structure");
    }
}
