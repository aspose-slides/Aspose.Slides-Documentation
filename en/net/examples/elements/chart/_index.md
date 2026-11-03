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
description: "Add, access, remove, and title PowerPoint charts with Aspose.Slides for .NET C# examples."
---

Add, access, remove, and title charts with **Aspose.Slides for .NET**. Each case receives the first slide of a new presentation.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim. The download runs the cases in `Program.cs` and checks the presentations before saving and after reopening them in `ChartVerification.cs`.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case01(ISlide slide)
    {
        slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
    }
}
```

## **Access a Chart**

After creating a chart, you can retrieve it through the shape collection.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case02(ISlide slide)
    {
        slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

        var firstChart = slide.Shapes.OfType<IChart>().First();
        Console.WriteLine(firstChart.Type);
    }
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case03(ISlide slide)
    {
        var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);
        slide.Shapes.Remove(chart);
    }
}
```

<a id="update-chart-data"></a>

## **Change the Chart Title**

Enable the chart title and set its text to "Sales".

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    static void Case04(ISlide slide)
    {
        var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("Sales");
    }
}
```
