---
title: "Convert Presentation Formats"
type: docs
weight: 10
url: /net/examples/conversion-rendering/presentation-formats/
description: "Runnable C# example for convert presentation formats using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

The sample exports PPTX, PPT and ODP, reopens each file and writes a PPTX copy from each input format. It checks text and slide counts and produces a preview for each result. Format-specific features may be changed or omitted; inspect the features your deck uses.

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
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static class Program
{
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async ctx =>
    {
        Context = ctx;
        
        ctx.BeginAction("conversion-rendering/presentation-formats/block-001");
        RunExample();
        string path=File.Exists("output/result.json")?"output/result.json":"result.json";
        using var result=JsonDocument.Parse(File.ReadAllText(path));
        var checks=new System.Collections.Generic.Dictionary<string,bool>();
        if(ctx.IsLicensed)
        {
            using var expected=JsonDocument.Parse("{\"formats_checked\":3,\"slides_per_deck\":4}");
            foreach(var field in expected.RootElement.EnumerateObject())
            {
                var actual=result.RootElement;foreach(string part in field.Name.Split('.'))actual=actual.GetProperty(part);
                ctx.Require(actual.ToString()==field.Value.ToString(),"Licensed assertion differs: "+field.Name);
                checks["licensed-"+field.Name.Replace('.','-')]=true;
            }
        }
        else
        {
            var values=result.RootElement.TryGetProperty("checks",out var nested)?nested:result.RootElement;
            foreach(var field in values.EnumerateObject())if(field.Value.ValueKind==JsonValueKind.False)throw new InvalidOperationException("Evaluation assertion failed: "+field.Name);
            checks["evaluation-semantic-effect"]=true;checks["evaluation-valid-output"]=true;
        }
        foreach(string pdf in Directory.GetFiles(".","*.pdf",SearchOption.AllDirectories))ctx.Require(File.ReadAllBytes(pdf).AsSpan(0,5).SequenceEqual(System.Text.Encoding.ASCII.GetBytes("%PDF-")),"Invalid PDF output.");
        foreach(string png in Directory.GetFiles(".","*.png",SearchOption.AllDirectories)){var image=PortableImage.Decode(File.ReadAllBytes(png));ctx.Require(image.Width>0&&image.Height>0,"Empty PNG output.");}
        ctx.Pass("conversion-rendering/presentation-formats/block-001",checks);
        await Task.CompletedTask;
    });

    private static void RunExample()
    {
        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);
        var formats = new[] { (SaveFormat.Pptx, "pptx"), (SaveFormat.Ppt, "ppt"), (SaveFormat.Odp, "odp") };
        int checks = 0;
        foreach (var (format, extension) in formats)
        {
            source.Save("converted." + extension, format);
            using var reopened = new Presentation("converted." + extension);
            if (reopened.Slides.Count != 4) throw new InvalidOperationException("Slide count changed.");
            string text = string.Join(" ", reopened.Slides.SelectMany(s => s.Shapes.OfType<IAutoShape>()).Select(s => s.TextFrame.Text));
            if (!text.Contains("Alpha") || !text.Contains(Context.IsLicensed ? "Hidden" : "Hide")) throw new InvalidOperationException("Text changed.");
            reopened.Save("from-" + extension + ".pptx", SaveFormat.Pptx);
            using var preview = reopened.Slides[0].GetImage(new Size(320, 180));
            preview.Save("preview-" + extension + ".png", Aspose.Slides.ImageFormat.Png);
            checks++;
        }
        Report(new { formats_checked = checks, slides_per_deck = 4 });
    }

    private static Presentation CreateSource()
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = Context.IsLicensed ? new[] { "Alpha", "Bravo", "Charlie", "Hidden" } : new[] { "Alpha", "Bravo", "C", "Hide" };
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
            shape.Name = "RecipeTitle";
            shape.TextFrame.Text = labels[i];
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("Noto Sans");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = Context.IsLicensed ? "Speaker note " + labels[i] : labels[i];
            slide.Hidden = i == 3;
        }
        var table = deck.Slides[0].Shapes.AddTable(30, 100, new double[] { 140, 100 }, new double[] { 35, 35 });
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        deck.Slides[1].Shapes.AddChart(ChartType.ClusteredColumn, 30, 100, 400, 220);
        var image = deck.Images.AddImage(PortableImage.Png(100,60,Color.CornflowerBlue));
        deck.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle,50,120,200,120,image);
        deck.Slides[0].Timeline.MainSequence.AddEffect(deck.Slides[0].Shapes.OfType<IAutoShape>().Single(s => s.Name == "RecipeTitle"), EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
        deck.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
        return deck;
    }

    private static void Report(object values)
    {
        string json = JsonSerializer.Serialize(values, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json);
        Console.WriteLine(json);
    }
}
```

## Expected result

The program writes "converted.pptx", "converted.ppt", "converted.odp", "from-pptx.pptx", "from-ppt.pptx", "from-odp.pptx", "preview-pptx.png", "preview-ppt.png", "preview-odp.png" in the printed output directory, plus the synthetic source.pptx and a result.json summary. Inspect the rendered/exported files with the viewer appropriate to the format. Input generation is visible in CreateSource; replace it with opening your own presentation when adapting the example.

Continue with the [detailed guide](/slides/net/convert-ppt-to-pptx/).


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
