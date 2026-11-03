using System.Threading.Tasks;
using System.IO;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ExportSvg(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        using (var stream = File.Create("slide.svg"))
        {
            var selectedSlide = source.Slides[0];
            selectedSlide.WriteAsSvg(stream);
        }

        Report(new { svg_created = File.Exists("slide.svg"), source_slide = 1 });
    }
}
