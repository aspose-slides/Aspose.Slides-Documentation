---
title: Repeat a Template Slide for Each Record
type: docs
weight: 50
url: /net/examples/templates-data/repeat-slides/
description: "Clone one template slide per customer, then fill its text, chart and picture. The copied program uses inline records; the download reads its records from JSON."
---

Clone one template slide per customer, then fill its text, chart and picture. The copied program uses inline records; the download reads its records from JSON.

<span id="run-the-example"></span>

## **Example**

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.
The copied program writes its files in the current working directory.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

internal static class Program
{
    private static void Main()
    {
        string? licensePath = Environment.GetEnvironmentVariable("ASPOSE_LICENSE_PATH");
        if (!string.IsNullOrWhiteSpace(licensePath))
            new License().SetLicense(licensePath);

        // Original compact blue and orange logos; each customer gets its own image.
        Customer[] customers = [new("Acme", 125.5, "iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII="), new("東京", 80, "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAMCAYAAABfnvydAAAAJElEQVR4nGP4v5ThPz7MQAMFIIBTATIgXQE2QGUriPIFOQEFAOHGFsu+FDRbAAAAAElFTkSuQmCC")];
        Generate(customers, "report.pptx");
    }

    private sealed record Customer(string Name, double Amount, string Logo);
    private static Presentation CreateTemplate()
    {
        var presentation = new Presentation();
        var slide = presentation.Slides[0];
        var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 35, 20, 550, 70);
        title.Name = "Customer";
        title.TextFrame.Text = "{{Customer}}";
        var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 130, 600, 290);
        chart.Name = "Sales";
        byte[] logoBytes = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAwAAAAICAYAAADN5B7xAAAAI0lEQVR4nGNImfr2PymYgWoaQIAoDdgATg34AHVsIMsPhDAAMPMqpQBAkJ0AAAAASUVORK5CYII=");
        var logo = presentation.Images.AddImage(logoBytes);
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 600, 15, 60, 60, logo).Name = "Logo";
        return presentation;
    }

    private static bool Generate(Customer[] customers, string path)
    {
        if (customers.Length == 0)
        {
            Console.WriteLine("No customers: no presentation was written.");
            return true;
        }

        using var presentation = CreateTemplate();
        var template = presentation.Slides[0];
        foreach (var customer in customers)
        {
            var slide = presentation.Slides.AddClone(template);
            var title = FindNamed<IAutoShape>(slide, "Customer");
            var chart = FindNamed<IChart>(slide, "Sales");
            var logo = FindNamed<IPictureFrame>(slide, "Logo");
            if (title is null || chart is null || logo is null)
                return false;
            title.TextFrame.ReplaceText("{{Customer}}", customer.Name, new TextSearchOptions(), null);
            SetSales(chart, customer.Name, customer.Amount);
            byte[] logoBytes = Convert.FromBase64String(customer.Logo);
            logo.PictureFormat.Picture.Image = presentation.Images.AddImage(logoBytes);
        }

        presentation.Slides.Remove(template);
        presentation.Save(path, SaveFormat.Pptx);
        SavePreview(presentation, path + ".png");
        Console.WriteLine($"{path}: {presentation.Slides.Count} slides");
        return true;
    }

    private static void SetSales(IChart chart, string customer, double amount)
    {
        var data = chart.ChartData;
        var workbook = data.ChartDataWorkbook;
        data.Series.Clear();
        data.Categories.Clear();
        workbook.Clear(0);
        data.Categories.Add(workbook.GetCell(0, 1, 0, "Sales"));
        var series = data.Series.Add(workbook.GetCell(0, 0, 1, customer), ChartType.ClusteredColumn);
        series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, amount));
    }

    private static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (var shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
            {
                foreach (var child in Walk(group.Shapes))
                    yield return child;
            }
        }
    }

    private static T? FindNamed<T>(ISlide slide, string name)
        where T : class, IShape
    {
        var matches = Walk(slide.Shapes).Where(shape => shape.Name == name).ToArray();
        if (matches.Length == 1 && matches[0] is T result)
            return result;
        Console.Error.WriteLine("Expected exactly one named shape: " + name);
        return null;
    }

    private static void SavePreview(Presentation presentation, string path)
    {
        using var image = presentation.Slides[0].GetImage(new Size(800, 450));
        image.Save(path, Aspose.Slides.ImageFormat.Png);
    }
}
```

## **Expected result and checks**

`report.pptx` contains two slides, Acme then 東京, with separate chart values and blue/orange logos. The template slide is removed. `report.pptx.png` previews the first slide. An empty customer array writes no deck; duplicate required shape names stop generation with a diagnostic.

The downloaded project writes its verification checks to `output/result.json`. The following values describe the ZIP’s checks; the copied program does not write this report:

```json
{
  "slide_count": 2,
  "order_preserved": true,
  "no_template_slide": true,
  "no_state_leak": true,
  "semantic_repeatability": true,
  "duplicate_name_rejected": true
}
```

The original template slide is removed deliberately. Output order matches the data order. The checks compare repeatable content, not identical ZIP bytes or timestamps. Shape names must be unique within the relevant slide; duplicate names are rejected. An empty dataset returns no report slides.

## **Learn more**

- [Clone Presentation Slides in .NET](/slides/net/clone-slides/)
- [Manage Presentation Placeholders in .NET](/slides/net/manage-placeholder/)


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
