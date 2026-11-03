---
title: "Assemble a Customer Proposal"
type: docs
weight: 20
url: /net/examples/complete-workflows/customer-proposal/
description: "Complete runnable C# project to assemble a customer proposal using Aspose.Slides for .NET."
---

Assemble a customer proposal from a synthetic product catalog and a JSON selection. The complete project creates a cover, copies the chosen product slides in request order, and saves an editable deck and a PDF. The original catalog remains unchanged.

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

This program creates a three-product catalog and assembles a proposal for Contoso. Zero-based selections `2, 0` preserve the requested order: Reporting, then Analytics. The download also supports the equivalent `customer.json` request fixture.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        var customerName = "Contoso";
        var selectedProductIndices = new[]
        {
            2,
            0
        };
        using (var catalog = CreateDeck("Analytics", "Planning", "Reporting"))
            catalog.Save("example-output/catalog.pptx", SaveFormat.Pptx);
        using var sourceCatalog = new Presentation("example-output/catalog.pptx");
        if (selectedProductIndices.Any(index => index < 0 || index >= sourceCatalog.Slides.Count))
        {
            Console.Error.WriteLine("A selected product does not exist in the catalog.");
            return;
        }

        using var proposal = CreateDeck("Proposal for " + customerName);
        foreach (var productIndex in selectedProductIndices)
            proposal.Slides.AddClone(sourceCatalog.Slides[productIndex]);
        proposal.Save("example-output/proposal.pptx", SaveFormat.Pptx);
        proposal.Save("example-output/proposal.pdf", SaveFormat.Pdf);
        using var reopenedProposal = new Presentation("example-output/proposal.pptx");
        Preview(reopenedProposal, "example-output/preview.png");
        Console.WriteLine($"Saved proposal: {reopenedProposal.Slides.Count} slides, with Reporting then Analytics after the cover.");
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
}
```

## **Expected outputs**

The project writes proposal.pptx, proposal.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
