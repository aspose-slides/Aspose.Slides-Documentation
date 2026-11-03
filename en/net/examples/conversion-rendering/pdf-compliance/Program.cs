using System.Threading.Tasks;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ExportComplianceProfiles(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.DocumentProperties.Title = "Accessible sample";
        source.DocumentProperties.Author = "Example author";
        foreach (var slide in source.Slides)
            foreach (var shape in slide.Shapes)
            {
                if (shape is IChart)
                    shape.AlternativeText = "Example column chart comparing three series across three categories.";
                if (shape is IPictureFrame)
                    shape.AlternativeText = "Blue rectangle with a white ellipse.";
            }

        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("archive.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfA2b });
        source.Save("tagged.pdf", SaveFormat.Pdf, new PdfOptions { Compliance = PdfCompliance.PdfUa });
        Report(new { archival_output = File.Exists("archive.pdf"), tagged_output = File.Exists("tagged.pdf") });
    }
}
