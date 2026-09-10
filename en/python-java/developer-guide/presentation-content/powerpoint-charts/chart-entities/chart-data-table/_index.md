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
description: "Customize chart data tables in Python for PPT and PPTX with Aspose.Slides for Python via Java to boost efficiency and appeal in presentations."
---

## **Overview**

This article explains how to work with chart data tables in Aspose.Slides. It shows how to display a data table for a chart and customize its text formatting by setting font properties such as bold style and font height. The example demonstrates creating a presentation, adding a chart, enabling the chart data table, applying font settings, and saving the updated presentation.

It also includes brief answers to common questions about showing legend keys in a chart data table, preserving the data table during export, working with charts loaded from existing presentations or templates, and identifying charts where the data table is enabled.

## **Set Font Properties for a Chart Data Table**

Aspose.Slides for Python via Java allows you to show the data table of a chart and change the font properties of its text.

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Add a chart to the slide.
1. Show the chart data table.
1. Set the bold style and font height of the data table text.
1. Save the modified presentation.

The following example demonstrates these steps.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Create an empty presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I show small legend keys next to the values in the chart’s data table?**

Yes. The data table supports [legend keys](https://reference.aspose.com/slides/python-java/aspose.slides/datatable/#setShowLegendKey), and you can turn them on or off.

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

Yes. Aspose.Slides renders the chart as part of the slide, so the exported [PDF](/slides/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/python-java/convert-powerpoint-to-html/)/[image](/slides/python-java/convert-powerpoint-to-png/) includes the chart with its data table.

**Are data tables supported for charts that come from a template file?**

Yes. For any chart loaded from an existing presentation or template, you can check and change whether a data table [is shown](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#hasDataTable) using the chart’s properties.

**How can I quickly find which charts in a file have the data table enabled?**

Inspect each chart’s property that indicates whether the data table [is shown](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#hasDataTable) and iterate through the slides to identify the charts where it is enabled.
