---
title: "Export Presentations to HTML"
type: docs
weight: 40
url: /net/examples/conversion-rendering/html/
description: "Runnable C# example for export presentations to html using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Classic HTML uses SVG-based slide output and can scale to its container. HTML5 has presentation navigation and supported shape/transition animation. Serve the generated HTML together with its supporting asset folders; the example keeps HTML5 images and styles external. The HTML5 copy contains only visible slides so its navigation matches the exported deck. Click its first slide to play the title fade; each visible slide has a title effect and fade transition. In this SDK, generated navigation can remain disabled after a slide without animations, so verify mixed animated/static decks before hosting them. Generated HTML5 also references public JavaScript CDNs; offline hosting must provide those dependencies. The export flags do not add effects to a deck without them.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);
        var classicOptions = new HtmlOptions
        {
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new ResponsiveHtmlController())
        };
        source.Save("classic.html", SaveFormat.Html, classicOptions);
        using var visibleSlides = new Presentation("source.pptx");
        for (int i = visibleSlides.Slides.Count - 1; i >= 0; i--)
        {
            if (visibleSlides.Slides[i].Hidden)
                visibleSlides.Slides.RemoveAt(i);
        }

        foreach (var slide in visibleSlides.Slides)
        {
            var title = slide.Shapes.OfType<IAutoShape>().Single(shape => shape.Name == "RecipeTitle");
            slide.Timeline.MainSequence.AddEffect(title, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            slide.SlideShowTransition.Type = TransitionType.Fade;
        }

        var html5Options = new Html5Options
        {
            AnimateShapes = true,
            AnimateTransitions = true,
            EmbedImages = false
        };
        visibleSlides.Save("slides.html", SaveFormat.Html5, html5Options);
        Console.WriteLine("Open classic.html or slides.html with its generated assets.");
    }

    private static Presentation CreateSource()
    {
        var presentation = new Presentation();
        presentation.SlideSize.SetSize(640, 360, SlideSizeScaleType.DoNotScale);
        var blank = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
        string[] labels = ["Alpha", "Bravo", "C", "Hide"];
        for (int i = 0; i < labels.Length; i++)
        {
            var slide = i == 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(blank);
            AddTitle(slide, labels[i]);
            slide.Hidden = i == labels.Length - 1;
        }

        var table = presentation.Slides[0].Shapes.AddTable(30, 100, [140, 100], [35, 35]);
        table[0, 0].TextFrame.Text = "Item";
        table[1, 0].TextFrame.Text = "Units";
        table[0, 1].TextFrame.Text = "Pens";
        table[1, 1].TextFrame.Text = "12";
        byte[] imageBytes = SampleImage();
        var image = presentation.Images.AddImage(imageBytes);
        presentation.Slides[2].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 120, 200, 120, image);
        return presentation;
    }

    private static IAutoShape AddTitle(ISlide slide, string text)
    {
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 580, 55);
        title.Name = "RecipeTitle";
        title.TextFrame.Text = text;
        title.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 26;
        return title;
    }

    // Original blue-and-white fixture; no image library or download is needed.
    private static byte[] SampleImage() => Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
}
```

## **Expected result**

Open `classic.html` for the responsive export, or `slides.html` for three visible slides with click-triggered title fades and slide transitions. Keep its generated image, script and style resources together. The HTML5 viewer also uses its documented CDN resources, so browser playback requires access to those URLs.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-html/).


## **Open and run the complete project**

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
See [setup and prerequisites](/slides/net/examples/getting-started/) for native libraries,
fonts, IDE settings and the .NET 8/9 runtime support boundary of 2026-11-10.
