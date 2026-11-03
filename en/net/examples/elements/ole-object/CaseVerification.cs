using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;
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
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("doc.pdf"))), "AddOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-001", "AddOleObject", "save-reopen-structure");
    }

    private static void VerifyCase02(Presentation presentation)
    {
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileExtension.TrimStart('.') == "pdf", "AccessOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-002", "AccessOleObject", "save-reopen-structure");
    }

    private static void VerifyCase03(Presentation presentation)
    {
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IOleObjectFrame>().Any(), "RemoveOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-003", "RemoveOleObject", "save-reopen-structure");
    }

    private static void VerifyCase04(Presentation presentation)
    {
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "UpdateOleObjectData: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-004", "UpdateOleObjectData", "save-reopen-structure");
    }
}
