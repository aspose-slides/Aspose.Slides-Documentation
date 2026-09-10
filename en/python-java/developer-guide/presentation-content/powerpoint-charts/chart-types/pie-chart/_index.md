---
title: Customize Pie Charts in Presentations Using Python via Java
linktitle: Pie Chart
type: docs
url: /python-java/pie-chart/
keywords:
- pie chart
- manage chart
- customize chart
- chart options
- chart settings
- plot options
- slice color
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to create and customize pie charts in Python via Java with Aspose.Slides, exportable to PowerPoint, boosting your data storytelling in seconds."
---

## **Overview**

This article explains how to work with pie charts in Aspose.Slides. It shows how to configure secondary plot options for Pie of Pie and Bar of Pie charts, and how to enable automatic slice coloring for a standard pie chart.

The examples focus on practical chart customization steps such as adding a chart to a slide, adjusting series and label settings, replacing default chart data with custom categories and values, and saving the updated presentation.

## **Second Plot Options for Pie of Pie and Bar of Pie Charts**

Aspose.Slides for Python via Java supports second plot options for Pie of Pie and Bar of Pie charts. This section shows how to specify those options using Aspose.Slides. Follow these steps:

1. Instantiate a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) object.
1. Add a chart to the slide.
1. Specify the chart's second plot options.
1. Write the presentation to disk.

The following example sets different properties of a Pie of Pie chart.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    # Add a chart to the slide.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Set different properties.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Write the presentation to disk.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set Automatic Pie Chart Slice Colors**

Aspose.Slides for Python via Java provides a simple API for setting automatic pie chart slice colors. The following example demonstrates how to apply these settings.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a chart with default data.
1. Set the chart title.
1. Set the index of the chart data worksheet.
1. Get the chart data workbook.
1. Delete the default series and categories.
1. Add new categories.
1. Add a new series.
1. Set the new series to show values.

Write the modified presentation to a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Create an instance of the Presentation class.
presentation = Presentation()
try:
    # Add a chart with default data.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Set the chart title.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Set the index of the chart data worksheet.
    default_worksheet_index = 0

    # Get the chart data workbook.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Delete the default series and categories.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Add new categories.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Add a new series.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Populate the series data.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Set the new series to show values.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) a secondary plot for pie charts, including the 'Pie of Pie' and 'Bar of Pie' types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (such as PNG) without the entire presentation.
