---
title: "Export Presentations to HTML"
type: docs
weight: 40
url: /net/examples/conversion-rendering/html/
description: "Runnable C# example for export presentations to html using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Classic HTML uses SVG-based slide output and can scale to its container. HTML5 has presentation navigation and supported shape/transition animation. Serve the generated HTML together with its supporting asset folders; the example keeps HTML5 images and styles external. The HTML5 copy contains only visible slides so its navigation matches the exported deck. Click its first slide to play the title fade; each visible slide has a title effect and fade transition. In this SDK, generated navigation can remain disabled after a slide without animations, so verify mixed animated/static decks before hosting them. Generated HTML5 also references public JavaScript CDNs; offline hosting must provide those dependencies. The export flags do not add effects to a deck without them.

## Run the example

[Download the complete project](example.zip). It includes the solution, source, SDK settings, package configuration and required fixtures. The code creates its own four-slide input with a hidden slide, speaker notes, a table, chart and picture.

This download uses Aspose.Slides.NET6.CrossPlatform 26.10.0, bundled Noto Sans fonts and original portable PNG fixtures. Open the supplied solution with a compatible stable SDK; the current .NET 10 LTS is recommended. Evaluation runs without a license; unrestricted assertions use your authorized license. See [setup and prerequisites](/slides/net/examples/getting-started/) for native dependencies and tool selection.

```text
dotnet run --project Example.csproj --configuration Release
```

## Complete C# example

```csharp
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

    private static void ExportHtml(bool licensed)
    {
        using var source = CreateSource(licensed);
        source.Save("source.pptx", SaveFormat.Pptx);
        source.Save("classic.html", SaveFormat.Html, new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new ResponsiveHtmlController()) });
        using var web = new Presentation("source.pptx");
        for (int i = web.Slides.Count - 1; i >= 0; i--)
            if (web.Slides[i].Hidden) web.Slides.RemoveAt(i);
        web.Slides[0].Timeline.MainSequence[0].Timing.TriggerType = EffectTriggerType.OnClick;
        foreach (var slide in web.Slides)
        {
            slide.SlideShowTransition.Type = TransitionType.Fade;
            if (slide.Timeline.MainSequence.Count == 0)
                slide.Timeline.MainSequence.AddEffect(slide.Shapes.OfType<IAutoShape>().Single(s => s.Name == "RecipeTitle"), EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
        }
        web.Save("slides.html", SaveFormat.Html5, new Html5Options { AnimateShapes = true, AnimateTransitions = true, EmbedImages = false });
        Report(new { classic_html = File.Exists("classic.html"), html5 = File.Exists("slides.html"), asset_files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories).Length });
    }
}
```

## Expected result

The program writes "classic.html", "slides.html" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-html/).


## Open and run the complete project

[Download the complete project](example.zip), extract it and open `Example.sln`, or run:

```text
dotnet restore Example.sln
dotnet run --project Example.csproj --configuration Release -- --mode evaluation
```

Use the current supported .NET 10 SDK/runtime. The project keeps a stable `net8.0`
target and accepts compatible stable SDKs; no exact SDK patch is required.
Evaluation runs without a license and explicitly ignores license environment settings.
It uses bounded fixtures and checks valid output while allowing the evaluation watermark
and documented read-back text truncation. For unrestricted checks, use `--mode licensed`
with your authorized `ASPOSE_LICENSE_PATH`. No license is included.

Inputs are copied from `Fixtures` into a separate output workspace. The program prints
the absolute output path; `execution.json` records the actual runtime and verified action.
The portable PNG helper creates original synthetic pixels without a Windows bitmap engine.
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
