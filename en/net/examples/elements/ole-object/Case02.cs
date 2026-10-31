using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        var firstOleFrame = slide.Shapes.OfType<IOleObjectFrame>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileExtension.TrimStart('.') == "pdf", "AccessOleObject: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-002", "AccessOleObject", "save-reopen-structure");
    }
}
