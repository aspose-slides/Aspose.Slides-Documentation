---
title: "Generate a Monthly Report"
type: docs
weight: 10
url: /net/examples/complete-workflows/monthly-report/
description: "Complete runnable C# project to generate a monthly report using Aspose.Slides for .NET."
---

Build a monthly report from a small JSON dataset and an original branded template. The project populates an editable chart/table, repeats a detail slide for every product and delivers PPTX plus PDF. It checks that chart totals reconcile to the source and preserves the template.

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

The complete program embeds its three sales records and generates its template. It creates a summary chart and table from the same product data, then clones one detail slide per product. Negative units stop the program before report assembly.

```csharp
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static class Program
{
    private static void Main()
    {
        var licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);
        var outputDirectory = Directory.CreateDirectory("example-output").FullName;
        const string salesJson = """[{"product":"Pens","units":12},{"product":"Notebooks","units":8},{"product":"Folders","units":5}]""";
        using var salesDocument = JsonDocument.Parse(salesJson);
        var sales = salesDocument.RootElement.EnumerateArray().Select(row => new ProductSales(row.GetProperty("product").GetString()!, row.GetProperty("units").GetDouble())).ToArray();
        if (sales.Any(row => row.Units < 0))
        {
            Console.Error.WriteLine("Units must be nonnegative.");
            return;
        }

        var totalUnits = sales.Sum(row => row.Units);
        CreateTemplate();
        using var report = new Presentation("example-output/template.pptx");
        var searchOptions = new TextSearchOptions
        {
            CaseSensitive = true
        };
        foreach (var shape in report.Slides[0].Shapes.OfType<IAutoShape>())
        {
            shape.TextFrame.ReplaceText("{{month}}", "October", searchOptions, null);
            shape.TextFrame.ReplaceText("{{total}}", "Total units: " + totalUnits, searchOptions, null);
        }

        AddSalesChart(report.Slides[0], sales);
        AddSummaryTable(report.Slides[0], sales);
        AddProductDetails(report, sales, searchOptions);
        if (report.Slides.Any(slide => slide.Shapes.OfType<IAutoShape>().Any(shape => shape.TextFrame.Text.Contains("{{"))))
        {
            Console.Error.WriteLine("A template placeholder remains unfilled.");
            return;
        }

        report.Save("example-output/monthly-report.pptx", SaveFormat.Pptx);
        report.Save("example-output/monthly-report.pdf", SaveFormat.Pdf);
        using var savedReport = new Presentation("example-output/monthly-report.pptx");
        Preview(savedReport, "example-output/preview.png");
        Console.WriteLine($"Saved {savedReport.Slides.Count} slides for {sales.Length} products; total units: {totalUnits}.");
        Console.WriteLine("Output: " + outputDirectory);
    }

    private sealed record ProductSales(string Product, double Units);
    private static void CreateTemplate()
    {
        using var template = CreateReportTemplate("Monthly report: {{month}}", "{{product}}");
        AddLabel(template.Slides[0], "{{total}}", "Total", 40, 120, 350, 60);
        AddLabel(template.Slides[1], "{{units}}", "Units", 40, 150, 500, 80);
        template.Save("example-output/template.pptx", SaveFormat.Pptx);
    }

    private static void AddSalesChart(ISlide summary, ProductSales[] sales)
    {
        var chart = summary.Shapes.AddChart(ChartType.ClusteredColumn, 410, 120, 500, 340);
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();
        var workbook = chart.ChartData.ChartDataWorkbook;
        workbook.Clear(0);
        var series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Units"), chart.Type);
        for (var index = 0; index < sales.Length; index++)
        {
            chart.ChartData.Categories.Add(workbook.GetCell(0, index + 1, 0, sales[index].Product));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, index + 1, 1, sales[index].Units));
        }
    }

    private static void AddSummaryTable(ISlide summary, ProductSales[] sales)
    {
        var rowHeights = Enumerable.Repeat(36.0, sales.Length + 1).ToArray();
        var table = summary.Shapes.AddTable(40, 220, new double[] { 210, 120 }, rowHeights);
        table[0, 0].TextFrame.Text = "Product";
        table[1, 0].TextFrame.Text = "Units";
        for (var index = 0; index < sales.Length; index++)
        {
            table[0, index + 1].TextFrame.Text = sales[index].Product;
            table[1, index + 1].TextFrame.Text = sales[index].Units.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    private static void AddProductDetails(Presentation report, ProductSales[] sales, TextSearchOptions searchOptions)
    {
        var detailTemplate = report.Slides[1];
        foreach (var product in sales)
        {
            var detailSlide = report.Slides.AddClone(detailTemplate);
            foreach (var shape in detailSlide.Shapes.OfType<IAutoShape>())
            {
                shape.TextFrame.ReplaceText("{{product}}", product.Product, searchOptions, null);
                shape.TextFrame.ReplaceText("{{units}}", product.Units.ToString(System.Globalization.CultureInfo.InvariantCulture), searchOptions, null);
            }
        }

        // Clone all detail slides before removing their template.
        report.Slides.RemoveAt(1);
    }

    private static Presentation CreateReportTemplate(params string[] titles)
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

The project writes monthly-report.pptx, monthly-report.pdf, preview.png and result.json. Reopen the PPTX/PDF or gallery and inspect its content before adapting the code to a real dataset. Production applications should validate external inputs and choose their own output paths and credentials.

See also [Templates and Data](/slides/net/examples/templates-data/), [Presentations](/slides/net/examples/presentations/) and [Conversion and Rendering](/slides/net/examples/conversion-rendering/).
