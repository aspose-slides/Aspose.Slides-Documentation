---
title: Customize 3D Charts in Presentations with Python
linktitle: 3D Chart
type: docs
url: /python-net/3d-chart/
keywords:
- 3D chart
- rotation
- depth
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create 3D charts in PowerPoint presentations with Aspose.Slides for Python via .NET. Adjust rotation, chart depth, and spacing between series with Python examples."
---

## **Overview**

Aspose.Slides for Python via .NET lets you customize the view of a 3D chart through the [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) property. This article demonstrates how to adjust rotation, depth, right-angle axes, and spacing between series, then save the presentation in PPTX format.

## **Set the Rotation and Depth of a 3D Chart**

The example below creates a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and uses [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) to add a stacked 3D column chart to its first slide. It replaces the default series and categories with two series containing three values each. Worksheet index `0` identifies the chart's first data worksheet; row `0` holds series names, and column `0` holds category labels.

The [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) and [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) properties set the chart's rotation to 40 and 270 degrees, respectively. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) sets its depth to 150% of its width, while [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) enables right-angle axes instead of perspective. The resulting presentation contains the populated chart with these 3D view settings.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Adjust the Gap Between Series**

Use [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) to control the distance between data series along the depth axis of a 3D chart, expressed as a percentage of the marker width. Use values from **0 to 500**, inclusive: `0` removes the gap, while larger values increase the spacing. With a fixed chart depth, increasing the gap makes the markers thinner along the depth axis.

Access the group through [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). The setting applies to every series in that group, not just the series used to access it. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) is read-only and reflects the parent group's setting.

This setting affects 3D column and bar charts, including their cylinder, cone, and pyramid variants, as well as 3D line and area charts. The appearance depends on whether the series are arranged in depth, clustered, or stacked. For a clear comparison of gaps between separate series, use `ChartType.COLUMN_3D` from the [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enumeration.

These properties control different aspects of the chart:

| Property | Effect |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Spacing between series along the depth axis, as a percentage of the marker width. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Spacing between adjacent bar or column clusters, as a percentage of the bar or column width. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Overall chart depth, as a percentage of the chart width. |

The following self-contained example uses the default chart data, which contains three series and four categories. It saves two presentations with identical data, rotation, gap width, and chart depth; only the gap depth changes.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

The following images were exported from the generated presentations using Microsoft PowerPoint.

| Gap depth: 0% | Gap depth: 500% |
| --- | --- |
| ![3D column chart with no gap between series along the depth axis](gap_depth_0.png) | ![3D column chart with a 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides supports 3D variants of column charts, including Column 3D, Clustered Column 3D, Stacked Column 3D, and 100% Stacked Column 3D, along with related 3D types exposed through the [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enumeration. For an exact, up-to-date list, check the [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) members in the API reference of your installed version.

**Can I get a raster image of a 3D chart for a report or the web?**

Yes. You can export a chart to an image with [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) or [render the entire slide](/slides/python-net/convert-powerpoint-to-png/) to formats like PNG or JPEG. This is useful when you need a raster preview or want to embed the chart into documents, dashboards, or web pages without requiring PowerPoint.

**How performant is building and rendering large 3D charts?**

Performance depends on data volume and visual complexity. For best results, keep 3D effects minimal, avoid heavy textures on walls and plot areas, limit the number of data points per series when possible, and render to an appropriately sized output (resolution and dimensions) to match the target display or print needs.
