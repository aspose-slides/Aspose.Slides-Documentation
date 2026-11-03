using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static partial class Program
{
    private static Task<int> Main(string[] args) => RunChecked(args);
    private sealed record ExportWarning(string type, string description);
    private sealed class ExportWarnings : IWarningCallback
    {
        public List<ExportWarning> Items { get; } = new();

        public ReturnAction Warning(IWarningInfo warning)
        {
            Items.Add(new ExportWarning(warning.WarningType.ToString(), warning.Description));
            return ReturnAction.Continue;
        }
    }

    private static void CollectWarnings()
    {
        Example.Setup();
        using (var p = new Presentation())
        {
            var shape = Example.Text(p.Slides[0].Shapes, "Text", "Font substitution warning fixture");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Example_Missing_Font_734991");
            p.Save("output/input.pptx", SaveFormat.Pptx);
        }

        var warnings = new ExportWarnings();
        using (var p = new Presentation("output/input.pptx"))
        {
            p.Save("output/with-warning.pdf", SaveFormat.Pdf, new PdfOptions { WarningCallback = warnings });
        }

        File.WriteAllBytes("output/corrupt.pptx", new byte[] { 0x50, 0x4b, 3, 4, 0, 0, 0 });
        string? error = null;
        try
        {
            using var failed = new Presentation("output/corrupt.pptx", new LoadOptions { LoadFormat = LoadFormat.Pptx });
            failed.Save("output/should-not-exist.pdf", SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            error = ex.GetType().Name + ": " + ex.Message;
        }
        finally
        {
            if (File.Exists("output/should-not-exist.pdf"))
                File.Delete("output/should-not-exist.pdf");
        }

        Example.Require(warnings.Items.Count > 0, "Missing-font warning was not observed.");
        Example.Require(error != null && !File.Exists("output/should-not-exist.pdf"), "Failed conversion reported success.");
        Example.Json("output/report.json", new { successful_export_with_warnings = new { success = true, warnings = warnings.Items }, failed_export = new { success = false, error } });
        Example.Result(new { font_warning_observed = true, warning_export_completed = true, corrupt_input_failed = true, error_not_reported_as_success = true });
    }
}
