---
title: Customize Doughnut Charts in Presentations Using Python via Java
linktitle: Doughnut Chart
type: docs
weight: 30
url: /python-java/doughnut-chart/
keywords:
- doughnut chart
- center gap
- hole size
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Discover how to create and customize doughnut charts in Aspose.Slides for Python via Java, supporting PowerPoint formats for dynamic presentations."
---

## **Overview**

This article shows how to work with a doughnut chart in Aspose.Slides by adding the chart to a slide, setting the size of its center hole, and saving the presentation. It focuses on the [setDoughnutHoleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) method and demonstrates the basic steps required to customize this chart type in code.

It also includes a short FAQ covering related doughnut-chart scenarios, such as using multiple series to create multiple rings, working with exploded doughnut charts, and exporting a chart as a raster image or SVG.

## **Specify the Center Gap in a Doughnut Chart**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java supports specifying the size of the hole in a doughnut chart. This section demonstrates how to specify the hole size with an example.

{{% /alert %}}

To specify the size of the hole in a doughnut chart, follow these steps:

1. Instantiate a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
1. Add a doughnut chart to the slide.
1. Specify the size of the hole in the doughnut chart.
1. Write the presentation to disk.

The following example sets the size of the hole in a doughnut chart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Write the presentation to disk.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Yes. Add multiple series to a single doughnut chart—each series becomes a separate ring. The ring order is determined by the order of the series in the collection.

**Is an "exploded" doughnut (separated slices) supported?**

Yes. There is an Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) and an explosion property on data points; you can separate individual slices.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

A chart is a [shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/); you can render it to a [raster image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) or export the chart to an SVG image.
