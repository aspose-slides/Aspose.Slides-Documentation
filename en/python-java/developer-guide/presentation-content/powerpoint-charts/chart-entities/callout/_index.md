---
title: Manage Callouts in Presentation Charts Using Python
linktitle: Callout
type: docs
url: /python-java/callout/
keywords:
- chart callout
- use callout
- data label
- label format
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Create and style callouts in Aspose.Slides for Python via Java with concise code examples, compatible with PPT and PPTX to automate presentation workflows."
---

## **Overview**

This article explains how to work with callouts for chart data labels in Aspose.Slides. It shows how to use the [setShowLabelAsDataCallout](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) method to display labels as callouts, how to configure callout-related label settings for a doughnut chart, and notes that callouts and their appearance are preserved when presentations are exported to PDF, HTML5, SVG, and raster image formats.

## **Using Callouts**

The [getShowLabelAsDataCallout](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#getShowLabelAsDataCallout) and [setShowLabelAsDataCallout](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLabelAsDataCallout) methods of the [DataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) class determine whether a chart data label is displayed as a callout or as a regular data label.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400)
    labels = chart.getChartData().getSeries().get_Item(0).getLabels()
    default_label_format = labels.getDefaultDataLabelFormat()
    default_label_format.setShowValue(True)
    default_label_format.setShowLabelAsDataCallout(True)
    labels.get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(False)

    presentation.save("DisplayCharts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set a Callout for a Doughnut Chart**

Aspose.Slides for Python via Java supports setting the series data label callout shape for a doughnut chart. The following example demonstrates this.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat, TextAutofitType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, False)
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(False)

    for series_index in range(15):
        series_cell = workbook.getCell(0, 0, series_index + 1, f"SERIES {series_index}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        series.setExplosion(0)
        series.getParentSeriesGroup().setDoughnutHoleSize(jpype.JByte(20))
        series.getParentSeriesGroup().setFirstSliceAngle(351)

    for category_index in range(15):
        category_cell = workbook.getCell(0, category_index + 1, 0, f"CATEGORY {category_index}")
        chart.getChartData().getCategories().add(category_cell)
        for i in range(chart.getChartData().getSeries().size()):
            series = chart.getChartData().getSeries().get_Item(i)
            data_cell = workbook.getCell(0, category_index + 1, i + 1, jpype.JInt(1))
            data_point = series.getDataPoints().addDataPointForDoughnutSeries(data_cell)
            data_point.getFormat().getFill().setFillType(FillType.Solid)
            line_format = data_point.getFormat().getLine()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)
            line_format.setWidth(1)
            line_format.setStyle(LineStyle.Single)
            line_format.setDashStyle(LineDashStyle.Solid)
            if i == chart.getChartData().getSeries().size() - 1:
                label = data_point.getLabel()
                label.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape)
                label_format = label.getDataLabelFormat()
                portion_format = label_format.getTextFormat().getPortionFormat()
                portion_format.setFontBold(NullableBool.True_)
                font = FontData("DINPro-Bold")
                portion_format.setLatinFont(font)
                portion_format.setFontHeight(12)
                portion_format.getFillFormat().setFillType(FillType.Solid)
                portion_format.getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)
                label_format.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.WHITE)
                label_format.setShowValue(False)
                label_format.setShowCategoryName(True)
                label_format.setShowSeriesName(False)
                label_format.setShowLeaderLines(True)
                label_format.setShowLabelAsDataCallout(False)
                chart.validateChartLayout()
                label.setX(label.getX() + 0.5)
                label.setY(label.getY() + 0.5)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Yes. Callouts are part of the chart rendering, so when you export to [PDF](/slides/python-java/convert-powerpoint-to-pdf/), [HTML5](/slides/python-java/export-to-html5/), [SVG](/slides/python-java/render-a-slide-as-an-svg-image/), or [raster images](/slides/python-java/convert-powerpoint-to-png/), they are preserved together with the slide’s formatting.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Yes. Aspose.Slides supports [embedding fonts](/slides/python-java/embedded-font/) into the presentation and controls font embedding during exports such as [PDF](/slides/python-java/convert-powerpoint-to-pdf/), ensuring the callouts look the same across different systems.
