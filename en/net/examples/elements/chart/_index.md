---
title: Chart
type: docs
weight: 60
url: /net/examples/elements/chart
---

Examples for adding, accessing, removing, and updating different chart types with **Aspose.Slides for .NET**. The snippets below demonstrate basic chart operations.

## Add a Chart

This method adds a simple area chart to the first slide.

```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Add a simple column chart to the first slide
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## Access a Chart

After creating a chart, you can retrieve it through the shape collection.

```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Access the first chart on the slide
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## Remove a Chart

The following code removes a chart from a slide.

```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Remove the chart
    slide.Shapes.Remove(chart);
}
```

## Update Chart Data

You can change chart properties such as the title.

```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Change the chart title
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
