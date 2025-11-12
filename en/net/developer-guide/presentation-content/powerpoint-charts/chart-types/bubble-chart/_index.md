---
title: Customize Bubble Charts in Presentations in .NET
linktitle: Bubble Chart
type: docs
url: /net/bubble-chart/
keywords:
- bubble chart
- bubble size
- size scaling
- size representation
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Create and customize powerful bubble charts in PowerPoint and OpenDocument with Aspose.Slides for .NET to enhance your data visualization easily."
---

## **Bubble Chart Size Scaling**
Aspose.Slides for .NET provides support for Bubble chart size scaling. In Aspose.Slides for .NET **IChartSeries.BubbleSizeScale** and **IChartSeriesGroup.BubbleSizeScale** properties have been added. Below sample example is given. 

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Represent Data as Bubble Chart Sizes**
Property **BubbleSizeRepresentation** has been added to IChartSeries, IChartSeriesGroup interfaces, and related classes. **BubbleSizeRepresentation** specifies how the bubble size values are represented in the bubble chart. Possible values are: **BubbleSizeRepresentationType.Area** and **BubbleSizeRepresentationType.Width**. Accordingly, **BubbleSizeRepresentationType** enum has been added to specify the possible ways to represent data as bubble chart sizes. Sample code is given below.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X-Y-S (size). The type is available in the [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeration.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart-graphics rendering rules apply (resolution, anti-aliasing), so choose sufficient DPI for printing.
