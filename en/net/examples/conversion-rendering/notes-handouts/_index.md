---
title: "Export Notes and Handouts"
type: docs
weight: 80
url: /net/examples/conversion-rendering/notes-handouts/
description: "Runnable C# example for export notes and handouts using Aspose.Slides for .NET, with input generation, outputs and a complete project."
---

Export speaker notes below slides and create handouts with several slides per PDF page. The notes example omits hidden slides by default; the handout explicitly selects three slides so its final page is partially filled. Check the final partially filled handout page when your slide count is not a multiple of the chosen layout.

<span id="run-the-example"></span>

## **Complete C# example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        using var source = CreateSource();
        source.Save("source.pptx", SaveFormat.Pptx);
        var notesOptions = new PdfOptions
        {
            SlidesLayoutOptions = new NotesCommentsLayoutingOptions
            {
                NotesPosition = NotesPositions.BottomFull
            }
        };
        source.Save("notes.pdf", SaveFormat.Pdf, notesOptions);
        var handoutOptions = new PdfOptions
        {
            ShowHiddenSlides = false,
            SlidesLayoutOptions = new HandoutLayoutingOptions
            {
                Handout = HandoutType.Handouts2,
                PrintSlideNumbers = true,
                PrintFrameSlide = true
            }
        };

        // These selected slide positions are one-based.
        int[] handoutSlides = [1, 2, 3];
        source.Save("handout.pdf", handoutSlides, SaveFormat.Pdf, handoutOptions);
        Console.WriteLine("Input summary: three visible slides with notes, one hidden slide.");
        Console.WriteLine("Created notes.pdf and handout.pdf.");
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
            slide.NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = labels[i];
        }

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
}
```

## **Expected result**

`notes.pdf` places each visible slide’s notes below that slide. `handout.pdf` places the three selected slides on two pages, with a frame and slide number for each. The hidden fourth slide is excluded. The console describes the input; the download verification inspects the exported files.

Continue with the [detailed guide](/slides/net/convert-powerpoint-to-pdf-with-notes/).


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
