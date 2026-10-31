using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("doc.pdf"))), "AddOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-001", "AddOleObject", "save-reopen-structure");
    }
}
