using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.Json;

internal static partial class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> RunChecked(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        Example.Context = ctx;
        ctx.BeginAction("optimization-batch/warnings/block-001");
        CollectWarnings();
        string path = File.Exists("output/result.json") ? "output/result.json" : "result.json";
        using var result = JsonDocument.Parse(File.ReadAllText(path));
        var checks = new System.Collections.Generic.Dictionary<string, bool>();
        if (ctx.IsLicensed)
        {
            using var expected = JsonDocument.Parse("{\"checks.font_warning_observed\":true,\"checks.warning_export_completed\":true,\"checks.corrupt_input_failed\":true,\"checks.error_not_reported_as_success\":true}");
            foreach (var field in expected.RootElement.EnumerateObject())
            {
                var actual = result.RootElement;
                foreach (string part in field.Name.Split('.'))
                    actual = actual.GetProperty(part);
                ctx.Require(actual.ToString() == field.Value.ToString(), "Licensed assertion differs: " + field.Name);
                checks["licensed-" + field.Name.Replace('.', '-')] = true;
            }
        }
        else
        {
            var values = result.RootElement.TryGetProperty("checks", out var nested) ? nested : result.RootElement;
            foreach (var field in values.EnumerateObject())
                if (field.Value.ValueKind == JsonValueKind.False)
                    throw new InvalidOperationException("Evaluation assertion failed: " + field.Name);
            checks["evaluation-semantic-effect"] = true;
            checks["evaluation-valid-output"] = true;
        }

        foreach (string pdf in Directory.GetFiles(".", "*.pdf", SearchOption.AllDirectories))
            ctx.Require(File.ReadAllBytes(pdf).AsSpan(0, 5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")), "Invalid PDF output.");
        foreach (string png in Directory.GetFiles(".", "*.png", SearchOption.AllDirectories))
        {
            var image = PortableImage.Decode(File.ReadAllBytes(png));
            ctx.Require(image.Width > 0 && image.Height > 0, "Empty PNG output.");
        }

        ctx.Pass("optimization-batch/warnings/block-001", checks);
        await Task.CompletedTask;
    });
}
