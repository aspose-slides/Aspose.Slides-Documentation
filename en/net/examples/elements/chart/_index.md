---
title: Chart
type: docs
weight: 60
url: /net/examples/elements/chart/
keywords:
- code example
- chart
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master charts with Aspose.Slides for .NET: create, format, bind data, and export charts in PPT, PPTX, and ODP with C# examples."
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for .NET**. The snippets below demonstrate basic chart operations.

## **Add a Chart**

This method adds a simple area chart to the first slide.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Add a simple area chart to the first slide.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Access a Chart**

After creating a chart, you can retrieve it through the shape collection.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Access the first chart on the slide.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Remove a Chart**

The following code removes a chart from a slide.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Remove the chart.
    slide.Shapes.Remove(chart);
}
```

## **Update Chart Data**

You can change chart properties such as the title.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Change the chart title.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
