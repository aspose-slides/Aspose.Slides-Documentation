---
title: Customize Chart Data Tables in Presentations Using Python
linktitle: Data Table
type: docs
url: /python-java/chart-data-table/
keywords:
- chart data
- data table
- font properties
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Customize chart data table fonts, borders, and legend keys in PowerPoint presentations using Aspose.Slides for Python via Java."
---

## **Overview**

Aspose.Slides for Python via Java lets you display a chart's data table and customize its text formatting, borders, and legend keys. This article explains how to enable the table, format its text, control each type of border, and show or hide legend keys. The examples save the configured charts in PPTX files.

## **Set Font Properties**

To display a chart's data table, pass `True` to [setDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDataTable). Use [getChartDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartDataTable) to access the table and configure its text formatting.

1. Load the presentation using the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a clustered column chart to the first slide.
1. Enable the chart's data table.
1. Enable bold text with [setFontBold](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontBold) and pass `20` to [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) for 20-point text.
1. Save the modified presentation.

The following example requires `test.pptx` in the working directory with at least one slide. It adds a chart with default data at position (50, 50), with a width of 600 points and a height of 400 points. The saved `output.pptx` contains the chart with its data table enabled and the specified font settings applied.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Customize Data Table Borders**

Enable the table with [Chart.setDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDataTable) and access it through [Chart.getChartDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartDataTable). You can control three types of borders independently:

- [setBorderHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setBorderHorizontal) controls horizontal cell borders.
- [setBorderVertical](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setBorderVertical) controls vertical cell borders.
- [setBorderOutline](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setBorderOutline) controls the outer border of the table.

Pass `True` to each method to display its borders or `False` to hide them. The following example creates a clustered column chart with default data, displays horizontal borders and the outer border, and hides vertical borders. It requires no input file. The chart's position and size are specified in points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The comparison below uses the same chart data and legend key setting in all four cases. Starting with all borders enabled, each remaining variant disables just one border setting. The lower-left variant matches the border settings in the example.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Show or Hide Legend Keys**

Legend keys are small colored markers beside the series names in the data table. They help readers match each table row to a chart series. Pass `True` to [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setShowLegendKey) to show these markers or `False` to hide them.

The chart's separate legend is controlled by [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend). These settings are independent: hiding the separate legend does not hide the keys inside the data table, and hiding the table's keys does not hide the separate legend.

The following example creates a chart with default data, enables its data table, and shows legend keys inside it while hiding the separate legend. All table borders are explicitly enabled. No input presentation is required. To hide only the table's keys, pass `False` to [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The comparison below shows the same table with legend keys enabled and disabled. All borders remain enabled, and the separate chart legend is hidden in both cases.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Can I show legend keys in a chart's data table?**

Yes. Pass `True` to [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setShowLegendKey) to display legend keys or `False` to hide them.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart and its displayed data table as part of the slide when exporting to [PDF](/slides/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/python-java/convert-powerpoint-to-html/), or [images](/slides/python-java/convert-powerpoint-to-png/).

**Can I work with data tables in charts loaded from a template?**

Yes. For a chart loaded from an existing presentation or template, use [hasDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#hasDataTable) and [setDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDataTable) to check or change whether its data table is displayed.

**How can I find charts that have a data table enabled?**

Iterate through the shapes on each slide, identify the charts, and call their [hasDataTable](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#hasDataTable) method. A value of `True` indicates that the data table is enabled.
