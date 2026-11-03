using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.AI;
using Aspose.Slides.Export;

internal static partial class Program
{
    private const string Prompt = "Create a short English presentation about the water cycle. Cover evaporation, condensation and precipitation. Use ordinary text slides with a title and a short paragraph. No charts, tables or images. For every section in the JSON, use the integer 0 for its type field instead of a type name. Return raw JSON without Markdown code fences or commentary.";

    private static async Task<int> RunExample()
    {
        try
        {
            int completed = 0;
            foreach (string kind in new[] { "template", "existing-style" })
            {
                string sourcePath = kind == "template" ? "template.potx" : "style-source.pptx";
                Color accent = kind == "template" ? Color.FromArgb(12, 110, 120) : Color.FromArgb(106, 43, 130);
                using (var design = new Presentation())
                {
                    design.MasterTheme.ColorScheme.Accent1.Color = accent;
                    design.MasterTheme.FontScheme.Major.LatinFont = new FontData("Noto Sans");
                    design.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Noto Sans");
                    design.Masters[0].Background.Type = BackgroundType.OwnBackground;
                    design.Masters[0].Background.FillFormat.FillType = FillType.Solid;
                    design.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(240, 246, 248);
                    if (kind == "existing-style")
                    {
                        var titleLayout = design.LayoutSlides.GetByType(SlideLayoutType.Title);
                        design.Slides.AddEmptySlide(titleLayout);
                        design.Slides.RemoveAt(0);
                        foreach (var placeholder in design.Slides[0].Shapes.OfType<IAutoShape>())
                            if (placeholder.Placeholder != null && placeholder.TextFrame != null) placeholder.TextFrame.Text = "Existing report design";
                    }
                    design.Save(sourcePath, kind == "template" ? SaveFormat.Potx : SaveFormat.Pptx);
                }
                byte[] sourceHash = System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(sourcePath));
                using var template = new Presentation(sourcePath);
                using var http = Http(kind);
                using var client = new AsposeAIWebClient(http);
                using IPresentation generated = await new SlidesAIAgent(client).GeneratePresentationAsync(Prompt, PresentationContentAmountType.Brief, template);
                VerifyGenerated(generated, kind + "-generated.pptx");
                Require(generated.MasterTheme.ColorScheme.Accent1.Color.ToArgb() == accent.ToArgb(), "Expected source theme color.");
                Require(generated.MasterTheme.FontScheme.Major.LatinFont.FontName == "Noto Sans", "Expected source font scheme.");
                Require(sourceHash.SequenceEqual(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(sourcePath))), "Design source changed.");
                using var retainedSource = new Presentation(sourcePath);
                Require(retainedSource.Slides.Count == 1, "Stored design source gained generated slides.");
                completed++;
            }
            Require(Requests.Count(r => r.StatusCode == 200) >= 2, "Both design paths need actual model responses.");
            Report(new { designs_checked = completed, theme_and_font_retained = true, source_files_unchanged = true, requests = Requests.ToArray() });
            return 0;
        }
        catch (Exception error)
        {
            int exit = error is OperationCanceledException ? 4 : error is HttpRequestException ? 3 : 2;
            File.WriteAllText("error.json", JsonSerializer.Serialize(new { error_type = error.GetType().Name, requests = Requests.ToArray(), exit_code = exit }));
            Console.Error.WriteLine("AI example failed: " + error.GetType().Name + ". Check configuration and provider access.");
            return exit;
        }
    }
}
