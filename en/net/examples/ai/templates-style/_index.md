---
title: "Generate with a Template or Existing Style"
type: docs
weight: 30
url: /net/examples/ai/templates-style/
description: "Runnable C# example to generate with a template or existing style, with a complete project, real model calls and editable PowerPoint output."
---

Compare generation from a reusable POTX template and from an existing PPTX style source. Both original designs are created visibly in code, passed through freshly loaded instances, and kept on disk for reuse.

## Prerequisites and input

Use a current supported .NET10 SDK/runtime and the supplied flexible SDK settings; no exact patch is required.

The example uses only synthetic prompts and creates its input presentation where needed. Generation and translation contact the selected model service.
## Complete C# example

The code below shows the main operation. The runnable download includes [ExampleSupport.cs](ExampleSupport.cs) with the entry point and supporting code.

```csharp
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
```

## Run and inspect the result

```text
dotnet run --project Example.csproj --configuration Release
```

The program writes "template.potx", "style-source.pptx", "template-generated.pptx", "template-generated.png", "existing-style-generated.pptx", "existing-style-generated.png" and a result.json summary in the current directory. Open the PPTX files to edit their text and review the PNG previews at normal size. The source and the generated output are kept separate. Wording varies between model responses; successful execution checks structure and saved text, not a byte-identical deck.

## Limitations

The theme, fonts, masters and available layouts supply a design starting point. Generation may modify the in-memory template instance, so load a fresh copy per request. Design reuse does not promise an exact visual replica or fixed text positioning.

Continue with the [detailed guide](/slides/net/ai/generator/).


## Download, prerequisites and run

[Download the complete project](example.zip) and open `Example.sln`. The stable
net8.0/C#12 project accepts compatible installed release SDKs and explicitly runs
on the current .NET10 runtime. No exact SDK patch or locked restore is required.
Bundled Noto Sans fonts include their redistribution notice. See
[setup and supported environments](/slides/net/examples/getting-started/).

The bootstrap prints the separate output workspace. Explicit `--mode evaluation`
ignores all license settings; `--mode licensed` accepts your authorized license
through `--license PATH` or ASPOSE_LICENSE_PATH. No license or credential is included.

Default evaluation performs no model request and reports the missing prerequisite
with exit2. To execute the real generation/translation, opt in explicitly:

```text
dotnet run --project Example.csproj -- --mode licensed --allow-network
```

Configured providers also need their endpoint, real model identifier and API key.
A prerequisite diagnostic never counts as a generated or translated presentation.
