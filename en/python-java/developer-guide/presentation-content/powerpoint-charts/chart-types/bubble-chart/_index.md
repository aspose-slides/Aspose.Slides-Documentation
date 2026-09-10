---
title: Customize Bubble Charts in Presentations Using Python
linktitle: Bubble Chart
type: docs
url: /python-java/bubble-chart/
keywords:
- bubble chart
- bubble size
- size scaling
- size representation
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Create and customize powerful bubble charts in PowerPoint with Aspose.Slides for Python via Java to enhance your data visualization easily."
---

## **Overview**

This article shows how to work with bubble charts in Aspose.Slides. It covers two specific customization options: scaling bubble sizes through the [setBubbleSizeScale](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) method and controlling how bubble size values are represented through the [setBubbleSizeRepresentation](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) method.

The examples demonstrate how to create a bubble chart, adjust its size scaling, and switch the bubble size representation to use width. The article also includes a short FAQ section that clarifies support for the “Bubble with 3-D” chart type, notes that practical chart limits depend on performance and the target PowerPoint version, and explains that export preserves the chart’s appearance through the Aspose.Slides rendering engine.

## **Bubble Chart Size Scaling**
Aspose.Slides for Python via Java supports bubble chart size scaling through the [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), and [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) methods. The following example shows how to scale bubble sizes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Represent Data as Bubble Chart Sizes**
The methods [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) and [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) are available in the [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) class. The bubble size representation specifies how the bubble size values are represented in the bubble chart. Possible values are [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/python-java/aspose.slides/bubblesizerepresentationtype/#Area) and [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/python-java/aspose.slides/bubblesizerepresentationtype/#Width). The [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/python-java/aspose.slides/bubblesizerepresentationtype/) enumeration specifies the possible ways to represent data as bubble chart sizes. The following example shows how to represent bubble sizes using width.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

Yes. There is a separate chart type, "Bubble with 3-D." It applies 3-D styling to the bubbles but does not add an additional axis; the data remain X-Y-S (size). The type is available in the [chart type](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) class.

**Is there a limit on the number of series and points in a bubble chart?**

There is no hard limit at the API level; constraints are determined by performance and the target PowerPoint version. It is recommended to keep the number of points reasonable for readability and rendering speed.

**How will export affect the appearance of a bubble chart (PDF, images)?**

Export to supported formats preserves the chart’s appearance; rendering is performed by the Aspose.Slides engine. For raster/vector formats, general chart-graphics rendering rules apply (resolution, anti-aliasing), so choose sufficient DPI for printing.
