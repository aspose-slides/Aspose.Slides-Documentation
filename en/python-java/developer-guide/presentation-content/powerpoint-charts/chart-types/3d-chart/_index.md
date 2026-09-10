---
title: Customize 3D Charts in Presentations Using Python
linktitle: 3D Chart
type: docs
url: /python-java/3d-chart/
keywords:
- 3D chart
- rotation
- depth
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to create and customize 3-D charts in Aspose.Slides for Python via Java, with support for PPT and PPTX files—boost your presentations today."
---

## **Overview**

This article explains how to customize a 3D chart in Aspose.Slides by configuring [Rotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/) settings such as [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents), and [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes). It walks through creating a presentation, adding a 3D chart with default data, applying the required 3D view settings, and saving the modified presentation as a PPTX file.

## **Set X Rotation, Y Rotation, and Depth of a 3D Chart**
Aspose.Slides for Python via Java provides a simple API for setting these properties. The following example shows how to set the X rotation, Y rotation, and depth of a 3D chart.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a chart with default data.
1. Set the 3D rotation properties.
1. Write the modified presentation to a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Access the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a chart with default data.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Set the chart data worksheet index.
    default_worksheet_index = 0

    # Get the chart data workbook.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Add series.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Add categories.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Set the 3D rotation properties.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Access the second chart series.
    series = chart.getChartData().getSeries().get_Item(1)

    # Populate the series data.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Save the presentation.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides supports 3D variants of column charts, including Column 3D, Clustered Column 3D, Stacked Column 3D, and 100% Stacked Column 3D, along with related 3D types exposed through the [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) class. For an exact, up-to-date list, check the [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) members in the API reference of your installed version.

**Can I get a raster image of a 3D chart for a report or the web?**

Yes. You can export a chart to an image via the [chart API](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) or [render the entire slide](/slides/python-java/convert-powerpoint-to-png/) to formats like PNG or JPEG. This is useful when you need a pixel-perfect preview or want to embed the chart into documents, dashboards, or web pages without requiring PowerPoint.

**How performant is building and rendering large 3D charts?**

Performance depends on data volume and visual complexity. For best results, keep 3D effects minimal, avoid heavy textures on walls and plot areas, limit the number of data points per series when possible, and render to an appropriately sized output (resolution and dimensions) to match the target display or print needs.
