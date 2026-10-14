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
description: "Create and customize pie charts in Python via Java with Aspose.Slides. Configure secondary plots, display data labels, and apply automatic slice colors in PowerPoint."
---

## **Overview**

This article explains how to work with pie charts in Aspose.Slides. It shows how to configure secondary plot options for Pie of Pie and Bar of Pie charts, and how to enable automatic slice coloring for a standard pie chart.

The examples focus on chart customization tasks such as adding a chart to a slide, adjusting series and label settings, replacing default chart data with custom categories and values, and saving the updated presentation.

## **Second Plot Options for Pie of Pie and Bar of Pie Charts**

Aspose.Slides for Python via Java supports secondary plot options for Pie of Pie and Bar of Pie charts. These options control the size of the secondary plot and how data points are split between the two plots.

The following example creates a Pie of Pie chart in a new presentation and displays data point values as labels. The [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) method sets the secondary plot size to 149% of the main plot. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selects percentage-based splitting, and [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) sets the threshold to 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Display values and configure the secondary plot.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Select Categories for the Secondary Plot**

Use custom splitting when you want to group specific categories in the secondary plot regardless of their percentage values. For example, a sales report might show Online and Events together so readers can compare these two channels, even though they account for 35% and 10% of total sales.

Call [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) with [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) and select the points through [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). The collection's [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) method accepts a zero-based index in the series; use [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) to add a data point object. In this example, index 1 selects Online, and the point at index 3 selects Events. Partners is also added temporarily, then excluded using [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Replace the default data with sales by channel.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Select Online by its zero-based index and Events by its data point object.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Exclude Partners from the selection without deleting its source data.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) and Events (10) appear as separate slices in the secondary plot. In the primary plot, they are represented by one combined slice with a value of 45, alongside Retail (40) and Partners (15). Removing Partners from the custom selection keeps it in the primary plot; it does not remove the category or its value from the chart's source data.

The following image shows the saved presentation in PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Set Automatic Pie Chart Slice Colors**

Aspose.Slides for Python via Java can automatically assign different colors to pie chart slices. The following example creates a pie chart with a centered title and replaces the default data with three quarterly categories and their values. The [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) method displays the values 20, 50, and 30 as labels, while [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) enables a distinct color for each slice.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Add a centered chart title.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Replace the default data using the first worksheet.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Show values and assign different colors to the slices.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Are the Pie of Pie and Bar of Pie variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) a secondary plot for pie charts, including the Pie of Pie and Bar of Pie types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (such as PNG) without exporting the entire presentation.
