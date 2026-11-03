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

    private static void ExportPdf(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("visible.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = false });
        source.Save("all-slides.pdf", SaveFormat.Pdf, new PdfOptions { ShowHiddenSlides = true });
        source.Save("selected.pdf", new int[] { 3, 1 }, SaveFormat.Pdf, new PdfOptions());
        source.Save("quality-high.pdf", SaveFormat.Pdf, new PdfOptions { JpegQuality = 95, SufficientResolution = 300 });
        source.Save("quality-small.pdf", SaveFormat.Pdf, new PdfOptions { JpegQuality = 35, SufficientResolution = 72 });
        Report(new { visible_slides = source.Slides.Count(s => !s.Hidden), all_slides = source.Slides.Count, selected_order = licensed ? "Charlie,Alpha" : "C,Alpha" });
    }
}
