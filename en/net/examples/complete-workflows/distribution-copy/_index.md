---
title: "Prepare a Distribution Copy"
type: docs
weight: 40
url: /net/examples/complete-workflows/distribution-copy/
description: "Complete runnable C# project to prepare a distribution copy using Aspose.Slides for .NET."
---

Prepare a separate distribution copy with an explicit removal list: speaker notes, comments, author/custom metadata and the VBA project. Add a visual watermark and a password-protected PDF. The synthetic original stays unchanged. This is not forensic sanitization: hyperlinks, embedded files, hidden objects and other properties require their own review.

## **Download and run**

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes the bootstrap, solution and editor profiles.


## **Inputs and execution**

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## **Complete project source**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files under `example-output` by default.

Set `OUTPUT_PDF_PASSWORD` for a real distribution password. The fallback `demonstration-only` is deliberately a demo credential. The generated `original.pptm` includes synthetic private notes, comments, a macro and a custom property.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        CreatePrivateSource();
        using var distributionCopy = new Presentation("example-output/original.pptm");
        foreach (var slide in distributionCopy.Slides)
        {
            if (slide.NotesSlideManager.NotesSlide != null)
                slide.NotesSlideManager.RemoveNotesSlide();
            AddLabel(slide, "DISTRIBUTION COPY", "DistributionWatermark", 520, 450, 400, 55);
        }

        foreach (var reviewer in distributionCopy.CommentAuthors)
            reviewer.Comments.Clear();
        distributionCopy.CommentAuthors.Clear();
        distributionCopy.VbaProject = null;
        distributionCopy.DocumentProperties.Author = "";
        distributionCopy.DocumentProperties.ClearCustomProperties();
        distributionCopy.Save("example-output/distribution.pptx", SaveFormat.Pptx);
        string password = Environment.GetEnvironmentVariable("OUTPUT_PDF_PASSWORD") ?? "demonstration-only";
        distributionCopy.Save("example-output/distribution.pdf", SaveFormat.Pdf, new PdfOptions { Password = password });
        using var reopened = new Presentation("example-output/distribution.pptx");
        var sanitized = reopened.VbaProject == null && reopened.CommentAuthors.Count == 0 && reopened.DocumentProperties.CountOfCustomProperties == 0 && reopened.Slides.All(slide => slide.NotesSlideManager.NotesSlide == null);
        if (!sanitized)
        {
            Console.Error.WriteLine("The reopened distribution copy still contains private content.");
            return;
        }

        Preview(reopened, "example-output/preview.png");
        Console.WriteLine("Distribution copy reopened without notes, comments, VBA, or custom properties.");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private static Presentation CreateDeck(params string[] titles)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(960, 540, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < titles.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            AddLabel(slide, titles[i], "Title", 40, 30, 880, 80);
        }

        return deck;
    }

    private static IAutoShape AddLabel(ISlide slide, string value, string name, float x, float y, float w, float h)
    {
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, w, h);
        shape.Name = name;
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.AliceBlue;
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.TextFrame.Text = value;
        shape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
        foreach (var paragraph in shape.TextFrame.Paragraphs)
            foreach (var portion in paragraph.Portions)
            {
                portion.PortionFormat.FontHeight = 24;
                portion.PortionFormat.LatinFont = new FontData("Noto Sans");
                portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
            }

        return shape;
    }

    private static void Preview(Presentation deck, string path)
    {
        using var image = deck.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }

    private static void CreatePrivateSource()
    {
        using (var input = CreateDeck("Quarterly update", "Public summary"))
        {
            input.DocumentProperties.Author = "Example internal author";
            input.DocumentProperties.SetCustomPropertyValue("ReviewStatus", "Draft");
            input.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Private example note";
            var author = input.CommentAuthors.AddAuthor("Example reviewer", "ER");
            author.Comments.AddComment("Example review", input.Slides[0], new PointF(10, 10), DateTime.UtcNow);
            input.VbaProject = new VbaProject();
            input.VbaProject.Modules.AddEmptyModule("SampleModule").SourceCode = "Sub Example()\nEnd Sub";
            input.Save("example-output/original.pptm", SaveFormat.Pptm);
        }
    }
}
```

## **Expected outputs**

The project writes distribution.pptx, distribution.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
