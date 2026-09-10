---
title: Customize Plot Areas of Presentation Charts in Python
linktitle: Plot Area
type: docs
url: /python-java/chart-plot-area/
keywords:
- chart
- plot area
- plot area width
- plot area height
- plot area size
- layout mode
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Discover how to customize chart plot areas in PowerPoint presentations with Aspose.Slides for Python via Java. Improve your slide visuals effortlessly."
---

## **Overview**

This article shows how to work with a chart’s plot area in Aspose.Slides. It explains how to get the actual position and size of the plot area by validating the chart layout and then reading its X, Y, width, and height values.

It also demonstrates how to configure the plot area’s layout mode when the layout is set manually, using [LayoutTargetType](https://reference.aspose.com/slides/python-java/aspose.slides/layouttargettype/) to define whether the plot area is calculated by its inner region or by its outer region together with axes and axis labels.

## **Get Width and Height of a Chart Plot Area**

Aspose.Slides for Python via Java provides a simple API for reading the actual position and size of a chart's plot area.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a chart with default data.
1. Call the [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) method before getting the actual values.
1. Get the actual X position (left) of the chart element relative to the top-left corner of the chart.
1. Get the actual Y position (top) of the chart element relative to the top-left corner of the chart.
1. Get the actual width of the chart element.
1. Get the actual height of the chart element.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Set the Layout Mode of a Chart Plot Area**

Aspose.Slides for Python via Java provides a simple API to set the layout mode of the chart plot area. The [setLayoutTargetType](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) and [getLayoutTargetType](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) methods are available in the [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) class. If the layout of the plot area is defined manually, this setting specifies whether to lay out the plot area by its inside (excluding axes and axis labels) or outside (including axes and axis labels). There are two possible values defined in the [LayoutTargetType](https://reference.aspose.com/slides/python-java/aspose.slides/layouttargettype/) enumeration.

- [Inner](https://reference.aspose.com/slides/python-java/aspose.slides/layouttargettype/#Inner) specifies that the plot area size excludes tick marks and axis labels.
- [Outer](https://reference.aspose.com/slides/python-java/aspose.slides/layouttargettype/#Outer) specifies that the plot area size includes tick marks and axis labels.

Sample code is given below.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In what units are actual X, actual Y, actual width, and actual height returned?**

In points; 1 inch = 72 points. These are Aspose.Slides coordinate units.

**How does the Plot Area differ from the Chart Area in terms of content?**

The Plot Area is the data drawing region (series, gridlines, trendlines, etc.); the Chart Area includes the surrounding elements (title, legend, etc.). In 3D charts, the Plot Area also includes the walls/floor and the axes.

**How are the Plot Area’s X, Y, width, and height interpreted when layout is manual?**

They are fractions (0–1) of the chart’s overall size; in this mode, auto-positioning is disabled and the fractions you set are used.

**Why did the Plot Area position change after adding or moving the legend?**

The legend sits in the chart area outside the Plot Area but affects layout and available space, so the Plot Area may shift when auto-positioning is in effect. (This is standard behavior for PowerPoint charts.)
