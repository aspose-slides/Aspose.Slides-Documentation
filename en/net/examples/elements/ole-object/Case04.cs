using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        var oleFrame = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        var newData = File.ReadAllBytes(Context.Input("Picture.png"));
        var newDataInfo = new OleEmbeddedDataInfo(newData, "png");
        oleFrame.SetEmbeddedData(newDataInfo);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IOleObjectFrame>().Single().EmbeddedData.EmbeddedFileData.SequenceEqual(File.ReadAllBytes(Context.Input("Picture.png"))), "UpdateOleObjectData: semantic check 1 failed.");
        });
        Context.Pass("elements/ole-object/block-004", "UpdateOleObjectData", "save-reopen-structure");
    }
}
