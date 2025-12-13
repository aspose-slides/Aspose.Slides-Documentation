---
title: Customize Plot Areas of Presentation Charts on Android
linktitle: Plot Area
type: docs
url: /androidjava/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Discover how to customize chart plot areas in PowerPoint presentations with Aspose.Slides for Android via Java. Improve your slide visuals effortlessly."
---


## **Get Width and Height of a Chart Plot Area**
Aspose.Slides for Android via Java provides a simple API for . 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) before to get actual values.
1. Gets actual X location (left) of the chart element relative to the left top corner of the chart.
1. Gets actual top of the chart element relative to the left top corner of the chart.
1. Gets actual width of the chart element.
1. Gets actual height of the chart element.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set the Layout Mode of a Chart Plot Area**
Aspose.Slides for Android via Java provides a simple API to set the layout mode of the chart plot area. Methods [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) and [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) have been added to [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) class and [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea) interface. If the layout of the plot area defined manually this property specifies whether to layout the plot area by its inside (not including axis and axis labels) or outside (including axis and axis labels). There are two possible values which are defined in [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType) enum.

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - specifies that the plot area size shall determine the size of the plot area, not including the tick marks and axis labels.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - specifies that the plot area size shall determine the size of the plot area, the tick marks, and the axis labels.

Sample code is given below.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**In what units are actual x, actual y, actual width, and actual height returned?**

In points; 1 inch = 72 points. These are Aspose.Slides coordinate units.

**How does the Plot Area differ from the Chart Area in terms of content?**

The Plot Area is the data drawing region (series, gridlines, trendlines, etc.); the Chart Area includes the surrounding elements (title, legend, etc.). In 3D charts, the Plot Area also includes the walls/floor and the axes.

**How are the Plot Area’s x, y, width, and height interpreted when layout is manual?**

They are fractions (0–1) of the chart’s overall size; in this mode, auto-positioning is disabled and the fractions you set are used.

**Why did the Plot Area position change after adding/moving the legend?**

The legend sits in the chart area outside the Plot Area but affects layout and available space, so the Plot Area may shift when auto-positioning is in effect. (This is standard behavior for PowerPoint charts.)
