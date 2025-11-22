---
title: Customize Plot Areas of Presentation Charts in .NET
linktitle: Plot Area
type: docs
url: /net/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover how to customize chart plot areas in PowerPoint presentations with Aspose.Slides for .NET. Improve your slide visuals effortlessly."
---

## **Get Width, Height of Chart Plot Area**
Aspose.Slides for .NET provides a simple API for . 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method IChart.ValidateChartLayout() before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Save presentation with chart
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Set Layout Mode of Chart Plot Area**
Aspose.Slides for .NET provides a simple API to set the layout mode of the chart plot area. Property **LayoutTargetType** has been added to **ChartPlotArea** and **IChartPlotArea** classes. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in **LayoutTargetType** enum.

- **LayoutTargetType.Inner** - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- **LayoutTargetType.Outer** - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**In what units are ActualX, ActualY, ActualWidth, and ActualHeight returned?**

In points; 1 inch = 72 points. These are Aspose.Slides coordinate units.

**How does the Plot Area differ from the Chart Area in terms of content?**

The Plot Area is the data drawing region (series, gridlines, trendlines, etc.); the Chart Area includes the surrounding elements (title, legend, etc.). In 3D charts, the Plot Area also includes the walls/floor and the axes.

**How are the Plot Area’s X, Y, Width, and Height interpreted when layout is manual?**

They are fractions (0–1) of the chart’s overall size; in this mode, auto-positioning is disabled and the fractions you set are used.

**Why did the Plot Area position change after adding/moving the legend?**

The legend sits in the chart area outside the Plot Area but affects layout and available space, so the Plot Area may shift when auto-positioning is in effect. (This is standard behavior for PowerPoint charts.)
