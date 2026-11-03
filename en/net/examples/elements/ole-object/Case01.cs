using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var pdfData = File.ReadAllBytes(Context.Input("doc.pdf"));
        var dataInfo = new OleEmbeddedDataInfo(pdfData, "pdf");
        slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);

        VerifyCase01(presentation);
    }
}
