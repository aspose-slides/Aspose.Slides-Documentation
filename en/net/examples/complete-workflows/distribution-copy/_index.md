---
title: "Prepare a Distribution Copy"
type: docs
weight: 40
url: /net/examples/complete-workflows/distribution-copy/
description: "Complete runnable C# project to prepare a distribution copy using Aspose.Slides for .NET."
---

Prepare a separate distribution copy with an explicit removal list: speaker notes, comments, author/custom metadata and the VBA project. Add a visual watermark and a password-protected PDF. The synthetic original stays unchanged. This is not forensic sanitization: hyperlinks, embedded files, hidden objects and other properties require their own review.

## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The projects were tested on Windows x64 with Arial and the .NET SDK8.0.427 pinned in global.json. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

```csharp
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static class Program
{
    private static void Main()
    {
        var path = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(path)) new License().SetLicense(path);
        using (var input = Deck("Quarterly update", "Public summary"))
        {
            input.DocumentProperties.Author = "Example internal author"; input.DocumentProperties.SetCustomPropertyValue("ReviewStatus", "Draft");
            input.Slides[0].NotesSlideManager.AddNotesSlide().NotesTextFrame.Text = "Private example note";
            var author = input.CommentAuthors.AddAuthor("Example reviewer", "ER");
            author.Comments.AddComment("Example review", input.Slides[0], new PointF(10, 10), DateTime.UtcNow);
            input.VbaProject = new VbaProject();
            input.VbaProject.Modules.AddEmptyModule("SampleModule").SourceCode = "Sub Example()\nEnd Sub";
            input.Save("original.pptm", SaveFormat.Pptm);
        }
        string original = Hash("original.pptm");
        using var copy = new Presentation("original.pptm");
        foreach (var slide in copy.Slides)
        {
            if (slide.NotesSlideManager.NotesSlide != null) slide.NotesSlideManager.RemoveNotesSlide();
            Label(slide, "DISTRIBUTION COPY", "DistributionWatermark", 520, 450, 400, 55);
        }
        foreach (var reviewer in copy.CommentAuthors) reviewer.Comments.Clear();
        copy.CommentAuthors.Clear(); copy.VbaProject = null;
        copy.DocumentProperties.Author = ""; copy.DocumentProperties.ClearCustomProperties();
        copy.Save("distribution.pptx", SaveFormat.Pptx);
        string password = Environment.GetEnvironmentVariable("OUTPUT_PDF_PASSWORD") ?? "demonstration-only";
        copy.Save("distribution.pdf", SaveFormat.Pdf, new PdfOptions { Password = password });
        using var reopened = new Presentation("distribution.pptx");
        Require(reopened.VbaProject == null && reopened.CommentAuthors.Count == 0 && reopened.DocumentProperties.CountOfCustomProperties == 0, "Selected removals failed.");
        Require(reopened.Slides.All(s => s.NotesSlideManager.NotesSlide == null), "Notes remain.");
        Require(Hash("original.pptm") == original, "Original was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { notes_removed = true, comments_removed = true, macros_removed = true, custom_properties_removed = true, input_preserved = true });
    }

    private static Presentation Deck(params string[] titles)
    {
        var deck = new Presentation();
        deck.SlideSize.SetSize(960, 540, SlideSizeScaleType.DoNotScale);
        var layout = deck.LayoutSlides.GetByType(SlideLayoutType.Blank);
        for (int i = 0; i < titles.Length; i++)
        {
            var slide = i == 0 ? deck.Slides[0] : deck.Slides.AddEmptySlide(layout);
            Label(slide, titles[i], "Title", 40, 30, 880, 80);
        }
        return deck;
    }

    private static IAutoShape Label(ISlide slide, string value, string name, float x, float y, float w, float h)
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
            portion.PortionFormat.LatinFont = new FontData("Arial");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Select(s => s.TextFrame?.Text));
    private static string Hash(string path) => Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path)));
    private static void Require(bool value, string message) { if (!value) throw new InvalidOperationException(message); }
    private static void Preview(Presentation deck, string path)
    {
        using var image = deck.Slides[0].GetImage(new Size(640, 360));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
    private static void Report(object value)
    {
        string json = JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("result.json", json); Console.WriteLine(json);
    }
}
```

## Expected outputs

The project writes distribution.pptx, distribution.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
