using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);

    private static void ImportPdf(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("input.pdf", new int[] { 1, 3 }, SaveFormat.Pdf, new PdfOptions());
        using var imported = new Presentation();
        imported.Slides.RemoveAt(0);
        imported.Slides.AddFromPdf("input.pdf");
        imported.Save("imported.pptx", SaveFormat.Pptx);
        if (imported.Slides.Count != 2) throw new InvalidOperationException("PDF page count was not preserved.");
        for (int i = 0; i < imported.Slides.Count; i++)
        {
            using var image = imported.Slides[i].GetImage(new Size(640, 360));
            image.Save($"imported-{i + 1}.png", Aspose.Slides.ImageFormat.Png);
        }
        Report(new { imported_slides = imported.Slides.Count, editable_text_shapes = imported.Slides.Sum(s => s.Shapes.OfType<IAutoShape>().Count(sh => sh.TextFrame != null)) });
    }
}
