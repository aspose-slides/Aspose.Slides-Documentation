---
title: Doughnut Chart
type: docs
weight: 30
url: /net/doughnut-chart/
keywords: "Doughnut chart, center gap, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Specify center gap in doughnut chart in PowerPoint presentation in C# or .NET"
---

## **Specify Center Gap in Doughnut Chart**
In order to specify the size of the hole in a doughnut chart. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

```c#
// Create an instance of Presentation class
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Write presentation to disk
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Yes. Add multiple series to a single doughnut chart—each series becomes a separate ring. The ring order is determined by the order of the series in the collection.

**Is an "exploded" doughnut (separated slices) supported?**

Yes. There is an Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) and an explosion property on data points; you can separate individual slices.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

A chart is a shape; you can render it to a [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) or export the chart to an [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).
