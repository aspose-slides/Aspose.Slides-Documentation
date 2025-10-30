---
title: Manage Chart Data Markers in Presentations with Python
linktitle: Data Marker
type: docs
url: /python-net/chart-data-marker/
keywords:
- chart
- data point
- marker
- marker options
- marker size
- fill type
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to customize chart data markers in Aspose.Slides, boosting presentation impact across PPT, PPTX and ODP formats with clear code examples."
---

## **Set Chart Marker Options**
The markers can be set on chart data points inside particular series. In order to set chart marker options. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
- Creating the default chart.
- Set the picture.
- Take first chart series.
- Add new data point.
- Write presentation to disk.

In the example given below, we have set the chart marker options on data points level.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Creating the default chart
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Getting the default chart data worksheet index
    defaultWorksheetIndex = 0

    # Getting the chart data worksheet
    fact = chart.chart_data.chart_data_workbook

    # Delete demo series
    chart.chart_data.series.clear()

    # Add new series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Set the picture
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Set the picture
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Take first chart series
    series = chart.chart_data.series[0]

    # Add new point (1:3) there.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Changing the chart series marker
    series.marker.size = 15

    # Write presentation to disk
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Which marker shapes are available out of the box?**

Standard shapes are available (circle, square, diamond, triangle, etc.); the list is defined by the [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/) enumeration. If you need a non-standard shape, use a marker with a picture fill to emulate custom visuals.

**Are markers preserved when exporting a chart to an image or SVG?**

Yes. When rendering charts to [raster formats](/slides/python-net/convert-powerpoint-to-png/) or saving [shapes as SVG](/slides/python-net/render-a-slide-as-an-svg-image/), markers retain their appearance and settings, including size, fill, and outline.
