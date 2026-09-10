---
title: Manage Chart Data Markers in Presentations Using Python
linktitle: Data Marker
type: docs
url: /python-java/chart-data-marker/
keywords:
- chart
- data point
- marker
- marker options
- marker size
- fill type
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to customize chart data markers in Aspose.Slides for Python via Java, boosting presentation impact across PPT and PPTX formats with clear Python code examples."
---

## **Overview**

This article explains how to work with chart data markers in Aspose.Slides. It shows how to create a chart, access a series and its data points, apply picture fills to markers at the data-point level, adjust marker size, and save the updated presentation. It also notes that standard marker shapes are available through the [MarkerStyleType](https://reference.aspose.com/slides/python-java/aspose.slides/markerstyletype/) enumeration and that marker appearance is preserved when exporting charts to raster formats or SVG.

## **Set Chart Marker Options**
Markers can be set on chart data points within a particular series. To set chart marker options, follow these steps:

- Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Create the default chart.
- Set the pictures.
- Access the first chart series.
- Add new data points.
- Write the presentation to disk.

The following example sets chart marker options at the data-point level.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Create an empty presentation.
presentation = Presentation()
try:
    # Access first slide
    slide = presentation.getSlides().get_Item(0)

    # Creating the default chart
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Get the default chart data worksheet index.
    default_worksheet_index = 0

    # Get the chart data workbook.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Delete demo series
    chart.getChartData().getSeries().clear()

    # Add new series
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Load the first picture.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Load the second picture.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Access the first chart series.
    series = chart.getChartData().getSeries().get_Item(0)

    # Add data points.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Change the chart series marker size.
    series.getMarker().setSize(15)

    # Save presentation with chart
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Which marker shapes are available out of the box?**

Standard shapes are available (circle, square, diamond, triangle, etc.); the list is defined by the [MarkerStyleType](https://reference.aspose.com/slides/python-java/aspose.slides/markerstyletype/) class. If you need a non-standard shape, use a marker with a picture fill to emulate custom visuals.

**Are markers preserved when exporting a chart to an image or SVG?**

Yes. When rendering charts to [raster formats](/slides/python-java/convert-powerpoint-to-png/) or saving [shapes as SVG](/slides/python-java/render-a-slide-as-an-svg-image/), markers retain their appearance and settings, including size, fill, and outline.
