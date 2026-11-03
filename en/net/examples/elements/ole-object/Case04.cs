using System.IO;
using Aspose.Slides;
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

        // Replace the PDF payload with a small PNG.
        var pngData = File.ReadAllBytes(Context.Input("Picture.png"));
        var newDataInfo = new OleEmbeddedDataInfo(pngData, "png");
        oleFrame.SetEmbeddedData(newDataInfo);

        VerifyCase04(presentation);
    }
}
