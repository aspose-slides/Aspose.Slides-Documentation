using System.Threading.Tasks;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private static void SaveProtectedPdf()
    {
        using (var original = new Presentation())
        {
            Label(original.Slides[0], "Protected PDF example");
            original.Save("original.pptx", SaveFormat.Pptx);
        }

        string originalHash = Hash("original.pptx");
        using (var presentation = new Presentation("original.pptx"))
        {
            var options = new PdfOptions
            {
                Password = "reader-demo",
                AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
            };
            presentation.Save("protected.pdf", SaveFormat.Pdf, options);
        }

        Require(new FileInfo("protected.pdf").Length > 100, "PDF export is empty.");
        Require(Hash("original.pptx") == originalHash, "Original changed.");
        Report(new { exported = true, original_unchanged = true });
    }
}
