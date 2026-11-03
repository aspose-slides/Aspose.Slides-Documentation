using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
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
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().Layout == SmartArtLayoutType.BasicProcess, "AddSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-001", "AddSmartArt", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().AllNodes.Count > 0, "AccessSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-002", "AccessSmartArt", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<ISmartArt>().Any(), "RemoveSmartArt: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-003", "RemoveSmartArt", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<ISmartArt>().Single().Layout == SmartArtLayoutType.VerticalPictureList, "ChangeSmartArtLayout: semantic check 1 failed.");
        });
        Context.Pass("elements/smart-art/block-004", "ChangeSmartArtLayout", "save-reopen-structure");
    }
}
