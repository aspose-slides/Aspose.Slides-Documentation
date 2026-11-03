using System.Threading.Tasks;
using System;
using System.IO;
using System.Linq;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void ExportXps(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("slides.xps", SaveFormat.Xps);
        Report(new { xps_created = File.Exists("slides.xps"), expected_visible_pages = source.Slides.Count(s => !s.Hidden) });
    }
}
