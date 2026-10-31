---
title: Chart
type: docs
weight: 60
url: /net/examples/elements/chart/
keywords:
- chart
- add chart
- access chart
- remove chart
- update chart
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master charts with Aspose.Slides for .NET: create, format, bind data, and export charts in PPT, PPTX, and ODP with C# examples."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for .NET**. The snippets below demonstrate basic chart operations.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a simple area chart to the first slide.
        var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().Type == ChartType.Area, "AddChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-001", "AddChart", "save-reopen-structure");
    }
}
```

## **Access a Chart**

After creating a chart, you can retrieve it through the shape collection.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

        // Access the first chart on the slide.
        var firstChart = slide.Shapes.OfType<IChart>().First();

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().Type == ChartType.Line, "AccessChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-002", "AccessChart", "save-reopen-structure");
    }
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

        // Remove the chart.
        slide.Shapes.Remove(chart);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(!p.Slides[0].Shapes.OfType<IChart>().Any(), "RemoveChart: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-003", "RemoveChart", "save-reopen-structure");
    }
}
```

## **Update Chart Data**

You can change chart properties such as the title.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];
        
        var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

        chart.HasTitle = true;

        // Change the chart title.
        chart.ChartTitle.AddTextFrameForOverriding("Sales");

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Shapes.OfType<IChart>().Single().ChartTitle.TextFrameForOverriding.Text == "Sales", "UpdateChartData: semantic check 1 failed.");
        });
        Context.Pass("elements/chart/block-004", "UpdateChartData", "save-reopen-structure");
    }
}
```
