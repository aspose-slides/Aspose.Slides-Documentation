---
title: "Assemble a Customer Proposal"
type: docs
weight: 20
url: /net/examples/complete-workflows/customer-proposal/
description: "Complete runnable C# project to assemble a customer proposal using Aspose.Slides for .NET."
---

Assemble a customer proposal from a synthetic product catalog and a JSON selection. The complete project creates a cover, copies the chosen product slides in request order, and saves an editable deck and a PDF. The original catalog remains unchanged.

## Download and run

Download [the complete project](example.zip) and open **Example.sln** in a compatible IDE. Automatic NuGet restore should run when it opens. The project accepts supported installed release SDKs instead of requiring one exact patch. [Setup and supported environments](/slides/net/examples/getting-started/) explains native libraries, fonts and the SDK/runtime distinction.

```text
dotnet run --project Example.csproj -- --mode evaluation
```

Evaluation mode needs no license and retains the SDK watermark/text limits. For full licensed checks, set ASPOSE_LICENSE_PATH to your authorized license and use --mode licensed. Fonts and synthetic fixtures needed by this recipe are included or acquired as documented. The supplied bootstrap prepares a separate output workspace and prints its absolute path. The complete download includes that bootstrap, solution and editor profiles; the C# block below is Program.cs from the same archive.


## Inputs and execution

[Download the complete project](example.zip), including its original inputs, all source and pinned dependencies. The project uses bundled Noto Sans and the flexible SDK policy described in the setup guide. Set `ASPOSE_LICENSE_PATH` to your license file; unrestricted content checks require a valid license. See [licensing](/slides/net/licensing/). No PowerPoint installation is required.

```text
dotnet run --project Example.csproj --configuration Release
```

The program generates its own original presentation/template fixture. JSON inputs, when present, are included in the download. All output files are separate from those inputs.

## Complete project source

```csharp
using System.IO.Compression;
using System.Threading.Tasks;
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
    private static ExampleContext Context = null!;
    private static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, async context =>
    {
        Context = context;
        context.BeginAction("complete-workflows/customer-proposal/block-001");
        RunExample();
        await Task.CompletedTask;
        context.Pass("complete-workflows/customer-proposal/block-001", "recipe semantic assertions", "source inputs preserved", "documented output generated");
    });

    private static void RunExample()
    {
        var request = JsonDocument.Parse(File.ReadAllText("customer.json")).RootElement;
        string customer = request.GetProperty("customer").GetString()!;
        int[] selected = request.GetProperty("product_indices").EnumerateArray().Select(v => v.GetInt32()).ToArray();
        using (var catalog = Deck("Analytics", "Planning", "Reporting")) catalog.Save("catalog.pptx", SaveFormat.Pptx);
        string original = Hash("catalog.pptx");
        using var source = new Presentation("catalog.pptx");
        Require(selected.All(i => i >= 0 && i < source.Slides.Count), "Unknown product selection.");
        using var proposal = Deck("Proposal for " + customer);
        foreach (int i in selected) proposal.Slides.AddClone(source.Slides[i]);
        proposal.Save("proposal.pptx", SaveFormat.Pptx); proposal.Save("proposal.pdf", SaveFormat.Pdf);
        using var reopened = new Presentation("proposal.pptx");
        Require(reopened.Slides.Count == selected.Length + 1 && Text(reopened.Slides[0]) == Context.ExpectedText("Proposal for " + customer), "Proposal identity or count is wrong.");
        string[] expectedOrder = selected.Select(i => Text(source.Slides[i])).ToArray();
        for (int i = 0; i < expectedOrder.Length; i++)
            Require(Text(reopened.Slides[i + 1]) == expectedOrder[i], "Product order changed.");
        Require(SavedText("proposal.pptx").Contains("Proposal for " + customer), "Persisted customer identity differs.");
        Require(Hash("catalog.pptx") == original, "Catalog was overwritten.");
        Preview(reopened, "preview.png");
        Report(new { customer, product_order = string.Join(",", expectedOrder), slides = reopened.Slides.Count, input_preserved = true });
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
            portion.PortionFormat.LatinFont = new FontData("Noto Sans");
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        }
        return shape;
    }

    private static string Text(ISlide slide) => string.Join(" ", slide.Shapes.OfType<IAutoShape>().Where(s => s.Name is "Title" or "Total" or "Units").Select(s => s.TextFrame?.Text));
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

    // Inspect persisted OOXML independently; evaluation text getters remain explicitly limited.
    private static string[] SavedText(string file)
    {
        using var archive = ZipFile.OpenRead(file);
        System.Xml.Linq.XNamespace drawing = "http://schemas.openxmlformats.org/drawingml/2006/main";
        return archive.Entries.Where(entry => entry.FullName.StartsWith("ppt/", StringComparison.Ordinal) && entry.FullName.EndsWith(".xml", StringComparison.Ordinal))
            .SelectMany(entry => { using var stream = entry.Open(); return System.Xml.Linq.XDocument.Load(stream, System.Xml.Linq.LoadOptions.PreserveWhitespace).Descendants(drawing + "p").Select(paragraph => string.Concat(paragraph.Descendants(drawing + "t").Select(node => node.Value))).ToArray(); }).ToArray();
    }

}
```

## Expected outputs

The project writes proposal.pptx, proposal.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
